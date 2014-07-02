//
//
//
//
//
namespace StefanApfel.Learning.AlgorithemDataStructures.Sorting
{
  using System;

  // ===================================================================================================
  /// <summary>Implementiert einen SelectionSort Algorithmus zum Sortieren von Daten nach Kapitel 9.1
  /// des Iversity MOOCs Algorithmen und Datenstrukturen.</summary>
  // ===================================================================================================
  public sealed class SelectionSort : SortingUnit<SelectionSort>
  {
    // -------------------------------------------------------------------------------------------------
    /// <summary>Implementierung für Selection Sort.</summary>
    /// <param name="values">Array mit Werten die sortiert werden sollen.</param>
    // -------------------------------------------------------------------------------------------------
    public static void Sort(Int32[] values)
    {
      for(var index = 0; index < values.Length; index++)
      {
        for(var comparerIndex = 0; comparerIndex < values.Length; comparerIndex++)
        {
          var current = values[comparerIndex];
          if(values[index] < current)
          {
            values[comparerIndex] = values[index];
            values[index] = current;
          }
        }
      }
    }
  }
}
