using System.Collections.Generic;

namespace Rythm.Models
{
  public class Band
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string CountryOfOrigin { get; set; }
    public string NumberOfMembers { get; set; }
    public string Website { get; set; }
    public string Style { get; set; }
    public bool IsSigned { get; set; }
    public string PersonOfContact { get; set; }
    public string ContactPhoneNumber { get; set; }
    // Nav props
    public List<Album> Albums { get; set; } = new List<Album>();

  }
}




// Id
// Name
// CountryOfOrigin
// NumberOfMembers
// Website
// Style
// IsSigned
// PersonOfContact
// // ContactPhoneNumber
// public int CohortId { get; set; }
//     public Cohort Cohort { get; set; }