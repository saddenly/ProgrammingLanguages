namespace A;

public class Parser
{
    public Parser(ValueReader valueReader)
    {
        ValueReader = valueReader;
    }

    public ValueReader ValueReader { get; }

    public int Parse()
    {
        try
        {
            return int.Parse(ValueReader.Read());
        }
        catch (Exception e)
        {
            Console.WriteLine($"There was a problem with a number parsed {ValueReader.Read()}");
            //DONT DO THIS:
            //throw e;

            //DO THIS
            throw;
        }
    }
}
