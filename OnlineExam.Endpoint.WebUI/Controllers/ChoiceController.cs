using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Domain.Core.Choices;

namespace OnlineExam.Endpoint.WebUI.Controllers
{
    public class ChoiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Choices()
        {
            return View();
        }
    }
}