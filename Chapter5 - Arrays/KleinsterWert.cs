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
  /// <summary>Implementiert die Kapitel 5.5 des Iversity MOOCs Algorithmen und Datenstrukturen. 
  /// Ziel aus einem Arry die kleinste Zahl zu ermitteln.</summary>
  // ===================================================================================================
  public sealed class KleinsterWert : IConsoleMenuCommand
  {
    // -------------------------------------------------------------------------------------------------
    /// <summary>Gibt den Namen der Unit zurück.</summary>
    // -------------------------------------------------------------------------------------------------
    public String Name
    {
      get { return "Kleinster Wert"; }
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary>Führt die Aufgabe aus.</summary>
    // -------------------------------------------------------------------------------------------------
    public void Run()
    {
      var values = IO.ReadInts("Bitte geben Sie eine Zahlenfolge ein (Leerzeichen getrennt):");
      
      var minIndex = 0;
      for (var index = 1; index < values.Length; index++)
      {
        if (values[index] < values[minIndex])
        {
          minIndex = index;
        }
      }
      IO.PrintLine("Der kleinste Wert ist {0} an Position {1}.", values[minIndex], minIndex + 1);
    }
  }
}
