using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
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
                        Category="Product category",
                        Discount=0,
                        Price=2340,
                        ImagePath="https://packmojo.com/cms_assets/packmojo_shop_tray_and_sleeve_box_f67686e3d4.png"
                    },
                    new Product
                    {
                        Id=2,
                        Name="Product 2",
                        Category="Product category",
                        Discount=0,
                        Price=5673,
                        ImagePath="https://packmojo.com/cms_assets/packmojo_mb_s_standard_mailer_box_product_catalogue_01_21608f7745.png"
                    },
                    new Product
                    {
                        Id=3,
                        Name="Product 3",
                        Category="Product category",
                        Discount=0,
                        Price=6584,
                        ImagePath="https://packmojo.com/cms_assets/medium_packmojo_rb_ml_magnetic_lid_rigid_box_product_catalogue_01_7374533248.png"
                    },
                    new Product
                    {
                        Id=4,
                        Name="Product 4",
                        Category="Product category",
                        Discount=0,
                        Price=4322,
                        ImagePath="https://packmojo.com/cms_assets/packmojo_fc_slb_folding_carton_snap_lock_product_catalogue_01_b0a87e75e5.png"
                    },
                     new Product
                    {
                        Id=5,
                        Name="Product 5",
                        Category="Product category",
                        Discount=23,
                        Price=5435,
                        ImagePath="https://packmojo.com/cms_assets/packmojo_shop_tray_and_sleeve_box_f67686e3d4.png"
                    },
                      new Product
                    {
                        Id=6,
                        Name="Product 6",
                        Category="Product category",
                        Discount=0,
                        Price=554,
                        ImagePath="https://packmojo.com/cms_assets/packmojo_fc_slb_folding_carton_snap_lock_product_catalogue_01_b0a87e75e5.png"
                    },
                       new Product
                    {
                        Id=7,
                        Name="Product 7",
                        Category="Product category",
                        Discount=0,
                        Price=10000,
                        ImagePath="https://packmojo.com/cms_assets/packmojo_mb_s_standard_mailer_box_product_catalogue_01_21608f7745.png"
                    }
        };
        public IActionResult Index()
        {
            var vm = new ProductViewModel
            {
                Products = Products
            };
            return View(vm);
        }

        [HttpGet]
        public IActionResult Update(int myid)
        {
            var prod = Products.SingleOrDefault(p => p.Id == myid);
            var vm = new ProductUpdateViewModel
            {
                Product = prod,
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Update(ProductUpdateViewModel vm)
        {
            var myId = 0;
            myId = Products.SingleOrDefault(p => p.Id == vm.Product.Id).Id;
            var prod = Products[--myId];
            prod.Price = vm.Product.Price;
            prod.Name = vm.Product.Name;
            prod.Category = vm.Product.Category;
            prod.Discount = vm.Product.Discount;
            prod.ImagePath = vm.Product.ImagePath;
            return RedirectToAction("index");
        }

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
            for (int i = (myid); i < Products.Count; i++)
            {
                Products[i].Id--;
            }
            return RedirectToAction("index");
        }
    }
}
