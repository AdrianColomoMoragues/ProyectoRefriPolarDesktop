using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProyectoRefriPolar.Validaciones
{
    class PercentageValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string porcentaje = value as string;

            if (string.IsNullOrWhiteSpace(porcentaje))
                return new ValidationResult(false, "El porcentaje no puede estar vacío.");

            if (!int.TryParse(porcentaje, out int resultado))
                return new ValidationResult(false, "El porcentaje debe ser un número.");

            if (resultado < 0 || resultado > 100)
                return new ValidationResult(false, "El porcentaje tiene que ser un valor entre 0 y 100");

            return ValidationResult.ValidResult;
        }
    }
}
