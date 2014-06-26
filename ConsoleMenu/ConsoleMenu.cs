//
//
//
//
//
namespace System
{
  using System.Collections.Generic;

  // ===================================================================================================
  /// <summary>Die Klasse ConsoleMenu konstruiert ein einfaches hierachisches Menü welches aus Knoten
  /// und Commands besteht. Während Knoten weiter verschachtelt sein können, werden Commands ausgeführt.
  /// Die Klasse implementiert IDisposable um in usings verwendet werden zu könne.</summary>
  // ===================================================================================================
  public sealed class ConsoleMenu : IDisposable, IConsoleMenuNode
  {
    #region Eigenschaften
    // -------------------------------------------------------------------------------------------------
    /// <summary>Gibt die Items des Menüs zurück.</summary>
    // -------------------------------------------------------------------------------------------------
    public IList<IConsoleMenuItem> Items
    {
      get;
      private set;
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary>Gibt den Namen des Menüs zurück.</summary>
    // -------------------------------------------------------------------------------------------------
    public String Name
    {
      get;
      private set;
    }
    #endregion

    #region Konstruktor
    // -------------------------------------------------------------------------------------------------
    /// <summary>Erstellt eine neue Instanz der Klasse ConsoleMenu.</summary>
    /// <param name="title">Titel des Basis Menüs.</param>
    // -------------------------------------------------------------------------------------------------
    public ConsoleMenu(String title)
    {
      Console.OutputEncoding = System.Text.Encoding.Unicode;
      Items = new List<IConsoleMenuItem>();
      Name = title;
    }
    #endregion

    #region Methoden
    // -------------------------------------------------------------------------------------------------
    /// <summary>Zeigt das Menü an.</summary>
    // -------------------------------------------------------------------------------------------------
    public void Show()
    {
      ShowItems(this);
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary>Listet die Menüpunkte.</summary>
    /// <param name="rootNode">Aktuelelr Basis Knoten.</param>
    // -------------------------------------------------------------------------------------------------
    private void ShowItems(IConsoleMenuNode rootNode)
    {
      do
      {
        StartScreen(rootNode.Name);
        for (var index = 0; index < rootNode.Items.Count; index++)
        {
          var item = rootNode.Items[index];
          Console.WriteLine("{0} - {1}", (index + 1).ToString().PadLeft(3, ' '), item.Name);
        }

        Console.WriteLine("\n");
      }
      while (SelectItem(rootNode.Items as IReadOnlyList<IConsoleMenuItem>));
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary>Wählt einen Menüpunkt.</summary>
    /// <param name="items">Die zur Auswahl stehenden Menüpunkte.</param>
    /// <returns>true wenn das aktuelle Menü noch kativ ist, false wenn abgebrochen wurde.</returns>
    // -------------------------------------------------------------------------------------------------
    private Boolean SelectItem(IReadOnlyList<IConsoleMenuItem> items)
    {
      while (true)
      {
        Console.Write("\rWählen Sie einen Menüpunkt: ");
        WriteNotice("(ESC um zurückzukehren)");

        var consoleKey = Console.ReadKey().Key;
        if (consoleKey == ConsoleKey.Escape)
        {
          return false;
        }

        var keyNumericValue = (Int32)consoleKey;
        if (keyNumericValue <= 48 || keyNumericValue > 48 + items.Count)
        {
          continue;
        }

        var item = items[keyNumericValue - 49];
        if(item is IConsoleMenuNode)
        {
          ShowItems(item as IConsoleMenuNode);
        }
        else if(item is IConsoleMenuCommand)
        {
          RunCommand(item as IConsoleMenuCommand);
        }
        return true;
      }
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary>Führt das Command aus.</summary>
    /// <param name="command">Das Command das ausgeführtw erden soll.</param>
    // -------------------------------------------------------------------------------------------------
    private void RunCommand(IConsoleMenuCommand command)
    {
      try
      {
        StartScreen(command.Name);
        command.Run();
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
    /// <summary>Fügt einen Hinweis unter der aktellen Zeile hinzu.</summary>
    /// <param name="notice">Hinweistext.</param>
    // -------------------------------------------------------------------------------------------------
    private void WriteNotice(String notice)
    {
      var left = Console.CursorLeft;
      Console.SetCursorPosition(0, Console.CursorTop + 1);
      Console.Write(notice);
      Console.SetCursorPosition(left, Console.CursorTop - 1);
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary>Startet einen neuen Screen (Bildschirm-Maske) und schreibt den Header.</summary>
    /// <param name="title">Titel des Screens.</param>
    // -------------------------------------------------------------------------------------------------
    private void StartScreen(String title)
    {
      Console.Clear();
      Console.WriteLine("\n{0}\n", title);
      Console.WriteLine(new String('═', Console.BufferWidth));
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary>Disposed das Consolen Menü.</summary>
    // -------------------------------------------------------------------------------------------------
    void IDisposable.Dispose() { }
    #endregion

    // =================================================================================================
    /// <summary>Die Klasse ConsoleMenu.Node implementiert IConsoleMenuNode udn repräsentiert einen Menü
    /// Knoten der weitere Menüknoten oder ein ausfühbares Command besitzt.</summary>
    // =================================================================================================
    public sealed class Node : IConsoleMenuNode
    {
      #region Member
      // -----------------------------------------------------------------------------------------------
      /// <summary>Gibt den Namen des Knoten zurück.</summary>
      // -----------------------------------------------------------------------------------------------
      public String Name
      {
        get;
        private set;
      }

      // -----------------------------------------------------------------------------------------------
      /// <summary>Gibt die Items des Knoten zurück.</summary>
      // -----------------------------------------------------------------------------------------------
      public IList<IConsoleMenuItem> Items
      {
        get;
        private set;
      }

      // -----------------------------------------------------------------------------------------------
      /// <summary>Erstellt eine neue Instanz der Klasse ConsoleMenu.Node.</summary>
      /// <param name="nodeName">Name des Knoten.</param>
      /// <param name="items">Optionale vor initialzierung der Items.</param>
      // -----------------------------------------------------------------------------------------------
      internal Node(String nodeName, params IConsoleMenuItem[] items)
      {
        Name = nodeName;
        Items = new List<IConsoleMenuItem>(items);
      }
      #endregion
    }
  }

  // ===================================================================================================
  /// <summary>Definiert den Basis Contract für ein ConsoleMenuItem.</summary>
  // ===================================================================================================
  public interface IConsoleMenuItem
  {
    #region Member
    // -------------------------------------------------------------------------------------------------
    /// <summary>Gibt den Namen des Knoten zurück.</summary>
    // -------------------------------------------------------------------------------------------------
    String Name { get; }
    #endregion
  }

  // ===================================================================================================
  /// <summary>Definiert den Contract für ein ConsolenMenu Command.</summary>
  // ===================================================================================================
  public interface IConsoleMenuCommand : IConsoleMenuItem
  {
    #region Member
    // -------------------------------------------------------------------------------------------------
    /// <summary>Führt das Command aus.</summary>
    // -------------------------------------------------------------------------------------------------
    void Run();
    #endregion
  }

  // ===================================================================================================
  /// <summary>Definiert den Contract für einen ConsolenMenu Knoten.</summary>
  // ===================================================================================================
  public interface IConsoleMenuNode : IConsoleMenuItem
  {
    #region Member
    // -------------------------------------------------------------------------------------------------
    /// <summary>Gibt die Items des Knoten zurück.</summary>
    // -------------------------------------------------------------------------------------------------
    IList<IConsoleMenuItem> Items { get; }
    #endregion
  }
}
