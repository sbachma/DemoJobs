using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJobs
{
    class HaroldsJobEntry
    {
        static bool hasInputed = false;
        static void Main(string[] args)
        {
            char menuControl = 'Y';
            int option;
            Job[] jobArray = new Job[5];
            while(menuControl == 'Y')
            {
                Console.WriteLine("Enter 1 to enter your 5 jobs, 2 to display all jobs, 3 to combine two jobs, and 4 to exit: ");
                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    option = 5;
                }
                if (option == 1)
                {
                    //Loop to enter all five jobs at once
                    for(int i = 0; i < 5; i++)
                    {
                        Console.WriteLine("Please enter job " + (i + 1));
                        jobArray[i] = OptionOne();
                    }
                }
                //If jobs have been entered then display them, else ask user to input their jobs first
                if(option == 2 && hasInputed == true)
                {
                    OptionTwo(jobArray);
                } else if(option == 2 && hasInputed == false)
                {
                    Console.WriteLine("Please enter in your jobs before displaying them.");
                }
                //If jobs have been entered then allow for combining, otherwise ask for input first
                if(option == 3 && hasInputed == true)
                {
                    OptionThree(jobArray);
                } else if(option == 3 && hasInputed == false)
                {
                    Console.WriteLine("Please enter in your jobs before combining them.");
                }
                if (option == 4)
                {
                    Console.WriteLine("Exiting Program.");
                    menuControl = 'N';
                }
                if(option != 1 && option != 2 && option != 3 && option != 4)
                {
                    Console.WriteLine("Invalid input. Please input a number 1 through 4.");
                }
            }
        }
        /**Combines two job objects and displays the new object using the Job class's toString method.
         * Decides which two objects using user input
         */
        static void OptionThree(Job[] arr)
        {
            int o1, o2;
            //Get input on what object to combine, subtracting 1 because array is 0-4
            Console.WriteLine("Enter the first object you would like to combine(1-5): ");
            try
            {
                o1 = Convert.ToInt32(Console.ReadLine()) - 1;
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input, defaulting to the first job.");
                o1 = 0;
            }
            Console.WriteLine("Enter the second object you would like to combine(1-5): ");
            try
            {
                o2 = Convert.ToInt32(Console.ReadLine()) - 1;
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input, defaulting to the second job.");
                o2 = 1;
            }
            Console.WriteLine((arr[o1] + arr[o2]).ToString());
        }
        /**
         * Displays job objects from the taken in job array, using the toString method from the job class.
         * Sorts the array before displaying in ascending order
         */
        static void OptionTwo(Job[] arr)
        {
            Array.Sort(arr);
            //Display the array in ascending order
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(arr[i].ToString());
            }
        }

        /**
         * Asks for input for job objects(description, hours, and rate).
         * Creates the job object and returns it
         */
        static Job OptionOne()
        {
            hasInputed = true;
            string desc;
            double hours, rate;
            Console.WriteLine("Enter the job description: ");
            try
            {
                desc = Console.ReadLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid description, defaulting to mow lawn.");
                desc = "";
            }
            Console.WriteLine("Enter the hours: ");
            try
            {
                hours = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid hours, defaulting to 1.");
                hours = 1;
            }
            Console.WriteLine("Enter the rate: ");
            try
            {
                rate = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid rate, defaulting to 10.");
                rate = 10;
            }
            //Validation is done in the Job class
            Job job = new Job(desc, hours, rate);
            return job;
        }
    }
}