using Entidad;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Logica
{
    public class Operaciones    
    {
        #region  Propiedades

        public Variables _variables { get; } 

        #endregion

        public Operaciones() => _variables = new Variables();

        public ResultadoCalculoDeduciones CalularIR(double salario_bruto, EnumSalarios tipo_calculo)
        {
            ResultadoCalculoDeduciones resultado = new ResultadoCalculoDeduciones();
            resultado.salario_bruto_anual = tipo_calculo == EnumSalarios.Mensual ?  salario_bruto * 12 : salario_bruto;

            double deduccion_inss = CalcularInss(resultado.salario_bruto_anual);
            double salario_deduccion =  resultado.salario_bruto_anual - deduccion_inss;

            try 
            {
                List<RangoCalculo> tablaIR  = _variables.ObtenerTablaIR();            
                RangoCalculo rango = tablaIR.FirstOrDefault(rang => salario_deduccion >= rang.desde && salario_deduccion < (rang.hasta ?? Double.MaxValue));

                if(rango == null)
                    return resultado.MensajeError("No se encontro un intervalo en la tabla del IR");   
                
                resultado.inss_anual = deduccion_inss;
                resultado.ir_anual = (((salario_deduccion - rango.exceso) * (rango.porcentaje / 100)) + rango.impuesto);                     
                resultado.salario_anual  = resultado.salario_bruto_anual - resultado.inss_anual -  resultado.ir_anual;
            }
            catch(Exception excepcion)
            {
                 resultado.MensajeError("Ocurrio un error al momento de realizar el calculo");      
                 Console.WriteLine(excepcion.Message);
            }

            return resultado;
        }

        public double CalcularInss(double salario_bruto_anual)
        {
            double porc_deducion_inss = _variables.ObtenerPorcentajeINSS();
            return (salario_bruto_anual * (porc_deducion_inss / 100));
        }
    }
}
