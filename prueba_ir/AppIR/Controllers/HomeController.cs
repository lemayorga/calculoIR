using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppIR.Models;
using Logica;
using Entidad;

namespace AppIR.Controllers
{
    public class HomeController : Controller
    {
        private readonly Operaciones _operaciones;

        public HomeController() =>  _operaciones = new Operaciones();

        public IActionResult Index() => View();

        [HttpPost]
        public PartialViewResult CalcularDeducciones(ParametrosCalculo param_calculo)
        {
            double msalario; string mensaje = string.Empty;
            ResultadoCalculoDeduciones resultado = new ResultadoCalculoDeduciones();

            mensaje += string.IsNullOrEmpty(param_calculo.salario) ?  "El valor del salario es requerido para realizar el cálculo." : "";
            mensaje += !double.TryParse(param_calculo.salario, out msalario ) ?  "Favor ingrese un valor numérico para el salario." : "";
            mensaje += !param_calculo.tipo_calculo.HasValue ?  "Favor seleccione el tipo salario a calcular" : "";

            if(!string.IsNullOrEmpty(mensaje)) 
               resultado =  resultado.MensajeError(mensaje);
            else    
              resultado = _operaciones.CalularIR(msalario, (EnumSalarios) param_calculo.tipo_calculo.Value);

            return PartialView("_TablaSalario", resultado);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() =>
            View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
