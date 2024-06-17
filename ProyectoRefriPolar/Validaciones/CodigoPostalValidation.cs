using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProyectoRefriPolar.Validaciones
{
    internal class CodigoPostalValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string codigoPostal = value as string;

            if (string.IsNullOrWhiteSpace(codigoPostal))
                return new ValidationResult(false, "El código postal no puede estar vacío.");

            // Validación de la expresión regular para verificar si es un código postal válido
            string pattern = @"^\d{5}$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(codigoPostal, pattern))
                return new ValidationResult(false, "El formato del código postal no es válido. Debe tener 5 dígitos.");

            return ValidationResult.ValidResult;
        }
    }
}
