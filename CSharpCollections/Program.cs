using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            //// This code is an example of how to use a dictionary.

            //string filePath = @"C:\Users\jflem\source\repos\CSharpCollections\CSharpCollections\Pop by Largest Final.csv";
            //CsvReader reader = new CsvReader(filePath);
            //Dictionary<string, Country> countries = reader.ReadAllCountries();

            //Console.WriteLine("Which country code do you want to look up? ");
            //string userInput = Console.ReadLine();
            //bool gotCountry = countries.TryGetValue(userInput, out Country country);
            //if (!gotCountry)
            //    Console.WriteLine($"sorry, there is no country with code, {userInput}");
            //else
            //    Console.WriteLine($"{country.Name} has population {PopulationFormatter.FormatPopulation(country.Population)}");

            // Below is the old code using a list.  I left it just for reference.

            string filePath = @"C:\Users\jflem\source\repos\CSharpCollections\CSharpCollections\Pop by Largest Final.csv";
            CsvReader reader = new CsvReader(filePath);

            List<Country> countries = reader.ReadAllCountries();

            // Asks the user how many countries they want to enumerate.

            Console.Write("Enter the number of countries to display> ");
            bool inputIsInt = int.TryParse(Console.ReadLine(), out int userInput);
            if (!inputIsInt || userInput<= 0)
            {
                Console.WriteLine("You must type in a +ve integer. Exiting");
                return;
            }

            //foreach (Country country in countries)

            int maxToDisplay = userInput;

            for (int i = 0; i < countries.Count; i++)
            {
                if(i > 0 && (i % maxToDisplay == 0))
                {
                    Console.WriteLine("Hit return to continue, anything else to quit>");
                    if (Console.ReadLine() != "")
                        break;
                }

                Country country = countries[i];
                Console.WriteLine($"{i+1}: {PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }
        }
    }
}
