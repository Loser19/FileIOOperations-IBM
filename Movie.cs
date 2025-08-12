using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileIOOperationsIBM
{
    internal class Movie
    {
        public Movie() { }

        public Movie(string title, string director) { }

        public static void AddMovie(string filePath)
        {
            try
            {
                Console.Write("Enter Movie Title: ");
                string? title = Console.ReadLine();

                Console.Write("Enter Director Name: ");
                string? director = Console.ReadLine();

                string? movieEntry = $"{title},{director}";

                File.AppendAllText(filePath, movieEntry + Environment.NewLine);
                Console.WriteLine("Movie added successfully.");
            }
            catch (IOException ex)
            {
                Console.WriteLine("An error occurred while writing to the file: " + ex.Message);
            }
        }

        public static void ViewMovies(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("No movies found.");
                }

                string[] movies = File.ReadAllLines(filePath);
                Console.WriteLine("\nAvailable Movies:");

                foreach (string movie in movies)
                {
                    string[] parts = movie.Split(',');
                    Console.WriteLine($"Title: {parts[0]}, Director: {parts[1]}");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("An error occurred while reading the file: " + ex.Message);
            }
        }
    }
}