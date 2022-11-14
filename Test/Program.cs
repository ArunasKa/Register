Main(null);


static void Main(string[] args)
{


    var integers = new List<int> { 1, 2, 3, 4 };
    var result = integers.Where(x => x == 1);
    foreach (var item in result)
    {

        Console.WriteLine(item);
    }
}

