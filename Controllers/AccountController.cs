using eBook.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBook.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(SignUpUserModel userModel)
        {
            if (ModelState.IsValid)
            {
                // write your code

                ModelState.Clear();
            }
            return View();
        }
    }
}
