//
//
//
//
//
namespace StefanApfel.Learning.AlgorithemDataStructures.Sorting
{
  using AlgoTools;
  using System;
  using System.Diagnostics;

  // ===================================================================================================
  /// <summary>Vergleicht die verschiedenen Sortieralgorithmen am Beispiel von 300 Werten die sortiert 
  /// werden sollen.</summary>
  // ===================================================================================================
  public sealed class SortingComparison : IConsoleMenuCommand
  {
    // -------------------------------------------------------------------------------------------------
    /// <summary>Gibt den Namen der Unit zurück.</summary>
    // -------------------------------------------------------------------------------------------------
    public String Name
    {
      get { return "Vergleich der Sortier-Algorithmen"; }
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary>Führt die ChapterUnit aus</summary>
    // -------------------------------------------------------------------------------------------------
    public void Run()
    {
      var timer = new Stopwatch();

      IO.PrintLine(" Algorithmus     │ Durchschnittsdauer");
      IO.PrintLine("═════════════════╪════════════════════");
      IO.PrintLine(" SelectionSort   │ {0}s", Run(timer, SelectionSort.Sort));
      IO.PrintLine(" SelectionSort   │ {0}s", Run(timer, SelectionSort.Sort));
      IO.PrintLine(" BubbleSort      │ {0}s", Run(timer, BubbleSort.Sort));
      IO.PrintLine(" MergeSort       │ {0}s", Run(timer, MergeSort.Sort));
      IO.PrintLine(" QuickSort       │ {0}s", Run(timer, QuickSort.Sort));
      IO.PrintLine(" HeapSort        │ {0}s", Run(timer, HeapSort.Sort));
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary>Führt den übergebenen Sortieralgorithmus aus, misst und validiert ihn.</summary>
    /// <param name="timer">Stopwatch Timer Instanz</param>
    /// <param name="sortingMethod">Die Sortiermethode die ausgeführt wird.</param>
    /// <returns>Die gemessene Zeit als String</returns>
    // -------------------------------------------------------------------------------------------------
    private String Run(Stopwatch timer, Action<Int32[]> sortingMethod)
    {
      var values = GetValues();
      var iterations = 10;

      Int64 totalElapsed = 0;
      for (var repeat = 0; repeat < iterations; repeat++)
      {
        timer.Restart();
        sortingMethod(values);
        timer.Stop();

        SortingUnit.ValidateResult(values);
        totalElapsed += timer.Elapsed.Ticks;
      }

      Int64 average = totalElapsed / iterations;
      return TimeSpan.FromTicks(average).ToString("ss\\.fffff");
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary>Gibt ein Array mit Zufallswerten zurück.</summary>
    /// <returns>Ein Int32 Array mit unsortieren Werten.</returns>
    // -------------------------------------------------------------------------------------------------
    private Int32[] GetValues()
    {
      return new Int32[] {
        725,816,767,557,205,561,905,441,976,273,291,466,632,469,981,38,861,994,676,316,816,847,990,32,
        699,525,933,686,546,81,186,452,296,987,642,762,30,380,342,956,504,715,118,273,906,793,336,456,
        146,221,409,718,619,487,194,877,824,734,857,679,624,218,894,895,86,837,169,643,825,212,998,48,
        651,719,808,100,728,717,125,904,188,476,540,325,670,467,832,808,792,763,936,294,522,662,332,7,
        286,819,222,187,68,623,692,629,926,234,927,66,899,677,193,148,106,609,952,490,147,676,569,225,
        617,5,360,849,62,281,704,957,987,386,523,280,506,531,56,282,495,845,612,104,741,401,932,130,9,
        698,614,829,684,569,172,184,608,250,996,568,63,263,841,567,645,515,969,77,512,155,812,641,574,
        552,671,993,301,64,465,482,216,71,230,151,444,450,19,388,815,202,912,29,508,961,992,16,652,28,
        966,587,771,323,420,973,885,971,254,135,896,178,882,544,784,513,352,990,33,61,121,197,496,580,
        261,310,241,783,132,611,558,654,343,23,97,877,710,891,650,255,264,473,195,886,491,637,319,368,
        244,949,609,1,982,960,156,771,91,190,52,109,732,101,838,642,572,240,836,858,446,906,82,49,340,
        777,426,646,997,608,89,623,989,872,539,137,13,556,671,378,865,324,785,519,828,542,521,162,633,
        555,314,249,799,459,920,337,192,150,660,208
      };
    }
  }
}
