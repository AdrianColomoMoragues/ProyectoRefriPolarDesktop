using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProyectoRefriPolar.Validaciones
{
    internal class PhoneValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string phone = value as string;
            bool HayError = !Regex.IsMatch(phone, @"^[0-9 ]{9,18}$");

            if (string.IsNullOrWhiteSpace(phone))
                return new ValidationResult(false, "El telefono no puede estar vacío.");

            if (HayError)
            {
                return new ValidationResult(false, "El telefono no es valido.");
            }
            return ValidationResult.ValidResult;
        }
    }
}
