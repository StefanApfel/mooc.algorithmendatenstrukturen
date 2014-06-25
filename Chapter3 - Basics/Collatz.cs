using AlgoTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StefanApfel.Learning.AlgorithemDataStructures.Basics
{

  public sealed class Collatz : IChapterUnit
  {
    // -------------------------------------------------------------------------------------------------
    /// <summary>Gibt den Namen der Unit zurück.</summary>
    // -------------------------------------------------------------------------------------------------
    public String Name
    {
      get { return "Der Collatz-Algorithmus"; }
    }

    private Boolean ShowTrace
    {
      get;
      set;
    }

    public Collatz(Boolean trace)
    {
      ShowTrace = trace;
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary></summary>
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
