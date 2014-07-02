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
  /// <summary>Implementiert das Kapitel 3.9 des Iversity MOOCs Algorithmen und Datenstrukturen. Ziel 
  /// ist es den größten gemeinsamen Teiler zweier Zahlen zu ermitteln.</summary>
  // ===================================================================================================
  public sealed class GroessterGemeinsamerTeiler
  {
    // -------------------------------------------------------------------------------------------------
    /// <summary>Führt die Aufgabe aus.</summary>
    // -------------------------------------------------------------------------------------------------
    public static void Main(String[] args)
    {
      var value1 = IO.ReadInt("Erste Zahl: ");
      var value2 = IO.ReadInt("Zweite Zahl: ");

      if(value1 <= 0 || value2 <= 0)
      {
        IO.Error("Die beiden Zahlen müssen größer als 0 sein.");
      }

      while (value2 != 0)
      {
        value1 = value2;
        value2 = value1 % value2;
      }

      IO.PrintLine("Der größte gemeinsame Teiler is {0}", value1);
    }
  }
}
