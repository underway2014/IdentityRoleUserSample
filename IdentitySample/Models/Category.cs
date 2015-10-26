using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdentitySample.Models
{
    [Table("Categories")]
    public class Category : Base
    {
        public void Modify(Category model)
        {
            base.Modify(model);
        }
    }
}