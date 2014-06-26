//
//
//
//
//
namespace StefanApfel.Learning.AlgorithemDataStructures.Sorting
{
  using AlgoTools;
  using System;

  // ===================================================================================================
  /// <summary>Die Abstrakte Basisklasse SortinUnit kapselt die gleichen Aufrufe der einzelnen Units des
  /// Kapitel Sortings um Redundanzen zu vermeiden..</summary>
  // ===================================================================================================
  public abstract class SortingUnit : IConsoleMenuCommand
  {
    // -------------------------------------------------------------------------------------------------
    /// <summary>Gibt den Namen der Unit zurück.</summary>
    // -------------------------------------------------------------------------------------------------
    public abstract string Name { get; }

    // -------------------------------------------------------------------------------------------------
    /// <summary>Führt die Sorting Method aus und ermittelt die benötigte Zeit.</summary>
    // -------------------------------------------------------------------------------------------------
    public void Run()
    {
      var values = IO.ReadInts("Geben Sie Ihre Zahlen ein (Leerzeichen getrennt): ");

      var methodInfo = GetType().GetMethod("Sort");
      var sortingMethod = (Action<Int32[]>)Delegate.CreateDelegate(typeof(Action<Int32[]>), methodInfo);

      var timer = new System.Diagnostics.Stopwatch();
      timer.Start();

      sortingMethod(values);

      timer.Stop();

      IO.PrintLine();
      IO.PrintLine("Das Ergebnis (Dauer: {0}):", timer.Elapsed.ToString("ss\\.fffff"));
      IO.PrintLine(values);
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary></summary>
    // -------------------------------------------------------------------------------------------------
    internal static void ValidateResult(Int32[] result)
    {
      for (var index = 1; index < result.Length; index++)
      {
        if (result[index] < result[index - 1])
        {
          throw new Exception("");
        }
      }
    }
  }
}
