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
  public static class Program
  {
    // -------------------------------------------------------------------------------------------------
    /// <summary>Haupteinstigspunkt der Konsolenanwendung.</summary>
    /// <param name="args">Kommandozeilen Argumente (nicht benutzt)</param>
    // -------------------------------------------------------------------------------------------------
    public static void Main(String[] args)
    {
      // Als kleine "Oberfläche" emuliert die Klasse ChapterMenu ein Anwendungsmenü bei dem die
      // einzelnen Kapitel und Units ausgewählt werden können.
      using(var chapterMenu = new ConsoleMenu("Algorithmen & Datenstrukturen MOOC", "Kapitelübersicht"))
      {
        // Kapitel 3 - Grundlagen -----------------------------------------------------------------
        var chapter3 = new ConsoleMenu.Node          ("Grundlagen");
            chapter3.Add("Collatz-Algorithmus",        Basics.Collatz.Main);
            chapter3.Add("Jahreszeiten",               Basics.Jahreszeiten.Main);
            chapter3.Add("Addieren (Schleife)",        Basics.Addieren.Main);
            chapter3.Add("Fakultät (Schleife)",        Basics.Fakultaet.Main);
            chapter3.Add("Größter Gemeinsamer Teiler", Basics.GroessterGemeinsamerTeiler.Main);
            chapter3.Add("Zahlenreihe (Hausaufgabe)",  Basics.Zahlenreihe.Main);
            chapter3.Add("Primzahl (Hausaufgabe)",     Basics.Primzahl.Main);                                             
        
        // Kapitel 5 - Arrays ---------------------------------------------------------------------
        var chapter5 = new ConsoleMenu.Node          ("Arrays");
            chapter5.Add("Array von Zeichen",          Arrays.Ziffern.Main);
            chapter5.Add("Array von Daten",            Arrays.Matrix.Main);
            chapter5.Add("Array von Wahrheitswerten",  Arrays.Primzahlen.Main);
            chapter5.Add("Kleinster Wert",             Arrays.KleinsterWert.Main);
            chapter5.Add("Lineare & Binäre Suche",     Arrays.Suche.Main);
            chapter5.Add("Matrix (Hausaufgabe)",       Arrays.ZeilenNummerNorm.Main);
            chapter5.Add("König Dodon (Hausaufgabe)",  Arrays.Dodon.Main);
                                         
        // Kapitel 9 - Sortieren ------------------------------------------------------------------
        var chapter9 = new ConsoleMenu.Node          ("Sortieren");
            chapter9.Add("Selection Sort",             Sorting.SelectionSort.Main);
            chapter9.Add("Bubble Sort",                Sorting.BubbleSort.Main);
            chapter9.Add("Merge Sort",                 Sorting.MergeSort.Main);
            chapter9.Add("Quick Sort",                 Sorting.QuickSort.Main);
            chapter9.Add("Heap Sort",                  Sorting.HeapSort.Main);
            chapter9.Add("Vergleich der Sortieralgorithmen", Sorting.SortingComparison.Main);
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

  // ===================================================================================================
  /// <summary>Helferklasse um die erforderlichen usecases an ConsoleMenu zu erleichertn.</summary>
  // ===================================================================================================
  internal static class ConsoleMenuExtension
  {
    // -------------------------------------------------------------------------------------------------
    /// <summary>Fügt einer IConsoleMenuNode ein neues Command hinzu.</summary>
    /// <param name="node">Aktueller Menu Knoten</param>
    /// <param name="name">Name des Menüknotens</param>
    /// <param name="action">Callback zur aufzurufenden Aktion.</param>
    /// <param name="argument">Optionale Argumente.</param>
    // -------------------------------------------------------------------------------------------------
    internal static void Add(this IConsoleMenuNode node, String name, Action<String[]> action, params String[] argument)
    {
      node.Items.Add(new ConsoleMenu.Command<String[]>(name, action, argument));
    }
  }
}
