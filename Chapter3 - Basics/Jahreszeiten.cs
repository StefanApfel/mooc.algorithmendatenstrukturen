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
  /// <summary>Implementiert Kapitel 3.4 des Iversity MOOCs Algorithmen und Datenstrukturen. Ziel ist es 
  /// anhand von Abfragen die Jahrezeit zu einem gegebenen Monat auszugeben.</summary>
  // ===================================================================================================
  public sealed class Jahreszeiten : IChapterUnit
  {
    // -------------------------------------------------------------------------------------------------
    /// <summary>Gibt den Namen der Unit zurück.</summary>
    // -------------------------------------------------------------------------------------------------
    public String Name
    {
      get { return "Jahreszeiten"; }
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary>Führt die Aufgabe aus.</summary>
    // -------------------------------------------------------------------------------------------------
    public void Run()
    {
      var month = IO.ReadInt("Geben Sie einen Monat (als Zahl) an: ");
      if (month < 1 || month > 12)
      {
        IO.Error("Ein Monat muss zwischen 1 (Januar) und 12 (Dezember) liegen");
      }

      String season = null;
      if(month >= 3 && month <=5)
      {
        season = "Frühling";
      }
      else if (month >= 6 && month <= 8)
      {
        season = "Sommer";
      }
      else if (month >= 9 && month <= 11)
      {
        season = "Herbst";
      }
      else if (month == 12 || month <= 2)
      {
        season = "Winter";
      }

      var name = GetMonthName(month);
      IO.PrintLine("Der Monat '{0}' ist im {1}", name, season);
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary>Gibt den Namen des Monats zurück.</summary>
    /// <param name="month">Monatszahl</param>
    /// <returns>Januar, Februar, März, ...., Dezember.</returns>
    // -------------------------------------------------------------------------------------------------
    private String GetMonthName(Int32 month)
    {
      switch (month)
      {
        case 1: return "Januar";
        case 2: return "Februar";
        case 3: return "März";
        case 4: return "April";
        case 5: return "Mai";
        case 6: return "Juni";
        case 7: return "Juli";
        case 8: return "August";
        case 9: return "September";
        case 10: return "Oktober";
        case 11: return "November";
        case 12: return "Dezember";
      }
      IO.Error("Ungültige Monatszahl ({0})", month);
      return null;
    }
  }
}
