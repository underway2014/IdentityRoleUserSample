using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IdentitySample.Models
{
    public class Award : Base
    {
        public string CoverUrl { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Quantity { get; set; }
        public int Level { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }

        public void Modify(Award model, ApplicationDbContext db)
        {
            base.Modify(model, db);
            CoverUrl = model.CoverUrl;
            Quantity = model.Quantity;
            Level = model.Level;

            var add = model.Activities.Where(o1 => !Activities.Any(o2 => o1.Id == o2.Id)).ToList();
            var remove = Activities.Where(o1 => !model.Activities.Any(o2 => o1.Id == o2.Id)).ToList();

            foreach(var item in add)
            {
                db.Entry(item).State = EntityState.Unchanged;
                Activities.Add(item);
            }

            foreach(var item in remove)
            {
                Activities.Remove(item);
            }
        }

        public void Create(ApplicationDbContext db)
        {
            base.Create(db);

            if (Activities != null)
            {
                foreach (var item in Activities)
                {
                    db.Entry<Activity>(item).State = EntityState.Unchanged;
                }
            }
        }
    }
}