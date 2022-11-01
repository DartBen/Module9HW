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
                    sortEventClass.SortSwitch(names, i);
                }
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Введенно некоректное значение");
            }
            catch (ExceptionExtension ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
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
    public delegate void SortDelegate();
    public event SortDelegate? SortEvent;
    public void SortSwitch(List<string> namesList, int i)
    {
        switch (i)
        {
            case 1:
                SortEventMethod(namesList);
                break;
            case 2:
                SortEventMethod(namesList);
                break;
        }
    }
    protected void SortEventMethod(List<string> namesList)
    {
        SortEvent?.Invoke();
    }
    /// <summary>
    /// Сортировка [A-Я]
    /// </summary>
    /// <param name="namesList"></param>
    public void SortAsc(List<string> namesList) { }
    /// <summary>
    /// Сортировка [Я-А]
    /// </summary>
    /// <param name="namesList"></param>
    public void SortDec(List<string> namesList) { }

    /// <summary>
    /// Сортировка [A-Я]
    /// </summary>
    /// <param name="namesList"></param>
    public void SortAsc() { }
    /// <summary>
    /// Сортировка [Я-А]
    /// </summary>
    /// <param name="namesList"></param>
    public void SortDec() { }
}