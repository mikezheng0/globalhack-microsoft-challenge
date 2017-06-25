using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularJSSample.Models
{
    public class EmotionTime
    {
        public int HoursAgo { get; set; }
        public EmotionAnalytics EmotionCounts{ get; set; }
    }
}
