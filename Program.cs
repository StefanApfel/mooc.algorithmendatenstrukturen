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
      using(var chapterMenu = new ConsoleMenu("Kapitelübersicht"))
      {
        // Kapitel 3 - Grundlagen...
        var chapter3 = new ConsoleMenu.Node("Grundlagen", new Basics.Collatz(true),
                                                          new Basics.Jahreszeiten(),
                                                          new Basics.Addieren(),
                                                          new Basics.Fakultaet(),
                                                          new Basics.GroessterGemeinsamerTeiler(),
                                                          new Basics.Zahlenreihe(),
                                                          new Basics.Primzahl());



        // Füge die Kapitel dem Menü hinzu.
        chapterMenu.Items.Add(chapter3);

        // Startet das Menu...
        chapterMenu.Show();
      }
    }
  }
}
