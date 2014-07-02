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
  /// <summary>Implementiert das Kapitel 3.1 des Iversity MOOCs Algorithmen und Datenstrukturen. Ziel 
  /// ist den Collatz-Algorithmus in C# abzubilden.</summary>
  // ===================================================================================================
  public sealed class Collatz
  {
    // -------------------------------------------------------------------------------------------------
    /// <summary>Gibt ob der Trace mit ausgegeben werden soll oder nicht..</summary>
    // -------------------------------------------------------------------------------------------------
    public static Boolean ShowTrace
    {
      get;
      set;
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary>Führt die Aufgabe aus.</summary>
    // -------------------------------------------------------------------------------------------------
    public static void Main(String[] args)
    {
      var value = IO.ReadInt("Bitte geben Sie eine Zahl an: ");
      var steps = 0;

      while(value != 1)
      {
        if(ShowTrace)
        {
          IO.PrintLine("{0,3} | {1}", value, steps);
        }

        // Laut Collatz wird eine Zahl wenn sie nicht gerade ist, mit 3 multipliziert und um 1 erhöht...
        value = ((value % 2) == 0) ? value / 2 : (value * 3) + 1;
        steps++;
      }

      IO.PrintLine("\nEs wurden {0} Schritte benötigt.", steps);
    }
  }
}
