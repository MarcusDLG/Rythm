using System;
using Rythm.Models;
using System.Linq;
using ConsoleTools;

namespace Rythm
{
  class Program
  {

    static void Main(string[] args)
    {
      var subMenu = new ConsoleMenu(args, level: 1)
        .Add("View All Bands", () => BandTracker.DisplayAllBands())
        .Add("View All Signed Bands", () => BandTracker.DisplaySigned())
        .Add("View All Unsigned Bands", () => BandTracker.DisplayUnsigned())
        .Add("View All Albums by Release Date", () => BandTracker.DisplayAllAlbums())
        .Add("View Albums by Band", () => BandTracker.DisplayByBand())
        .Add("View Specific Album", () => BandTracker.DisplaySpecific())
        .Add("Sub_Close", ConsoleMenu.Close)
        .Add("Sub_Exit", () => Environment.Exit(0))
        .Configure(config =>
        {
          config.Selector = "--> ";
          config.EnableFilter = true;
          config.Title = "Submenu";
          config.EnableBreadcrumb = true;
          config.WriteBreadcrumbAction = titles => Console.WriteLine(string.Join(" / ", titles));
        });

      var menu = new ConsoleMenu(args, level: 0)
        .Add("View", subMenu.Show)
        .Add("Add a Band", () => BandTracker.AddNewBand())
        .Add("Release a Band", () => BandTracker.BandToRelease())
        .Add("Resign a Band", () => BandTracker.BandToResign())
        .Add("Produce an Album", () => BandTracker.BandToRelease())
        .Add("Produce an Album", () => BandTracker.ProduceAlbum())
        // .Add("Close", ConsoleMenu.Close)
        .Add("Exit", () => Environment.Exit(0))
        .Configure(config =>
        {
          config.Selector = "--> ";
          config.EnableFilter = true;
          config.Title = "Main menu";
          config.EnableWriteTitle = true;
          config.EnableBreadcrumb = true;
        });

      menu.Show();
    }


    // var isRunning = true;
    // while (isRunning)
    // {

    //   // var = new DatabaseContext();


    //   Console.WriteLine("What would you like to do?");
    //   Console.WriteLine("(VIEW), (ADD), (RELEASE) Band, (RESIGN) a band, (PRODUCE) new album");
    //   var userInput = Console.ReadLine().ToLower();
    //   if (userInput == "view")
    //   {
    //     Console.WriteLine("Would you like to?");
    //     Console.WriteLine("VIEW: All (BANDS), (SIGNED), (UNSIGNED) OR All (ALBUMS), ALBUMS (BY) BAND, (SPECIFIC) ALBUM");
    //     userInput = Console.ReadLine().ToLower();
    //     if (userInput == "bands")
    //     {
    //       BandTracker.DisplayAllBands();
    //     }
    //     if (userInput == "signed")
    //     {
    //       BandTracker.DisplaySigned();
    //     }
    //     if (userInput == "unsigned")
    //     {
    //       BandTracker.DisplayUnsigned();
    //     }
    //     if (userInput == "albums")
    //     {
    //       BandTracker.DisplayAllAlbums();
    //     }
    //     if (userInput == "by")
    //     {
    //       BandTracker.DisplayByBand();
    //     }
    //     if (userInput == "specific")
    //     {
    //       BandTracker.DisplaySpecific();
    //     }
    //   }
    //   if (userInput == "add")
    //   {

    //     BandTracker.AddNewBand();
    //   }
    //   if (userInput == "release")
    //   {
    //     BandTracker.BandToRelease();
    //   }
    //   if (userInput == "resign")
    //   {
    //     BandTracker.BandToResign();

    //   }
    //   if (userInput == "produce")
    //   {
    //     BandTracker.ProduceAlbum();
    //   }
    //   else if (userInput == "quit")
    //   {
    //     isRunning = false;
    //   }
    // }
  }
}




