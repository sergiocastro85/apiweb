public class HelloWordService: IHelloWordService
{
    public string GetHelloworld()
    {
        return "Hello World!";
    }
}

public interface IHelloWordService
{
    string GetHelloworld();
}