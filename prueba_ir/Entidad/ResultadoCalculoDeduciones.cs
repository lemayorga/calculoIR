namespace Entidad
{
    public class ResultadoCalculoDeduciones
    {
        #region Propiedades

        public double inss_anual { get; set; }
        public double ir_anual { get; set; }
        public double salario_bruto_anual { get; set; }
        public double salario_anual { get; set; }

        private bool _error_calculo;
        public bool error_calculo { get { return _error_calculo; } }        
        private string _error_mensaje;
        public string error_mensaje { get { return _error_mensaje; } }
        
        #endregion

        public ResultadoCalculoDeduciones(bool error_calculo = false, string error_mensaje = "") 
        {
            _error_calculo = error_calculo;
            _error_mensaje = error_mensaje;
        }

        public ResultadoCalculoDeduciones MensajeError(string mensaje)
        {
            _error_calculo = true;
            _error_mensaje = mensaje;
            return this;
        }
    }
}