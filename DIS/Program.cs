using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS
{
    class Program
    {
        public static void Main()
        {
            int a = 5, b = 25;
            printPrimeNumbers(a, b);

            
            int n1 = 5;
            double r1 = getSeriesResult(n1);
            Console.WriteLine("The sum of the series is: " + r1);

            
            long n2 = 21;
            long r2 = decimalToBinary(n2);
            Console.WriteLine("Binary conversion of the decimal number " + n2 + " is: " + r2);


            long n3 = 1111;
            long r3 = binaryToDecimal(n3);
            Console.WriteLine("Decimal conversion of the binary number " + n3 + " is: " + r3);


            int n4 = 5;
            printTriangle(n4);

            int[] arr = new int[] { 1,2,3,2,2,1,3,2 };
            computeFrequency(arr);

            // write your self-reflection here as a comment
            /* Learing: 
                Using the debugger and breakpoints helped to find bugs and build the logic
                
                Also, it were used different test cases to approach corner cases
                
                It's important to create methods to encapsulate logic and 
                to use proper names for variables and methods, as well as to add comments to help
                others understand code.
                
                Support in websites to validate results for different scenarios, specially for the 
                decimalToBinary and binaryToDecimal methods.
               
               Recommendations:
                On the methods specifications in the Word doc, some methods were missing details.
                For instance, the getSeriesResults doesn't show which is the value of 
                the input n for the example given and neither the expected result.

                Also, will be good to have on the Main method a comment with the expected 
                result for each method, so we as students can make sure that at least the
                base case is working properly.

                Lastly, it would be nice to define in the assigment the expected output format, 
                either Console.WriteLine or Debug.WriteLine method, or other.
            */

        }

        public static void printPrimeNumbers(int x, int y)
        {
            try
            {
                string prime_numbers = "";

                // If x is less or equal to 1 (not primes there), change the starting range to 2
                if (x <= 1)
                {
                    x = 2;
                }

                //Base case: Two is the only even prime number
                if (x == 2) {
                    prime_numbers += (x + ", ");
                    x++;
                }
                // If the starting range value is not 2 but is even (not prime), start the loop on the next odd number
                if ((x != 2) && (x % 2 == 0))
                {
                    x++;
                }

                while (x <= y)
                {
                    if (isPrime(x))
                    {
                        prime_numbers += (x + ", ");
                    }
                    x += 2; // Only check odd number. Even numbers different from 2 are not prime.
                }

                // Print results
                if (prime_numbers.Length > 0)
                {
                    Debug.WriteLine(prime_numbers);
                }
                else
                {
                    Debug.WriteLine("There are no prime numbers within the given range");
                }
            }
            catch
            {
                Debug.WriteLine("Exception occured while computing printPrimeNumbers()");
            }
        }

        public static bool isPrime(int n)
        {
            // Prime numbers are greater than 1
            if (n > 1)
            {
                // First prime numbers are easy to recognize
                if (n == 2 || n == 3 || n == 5 || n == 7)
                {
                    return true;
                }

                // Even numbers are not prime
                if ((n % 2) == 0)
                {
                    return false;
                }

                // Trial division method. Check if n has divisors
                int i = 3;
                while (i < n) {
                    if ((n % i) == 0)
                    {
                        return false;
                    }
                    i += 2; //We already disregard factors of 2. Just check if other primes divide it
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public static double getSeriesResult(int n)
        {
            try
            {
                // n needs to be greater than 0 to have at least one term 
                if (n <= 0)
                {
                    Debug.WriteLine("Please provide a positive integer greater than 0");
                }
                else
                {
                    int i = 1;
                    double result = 0;
                    // Repeat n times because n represents the number of terms of the series.
                    while (i <= n)
                    {
                        int numerator = factorial(i);
                        int denominator = i + 1;
                        double factor = (double)numerator / (double)denominator;

                        // Odd terms are positive whereas even terms are all negative
                        if ((i % 2) == 0)
                        {
                            result -= factor;
                        }
                        else
                        {
                            result += factor;
                        }
                        i++;
                    }
                    result = Math.Round(result, 3);
                    Debug.WriteLine(result);
                    return result;
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing getSeriesResult()");
            }

            return 0;
        }

        public static int factorial(int n)
        {
            //Base case
            if (n == 0 || n == 1)
            {
                return 1;
            }
            else
            {
                int i = 2;
                int result = 1;
                while (i <= n)
                {
                    result *= i;
                    i++;
                }
                return result;
            }
        }

        public static long decimalToBinary(long n)
        {
            try
            {
                string binary_number = "";
                int quotient = Convert.ToInt32(n);
                int reminder = 0;

                while (quotient != 0)
                {
                    reminder = quotient % 2;
                    binary_number = binary_number.Insert(0, reminder.ToString());

                    quotient = quotient / 2;
                }
                Debug.WriteLine(binary_number);
                return Convert.ToInt64(binary_number);
            }
            catch
            {
                Console.WriteLine("Exception occured while computing decimalToBinary()");
            }

            return 0;
        }

        public static long binaryToDecimal(long n)
        {
            try
            {
                //Convert the binary number to string to start getting bits
                //from the rightmost position
                string binary_number = (Convert.ToInt32(n)).ToString();
                int i = 1;
                int num_digits = binary_number.Length;
                int decimal_number = 0;
                while (i <= num_digits)
                {
                    
                    int position = num_digits - i; //rightmost bits first
                    int bit_at = int.Parse((binary_number[position]).ToString());
                    if (bit_at != 0 && bit_at != 1)
                    {
                        Debug.WriteLine("Bad input. You must enter a binary number");
                        return 0;
                    }
                    else
                    {
                        int power = computePower(i - 1);
                        decimal_number += (power * bit_at);
                        i++;
                    }
                }
                Debug.WriteLine(decimal_number);
                return Convert.ToInt64(decimal_number);
            }
            catch
            {
                Debug.WriteLine("Exception occured while computing binaryToDecimal()");
            }
            return 0;
        }

        public static int computePower(int n)
        {
            int i = 1;
            int result = 1;
            while(i <= n) {
                result *= 2;
                i++;
            }
            return result;
        }

        public static void printTriangle(int n)
        {
            try
            {
                // At least one line to print the pattern 
                if (n > 0)
                {
                    int i = 1;
                    int star_counter = 1;
                    int space_counter = n - 1; //line i has n-i spaces side to side
                    int j = 1;
                    // Repeat n times because n represents the number  
                    // of lines for the pattern
                    while (i <= n)
                    {
                        string line = ""; // initialize a new line
                        j = 1;
                        while (j <= space_counter)
                        {
                            line += " ";
                            j++;
                        }
                        j = 1;
                        while (j <= star_counter)
                        {
                            line += "*";
                            j++;
                        }
                        j = 1;
                        while (j <= space_counter)
                        {
                            line += " ";
                            j++;
                        }
                        Debug.WriteLine(line);
                        star_counter += 2; // each line has odd starts 1,3,5,7
                        space_counter--;
                        i += 1;
                    }
                }
                else
                {
                    Debug.WriteLine("Bad Input. You must enter a positive int greater than 0");
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printTriangle()");
            }
        }

        public static void computeFrequency(int[] a)
        {
            try
            {
                // At least one element to compute frequency
                if (a.Length > 0)
                {
                    Array.Sort(a); //Order the array first
                    int i = 1;
                    int how_many = 1;
                    int counting_value = a[0];
                    Debug.WriteLine("Number          Frequency");
                    // Iterate the array
                    while (i < a.Length)
                    {
                        if (a[i] == counting_value)
                        {
                            how_many++;
                        }
                        else
                        {
                            Debug.WriteLine(counting_value + "          " + how_many);
                            how_many = 1; //reset counter
                            counting_value = a[i]; //start counting next value
                        }
                        i++;
                    }
                    // Show last counting value 
                    if (i == a.Length)
                    {
                        Debug.WriteLine(counting_value + "          " + how_many);
                    }
                }
                else
                {
                    Debug.WriteLine("Bad input. The array is empty");
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing computeFrequency()");
            }
        }

    }
}

