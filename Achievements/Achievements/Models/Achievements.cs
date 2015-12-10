using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Achievements.Models
{
    public class Achievement
    {
        [Key]
        public virtual string AchievementName
        {
            get;
            set;
        }
        public virtual bool AchievementStatus { get;set; }
        public virtual string AchievementDescription { get; set; }
    }
}