using System;
using System.Linq;
using Rythm.Models;

namespace Rythm
{
  public class BandTracker
  {
    public static DatabaseContext db { get; set; } = new DatabaseContext();
    internal static void AddNewBand(string name, string countryOfOrigin, string numberOfMembers, string website, string style, string personOfContact, string contactPhoneNumber)
    {
      //   var db = new DatabaseContext();
      db.Bands.Add(new Band
      {
        Name = name,
        CountryOfOrigin = countryOfOrigin,
        NumberOfMembers = numberOfMembers,
        Website = website,
        Style = style,
        IsSigned = true,
        PersonOfContact = personOfContact,
        ContactPhoneNumber = contactPhoneNumber,
      });
      db.SaveChanges();
    }

    internal static void DisplayAllBands()
    {
      var displayAll = db.Bands.OrderBy(Band => Band.Id);
      foreach (var b in displayAll)
      {
        Console.WriteLine($"{b.Id}: {b.Name}");
      }
    }

    public static void DisplayUnsigned()
    {
      var displayUnsigned = db.Bands.Where(b => b.IsSigned == false);
      foreach (var b in displayUnsigned)
      {
        Console.WriteLine($"{b.Id}: {b.Name}");
      }

    }

    internal static void DisplaySigned()
    {
      var displaySigned = db.Bands.Where(b => b.IsSigned == true);
      var orderById = displaySigned.OrderBy(b => b.Id);
      foreach (var b in orderById)
      {
        Console.WriteLine($"{b.Id}: {b.Name}");
      }
    }

    internal static void BandToRelease()
    {
      DisplayAllBands();
      Console.WriteLine("What band would you like to remove? Please enter the band id from the list above!");
      var userRemove = int.Parse(Console.ReadLine());
      var bToRemove = db.Bands.FirstOrDefault(b => b.Id == userRemove);
      if (bToRemove == null)
      {
        Console.WriteLine("That is not a valid option, please select a valid id number.");
        userRemove = int.Parse(Console.ReadLine());
        bToRemove = db.Bands.FirstOrDefault(b => b.Id == userRemove);

      }
      if (bToRemove != null)
      {
        bToRemove.IsSigned = false;
        db.SaveChanges();
      }
    }

    internal static void BandToResign()
    {
      DisplayUnsigned();
      Console.WriteLine("What band would you like to resign? Please enter the band id from the list above!");
      var userRemove = int.Parse(Console.ReadLine());
      var bToResign = db.Bands.FirstOrDefault(b => b.IsSigned == false);
      if (bToResign == null)
      {
        Console.WriteLine("That is not a valid option, please select a valid id number.");
        userRemove = int.Parse(Console.ReadLine());
        bToResign = db.Bands.FirstOrDefault(b => b.IsSigned == false);

      }
      if (bToResign != null)
      {
        bToResign.IsSigned = true;
        db.SaveChanges();
      }
    }

    internal static void ProduceAlbum()
    {
      DisplaySigned();
      Console.WriteLine("What band would you like to produce an album for today? Please enter the band id from the list above!");
      var userChoice = int.Parse(Console.ReadLine());
      Console.WriteLine($"What is the title for the album?");
      var title = Console.ReadLine();
      //   var isExplicit = tryParse(Console.ReadLine())
      Console.WriteLine("When was the release date?");
      //   var releaseDate = 
      Console.WriteLine("What songs are on the album? Please separate by commas and then press enter!");
      //   var songs = 


      db.Bands.Add(new Album
      {
        Title = title,
        IsExplicit = isExplicit,
        ReleaseDate = releaseDate,
        Songs = songs,
        BandId = userChoice,
      });
      db.SaveChanges();
    }
  }
}
