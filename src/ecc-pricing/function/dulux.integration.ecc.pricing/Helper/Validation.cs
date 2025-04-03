using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dulux.integration.ecc.pricing.Helper
{
    public static class Validation
    {
        public static bool TrySchemaValidate(object instance, out List<ValidationResult> results)
        {
            var context = new ValidationContext(instance);
            results = new List<ValidationResult>();
            return Validator.TryValidateObject(instance, context, results, true);
        }

        public static bool TryDataValidate(IDataToValidate instance, out List<ValidationResult> results)
        {
            return instance.Validate(out results);
        }
    }
}
