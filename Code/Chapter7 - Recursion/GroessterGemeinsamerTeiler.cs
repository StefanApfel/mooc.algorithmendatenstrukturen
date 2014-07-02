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
  /// <summary>Implementiert einen Rekursiven Algorithmus zur Berechnung einer Fibonaccifolge nach
  /// Kapitel 7.1 des Iversity MOOCs Algorithmen und Datenstrukturen.</summary>
  // ===================================================================================================
  public sealed class GroessterGemeinsamerTeiler
  {
    // -------------------------------------------------------------------------------------------------
    /// <summary>Führt die Aufgabe aus.</summary>
    // -------------------------------------------------------------------------------------------------
    public static void Main(String[] args)
    {
      var value1 = IO.ReadInt("Geben Sie die erste Zahl an: ");
      var value2 = IO.ReadInt("Geben Sie die zweite Zahl an: ");
      var result = Calculate(value1, value2);

      IO.PrintLine("Der größte gemeinesame Teiler von {0} und {1} ist {2}", value1, value2, result);
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary>Ermittelt den größten gemeinsamen Teiler in einem rekusiven Aufruf.</summary>
    // -------------------------------------------------------------------------------------------------
    public static Int32 Calculate(Int32 value1, Int32 value2)
    {
      if(value2 == 0)
      {
        return value1;
      }

      // Ruft sich selbst immer wieder auf solange Wert 2 nicht 0 ist, dann wird die Rekursion gestoppt.
      return Calculate(value2, value1 % value2);
    }
  }
}
