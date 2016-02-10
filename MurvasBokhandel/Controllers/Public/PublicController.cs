﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MurvasBokhandel.Controllers
{
    public class BookResult
    {
        public int Aid;
        public int ISBN;
        public string Title;
        public string FirstName;
        public string Lastname;
    };
    public class PublicController : Controller
    {
        // GET: Public
        public ActionResult Start()
        {
            
            return View();
        }

        public ActionResult Book(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Search(string search_field)
        {
            List<BookResult> SearchResults = new List<BookResult>() 
            {
                new BookResult() 
                {
                    Aid = 1,
                    ISBN = 11111,
                    Title = "Harry Potter och fången från Azkaban",
                    FirstName = "J.K",
                    Lastname = "Rowling"
                },
                new BookResult() 
                {
                    Aid = 1,
                    ISBN = 22222,
                    Title = "Harry Pulver och Kalle",
                    FirstName = "J.K",
                    Lastname = "Rowling"
                },
                new BookResult() 
                {
                    Aid = 2,
                    ISBN = 33333333,
                    Title = "En murvig Murva",
                    FirstName = "Murvan",
                    Lastname = "Murvansson"
                }
            };
            return View();
        }
    }
}