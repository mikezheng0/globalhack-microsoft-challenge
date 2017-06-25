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
    public DbSet<Emotions> Emotions { get; set; }

    public DbSet<Cordinates> Cordinates { get; set; }
  }

  public class Interaction
  {
    public int Id { get; set; }
    public byte[] Image { get; set; }
    public int CustomerId { get; set; }
    public DateTime Time { get; set; }
    public Emotions Emotions { get; set; }
    public Cordinates Cordinates { get; set; }
  }

  public class Emotions
  {
    public float Anger { get; set; }
    public float Contempt { get; set; }
    public float Fear { get; set; }
    public float Happiness { get; set; }
    public float Nuetral { get; set; }
    public float Sadness { get; set; }
    public float Disguest { get; set; }
    public float Suprise { get; set; }
    public int Id { get; set; }

    public Interaction Interaction { get; set; }
    public int InteractionId { get; set; }

  }

  public class Cordinates
  {
    public int Id { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Height { get; set; }
    public int Weight { get; set; }

    public Interaction Interaction { get; set; }
    public int InteractionId { get; set; }
  }


}
