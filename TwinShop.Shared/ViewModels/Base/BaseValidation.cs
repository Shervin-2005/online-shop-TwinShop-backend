using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwinShop.Shared.ViewModels.Base
{
    public abstract class BaseValidatoin
    {
        public bool IsValid
        {
            get
            {
                var vc = new ValidationContext(this);
                var result = new List<ValidationResult>();
                bool valid = Validator.TryValidateObject(this, vc, result, true);
                return valid;
            }
        }
        public string ErrorMessage
        {
            get
            {
                var vc = new ValidationContext(this);
                var result = new List<ValidationResult>();
                bool valid = Validator.TryValidateObject(this, vc, result, true);
                if (valid)
                {
                    return string.Empty;
                }
                else
                {
                    return string.Join(Environment.NewLine, result);
                }
            }
        }
    }
}
