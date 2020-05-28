using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PravinChopadeTest.Models;

namespace PravinChopadeTest.Controllers
{
    public class ProductMVCController : Controller
    {
        ProductDAL prodatabase = new ProductDAL();

        [HttpGet]
        public IActionResult ProductDetails()
        {
            List<ProductModel> productlist = new List<ProductModel>();
            productlist = prodatabase.getAllProductDetails().ToList();
            return View(productlist);
        }

        public IActionResult create([Bind] ProductModel proobj)
        {

            if (ModelState.IsValid)
            {
                if (proobj.ProductID==0)
                {
                    var data = prodatabase.checkProductName(proobj);
                    if (data != null)
                    {
                        TempData["notice"] = "The Product Name Already existed";
                        return View(proobj);

                    }
                }
                else
                {
                    var Productresult = prodatabase.getProductByID(proobj.ProductID);
                    if (Productresult.ProductName != proobj.ProductName)
                    {
                        var data = prodatabase.checkProductName(proobj);
                        if (data != null)
                        {
                            TempData["notice"] = "The Product Name Already existed";
                            return View(proobj);
                        }
                    }
                }

                prodatabase.addProduct(proobj);
                return RedirectToAction("ProductDetails");
            }
            return View(proobj);
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            ProductModel proobj = new ProductModel();
            if (id == 0)
            {
                return NotFound();
            }
            else
            {
                proobj= prodatabase.getProductByID(id);
            }
            return View(proobj);
        }

        [HttpPost]
        public IActionResult Edit([Bind] ProductModel proobj)
        {
            if (ModelState.IsValid)
            {
                prodatabase.addProduct(proobj);
                return RedirectToAction("ProductDetails");
            }
            return View(proobj);
        }


        [HttpPost]
        public IActionResult Delete(long ProductID)
        {
            if (ModelState.IsValid)
            {
                prodatabase.deleteProduct(ProductID);
                return RedirectToAction("ProductDetails");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Details(long id)
        {
            ProductModel proobj = new ProductModel();
            if (id == 0)
            {
                return NotFound();
            }
            else
            {
                proobj = prodatabase.getProductByID(id);
            }
            return View(proobj);
        }
    }
}