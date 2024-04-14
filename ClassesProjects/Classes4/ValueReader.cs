namespace A;

public class ValueReader
{
    private string _path = "input.txt";

    public string Read()
    {
        //One way
        //if (!File.Exists(_path))
        //{
        //    throw new InvalidOperationException("File does not exist");
        //}

        try
        {
            return File.ReadAllText(_path);
        }
        catch (FileNotFoundException e)
        {
            throw new NoFileException("File does not exist", e);
        }
        //below will work but is not needed
        //catch (Exception)
        //{
        //    throw;
        //}
    }
}

public class NoFileException : Exception
{
    public NoFileException(string message, Exception innerException) 
        : base(message, innerException) 
    {

    }
}