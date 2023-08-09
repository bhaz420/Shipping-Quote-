using System;
using System.Reflection.Metadata;

namespace PackageShippingQuote
{
    class Program
    {
        private static double GetDoubleNumericValue(int attempts = 3, double valueIfParseFails = 0.0)
        {
            Console.Write("Enter any numeric value:  ");
            string temp = "";
            double dblNum = valueIfParseFails;
            int n = 0; //the number of times the user has entered unrecognized values
            bool validEntry = false; //used to repeat opportunities to enter valid data
            while (!validEntry & n < attempts)
            {
                temp = Console.ReadLine();
                validEntry = double.TryParse(temp, out dblNum);
                if (!validEntry)
                {
                    n++;
                    if (n < attempts)
                    {
                        Console.Write("Sorry, we had trouble recognizing that as a numeric value. Please try again:  ");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, for demonstration purposes, we'll record that as the number {0}.", valueIfParseFails);
                        dblNum = valueIfParseFails; //set again because TryParse() converts "" to 0 even though it returns a false value
                    }
                }
            }
            return dblNum;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(“Welcome to Package Express.Please follow the instructions below.”);

            // Step 1: Gather package information


            Console.WriteLine();
            double weight, width, height, length, sumDims, cost;
            Console.Write("What is the weight of your package in pounds? ");
            weight = GetDoubleNumericValue(3, 5);
            if (weight > 50)
            {
                Console.WriteLine(“Package too heavy to be shipped via Package Express.Have a good day.” );
            }
            else
            {

                // Step 2: CalculateShippingCost method



                Console.Write("What is the width of your package in inches? ");
                width = GetDoubleNumericValue(3, 10);
                Console.Write("What is the height of your package in inches? ");
                height = GetDoubleNumericValue(3, 10);
                Console.Write("What is the length of your package in inches? ");
                length = GetDoubleNumericValue(3, 10);
                sumDims = width + height + length;
                if (sumDims > 50)
                {
                    Console.WriteLine("We're sorry. Your package is too large to be shipped via Package Express. Have a good day.");
                }
                else
                {
                    cost = sumDims * weight / 100;
                    Console.WriteLine();
                    Console.WriteLine("The estimated total for shipping this package is: {0}.", cost.ToString("C2"));
                }
            }
            Console.ReadLine();
        }
    }
}