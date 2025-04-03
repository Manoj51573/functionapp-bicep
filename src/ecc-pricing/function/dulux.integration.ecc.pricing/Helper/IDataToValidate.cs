using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dulux.integration.ecc.pricing.Helper
{
    public interface IDataToValidate
    {
        bool Validate(out List<ValidationResult> results);
    }
}
