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
  /// <summary>Implementiert die Kapitel 5.2 des Iversity MOOCs Algorithmen und Datenstrukturen. 
  /// Ziel ist einen EingabeString in seine Character-Array zu zerlegen und per Berechnung (Stelle * 10
  /// plus Wert) zu einem Integer zu wandeln.</summary>
  // ===================================================================================================
  public sealed class Ziffern
  {
    // -------------------------------------------------------------------------------------------------
    /// <summary>Führt die Aufgabe aus.</summary>
    // -------------------------------------------------------------------------------------------------
    public static void Main(String[] args)
    {
      var input = IO.ReadChars("Bitte geben Sie eine Ziffernfolge an: ");
      var total = 0;

      var zeroValue = (Int32)'0';
      for(var index = 0; index < input.Length; index++)
      {
        var value = (Int32)input[index] - zeroValue;
        total = total * 10 + value;
      }

      IO.PrintLine("Der Wert beträgt: {0}", total);
    }
  }
}
