namespace A;

public class Calculator 
{
    public Calculator(Parser parser)
    {
        Parser = parser;
    }

    public Parser Parser { get; }

    public double Calculate() => 100/Parser.Parse();
}
