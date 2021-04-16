using Entidad;
using System.Linq;
using System.Collections.Generic;

namespace Logica
{
    public class Variables    
    {
        public List<RangoCalculo> ObtenerTablaIR() 
        { 
            return Configuracion.config.GetSection("tablaIR").GetChildren().Select(propiedad =>  
            new RangoCalculo 
            { 	
                desde = double.Parse(string.IsNullOrEmpty(propiedad["desde"]) ? "0" : propiedad["desde"]), 		
                hasta = string.IsNullOrEmpty(propiedad["hasta"]) ? ((double?)null) : double.Parse(propiedad["hasta"]), 	  
                impuesto = double.Parse(string.IsNullOrEmpty(propiedad["impuesto"]) ? "0" : propiedad["impuesto"]), 	  
                porcentaje = double.Parse(string.IsNullOrEmpty(propiedad["porcentaje"]) ? "0" : propiedad["porcentaje"]), 	  
                exceso = double.Parse(string.IsNullOrEmpty(propiedad["exceso"]) ? "0" : propiedad["exceso"]) 	  
            }).ToList(); 
        }

        public double ObtenerPorcentajeINSS() 
        {
            string cong_inss =  Configuracion.config["deduccion_INSS"];
            return double.Parse(string.IsNullOrEmpty(cong_inss) ? "0" : cong_inss);
        }
    }
}



