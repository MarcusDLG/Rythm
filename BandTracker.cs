using System;
using System.Linq;
using Rythm.Models;

namespace Rythm
{
  public class BandTracker
  {
    public static DatabaseContext db { get; set; } = new DatabaseContext();
    internal static void AddNewBand()
    {
      Console.WriteLine("What is the name of the band that you would like to sign?");
      var name = Console.ReadLine();
      Console.WriteLine($"Where is {name} from? ");
      var countryOfOrigin = Console.ReadLine();
      Console.WriteLine($"How many people are in {name}");
      var numberOfMembers = Console.ReadLine();
      Console.WriteLine($"What is {name}'s website?");
      var website = Console.ReadLine();
      Console.WriteLine($"What style of music does {name} play?");
      var style = Console.ReadLine();
      Console.WriteLine("Who is the main contact for the band?");
      var personOfContact = Console.ReadLine();
      Console.WriteLine("What is their phone number?");
      var contactPhoneNumber = Console.ReadLine();
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
      Console.WriteLine("Press enter to continue.");
      Console.ReadKey();
    }

    public static void DisplayUnsigned()
    {
      var displayUnsigned = db.Bands.Where(b => b.IsSigned == false);
      var orderedUnsigned = displayUnsigned.OrderBy(b => b.Id);
      foreach (var b in orderedUnsigned)
      {
        Console.WriteLine($"{b.Id}: {b.Name}");
      }
      Console.WriteLine("Press enter to continue.");
      Console.ReadKey();


    }

    internal static void DisplayAllAlbums()
    {
      var displayAll = db.Albums.OrderBy(Album => Album.ReleaseDate);
      foreach (var b in displayAll)
      {
        Console.WriteLine($"{b.Id}: {b.Title} was released on {b.ReleaseDate}. ");
      }
      Console.WriteLine("Press enter to continue.");
      Console.ReadKey();
    }

    internal static void DisplaySigned()
    {
      var displaySigned = db.Bands.Where(b => b.IsSigned == true);
      var orderById = displaySigned.OrderBy(b => b.Id);
      foreach (var b in orderById)
      {
        Console.WriteLine($"{b.Id}: {b.Name}");
      }
      Console.WriteLine("Press enter to continue.");
      Console.ReadKey();
    }

    internal static void DisplaySpecific()
    {
      DisplayAllAlbums();
      Console.WriteLine("Please select the Id of the Album you'd like to view");
      var userChoice = int.Parse(Console.ReadLine());
      var albumToView = db.Songs.Where(a => a.AlbumId == userChoice);
      foreach (var s in albumToView)
      {
        Console.WriteLine($"{s.Title}: has a length of {s.Length} a genre of {s.Genre}");
        Console.WriteLine($"and has the following lyrics: {s.Lyrics}");
      }
      Console.WriteLine("Press enter to continue.");
      Console.ReadKey();

    }

    internal static void DisplayByBand()
    {
      DisplayAllBands();
      Console.WriteLine("Please select the Id of the Band whose albums you'd like to view!");
      var userChoice = int.Parse(Console.ReadLine());
      var userChoiceS = db.Bands.FirstOrDefault(b => b.Id == userChoice);
      var albums = userChoiceS.Albums;
      foreach (var a in albums)
      {
        Console.WriteLine($"{a.Title}");
      }
      Console.WriteLine("Press enter to continue.");
      Console.ReadKey();

    }

    internal static void BandToRelease()
    {
      DisplaySigned();
      Console.WriteLine("What band would you like to release? Please enter the band id from the list above!");
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
      var bandId = int.Parse(Console.ReadLine());
      Console.WriteLine($"What is the title for the album?");
      var title = Console.ReadLine();
      Console.WriteLine("Does it have explicit content, yes or no?");
      bool explicitContent = false;
      var explicitContentQ = Console.ReadLine().ToLower();
      if (explicitContentQ == "yes")
      {
        explicitContent = true;
      }

      var album = new Album
      {
        BandId = bandId,
        Title = title,
        IsExplicit = explicitContent,
        ReleaseDate = DateTime.Now
      };

      db.Albums.Add(album);
      db.SaveChanges();

      var albumId = album.Id;


      AddNewSong(albumId, album);
    }


    public static void AddNewSong(int albumId, Album album)
    {
      Console.WriteLine("How many songs are on the album?");
      var songCount = int.Parse(Console.ReadLine());
      for (var i = 0; i < songCount; i++)
      {
        Console.WriteLine("what is the name of the song?");
        var title = Console.ReadLine();
        Console.WriteLine("what are the lyrics");
        var lyrics = Console.ReadLine();
        Console.WriteLine("what is the length?");
        var length = Console.ReadLine();
        Console.WriteLine("what is the genre");
        var genre = Console.ReadLine();
        var song = new Song()
        {
          AlbumId = albumId,
          Title = title,
          Lyrics = lyrics,
          Length = length,
          Genre = genre,

        };
        album.Songs.Add(song);
        db.Songs.Add(song);
        db.SaveChanges();
      }
    }
  }
}

