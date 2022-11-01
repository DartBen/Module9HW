internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            if (true == false) throw new ExceptionExtension("Моё исключение");
        }
        catch (ExceptionExtension ex)
        {
            Console.WriteLine("Системное описание :", ex.Message);
        }
        catch (System.InvalidCastException ex)
        {
            Console.WriteLine("Невозможно произвести преобразование!");
            Console.WriteLine("Системное описание :", ex.Message);
        }
        catch (System.NullReferenceException ex)
        {
            Console.WriteLine("Пустая ссылка!");
            Console.WriteLine("Системное описание :", ex.Message);
        }
        catch (System.DivideByZeroException ex)
        {
            Console.WriteLine("На ноль делить нельзя!");
            Console.WriteLine("Системное описание :", ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла непредвиденная ошибка в приложении.");
            Console.WriteLine("Системное описание :", ex.Message);
        }
        finally
        {
            //Console.WriteLine("Блок Finally");
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