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
  /// Kapitel 7.2 des Iversity MOOCs Algorithmen und Datenstrukturen.</summary>
  // ===================================================================================================
  public sealed class Fibonacci
  {
    // -------------------------------------------------------------------------------------------------
    /// <summary>Führt die Aufgabe aus.</summary>
    // -------------------------------------------------------------------------------------------------
    public static void Main(String[] args)
    {
      var value = IO.ReadInt("Geben Sie die Anzahl der Durchläufe an: ");
      var result = Calculate(value);

      IO.PrintLine("Das Ergebnis nach {0} Durchläufen lautet: {1}", value, result);
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary>Errechnet einen Fibonacci-Wert in einem rekusiven Aufruf.</summary>
    // -------------------------------------------------------------------------------------------------
    public static Int32 Calculate(Int32 value)
    {
      if(value <= 1)
      {
        return 1;
      }

      // Ruft sich selbst immer wieder auf bis der Wert 1 oder kleiner ist.
      return Calculate(value - 1) + Calculate(value - 2);
    }
  }
}
