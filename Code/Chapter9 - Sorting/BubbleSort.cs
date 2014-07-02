//
//
//
//
//
namespace StefanApfel.Learning.AlgorithemDataStructures.Sorting
{
  using System;

  // ===================================================================================================
  /// <summary>Implementiert einen BubbleSort Algorithmus zum Sortieren von Daten nach Kapitel 9.2 des 
  /// Iversity MOOCs Algorithmen und Datenstrukturen.</summary>
  // ===================================================================================================
  public sealed class BubbleSort : SortingUnit<BubbleSort>
  {
    // -------------------------------------------------------------------------------------------------
    /// <summary>Implementierung für Bubble Sort.</summary>
    /// <param name="values">Array mit Werten die sortiert werden sollen.</param>
    // -------------------------------------------------------------------------------------------------
    public static void Sort(Int32[] values)
    {
      Boolean keepSorting = false;
      do
      {
        keepSorting = false;
        for(var index = 0; index < values.Length-1; index++)
        {
          var current = values[index];
          if (current > values[index + 1])
          {
            values[index] = values[index + 1];
            values[index + 1] = current;
            keepSorting = true;
          }
        }
      }
      while (keepSorting);
    }
  }
}
