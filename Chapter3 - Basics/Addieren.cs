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
  /// <summary>Implementiert das Kapitel 3.7 des Iversity MOOCs Algorithmen und Datenstrukturen. Ziel 
  /// ist es in einer While-Schleife solange Werte zu addieren bis 0 eingegeben wird.</summary>
  // ===================================================================================================
  public sealed class Addieren : IChapterUnit
  {
    // -------------------------------------------------------------------------------------------------
    /// <summary>Gibt den Namen der Unit zurück.</summary>
    // -------------------------------------------------------------------------------------------------
    public String Name
    {
      get { return "Addieren (Schleife)"; }
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary>Führt die Aufgabe aus.</summary>
    // -------------------------------------------------------------------------------------------------
    public void Run()
    {
      var value = 0;
      var total = 0;
      IO.PrintLine("Geben Sie Zahlen an, Abbruch mit 0: ");
      while((value = IO.ReadInt()) > 0)
      {
        total += value;
      }
      IO.PrintLine("Die Summe lautet: {0}", total);
    }
  }
}
