using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IdentitySample.Models
{
    public class Activity : Base
    {
        public string CoverUrl { get; set; }
        public DateTimeOffset BeginTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        /// <summary>
        /// 活动允许参加次数
        /// </summary>
        public int Count { get; set; }

        public virtual ICollection<Award> Awards { get; set; }

        public void Modify(Activity model, ApplicationDbContext db)
        {
            base.Modify(model, db);
            CoverUrl = model.CoverUrl;
            BeginTime = model.BeginTime;
            EndTime = model.EndTime;
            Count = model.Count;

            model.Awards = model.Awards ?? new List<Award>();

            var add = model.Awards.Where(o1 => !Awards.Any(o2 => o1.Id == o2.Id)).ToList();
            var remove = Awards.Where(o1 => !model.Awards.Any(o2 => o1.Id == o2.Id)).ToList();

            foreach (var item in add)
            {
                db.Entry(item).State = EntityState.Unchanged;
                Awards.Add(item);
            }

            foreach (var item in remove)
            {
                Awards.Remove(item);
            }
        }

        public override void Create(ApplicationDbContext db)
        {
            base.Create(db);
            if (Awards != null)
            {
                foreach (var item in Awards)
                {
                    db.Entry(item).State = EntityState.Unchanged;
                }
            }
        }
    }
}