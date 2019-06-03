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

            var filteredCountries = countries.Where(x => !x.Name.Contains(','));//.Take(20);

            var filteredCountries2 = from country in countries
                                    where !country.Name.Contains(',')
                                    select country;

            foreach (Country country in filteredCountries2) 
            {
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }

            Console.WriteLine($"{countries.Count} countries");
        }
    }
}
