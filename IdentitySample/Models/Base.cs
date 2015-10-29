using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IdentitySample.Models
{
    public class Base
    {
        [Key]
        [ScaffoldColumn(false)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset CreateTime { get; set; }
        public DateTimeOffset ModifyTime { get; set; }


        public virtual void Create(ApplicationDbContext db)
        {
            CreateTime = DateTime.Now;
            if (string.IsNullOrEmpty(Id))
            {
                Id = Guid.NewGuid().ToString();
            }
        }

        public void Modify(Base model, ApplicationDbContext db)
        {
            ModifyTime = DateTime.Now;
            Name = model.Name;
            Description = model.Description;

            db.Entry(this).State = EntityState.Modified;
        }
    }
}