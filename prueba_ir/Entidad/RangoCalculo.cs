namespace Entidad
{
    public class RangoCalculo
    {
        private double _desde;
        public double desde
        {
            get { return _desde; }
            set { _desde = value; }
        }
        
        private double? _hasta;
        public double? hasta
        {
            get { return _hasta; }
            set { _hasta = value; }
        }
        
        private double _impuesto;
        public double impuesto
        {
            get { return _impuesto; }
            set { _impuesto = value; }
        }
        
        private double _porcentaje;
        public double porcentaje
        {
            get { return _porcentaje; }
            set { _porcentaje = value; }
        }
        
        private double _exceso;
        public double exceso
        {
            get { return _exceso; }
            set { _exceso = value; }
        }
        
    }
}