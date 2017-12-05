using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Controllers
{
    //[Route("myOwnPath/[controller]/[action]")]
    [Route("[controller]/[action]")] //using tokens
    //[Route("About")]
    public class AboutController
    {
        //[Route("Phone")]//using text literal
        //[Route("")]//when blank space, making like default action, kind of
        public string Phone()
        {
            return "1+555+555+555+555";
        }

        //[Route("[action]")]//using token
        public string Address()
        {
            return "USA";
        }
    }
}
