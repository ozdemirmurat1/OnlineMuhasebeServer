using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebeServer.Presentation.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Presentation.Controller
{
    // sealed bu class ın başka class a inherit edilmesini engeller.
    public sealed class TestController:ApiController
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("İşlem başarılı");
        }
    }
}
