using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIOOperationsIBM
{
    internal class BasicLINQ
    {
        int[] numbers = { 101, 122, 365, 14, 95, 86, 57, 78, 89, 10 };

        List<Superhero> sp = new List<Superhero>
        {
            new Superhero(){Name= "Batman", Power = "Money", Age = "27" },
            new Superhero("Superman", "Strength", "32"),
            new Superhero("Flash", "Speed", "23")
        };

        ArrayList arrayList = new ArrayList
        {
            101, 122, 365, 14, 95, 86, 57, 78, 89, 10,
            "Ted Bundy", "John Wayne Gacy", "Harold Shipman"
        };


        // Linq queries

        public void TakeLinq()
        {
            Console.Write("Using Take in LINQ: ");
            var result = numbers.Take(5);
            foreach (var n in result)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            var takeresult = numbers.TakeWhile(n => n > 100);

            Console.Write("Using TakeWhile in LINQ: ");
            foreach (var n in takeresult)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        public void LinqFirstorFirstDeafault()
        {
            Console.WriteLine("Using First and FirstOrDefault in LINQ: ");
            var firstTrainee = sp.First();
            Console.WriteLine($"First Trainee: Name: {firstTrainee.Name}, Power: {firstTrainee.Power}, Age: {firstTrainee.Age}");
            var firstOrDefaultTrainee = sp.FirstOrDefault(t => t.Name == "Superman");
            if (firstOrDefaultTrainee == null)
            {
                Console.WriteLine("No trainee found with the specified condition.");
            }
            else
            {
                Console.WriteLine($"First Or Default Trainee: Name: {firstOrDefaultTrainee.Name}, Power: {firstOrDefaultTrainee.Power}, Age: {firstOrDefaultTrainee.Age}");
            }
            Console.WriteLine();
        }

        public void LinqSingleorSingleDeafult()
        {
            Console.WriteLine("Using Single in LINQ: ");
            var singleTrainee = sp.Single(t => t.Name == "Batman");
            Console.WriteLine(singleTrainee.Power);
            //Console.WriteLine("Using SingleOrDefault in LINQ: ");
            //var singleordefaultTrainee = sp.Single(t => t.Name == "Spiderman");
            //Console.WriteLine(singleordefaultTrainee.Power);
        }
        public void GroupByLinq()
        {
            Console.WriteLine("Using GroupBy in LINQ: ");
            var groupedTrainees = sp.GroupBy(t => t.Age);
            foreach (var group in groupedTrainees)
            {
                Console.Write($"Age: {group.Key}");
                foreach (var trainee in group)
                {
                    Console.WriteLine($"  Name: {trainee.Name}, Power: {trainee.Power}");
                }
            }
            Console.WriteLine();
        }

        public void GroupByIntoLinq()
        {
            Console.WriteLine("Using GroupBy with Into in LINQ: ");
            var groupedTrainees = from trainee in sp
                                  group trainee by trainee.Age into traineeGroup
                                  select new
                                  {
                                      Age = traineeGroup.Key,
                                      Trainees = traineeGroup.ToList()
                                  };
            foreach (var group in groupedTrainees)
            {
                Console.WriteLine($"Age: {group.Age}");
                foreach (var trainee in group.Trainees)
                {
                    Console.WriteLine($"  Name: {trainee.Name}, Power: {trainee.Power}");
                }
            }
            Console.WriteLine();
        }
        public void OrderByThenByLinq()
        {
            Console.WriteLine("Using OrderBy and ThenBy in LINQ:- ");
            /* var result = from trainee in trainees
                          orderby trainee.Name ascending, trainee.Id descending
                          select trainee;*/
            var result = sp.OrderBy(t => t.Name).ThenByDescending(t => t.Power);
            foreach (var t in result)
            {
                Console.WriteLine($"Name: {t.Name}, Power: {t.Power}, Age: {t.Age}");
            }
            Console.WriteLine();
        }

        public void LinqOfTypeArraylist()
        {

            var names = arrayList.OfType<string>();
            var numbers = arrayList.OfType<int>();
            Console.Write("Names are: ");
            foreach (var name in names)
            {
                Console.Write(name + "  ");

            }
            Console.Write("\nNumbers are:");

            foreach (var no in numbers)
            {
                Console.Write(no + " ");
            }
            Console.WriteLine();
        }

        public void BasicLinqery()
        {
            Console.WriteLine();
            var result = from no in numbers select no;
            Console.Write("Using LINQ to query an array of numbers: ");
            foreach (var n in result)
            {
                Console.Write(n + "  ");
            }
            Console.WriteLine();
        }

        public void UsingwhereLinq()
        {
            Console.WriteLine();
            Console.WriteLine("Using where clause in LINQ: ");
            var result = from no in numbers //numbers.Where(no => no > 70);
                         where no > 70
                         select no;

            foreach (var n in result)
            {
                Console.Write(" " + n);
            }
        }

        public void UsingOrderByLinq()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Using OrderBy clause in LINQ: ");
            var result = from trainee in sp
                         orderby trainee.Name ascending
                         select trainee;
            foreach (var t in result)
            {
                Console.WriteLine($"Name: {t.Name}, Power: {t.Power}, Age: {t.Age}");
            }
        }
    }
}
