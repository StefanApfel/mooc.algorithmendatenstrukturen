//
//
//
//
//
namespace StefanApfel.Learning.AlgorithemDataStructures.Arrays
{
  using AlgoTools;
  using System;

  // ===================================================================================================
  /// <summary>Implementiert die Kapitel 5.4 des Iversity MOOCs Algorithmen und Datenstrukturen. 
  /// Ziel ist es in einem Boolean-Array, wessen Index eine Zahlenreihe repräsentiert, die Primzahlen zu
  /// makieren (bzw. true = Primzahl, ansonsten false).</summary>
  // ===================================================================================================
  public sealed class Primzahlen
  {
    // -------------------------------------------------------------------------------------------------
    /// <summary>Führt die Aufgabe aus.</summary>
    // -------------------------------------------------------------------------------------------------
    public static void Main(String[] args)
    {
      var length = IO.ReadInt("Länge der Zahlenreihe: ");
      var primeValues = new Boolean[length];

      // Setze alle Werte auf true, anschließend werden die Zahlen deren Vielfache im Array vorkommen
      // ausgesiebt (= false gesetzt).
      for (var index = 0; index < primeValues.Length; index++) { primeValues[index] = true; }

      // Suche nach Vielfachen von Primzahlen. Für jeden Wert (der noch nicht als geprüft wurde) werden
      // die weiteren Werte durchlaufen. Falls ein Vielfaches gefunden wurde wird diesen als keine
      // Primzahl makiert (false) und wird damit bei weiteren Prüfungen nicht mehr berücksichtigt.
      for (var index = 2; index < length; index++)
      {
        for (var multiple = index + index; primeValues[index] && multiple < length; multiple += index)
        {
          primeValues[multiple] = false;
        }
      }

      // Ausgabe...
      PrintResult(primeValues);
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary>Gibt die gefundenen Primzahlen aus.</summary>
    // -------------------------------------------------------------------------------------------------
    private static void PrintResult(Boolean[] primeValues)
    {
      IO.Print("Primzahlen zwischen 2 und {0}: ", primeValues.Length);
      for (var index = 3; index < primeValues.Length; index++)
      {
        if (primeValues[index])
        {
          IO.Print("{0} ", index);
        }
      }
      IO.PrintLine();
    }
  }
}
