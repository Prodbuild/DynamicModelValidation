using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DynamicModelValidation.Services
{
    public class BackEndDataService
    {

        public Dictionary<string, bool> GetFieldGrouppings()
        {

            if (HttpContext.Current.Items["FieldGroupppings"] != null)
            {
                return HttpContext.Current.Items["FieldGroupppings"] as Dictionary<string, bool>;
            }

            var fieldGrouppings = new Dictionary<string, bool>();
            fieldGrouppings.Add("Student_Name", true);
            fieldGrouppings.Add("Student_Age", true);
            fieldGrouppings.Add("Student_Standard", false);
            HttpContext.Current.Items["FieldGroupppings"] = fieldGrouppings;
            return fieldGrouppings;
        }


    }


}