using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        [Route("register")]
        public IActionResult Index(Person person)   // can use Bind for binding only certain parameters.
        // Example: public IActionResult Index([Bind(nameof(Person.PersonName), nameof(Person.Email), nameof(Person.ConfirmPassword))] Person person)
        // also can use [BindNever] in person attribute for excluding certain fields from model binding
        {
            /*
            List<string> errorsList = [];
            
            if (!ModelState.IsValid)
            {
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        errorsList.Add(error.ErrorMessage);
                    }
                }
                string errors = string.Join("\n", errorsList);
                return BadRequest(errors);
            }*/

            /* ANOTHER WAY */
            if (!ModelState.IsValid)
            {
                string errors = string.Join("\n", 
                    ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage));
                return BadRequest(errors);
            }

            return Content($"{person}");
        }

        [Route("register2")]
        public IActionResult Index2(PersonIValidateInterface personIValidateInterface)
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("\n",
                    ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage));
                return BadRequest(errors);
            }
            return Content($"{personIValidateInterface}");
        }
    }
}
