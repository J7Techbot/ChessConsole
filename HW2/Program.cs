using ViewLayer;

/// <summary>
/// Run this application
/// </summary>
internal class Program
{
    private static void Main(string[] args)
    {       
        View view = new View();

        view.Start();

        Console.ReadKey();
    }
}