
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularJSSample.Models
{
    public class Emotion
    {
        public FaceRectangle rectangle { get; set; }
        public EmotionScore score { get; set; }
    }
}
