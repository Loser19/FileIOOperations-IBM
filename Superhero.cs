using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIOOperationsIBM
{
    internal class Superhero
    {
        public string Name { get; set; }
        public string Power { get; set; }
        public string Age { get; set; }
        public Superhero() { }
        public Superhero(string name, string power, string age)
        {
            Name = name;
            Power = power;
            Age = age;
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}, Power: {Power}, Age: {Age}");
        }

        // write a method to  write Superhero details to a  file using stream writer.
        public void addSuperhero(Superhero superhero, string filepath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filepath, true))
                {
                    writer.WriteLine($"{superhero.Name},{superhero.Power},{superhero.Age}");
                }

            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("Access denied: " + e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine("IO error: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected error: " + e.Message);
            }

        }
        // read Superhero details from a file using stream reader.
        public void readSuperhero(string filepath)
        {
            try
            {
                if (!File.Exists(filepath))
                {
                    Console.WriteLine("File not found.");
                    return;
                }
                using (StreamReader reader = new StreamReader(filepath))
                {
                    string? line;
                    while((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File not found: " + e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine("IO error: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected error: " + e.Message);
            }
        }
    }
}
