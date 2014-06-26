//
//
//
//
//
namespace StefanApfel.Learning.AlgorithemDataStructures.Arrays
{
  using AlgoTools;
  using System;

  // ===================================================================================================
  /// <summary>Implementiert die Hausaufgabe 3 von Kapitel 5 des Iversity MOOCs Algorithmen und 
  /// Datenstrukturen. Ziel ist ein Boolisches Array n-mal zu manipulieren.</summary>
  // ===================================================================================================
  public sealed class Dodon : IConsoleMenuCommand
  {
    // -------------------------------------------------------------------------------------------------
    /// <summary>Gibt den Namen der Unit zurück.</summary>
    // -------------------------------------------------------------------------------------------------
    public String Name
    {
      get { return "König Dodon (Hausaufgabe)"; }
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary>Führt die Aufgabe aus.</summary>
    /// <remarks>Der Märchenkönig Dodon hat in seiner Burg einen Kerker mit 100 Zellen und je einem 
    /// Gefangenen darin. Alle Zellen lassen sich mit demselben Schlüssel öffnen. Wird der Schlüssel 
    /// einmal im Schloss umgedreht, ist die Tür offen. Dreht man ihn noch einmal herum ist die Tür 
    /// wieder verschlossen usw.
    /// 
    /// Am Abend vor seinem 1000. Geburtstag lässt Dodon von einem Boten alle Zellentüren öffnen, denn 
    /// er will den Gefangenen die Freiheit schenken. Die Wachen sorgen dafür, dass kein Gefangener vor 
    /// 0:00 Uhr seine Zelle verlässt. Im Laufe des Abends vergisst Dodon seine Barmherzigkeit und 
    /// schickt einen zweiten Boten, der den Schlüssel in jeder zweiten Tür - beginnend mit der zweiten 
    /// noch einmal herumdreht. Danach schickt er einen dritten Boten, der den Schlüssel in jedem 
    /// dritten Schloss - beginnend mit dem dritten - umdreht, ... , dann einen k-ten Boten, der den 
    /// Schlüssel in jedem k-ten Schloss - beginnend mit dem k-ten - umdreht usw.. Um 0:00 Uhr Uhr dreht 
    /// der 100. Bote den Schlüssel in nur einer Tür - der 100. - herum und alle Gefangenen, deren 
    /// Zellentüren offen sind, dürfen gehen.</remarks>
    // -------------------------------------------------------------------------------------------------
    public void Run()
    {
      var guardCount = IO.ReadInt("Geben Sie die Anzahl der Boten an: ");
      var prisonCells = new Boolean[100];

      // Die Wächter/Boten drehen die SChlüssel um. Der erste Wächter jedes Schloss, der 2. jedes zweite
      // der 3. jedes dritte,...
      for(var guardIndex = 1; guardIndex <= guardCount; guardIndex++)
      {
        for (var cellIndex = guardIndex-1; cellIndex < prisonCells.Length; cellIndex += guardIndex)
        {
          prisonCells[cellIndex] = !prisonCells[cellIndex];
        }
      }

      // Gibt die geöffneten Zellen aus...
      IO.PrintLine("Die folgenden Zellen sind geöffnet: ");
      for(var cellIndex = 0; cellIndex < prisonCells.Length; cellIndex++)
      {
        if(prisonCells[cellIndex])
        {
          IO.PrintLine("Zelle #{0}, ", cellIndex + 1);
        }
      }
    }
  }
}
