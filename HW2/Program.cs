using DomainLayer.Managers;
using ViewLayer.Models;

internal class Program
{
    private static void Main(string[] args)
    {       
        GameManager gameManager = new GameManager();
        GamePresenter gamePresenter = new GamePresenter(gameManager);

        //gamePresenter.StartNewMatch();

        gameManager.Run();

        Console.ReadKey();
    }
}