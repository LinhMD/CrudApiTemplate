using System.ComponentModel.DataAnnotations;
using CrudApiTemplate.CustomException;

namespace CrudApiTemplate.Utilities
{
    public class Validation
    {

        public static void Validate(Object obj)
        {
            ValidationContext vc = new ValidationContext(obj);
            ICollection<ValidationResult> results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(obj, vc, results, true);
            if (!isValid)
            {
                string error = "";
                foreach (var item in results)
                {
                    error += item.ErrorMessage;
                    error += "\n";
                }
                throw new ModelValueInvalidException(error);
            }
        }

    }
}
