using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentitySample.Models
{
    [Table("Products")]
    public class Product : Base
    {
        [ForeignKey("Category")]
        public string CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public string Price { get; set; }
        /// <summary>
        /// 保质期
        /// </summary>
        public String ShelfLife { get; set; }
        public string CoverUrl { get; set; }

        public void Modify(Product model, ApplicationDbContext db)
        {
            base.Modify(model, db);

            CategoryId = model.CategoryId;
            Price = model.Price;
            ShelfLife = model.ShelfLife;
            CoverUrl = model.CoverUrl;
        }

    }
}