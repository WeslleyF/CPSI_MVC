using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Educar.Site.Controllers
{   
    [Authorize]
    public class InicialController : Controller
    {
        [AllowAnonymous]
        [Route("")]
        [Route("Inicial")]
        public IActionResult Inicial()
        {
            return View();
        }

        [Route("Modulos")]
        public IActionResult Modulos()
        {
            return View();
        }
    }
}