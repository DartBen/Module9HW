using System.Collections;
using System.Globalization;
using static System.Console;


internal class Program
{
    private static void Main(string[] args)
    {
        int i = 0;
        List<string> names = new List<string>() { "Суслов", "Иванов", "Петров", "Агатис", "Берия" };
        sortEventClass sortEventClass = new sortEventClass();
        while (i != 1 & i != 2)
        {
            try
            {
                WriteLine("Введите вариант сортировки: 1 для [A-Я], 2 для [Я-А]");
                Int32.TryParse(ReadLine(), out i);
                if (!(i == 1) & !(i == 2)) throw new ExceptionExtension("Введённое число не соответствует вариантам сортировки");
                else
                {
                    switch (i)
                    {
                        case 1:
                            sortEventClass.SortEvent += sortEventClass.SortAsc;
                            break;
                        case 2:
                            sortEventClass.SortEvent += sortEventClass.SortDec;
                            break;
                    }
                    sortEventClass.SortEventMethod(names);

                    foreach(var name in names)
                    {
                        WriteLine(name);
                    }
                }
            }
            catch (System.FormatException)
            {
                WriteLine("Введенно некоректное значение");
            }
            catch (ExceptionExtension ex)
            {
                WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                WriteLine(ex.ToString());
            }
        }
    }
}
class ExceptionExtension : Exception
{
    public ExceptionExtension()
    { }
    public ExceptionExtension(string name) : base(name)
    { }
}
class sortEventClass
{
    public delegate void SortDelegate(List<string> namesList);
    public event SortDelegate? SortEvent;
    public void SortEventMethod(List<string> namesList)
    {
        SortEvent?.Invoke(namesList);
    }
    /// <summary>
    /// Сортировка [A-Я]
    /// </summary>
    /// <param name="namesList"></param>
    public void SortAsc(List<string> namesList)
    {
        namesList.Sort();
    }
    /// <summary>
    /// Сортировка [Я-А]
    /// </summary>
    /// <param name="namesList"></param>
    public void SortDec(List<string> namesList)
    {
        namesList.Sort();
        namesList.Reverse();
    }
}