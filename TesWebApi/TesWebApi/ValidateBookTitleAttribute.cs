using System.ComponentModel.DataAnnotations;
using TesWebApi.Services;

namespace TesWebApi
{
    public class ValidateBookTitleAttribute: ValidationAttribute
    {
        public IService Service { get; set; }
        public override bool IsValid(object value)
        {
            var number = Service.GetNumber();

            return true;
        }
    }
}