using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using second_excersise.models;

namespace second_excersise.Pages
{
    public class NominaModel : PageModel
    {
        private readonly ILogger<NominaModel> _logger;

        public NominaModel(ILogger<NominaModel> logger)
        {
            _logger = logger;
        }

        public List<Worker>
            workers =
                new List<Worker> {
                    new Worker("Juan", "Garza", "Vendedor", 45000),
                    new Worker("John",
                        "Doe",
                        "Asistente Administrativo",
                        35000),
                    new Worker("Emilia", "Lopez", "Asistente RRHH", 30000),
                    new Worker("Brayan",
                        "Gonzalez",
                        "Gerente Administrativo",
                        85000),
                    new Worker("Alvaro",
                        "Guzman",
                        "Desarollador de Software",
                        50000),
                        new Worker("Jeirison",
                        "Gomez",
                        "Desarollador de Juegos",
                        70000)
                };

        public float CalcSFS(int salary)
        {
            float deduction = (salary * 0.0304f);
            return deduction > 4098.53f ? 4098.53f : deduction;
        }

        public float CalcAFP(int salary)
        {
            float deduction = (salary * 0.0287f);
            return deduction > 7738.67f ? 738.67f : deduction;
        }

        public double CalcISR(int salary)
        {
            double max;
            double payToTax;

            if (salary * 12 > 867123)
            {
                max = 79776 / 12;
                double cap = (salary * 12) - 867123;
                payToTax = (cap / 12) * 0.25 + max;
                return Math.Round(payToTax,2);
            }
            else if (salary * 12 > 624329)
            {
                max = 31216 / 12;
                double cap = (salary * 12) - 624329;
                payToTax = (cap / 12) * 0.20 + max;
                return Math.Round(payToTax,2);
            }
            else if (salary * 12 > 416220)
            {
                max = 416220 / 12;
                payToTax = (double) salary - max;
                return payToTax * 0.15;
            }
            else
            {
                return 0;
            }
        }

        public float CalcAllDeductions(int salary)
        {
            var totalDiscount =
                CalcSFS(salary) + CalcAFP(salary) + CalcISR(salary);
            return (float) totalDiscount;
        }

        public float CalcTakeHomeSalary(int salary)
        {
            var totalNetIncome = salary - CalcAllDeductions(salary);
            return totalNetIncome;
        }

        public void OnGet()
        {
        }
    }
}
