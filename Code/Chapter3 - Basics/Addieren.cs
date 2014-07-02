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
  public sealed class Addieren
  {
    // -------------------------------------------------------------------------------------------------
    /// <summary>Führt die Aufgabe aus.</summary>
    // -------------------------------------------------------------------------------------------------
    public static void Main(String[] args)
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
