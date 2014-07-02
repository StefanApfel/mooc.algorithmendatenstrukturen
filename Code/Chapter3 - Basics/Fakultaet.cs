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
  /// <summary>Implementiert das Kapitel 3.8 des Iversity MOOCs Algorithmen und Datenstrukturen. Ziel 
  /// ist es in einer For-Schleife die Fakultät zu kalkulieren.</summary>
  // ===================================================================================================
  public sealed class Fakultaet
  {
    // -------------------------------------------------------------------------------------------------
    /// <summary>Führt die Aufgabe aus.</summary>
    // -------------------------------------------------------------------------------------------------
    public static void Main(String[] args)
    {
      var value = IO.ReadInt("Die Zahl: ");
      var total = 1;

      for (var index = 1; index <= value; index++)
      {
        total = total * index;
      }
      IO.PrintLine("Die Faktulät von {0} beträgt {1}", value, total);
    }
  }
}
