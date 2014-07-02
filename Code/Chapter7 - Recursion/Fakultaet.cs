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
  /// <summary>Implementiert einen Rekursiven Algorithmus zur Berechnung einer der Fakultät nach Kapitel 
  /// 7.1 des Iversity MOOCs Algorithmen und Datenstrukturen.</summary>
  // ===================================================================================================
  public sealed class Fakultaet
  {
    // -------------------------------------------------------------------------------------------------
    /// <summary>Führt die Aufgabe aus.</summary>
    // -------------------------------------------------------------------------------------------------
    public static void Main(String[] args)
    {
      var value = IO.ReadInt("Geben Sie eine Zahl an: ");
      var result = Calculate(value);

      IO.PrintLine("Das Ergebnis der Fakultät von {0} lautet: {1}", value, result);
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary>Errechnet die Fakultät in einem rekusiven Aufruf.</summary>
    // -------------------------------------------------------------------------------------------------
    private static Int32 Calculate(Int32 value)
    {
      if(value == 0)
      {
        return 1;
      }

      // Ruft sich selbst immer wieder auf bis der Wert 1 ist, dann wird die Rekursion gestoppt.
      return value * Calculate(value - 1);
    }
  }
}
