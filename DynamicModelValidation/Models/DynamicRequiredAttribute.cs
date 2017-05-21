using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using DynamicModelValidation.Services;

namespace DynamicModelValidation.Models
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class DynamicRequiredAttribute : ValidationAttribute, IClientValidatable
    {
        public string FieldName { get; set; }

        public DynamicRequiredAttribute(string fieldName, string errorMessage)
        {
            FieldName = fieldName;
            ErrorMessage = errorMessage;
        }

        //protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        //{
        //    BackEndDataService service = new BackEndDataService();
        //    var grouppings = service.GetFieldGrouppings();

        //    bool isValueExists;
        //    if (grouppings.TryGetValue(FieldName, out isValueExists))
        //    {
        //        if (isValueExists && value == null)
        //        {
        //            return new ValidationResult(ErrorMessage);
        //        }
        //    }

        //    return ValidationResult.Success;

        //}

        public override bool IsValid(object value)
        {
            if (IsFieldMandatory && value == null)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            if (IsFieldMandatory)
            {
                yield return new ModelClientValidationRule
                {
                    ErrorMessage = ErrorMessage,
                    ValidationType = "dynamicRequired"
                };
            }
            else
            {
                yield return new ModelClientValidationRule
                {
                    ErrorMessage = string.Empty,
                    ValidationType = "notrequired"
                };
            }

        }


        private bool IsFieldMandatory
        {
            get
            {
                BackEndDataService service = new BackEndDataService();
                var grouppings = service.GetFieldGrouppings();

                bool isValueExists;

                grouppings.TryGetValue(FieldName, out isValueExists);

                return isValueExists;

            }
        }

    }
}