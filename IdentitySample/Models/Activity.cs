using System;
using System.Collections.Generic;
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
    }
}