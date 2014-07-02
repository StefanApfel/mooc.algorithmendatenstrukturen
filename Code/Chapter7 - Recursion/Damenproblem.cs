//
//
//
//
//
namespace StefanApfel.Learning.AlgorithemDataStructures.Recursion
{
  using AlgoTools;
  using System;

  // ===================================================================================================
  /// <summary>Implementiert einen Rekursiven Algorithmus nach Hausaufgabe 3 von Kapitel 7 des Iversity 
  /// MOOCs Algorithmen und Datenstrukturen.</summary>
  // ===================================================================================================
  public sealed class Damenproblem
  {
    // -------------------------------------------------------------------------------------------------
    /// <summary>Führt die Aufgabe aus.</summary>
    // -------------------------------------------------------------------------------------------------
    public static void Main(String[] args)
    {
      // Initialisiere und deklariere Spielfeld
      Boolean[,] grid = new Boolean[8,8];

      // Versuche Damenproblem zu lösen, falls es möglich ist, wird das Ergebnis ausgegeben...
      if (TrySolveDameProblem(grid, 8))
      {
        PrintResult(grid);
      }
      else
      {
        // ... Ansonsten gebe Fehlermeldung aus...
        IO.PrintLine("Eine Lösung konnte nicht gefunden werden. Das Damenproblem für die Kantelänge 8 " +
                     "ist aber lösbar, was bedeutet, dass Ihr Algorithmus noch nicht richtig " +
                     "funktioniert.");
      }
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary>Prüft ob an dieser Stelle eine Dame gesetztw erden kann.</summary>
    /// <param name="grid">Das Schachbrett als boolisches Array.</param>
    /// <param name="missingDames">Zähler der fehlenden Damen.</param>
    /// <remarks>Jeder Methodenaufruf sollte versuchen genau eine Dame auf dem Feld zu platzieren ohne 
    /// gegen die Regeln zu verstoßen. Suchen Sie dafür eine noch freies Feld, das "okay" ist und 
    /// platzieren Sie dort eine Dame. 
    /// 
    /// Starten Sie nun die Rekursion. Rufen Sie die Methode TrySolveDameProblem wieder auf, jedoch muss 
    /// ja jetzt eine Dame weniger gesetzt werden. Der Aufruf der Methode wird Ihnen true oder false 
    /// zurückliefern. Im Falle von false kann offenbar keine Lösung gefunden werden, wenn Sie die Dame 
    /// dort belassen wo Sie sie platziert haben. Sie müssen die Dame, die Sie gerade gesetzt haben, 
    /// also wieder entfernen die nächste mögliche Position genauso "ausprobieren". 
    /// 
    /// Wenn Sie selbst keine Position mehr finden können, weil alle Positionen zum Rückgabewert false 
    /// des rekursiven Methodenaufruf geführt haben, dann liefern Sie selbst false zurück. true, also 
    /// die Meldung, dass das Problem gelöst ist, können Sie in genau zwei Fällen zurückgeben: Entweder 
    /// wenn der Parameter missingDames 0 ist - dann haben die vorherigen Aufrufe das Problem offenbar 
    /// gelöst - oder wenn Sie als Rückgabewert eines rekursiven Aufrufs true erhalten, denn dann melden 
    /// quasi die nachfolgenden rekursiven aufrufe, dass das Problem gelöst werden konnte.</remarks>
    // -------------------------------------------------------------------------------------------------
    private static Boolean TrySolveDameProblem(Boolean[,] grid, Int32 missingDames)
    {
      // ----------------------------------------------
      // Fügen Sie hier Ihre Lösung ein.
      // ----------------------------------------------
      if (missingDames <= 0)
      {
        return true; 
      }

      var rowCount = grid.GetLength(0);
      var columnCount = grid.GetLength(1);

      //Durchlaufe das Brett und suche ein freies und erlaubtes Feld
      for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
      {
        for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
        {
          // Prüft ob der Wert bereits gesetzt wurde...
          if (grid[rowIndex,columnIndex])
          {
            continue;
          }

          // Prüft ob an dieser Zellpostion eine Dame stehen kann...
          if (ValidateCell (grid, rowIndex, columnIndex))
          {
            grid[rowIndex,columnIndex] = true;  
            
            // Rufe Methode rekursiv auf im die nächste Dame zu testen.
            if (TrySolveDameProblem(grid, missingDames - 1))
            {
              return true;
            }
            else
            {
              grid[rowIndex,columnIndex] = false;
            }
          }

        }
      }
      return false;
    }

    #region Hilfsmethoden (Vorgegeben aber angepasst)
    // -------------------------------------------------------------------------------------------------
    /// <summary>Prüft ob an dieser Stelle eine Dame platziert werden kann.</summary>
    /// <param name="grid">Das Schachbrett.</param>
    /// <param name="dameRow">Aktuelle Reihe in der die Dame stehen soll.</param>
    /// <param name="dameColumn">Aktuelle Spalte in der die Dame stehen soll.</param>
    /// <returns>Gibt zurück ob an der gegebenen Position eine Dame stehen kann.</returns>
    // -------------------------------------------------------------------------------------------------
    private static Boolean ValidateCell(Boolean[,] grid, Int32 dameRow, Int32 dameColumn)
    {
      var rowCount = grid.GetLength(0);

      // Teste ob eine Dame in derselben Spalte oder Zeile gibt, aflls ja gibt die Methode false zurück.
      for (Int32 rowIndex = 0; rowIndex < rowCount; rowIndex++)
      {
        if (grid[dameRow,rowIndex] || grid[rowIndex,dameColumn])
        {
          return false;
        }
      }

      // Teste Diagonale nach rechts unten
      for (Int32 z = dameRow + 1, s = dameColumn + 1; z < rowCount && s < rowCount; z++, s++)
      {
        if (grid[z,s])
        {
          return false;
        }
      }

      // Teste Diagonale nach links oben
      for (Int32 z = dameRow - 1, s = dameColumn - 1; z >= 0 && s >= 0; z--, s--)
      {
        if (grid[z,s])
        {
          return false;
        }
      }

      // Teste Diagonale nach links unten
      for (Int32 z = dameRow + 1, s = dameColumn - 1; z < rowCount && s >= 0; z++, s--)
      {
        if (grid[z,s])
        {
          return false;
        }
      }

      //teste Diagonale nach rechts oben
      for (Int32 z = dameRow - 1, s = dameColumn + 1; z >= 0 && s < rowCount; z--, s++)
      {
        if (grid[z,s])
        { 
        return false;
        } 
      }

      // Wenn in der Zeile, Spalte oder den Diagonalen keine Dame gefunden, ist das Feld gültig.
      return true;
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary>Gibt das Ergebnis des Feld-Checks aus.</summary>
    /// <param name="grid">Das Schachbrett as mehrdimensionales Boolen Array.</param>
    // -------------------------------------------------------------------------------------------------
    private static void PrintResult(Boolean[,] grid)
    {
      var rowCount = grid.GetLength(0);
      var columnCount = grid.GetLength(1);

      IO.Print("   ");
      for (var headerIndex = 0; headerIndex < rowCount; headerIndex++)
      {
        IO.Print(((Char)('a' + headerIndex)) + " ");
      }

      IO.PrintLine();

      IO.Print("  ");
      for (int headerIndex = 0; headerIndex < rowCount; headerIndex++)
      {
        IO.Print("+");
        IO.Print("-");
      }

      IO.PrintLine("+");

      for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
      {
        IO.Print((8 - rowIndex) + " ");
        for (var columnIndex = 0; columnIndex < columnCount; columnIndex++)
        {
          IO.Print("|");
          IO.Print(grid[rowIndex,columnIndex] ? "D" : " ");
        }
        IO.PrintLine("|");
        IO.Print("  ");

        for (var columnIndex = 0; columnIndex < columnCount; columnIndex++)
        {
          IO.Print("+");
          IO.Print("-");
        }
        IO.PrintLine("+");
      }

      IO.Print("\n\n");

      // Ausgabe als Liste, durchlaufe wieder das komplette Grid über die Zeilen und Spalten Indizes und
      // gebe die Position aus, wenn an der Position eine Dame platzier werden kann.
      int index = 0;
      for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
      {
        for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
        {
          if (grid[rowIndex,columnIndex])
          {
            IO.Print(((Char)('a' + columnIndex)) + "" + (8 - rowIndex));
            index++;

            //Komma beim letzten Element auslassen
            if (index < rowCount)
            {
              IO.Print(",");
            }
          }
        }
      }

      //Zeilumbruch am Ende
      IO.PrintLine(); 
    }
    #endregion
  }
}
