//
//
//
//
//
namespace StefanApfel.Learning.AlgorithemDataStructures.Arrays
{
  using AlgoTools;
  using System;

  // ===================================================================================================
  /// <summary>Implementiert die Kapitel 5.6 des Iversity MOOCs Algorithmen und Datenstrukturen. Ziel 
  /// ist es durch eine lineare und eine binäre Suche bestimmte Daten in einem Array zu finden und
  /// auszugeben.</summary>
  // ===================================================================================================
  public sealed class Suche
  {
    // -------------------------------------------------------------------------------------------------
    /// <summary>Führt die Aufgabe aus.</summary>
    // -------------------------------------------------------------------------------------------------
    public static void Main(String[] args)
    {
      var values = IO.ReadInts("Bitte geben Sie eine Zahlenfolge ein (Leerzeichen getrennt):");
      var needle = IO.ReadInt("\nGeben Sie eine Zahl an die gesucht werden soll: ");
      
      FindValueLinear(values, needle);
      FindValueBinary(values, needle);
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary>Durchsucht ein Array linear nach einem Wert (von vorne bis hinten).</summary>
    /// <param name="values">Das Werte Array.</param>
    /// <param name="value">Der Wert der gesucht wird.</param>
    // -------------------------------------------------------------------------------------------------
    private static void FindValueLinear(Int32[] values, Int32 value)
    {
      for (var index = 1; index < values.Length; index++)
      {
        if (values[index] == value)
        {
          IO.PrintLine("Der Wert {0} ist an Position {1}.", value, index+1);
          return;
        }
      }
      IO.PrintLine("Der Wert {0} konnte nicht gefunden werden.", value);
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary>Durchsucht das Array mit einer anderen Herangehensweise. Hierbei wird geprüft ob der
    /// Wert größer oder kleiner des Mittelwerts eines Bereichs ist. Damit wird verhindert das das
    /// gesamte Array durchlaufen werden muss. Gegebenfalls sind mehrere Durchgänge nötig.</summary>
    // -------------------------------------------------------------------------------------------------
    private static void FindValueBinary(Int32[] values, Int32 value)
    {
      // Sortiere das Array...
      SortValues(values);

      var left = 0;
      var right = values.Length - 1;
      var pivot = (left + right) / 2;

      while (left <= right)
      {
        // Checke ob an der Pivot Stelle der gesuchte Wert ist...
        if (values[pivot] == value)
        {
          IO.PrintLine("Der Wert {0} ist an Position {1}.", value, pivot+1);
          return;
        }

        // Ist der Wert am Pivot-Punkt kleiner als der gesucht, wird der Pivot-Punkt um 1 nach rechts
        // verschoben, ist er größer, um 1 nach links.
        if (values[pivot] < value)
        {
          left = pivot + 1;
        }
        else
        {
          right = pivot - 1;
        }

        // Ermittle einen neuen Pivot-Punkt in der Mitte.
        pivot = (right + left) / 2; 
      }

      IO.PrintLine("Der Wert {0} konnte nicht gefunden werden.", value);
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary>Sortiere das übergebene Array.</summary>
    /// <param name="values">Das Werte Array.</param>
    // -------------------------------------------------------------------------------------------------
    private static void SortValues(Int32[] values)
    {
      IO.PrintLine("\nSortiere Array...");
      Array.Sort(values);

      IO.PrintLine("Neue Reihenfolge: {0}\n", String.Join(" ", values));
    }
  }
}
