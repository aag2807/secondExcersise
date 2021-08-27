using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace second_excersise.models
{
    public class Worker
    {
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Cargo { get; set; }

        public double Salario { get; set; }

        public Worker(
            string name,
            string surname,
            string title,
            int salary
        ) 
        {
            this.Nombre = name;
            this.Apellido = surname;
            this.Cargo = title;
            this.Salario = salary;
        }
    }
}
