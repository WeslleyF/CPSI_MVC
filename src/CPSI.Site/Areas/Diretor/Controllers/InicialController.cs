using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Educar.Site.Areas.Diretor.Controllers
{   
    [Area("Diretor")]
    [Authorize]
    public class InicialController : Controller
    {
        [Route("Diretor/Inicial")]
        public IActionResult Inicial()
        {
            return View();
        }
    }
}