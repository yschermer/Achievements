using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Achievements.Models
{
    public class Achievement
    {
        public enum statusEnum
        {
            Pass,
            Failed,
            NoStatus
        }

        [Key]
        public virtual int AchievementId { get; set; }
        public virtual string UserId { get; set; }
        public virtual string Name { get; set; }
        public virtual string AchievementName
        {
            get;
            set;
        }
        public virtual statusEnum AchievementStatus { get;set; }
        public virtual string AchievementDescription { get; set; }
    }
}