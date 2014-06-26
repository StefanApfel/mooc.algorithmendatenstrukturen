//
//
//
//
//
namespace StefanApfel.Learning.AlgorithemDataStructures.Sorting
{
  using System;

  // ===================================================================================================
  /// <summary>Implementiert einen MergeSort Algorithmus zum Sortieren von Daten nach Kapitel 9.3 des 
  /// Iversity MOOCs Algorithmen und Datenstrukturen.</summary>
  /// <remarks>Beim Merge Algorithmus wird nach dem Divide&Conquer Prinzip vorgegangen. Im Grunde werden
  /// die kompletten Daten auf sortierte Pärchen reduziert und beim Mergen mit dem nächsten Pärchen in
  /// die Endgültige Reihenfolge gebracht.</remarks>
  // ===================================================================================================
  public sealed class MergeSort : SortingUnit
  {
    // -------------------------------------------------------------------------------------------------
    /// <summary>Gibt den Namen der Unit zurück.</summary>
    // -------------------------------------------------------------------------------------------------
    public override String Name
    {
      get { return "Merge Sort"; }
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary>Implementierung für Selection Sort.</summary>
    /// <param name="values">Array mit Werten die sortiert werden sollen.</param>
    // -------------------------------------------------------------------------------------------------
    public static void Sort(Int32[] values)
    {
      if(values.Length < 2)
      {
        return;
      }

      var pivot = values.Length / 2;

      var leftValues = new Int32[pivot];
      for (var index = 0; index < pivot; index++)
        leftValues[index] = values[index];

      var rightValues = new Int32[values.Length - pivot];
      for (var index = 0; index < rightValues.Length; index++)
        rightValues[index] = values[pivot + index - 1];

      // Sortiere den Inhalt des rechen und linken Werte Arrays erneut.
      Sort(leftValues);
      Sort(rightValues);

      // Dann merge die beiden Arrays zu dem ZielArray
      Merge(values, leftValues, rightValues);
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary>Merged das linke und rechte Array in das Ziel Array</summary>
    /// <param name="target">Ziel Array</param>
    /// <param name="leftValues">Linkes Werte Array</param>
    /// <param name="rightValues">Rechtes Werte Array</param>
    // -------------------------------------------------------------------------------------------------
    private static void Merge(Int32[] target, Int32[] leftValues, Int32[] rightValues)
    {
      var leftIndex = 0;
      var rightIndex = 0;
      var targetIndex = 0;

      // Läuft nun solange durch das linke und rechte Werte Array bis eines davon am Ende angelangt ist.
      // Der jeweils kleinere Wert (aus links und rechts) wird dem Zielarray hinzugefügt. 
      for (targetIndex = 0; leftIndex < leftValues.Length && rightIndex < rightValues.Length; targetIndex++)
      {
        target[targetIndex] = (leftValues[leftIndex] < rightValues[rightIndex]) ? leftValues[leftIndex++]
                                                                                : rightValues[rightIndex++];
      }

      // Füge die restlichen Elemente ins Zielarray.
      while (leftIndex < leftValues.Length) target[targetIndex++] = leftValues[leftIndex++];
      while (rightIndex < rightValues.Length) target[targetIndex++] = rightValues[rightIndex++];
    }
  }
}
