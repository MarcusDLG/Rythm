using System;
using Rythm.Models;
using System.Linq;

namespace Rythm
{
  class Program
  {

    static void Main(string[] args)
    {
      Console.WriteLine("Welcome to your band management app!");
      var isRunning = true;
      while (isRunning)
      {

        // var = new DatabaseContext();

        Console.WriteLine("What would you like to do?");
        Console.WriteLine("(VIEW), (ADD), (RELEASE) Band, (RESIGN) a band, (PRODUCE) new album");
        var userInput = Console.ReadLine().ToLower();
        if (userInput == "view")
        {
          Console.WriteLine("Would you like to?");
          Console.WriteLine("VIEW: All (BANDS), (SIGNED), (UNSIGNED) OR All (ALBUMS), ALBUMS (BY) BAND, (SPECIFIC) ALBUM");
          userInput = Console.ReadLine().ToLower();
          if (userInput == "bands")
          {
            BandTracker.DisplayAllBands();
          }
          if (userInput == "signed")
          {
            BandTracker.DisplaySigned();
          }
          if (userInput == "unsigned")
          {
            BandTracker.DisplayUnsigned();
          }
          if (userInput == "albums")
          {
            BandTracker.DisplayAllAlbums();
          }
          if (userInput == "by")
          {
            BandTracker.DisplayByBand();
          }
          if (userInput == "specific")
          {
            BandTracker.DisplaySpecific();
          }
        }
        if (userInput == "add")
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

          BandTracker.AddNewBand(name, countryOfOrigin, numberOfMembers, website, style, personOfContact, contactPhoneNumber);
        }
        if (userInput == "release")
        {
          BandTracker.BandToRelease();
        }
        if (userInput == "resign")
        {
          BandTracker.BandToResign();

        }
        if (userInput == "produce")
        {
          BandTracker.ProduceAlbum();
        }
        else if (userInput == "quit")
        {
          isRunning = false;
        }
      }
    }
  }

}


