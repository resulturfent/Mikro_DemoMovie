using DemoMovie.Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoMovie.API.Controllers
{
 
    public class CustomBaseController : ControllerBase
    {

        [NonAction]//EndPoint olmadığını belirtmek için kullandık
        public IActionResult CreateActionResult<T>(CustomResponseDTO<T> response)
        {
            if (response.StatusCode == 204)//Eğer content yok ise 204 mesajı veriyor
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode
                };
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }

    }
}
