using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _01.Calc.ViewModels;

namespace _01.Calc.Controllers
{
    public class CalculatorController : Controller
    {
        private List<string> types = new List<string>()
                { 
                    "bit", "byte", "kilobit", "kilobyte", "megabit", "megabyte", "gigabit",
                    "gigabyte", "terabit", "terabyte", "petabit", "petabyte", "exabit", "exabyte",
                    "zettabit", "zettabyte", "yottabit", "yottabyte"
                };

        private Dictionary<string, decimal> bitTypesSize = new Dictionary<string, decimal>();

        public ActionResult Index()
        {
            FillWithZeroes();
            ViewBag.typesSizes = this.bitTypesSize;

            return View();
        }

        [ActionName("Calculate")]
        [HttpPost]
        public ActionResult Calc(Data parameters)
        {
            FillWithZeroes();

            var enteredType = parameters.Type.ToLower().Trim();
            var currQuantity = 0;

            int kilo = 1024;
            if (parameters.Kilo != 0)
            {
                kilo = parameters.Kilo;
            }

            if (this.bitTypesSize.ContainsKey(enteredType)) 
            {
                currQuantity = parameters.Quantity;
            }

            decimal bits = CalcBits(enteredType, currQuantity, kilo);

            this.bitTypesSize[this.types[0]] = bits;
            this.bitTypesSize[this.types[1]] = bits / 8;
            this.bitTypesSize[this.types[2]] = bits / kilo;

            FillBits(kilo);

            ViewBag.typesSizes = this.bitTypesSize;

            return View("Index");
        }

        private void FillWithZeroes()
        {
            foreach (var type in this.types)
            {
                this.bitTypesSize[type] = 0m;
            }
        }

        private void FillBits(int kilo)
        {
            for (int i = 3; i < this.types.Count; i++)
            {
                var prevVal = this.bitTypesSize[this.types[i - 2]];
                this.bitTypesSize[this.types[i]] = prevVal / kilo;
            }
        }

        private decimal CalcBits(string enteredType, decimal bits, int kilo)
        {
            if (enteredType != this.types[0])
            {
                int pos = this.types.IndexOf(enteredType) + 1;

                if (pos % 2 == 0)
                {
                    bits *= 8;
                }

                for (int i = pos-3; i > 0; i--)
                {
                    bits *= kilo;
                }
            }

            return bits;
        }
    }
}