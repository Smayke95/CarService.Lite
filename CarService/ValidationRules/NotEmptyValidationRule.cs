﻿using System.Globalization;
using System.Windows.Controls;

namespace CarService.ValidationRules
{
    public class NotEmptyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return string.IsNullOrWhiteSpace((value ?? "").ToString())
                ? new ValidationResult(false, "Polje je obavezno.")
                : ValidationResult.ValidResult;
        }
    }
}