using System;
using System.Collections.Generic;

namespace Rythm.Models
{
  public class Album
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsExplicit { get; set; }
    public DateTime ReleaseDate { get; set; }
    // nav properties
    public List<Song> Songs { get; set; } = new List<Song>();

    public int BandId { get; set; }
    public Album Bands { get; set; }
  }
}




// Id
// Title
// IsExplicit
// ReleaseDate