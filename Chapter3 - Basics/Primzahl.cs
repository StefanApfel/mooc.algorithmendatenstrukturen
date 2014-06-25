//
//
//
//
//
namespace StefanApfel.Learning.AlgorithemDataStructures.Basics
{
  using AlgoTools;
  using System;

  // ===================================================================================================
  /// <summary>Implementiert die Hausaufgabe 4 von Kapitel 3 des Iversity MOOCs Algorithmen und 
  /// Datenstrukturen. Ziel ist es herauszufinden ob eine gegebene Zahl eine Primzahl ist.</summary>
  // ===================================================================================================
  public sealed class Primzahl : IChapterUnit
  {
    // -------------------------------------------------------------------------------------------------
    /// <summary>Gibt den Namen der Unit zurück.</summary>
    // -------------------------------------------------------------------------------------------------
    public String Name
    {
      get { return "Primzahl (Hausaufgabe)"; }
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary>Führt die Aufgabe aus.</summary>
    // -------------------------------------------------------------------------------------------------
    public void Run()
    {
      var value = IO.ReadInt("Geben Sie eine natürliche Zahl > 1 an: ");
      if (value <= 1)
      {
        IO.Error("Die Zahl muss größer als 1 sein.");
      }

      Boolean isPrime = false;
      for(var index = 2; index < value-1 && !isPrime; index++)
      {
        // Wenn die Zahl ohne Rest teilbar ist, kann es keine Primzahl sein.
        isPrime = (value % index != 0);
      }
      
      IO.PrintLine("{0} ist {1} Primzahl.", value, (isPrime) ? "eine" : "keine");
    }
  }
}
