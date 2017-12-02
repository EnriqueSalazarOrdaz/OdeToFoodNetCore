namespace OdeToFood
{
    public interface IGreeter
    {
        string GetMessage();
    }
    public class Greeter : IGreeter
    {
        public string GetMessage()
        {
            return "Hello from Greeter services";
        }
    }
}