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
  public abstract class SortingUnit<T>
  {
    // -------------------------------------------------------------------------------------------------
    /// <summary>Führt die Sorting Method aus und ermittelt die benötigte Zeit.</summary>
    // -------------------------------------------------------------------------------------------------
    public static void Main(String[] args)
    {
      var values = IO.ReadInts("Geben Sie Ihre Zahlen ein (Leerzeichen getrennt): ");

      var methodInfo = typeof(T).GetMethod("Sort");
      var sortingMethod = (Action<Int32[]>)Delegate.CreateDelegate(typeof(Action<Int32[]>), methodInfo);

      var timer = new System.Diagnostics.Stopwatch();
      timer.Start();

      sortingMethod(values);

      timer.Stop();

      IO.PrintLine();
      IO.PrintLine("Das Ergebnis (Dauer: {0}):", timer.Elapsed.ToString("ss\\.fffff"));
      IO.PrintLine(values);
    }
  }
}
