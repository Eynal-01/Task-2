using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using Task_2.Entities;
using Task_2.Models;

namespace Task_2.Controllers
{
    public class ProductController : Controller
    {
        public static List<Product> Products { get; set; } = new List<Product>
        {
              new Product
                    {
                        Id=1,
                        Name="Product 1",
                        Category="Flour products",
                        Discount=0,
                        Price=0.60,
                        ImagePath="feewfew"
                    },
                    new Product
                    {
                        Id=2,
                        Name="Product 2",
                        Category="Sparkling waters",
                        Discount=0,
                        Price=1.5,
                        ImagePath="feewfew"
                    },
                    new Product
                    {
                        Id=3,
                        Name="Product 3",
                        Category="Energy drinks",
                        Discount=0,
                        Price=4.7,
                        ImagePath="feewfew"
                    },
                    new Product
                    {
                        Id=4,
                        Name="Product 4",
                        Category="Flour products",
                        Discount=0,
                        Price=0.60,
                        ImagePath="feewfew"
                    }
        };
        public IActionResult Index()
        {
            var vm = new ProductListViewModel
            {
                Products = Products
            };
            return View(vm);
        }

        //[HttpGet]
        //public IActionResult Update(int myid)
        //{
        //    var prod = Products[--myid];

        //    var vm = new ProductUpdateViewModel
        //    {
        //        Product = prod
        //    };
        //    return View(vm);
        //}

        //[HttpPost]
        ////public IActionResult Update(ProductUpdateViewModel vm)
        ////{

        ////}

        [HttpGet]
        public IActionResult Add()
        {
            var vm = new ProductAddViewModel
            {
                Product = new Product(),
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Add(ProductAddViewModel vm)
        {
            Products.Add(vm.Product);
            vm.Product.Id = Products.Count;
            return RedirectToAction("index");
        }

        public IActionResult Delete(int myid)
        {
            var prod = Products[--myid];
            Products.Remove(prod);
            foreach (var item in Products)
            {
                item.Id--;
            }
            return RedirectToAction("index");
        }
    }
}
