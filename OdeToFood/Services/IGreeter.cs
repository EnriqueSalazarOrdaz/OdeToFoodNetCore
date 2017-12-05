using Microsoft.Extensions.Configuration;

namespace OdeToFood.Services
{
    public interface IGreeter
    {
        string GetMessage();
    }
    public class Greeter : IGreeter
    {
        private IConfiguration _configuration;//this is a private field

        public Greeter(IConfiguration configuration)//we do that because when we need to split and it will make easy for testingProject
        {
            _configuration = configuration;
        }
        public string GetMessage()
        {
            //return "Hello from Greeter services";
            return _configuration["Greeting"];
        }
    }
}