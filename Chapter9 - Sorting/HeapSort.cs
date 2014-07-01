//
//
//
//
//
namespace StefanApfel.Learning.AlgorithemDataStructures.Sorting
{
  using System;

  // ===================================================================================================
  /// <summary>Implementiert einen HeapSort Algorithmus zum Sortieren von Daten nach Kapitel 9.5 des 
  /// Iversity MOOCs Algorithmen und Datenstrukturen.</summary>
  // ===================================================================================================
  public sealed class HeapSort : SortingUnit
  {
    // -------------------------------------------------------------------------------------------------
    /// <summary>Gibt den Namen der Unit zurück.</summary>
    // -------------------------------------------------------------------------------------------------
    public override String Name
    {
      get { return "Heap Sort"; }
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary>Implementierung für Heap Sort.</summary>
    /// <param name="values">Array mit Werten die sortiert werden sollen.</param>
    // -------------------------------------------------------------------------------------------------
    public static void Sort(Int32[] values)
    {
      var valuesCount = values.Length;

      // Sortiert den hinteren Bereich des Arrays in absteigende Reihenfolge...
      for(var index = ((valuesCount-2)/2); index >= 0; index--)
      {
        UpdateHeap(values, index, valuesCount - 1);
      }

      // Durchläuft das Array von vorne nach hinten und fügt nach und nach auch die vordere Hälfte des
      // Des Arrays zur Sortierung hinzu.
      for(var index = valuesCount-1; index > 0; index--)
      {
        var firstNode = values[0];
        values[0] = values[index];
        values[index] = firstNode;

        UpdateHeap(values, 0, index - 1);
      }

      Array.Reverse(values);
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary>Aktualisert den Heap in dem es die Werte absteigend sortiert.</summary>
    /// <param name="values">Das Array mit den Werten.</param>
    /// <param name="startIndex">Index des ersten Elements des zu suchenden Bereiches.</param>
    /// <param name="endIndex">Index des letzten Elements.</param>
    // -------------------------------------------------------------------------------------------------
    private static void UpdateHeap(Int32[] values, Int32 startIndex, Int32 endIndex)
    {
      var currentIndex = startIndex;
      var rootValue = values[currentIndex];

      // Wandere nun durch das Array solange die Unterknoten sich im vorgegebenen Interval befinden und
      // solange der Child-Knoten Werte kleiner ist, als der Root-Knoten Wert. In diesem Fall werden die
      // Knoten ermittelt mit denen der Root-Knoten (welches der kleinest Wert sein soll) tauschen kann. 
      // Dabei rücken die kleineren Werte im Heap immer weiter nach oben...
      var childNodeIndex = GetSmallestChildIndex(values, currentIndex, endIndex);
      while(childNodeIndex <= endIndex && values[childNodeIndex] < rootValue)
      {
        values[currentIndex] = values[childNodeIndex];
        currentIndex = childNodeIndex;

        childNodeIndex = GetSmallestChildIndex(values, currentIndex, endIndex);
      }

      // Schließlich wird der Ursprungswert an die freie Stelle verschoben.
      values[currentIndex] = rootValue;
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary>Ermittelt den Knoten mit dem kleineren Wert und gibt dessen Index zurück.</summary>
    /// <param name="values">Array mit den Werten.</param>
    /// <param name="rootIndex">Der Start-Index des Suchbereiches</param>
    /// <param name="endIndex">Der End-Index des Suchbereiches</param>
    /// <returns>Den Index des kleineren Knoten Wertes.</returns>
    // -------------------------------------------------------------------------------------------------
    private static Int32 GetSmallestChildIndex(Int32[] values, Int32 rootIndex, Int32 endIndex)
    {
      // Da jeder Knoten (bis auf das letzte Knoten Level) zwei Unterknoten besitzt, kann der Index der
      // Unterknoten mit folgender Formel errechnet werden:
      var childNodeIndex = (2 * rootIndex) + 1;

      // Testet ob die childNodeIndex noch im Intervall ist und wenn der folgende Wert kleiner als der
      // aktuelle Child-Knoten, wird der Zeiger auf den Knoten mit dem kleineren Wert gesetzt.
      if (childNodeIndex < endIndex && values[childNodeIndex + 1] < values[childNodeIndex])
      {
        return childNodeIndex+1;
      }

      return childNodeIndex;
    }
  }
}
