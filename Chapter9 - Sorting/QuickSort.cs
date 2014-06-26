//
//
//
//
//
namespace StefanApfel.Learning.AlgorithemDataStructures.Sorting
{
  using System;

  // ===================================================================================================
  /// <summary>Implementiert einen QuickSort Algorithmus zum Sortieren von Daten nach Kapitel 9.4 des 
  /// Iversity MOOCs Algorithmen und Datenstrukturen.</summary>
  // ===================================================================================================
  public sealed class QuickSort : SortingUnit
  {
    // -------------------------------------------------------------------------------------------------
    /// <summary>Gibt den Namen der Unit zurück.</summary>
    // -------------------------------------------------------------------------------------------------
    public override String Name
    {
      get { return "Quick Sort"; }
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary>Implementierung für Quick Sort.</summary>
    /// <param name="values">Array mit Werten die sortiert werden sollen.</param>
    // -------------------------------------------------------------------------------------------------
    public static void Sort(Int32[] values)
    {
      Sort(values, 0, values.Length-1);
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary>Sortiert das übergebene Werte-Array</summary>
    /// <param name="values">Werte Array</param>
    /// <param name="start">Beginn des Array-Bereichs.</param>
    /// <param name="end">Ende des Array-Bereiches</param>
    // -------------------------------------------------------------------------------------------------
    private static void Sort(Int32[] values, Int32 start, Int32 end)
    {
      if (values.Length < 2)
      {
        return;
      }

      // Ermittle Mitte
      var pivotIndex = (start + end) / 2;
      var pivotValue = values[pivotIndex];

      var leftIndex = start;
      var rightIndex = end;

      do
      {
        while (values[leftIndex] < pivotValue) { leftIndex++; }
        while (values[rightIndex] > pivotValue) { rightIndex--; }

        if(leftIndex <= rightIndex)
        {
          var temp = values[leftIndex];
          values[leftIndex] = values[rightIndex];
          values[rightIndex] = temp;

          leftIndex++;
          rightIndex--;
        }
      }
      while (leftIndex <= rightIndex);

      if(start < rightIndex) { Sort(values, start, rightIndex); }
      if(leftIndex < end) { Sort(values, leftIndex, end); }
    }
  }
}
