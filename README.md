
![My Skills](https://skillicons.dev/icons?i=dotnet,html,js,&theme=light)

# Prueba técnica de calculo del IR 

Pequeña aplicación para calcular el IR según el salario bruto del empleado.
Consiste en un formulario que solicitan dos parámetros para poder realizar 
la operación:

* Tipo salario a calcular (Mensual o Anual) (tipo_calculo)
* Monto salario  (salario_bruto)

Siendo la operación:

```
salario_bruto_anual = tipo_calculo == Mensual ?  salario_bruto * 12 : salario_bruto

salario_deduccion =  resultado.salario_bruto_anual - deduccion_inss

tablaIR  = ObtenerTablaIR()

rango = rang => salario_deduccion >= rang.desde && salario_deduccion < (rang.hasta ?? Double.MaxValue)


ir_anual = (((salario_deduccion - rango.exceso) * (rango.porcentaje / 100)) + rango.impuesto);    

salario_anual  = resultado.salario_bruto_anual - resultado.inss_anual -  resultado.ir_anual;
```


Este calculo es lo basadado en su momento en el país de Nicaragua.
