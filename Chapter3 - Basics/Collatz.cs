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
  public sealed class Collatz : IChapterUnit
  {
    // -------------------------------------------------------------------------------------------------
    /// <summary>Gibt den Namen der Unit zurück.</summary>
    // -------------------------------------------------------------------------------------------------
    public String Name
    {
      get { return "Der Collatz-Algorithmus"; }
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary>Gibt ob der Trace mit ausgegeben werden soll oder nicht..</summary>
    // -------------------------------------------------------------------------------------------------
    private Boolean ShowTrace
    {
      get;
      set;
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary>Erstellt eine neue Instanz der Klasse Collatz.</summary>
    /// <param name="trace">Gibt an ob Tracing eingeschaltet ist oder nicht.</param>
    // -------------------------------------------------------------------------------------------------
    public Collatz(Boolean trace)
    {
      ShowTrace = trace;
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary>Führt die Aufgabe aus.</summary>
    // -------------------------------------------------------------------------------------------------
    public void Run()
    {
      var value = IO.ReadInt("Bitte geben Sie eine Zahl an: ");
      var steps = 0;

      while(value != 1)
      {
        if(ShowTrace)
        {
          IO.PrintLine("{0} | {1}", value.ToString().PadLeft(5, ' '), steps);
        }

        // Laut Collatz wird eine Zahl wenn sie nicht gerade ist, mit 3 multipliziert und um 1 erhöht...
        value = ((value % 2) == 0) ? value / 2 : (value * 3) + 1;
        steps++;
      }

      IO.PrintLine("\nEs wurden {0} Schritte benötigt.", steps);
    }
  }
}
