using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.OData.Builder;

namespace IdentitySample.Models
{
    public class ODataModel
    {
        public static IEdmModel GetEdmModel()
        {
            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Product>("Product");
            builder.EntitySet<Category>("Category");
            builder.EntitySet<Award>("Award");
            builder.EntitySet<Activity>("Activity");

            return builder.GetEdmModel();
        }
    }
}