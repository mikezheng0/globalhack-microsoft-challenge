
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularJSSample.Models
{
    public class Emotion
    {
        public FaceRectangle FaceRectangle { get; set; }
        public EmotionScore Scores { get; set; }
    }
}
