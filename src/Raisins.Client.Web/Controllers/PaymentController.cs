﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Raisins.Client.Web.Models;

namespace Raisins.Client.Web.Controllers
{
    public class PaymentController : Controller
    {
        //
        // GET: /Payment/

        public ActionResult Index()
        {
            Payment[] models = Payment.GetAll();
            
            ViewData["CashOnHand"] = Payment.GetCashOnHand(HttpContext.User.Identity.Name);

            if (Request.QueryString["Locked"] == "True")
            {
                models = models.Where(payment => payment.Locked).ToArray();
            }
            else if (Request.QueryString["Locked"] == "False")
            {
                models = models.Where(payment => !payment.Locked).ToArray();
            }

            return View(models);
        }

        //
        // GET: /Payment/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Payment/Create

        public ActionResult Create()
        {
            ViewBag.Beneficiaries = Beneficiary.GetAll(HttpContext.User.Identity.Name);
            ViewBag.Currencies = Currency.GetAll(HttpContext.User.Identity.Name);

            return View();
        } 

        //
        // POST: /Payment/Create

        [HttpPost]
        public ActionResult Create(Payment payment)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Payment/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Payment/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Payment/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Payment/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
