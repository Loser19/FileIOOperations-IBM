// See https://aka.ms/new-console-template for more information
using FileIOOperationsIBM;

Console.WriteLine("                                 ATTENTION!! Everything you see here is done by CO_PILOT");
Console.WriteLine();
Console.WriteLine();

//string? filePath = "movies.txt";
//FileClassDemo(filePath);

//string? filePath = "superhero.txt";
//StreamClassDemo(filePath);

//string? filePath = "product.txt";
//StreamProductDemo(filePath);

//BasicLINQDemo();
//ProductLINQDemo();
//JSONSerializerDemo();
//SynchronousGetnumbers();
//AsyncGetNumbers();
static void SynchronousGetnumbers()
{
    Console.WriteLine($"Start: {DateTime.Now.ToLongTimeString()}");
    var numbers = AsynStreamDemo.GetNumbers(1, 10);
    foreach (var number in numbers)
    {
        Console.WriteLine($"Number: {number}");
    }
    Console.WriteLine($"End: {DateTime.Now.ToLongTimeString()}");
}
static async void AsyncGetNumbers()
{
    //AsynchronousStreamsDemos asynchronousStreamsDemos = new AsynchronousStreamsDemos();
    Console.WriteLine($"Start: {DateTime.Now.ToLongTimeString()}");
    var numbersAsync = AsynStreamDemo.GetNumbersAsync(1, 11);
    await foreach (var number in numbersAsync)
    {
        Console.WriteLine(number);
    }
    Console.WriteLine($"End: {DateTime.Now.ToLongTimeString()}");
}
static void JSONSerializerDemo()
{
    Superhero obj = new Superhero();
    //obj.Name = "Superman";
    //obj.Power = "Strength";
    //obj.Age = "30";
    //obj.JsonSerializeSuperhero(obj);
    obj.JsonSerializeSuperhero(new Superhero() { Name = "Batman", Power = "Money", Age = "27" });
}
static void ProductLINQDemo()
{
    ProdLINQ productLINQ = new ProdLINQ();
    productLINQ.BasicLinq();
    productLINQ.WhereLinq();
    productLINQ.TakeLinq();
    productLINQ.TakeWhileLinq();
    productLINQ.LinqFirstorFirstDeafault();
    productLINQ.LinqSingleorSingleDeafult();
    productLINQ.GroupByLinq();
    productLINQ.GroupByIntoLinq();
    productLINQ.OrderByLinq();
    productLINQ.OrderByThenByLinq();

}
static void BasicLINQDemo()
{
    BasicLINQ basicLINQ = new BasicLINQ();
    basicLINQ.TakeLinq();
    basicLINQ.LinqFirstorFirstDeafault();
    basicLINQ.LinqSingleorSingleDeafult();
    basicLINQ.GroupByLinq();
    basicLINQ.GroupByIntoLinq();
    basicLINQ.OrderByThenByLinq();
    basicLINQ.LinqOfTypeArraylist();
    basicLINQ.BasicLinqery();
    basicLINQ.UsingwhereLinq();
    basicLINQ.UsingOrderByLinq();
}
static void StreamProductDemo(string filePath)
{
    while (true)
    {
        Console.WriteLine("\n--- Product Stream Demo ---");
        Console.WriteLine("1. Add New Product");
        Console.WriteLine("2. View All Products");
        Console.WriteLine("3. Exit");
        Console.Write("Choose an option (1-3): ");

        string? choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                Console.Write("Enter Product ID: ");
                int id = int.Parse(Console.ReadLine() ?? "0");

                Console.Write("Enter Product Name: ");
                string? name = Console.ReadLine();

                Console.Write("Enter Product Price: ");
                decimal price = decimal.Parse(Console.ReadLine() ?? "0");

                Product product = new Product(id, name ?? string.Empty, price);
                ProductWriter writer = new ProductWriter(filePath);
                writer.WriteProduct(product);
                break;

            case "2":
                ProductReader reader = new ProductReader(filePath);
                reader.ReadProducts();
                break;

            case "3":
                return;

            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }
}
static void StreamClassDemo(string filepath)
{ 
    Superhero superhero = new Superhero();
    Console.Write("Enter the superhero name: ");
    superhero.Name = Console.ReadLine();
    Console.Write("Enter the superhero power: ");
    superhero.Power = Console.ReadLine();
    Console.Write("Enter the superhero age: ");
    superhero.Age = Console.ReadLine();
    superhero.addSuperhero(superhero, filepath);
    superhero.readSuperhero(filepath);
}
static void FileClassDemo(string filePath)
{
    while (true)
    {
        Console.WriteLine("\n--- Movie App System ---");
        Console.WriteLine("1. Add New Movie");
        Console.WriteLine("2. View All Movies");
        Console.WriteLine("3. Read File (StreamReader Demo)");
        Console.WriteLine("4. Write File (StreamWriter Demo)");
        Console.WriteLine("5. Exit");
        Console.Write("Choose an option (1-5): ");

        string? choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                Movie.AddMovie(filePath);
                break;
            case "2":
                Movie.ViewMovies(filePath);
                break;
            case "3":
                FileReader reader = new FileReader(filePath);
                reader.ReadFromFile();
                break;
            case "4":
                Console.Write("Enter text to write to file: ");
                string? content = Console.ReadLine();
                FileWriter writer = new FileWriter(filePath);
                writer.WriteToFile(content);
                break;
            case "5":
                return;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }
}