using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProyectoRefriPolar.Validaciones
{
    class EmptyValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string texto = value as string;
            if (string.IsNullOrWhiteSpace(texto))
                return new ValidationResult(false, "El campo no puede estar vacío.");


            return ValidationResult.ValidResult;
        }
    }
}
