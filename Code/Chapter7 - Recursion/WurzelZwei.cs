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
  /// <summary>Implementiert einen Rekursiven Algorithmus nach Hausaufgabe 1 von Kapitel 7 des Iversity 
  /// MOOCs Algorithmen und Datenstrukturen.</summary>
  // ===================================================================================================
  public sealed class WurzelZwei
  {
    // -------------------------------------------------------------------------------------------------
    /// <summary>Führt die Aufgabe aus.</summary>
    // -------------------------------------------------------------------------------------------------
    public static void Main(String[] args)
    {
      var value = IO.ReadInt("Durchläufe bei denen die Quadratwurzel gezogen werden soll: ");
      var result = Calculate(value);

      IO.PrintLine("Das Ergebnis nach {0} Durchläufen lautet: {1}", value, result.ToString("0.0###"));
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary>Zieht die Quadratwurzel vom aktuellen Wert.</summary>
    // -------------------------------------------------------------------------------------------------
    public static Double Calculate(Double value)
    {
      if(value == 0)
      {
        return 1;
      }

      value = Calculate(value - 1);
      return 0.5 * (value + 2 / value);
    }
  }
}
