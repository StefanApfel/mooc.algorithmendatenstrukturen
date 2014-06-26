//
//
//
//
//
namespace StefanApfel.Learning.AlgorithemDataStructures
{
  using System;

  // ===================================================================================================
  /// <summary>Die Klasse Program ist eien statische Klasse die den Einstiegspunkt für eien Konsolen-
  /// Anwendung enthält (Main).</summary>
  // ===================================================================================================
  internal static class Program
  {
    // -------------------------------------------------------------------------------------------------
    /// <summary>Haupteinstigspunkt der Konsolenanwendung.</summary>
    /// <param name="args">Kommandozeilen Argumente (nicht benutzt)</param>
    // -------------------------------------------------------------------------------------------------
    internal static void Main(String[] args)
    {
      // Als kleine "Oberfläche" emuliert die Klasse ChapterMenu ein Anwendungsmenü bei dem die
      // einzelnen Kapitel und Units ausgewählt werden können.
      using(var chapterMenu = new ConsoleMenu("Algorithmen & Datenstrukturen MOOC", "Kapitelübersicht"))
      {
        // Kapitel 3 - Grundlagen -----------------------------------------------------------------
        var chapter3 = new ConsoleMenu.Node("Grundlagen", new Basics.Collatz(true),
                                                          new Basics.Jahreszeiten(),
                                                          new Basics.Addieren(),
                                                          new Basics.Fakultaet(),
                                                          new Basics.GroessterGemeinsamerTeiler(),
                                                          new Basics.Zahlenreihe(),
                                                          new Basics.Primzahl());
        // Kapitel 5 - Arrays ---------------------------------------------------------------------
        var chapter5 = new ConsoleMenu.Node("Arrays",     new Arrays.Ziffern(),
                                                          new Arrays.Matrix(),
                                                          new Arrays.Primzahlen(),
                                                          new Arrays.KleinsterWert(),
                                                          new Arrays.Suche(),
                                                          new Arrays.ZeilenNummerNorm(),
                                                          new Arrays.Dodon());
        // Kapitel 9 - Sortieren ------------------------------------------------------------------
        var chapter9 = new ConsoleMenu.Node("Sortieren",  new Sorting.SelectionSort(),
                                                          new Sorting.BubbleSort(),
                                                          new Sorting.MergeSort(),
                                                          new Sorting.QuickSort(),
                                                          new Sorting.HeapSort(),
                                                          new Sorting.SortingComparison());
        // ----------------------------------------------------------------------------------------

        // Füge die Kapitel dem Menü hinzu.
        chapterMenu.Items.Add(chapter3);
        chapterMenu.Items.Add(chapter5);
        chapterMenu.Items.Add(chapter9);

        // Startet das Menu...
        chapterMenu.Show();
      }
    }
  }
}
