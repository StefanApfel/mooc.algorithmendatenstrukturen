//
//
//
//
//
namespace StefanApfel.Learning.AlgorithemDataStructures.Basics
{
  using AlgoTools;
  using System;
  using System.Globalization;

  // ===================================================================================================
  /// <summary>Implementiert Kapitel 3.4 des Iversity MOOCs Algorithmen und Datenstrukturen. Ziel ist es 
  /// anhand von Abfragen die Jahrezeit zu einem gegebenen Monat auszugeben.</summary>
  // ===================================================================================================
  public sealed class Jahreszeiten
  {
    // -------------------------------------------------------------------------------------------------
    /// <summary>Führt die Aufgabe aus.</summary>
    // -------------------------------------------------------------------------------------------------
    public static void Main(String[] args)
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

      var germanCulture = new CultureInfo("de-de");
      var name = germanCulture.DateTimeFormat.GetMonthName(month);

      IO.PrintLine("Der Monat '{0}' ist im {1}", name, season);
    }
  }
}
