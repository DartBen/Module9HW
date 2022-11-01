using System.Security.Cryptography.X509Certificates;

internal class Program
{

    public delegate void SortDelegate();
    public event SortDelegate SortEvent;
    private static void Main(string[] args)
    {
        SortDelegate sortDelegate;
        

        Console.WriteLine("Hello, World!");
    }

}