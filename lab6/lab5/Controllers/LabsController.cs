using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using lab5.ClassLibrary;

namespace lab5.Controllers
{
    public class LabsController : Controller
    {
        public IActionResult PR1()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult PR1(lab1DTO model)
        {
            try
            {
                model.response = Lab1.Run(model.a, model.b, model.c);
                model.isSuccessful = true;
            }
            catch (Exception e)
            {
                model.error = e.Message;
            }
            return View(model);
        }
        
        public IActionResult PR2()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult PR2(lab2DTO model)
        {
            try
            {
                model.response = Lab2.Run(model.n, model.s, model.w, model.e, model.u, model.d, model.firstMove);
                model.isSuccessful = true;
            }
            catch (Exception e)
            {
                model.error = e.Message;
            }
            return View(model);
        }
        
        public IActionResult PR3()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult PR3(lab3DTO model)
        {
            try
            {
                model.response = Lab3.Run(model.input);
                model.isSuccessful = true;
            }
            catch (Exception e)
            {
                model.error = e.Message;
            }
            return View(model);
        }
    }
}