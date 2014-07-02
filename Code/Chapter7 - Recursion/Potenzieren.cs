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
  /// <summary>Implementiert einen Rekursiven Algorithmus nach Kapitel 7.1 des Iversity MOOC Algorithmen 
  /// und Datenstrukturen welcher die Zahl 2 mit einem beliebigen Eingabewert potenziert.</summary>
  // ===================================================================================================
  public sealed class Potenzieren
  {
    // -------------------------------------------------------------------------------------------------
    /// <summary>Führt die Aufgabe aus.</summary>
    // -------------------------------------------------------------------------------------------------
    public static void Main(String[] args)
    {
      var value = IO.ReadInt("Geben Sie die Potenz die an 2 angewendet werden soll: ");
      var result = Calculate(value);

      IO.PrintLine("Das Ergebnis von 2^{0} lautet: {1}", value, result);
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary>Potenziert die gegebene Zahl in einem rekusiven Aufruf.</summary>
    // -------------------------------------------------------------------------------------------------
    public static Int32 Calculate(Int32 value)
    {
      if(value == 0)
      {
        return 1;
      }

      // Ruft sich selbst immer wieder auf bis der Wert 1 ist, dann wird die Rekursion gestoppt.
      return 2 * Calculate(value - 1);
    }
  }
}
