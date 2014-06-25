//
//
//
//
//
namespace StefanApfel.Learning.AlgorithemDataStructures
{
  using System;
  using System.Collections.Generic;

  // ===================================================================================================
  /// <summary></summary>
  // ===================================================================================================
  internal sealed class ChapterMenu : IDisposable
  {
    // -------------------------------------------------------------------------------------------------
    /// <summary></summary>
    // -------------------------------------------------------------------------------------------------
    private List<Chapter> Chapters
    {
      get;
      set;
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary></summary>
    // -------------------------------------------------------------------------------------------------
    public ChapterMenu()
    {
      Console.OutputEncoding = System.Text.Encoding.Unicode;
      Chapters = new List<Chapter>();
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary></summary>
    // -------------------------------------------------------------------------------------------------
    internal void Add(String chapterName, params IChapterUnit[] units)
    {
      Chapters.Add(new Chapter(chapterName, units));
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary></summary>
    // -------------------------------------------------------------------------------------------------
    internal void Run()
    {
      //
      ShowChapters();
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary></summary>
    // -------------------------------------------------------------------------------------------------
    private void ShowChapters()
    {
      do
      {
        Console.Clear();
        Console.WriteLine("\nKapitelübersicht\n");
        Console.WriteLine(new String('═', Console.BufferWidth));

        for (var index = 0; index < Chapters.Count; index++)
        {
          var chapter = Chapters[index];
          Console.WriteLine("{0} - {1}", (index + 1).ToString().PadLeft(3, ' '), chapter.Name);
        }

        Console.WriteLine("\n");
      }
      while(SelectChapter(Chapters));
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary></summary>
    // -------------------------------------------------------------------------------------------------
    private void ShowUnits(Chapter chapter)
    {
      do
      {
        Console.Clear();
        Console.WriteLine("\nKapitel {0}\n", chapter.Name);
        Console.WriteLine(new String('═', Console.BufferWidth));

        for (var index = 0; index < chapter.Units.Count; index++)
        {
          var unit = chapter.Units[index];
          Console.WriteLine("{0} - {1}", (index + 1).ToString().PadLeft(3, ' '), unit.Name);
        }

        Console.WriteLine("\n");
      }
      while (SelectUnit(chapter.Units));
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary></summary>
    // -------------------------------------------------------------------------------------------------
    private Boolean SelectChapter(IReadOnlyList<Chapter> chapters)
    {
      while (true)
      {
        Console.Write("\rWählen Sie ein Kapitel: ");
        AddEscapeNotice("Beenden");
       
        var consoleKey = Console.ReadKey().Key;
        if (consoleKey == ConsoleKey.Escape)
        {
          return false;
        }

        var keyNumericValue = (Int32)consoleKey;
        if (keyNumericValue <= 48 || keyNumericValue > 48 + chapters.Count)
        {
          continue;
        }

        var chapterIndex = keyNumericValue -49;
        ShowUnits(chapters[chapterIndex]);
        
        return true;
      }
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary></summary>
    // -------------------------------------------------------------------------------------------------
    private Boolean SelectUnit(IReadOnlyList<IChapterUnit> units)
    {
      while (true)
      {
        Console.Write("\rWählen Sie eine Unit: ");
        AddEscapeNotice("Hauptmenü");

        var consoleKey = Console.ReadKey().Key;
        if (consoleKey == ConsoleKey.Escape)
        {
          return false;
        }

        var keyNumericValue = (Int32)consoleKey;
        if (keyNumericValue <= 48 || keyNumericValue > 48 + units.Count)
        {
          continue;
        }

        var unitIndex = keyNumericValue - 49;
        RunUnit(units[unitIndex]);

        return true;
      }
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary></summary>
    // -------------------------------------------------------------------------------------------------
    private void RunUnit(IChapterUnit unit)
    {
      try
      {
        Console.Clear();
        Console.WriteLine("\nUnit {0}\n", unit.Name);
        Console.WriteLine(new String('═', Console.BufferWidth));

        unit.Run();
      }
      catch(Exception ex)
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(ex.Message);
        Console.ResetColor();
      }
      Console.WriteLine("\n\nDrücken sie eine Taste um zum Menu zurückzukehren.");
      Console.ReadKey();
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary></summary>
    // -------------------------------------------------------------------------------------------------
    private void AddEscapeNotice(String target)
    {
      var left = Console.CursorLeft;
      Console.SetCursorPosition(0, Console.CursorTop + 1);
      Console.Write("(ESC zum {0})", target);
      Console.SetCursorPosition(left, Console.CursorTop - 1);
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary></summary>
    // -------------------------------------------------------------------------------------------------
    void IDisposable.Dispose() { }

    // =================================================================================================
    /// <summary></summary>
    // =================================================================================================
    private class Chapter
    {
      #region Member
      // -----------------------------------------------------------------------------------------------
      /// <summary></summary>
      // -----------------------------------------------------------------------------------------------
      internal String Name
      {
        get;
        private set;
      }

      // -----------------------------------------------------------------------------------------------
      /// <summary></summary>
      // -----------------------------------------------------------------------------------------------
      internal List<IChapterUnit> Units
      {
        get;
        private set;
      }

      // -----------------------------------------------------------------------------------------------
      /// <summary></summary>
      // -----------------------------------------------------------------------------------------------
      internal Chapter(String chapterName, params IChapterUnit[] units)
      {
        Name = chapterName;
        Units = new List<IChapterUnit>(units);
      }
      #endregion
    }
  }

  // ===================================================================================================
  /// <summary></summary>
  // ===================================================================================================
  internal interface IChapterUnit
  {
    String Name { get; }
    void Run();
  }
}
