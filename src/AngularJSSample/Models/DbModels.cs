using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AngularJSSample.Models
{
  public class CameraContext : DbContext
  {
    public CameraContext(DbContextOptions<CameraContext> options)
        : base(options)
    { }

    public DbSet<Interaction> Interaction { get; set; }
  }

  public class Interaction
  {
    public int Id { get; set; }
    public byte[] Image { get; set; }
    //public int CustomerId { get; set; }
    public DateTime Time { get; set; }

        public float Anger { get; set; }
        public float Contempt { get; set; }
        public float Fear { get; set; }
        public float Happiness { get; set; }
        public float Neutral { get; set; }
        public float Sadness { get; set; }
        public float Disgust { get; set; }
        public float Surprise { get; set; }

        public int Left { get; set; }
        public int Top { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

    }

}
