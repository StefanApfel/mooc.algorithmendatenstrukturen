﻿//
//
//
//
//
namespace StefanApfel.Learning.AlgorithemDataStructures.Basics
{
  using AlgoTools;
  using System;

  // ===================================================================================================
  /// <summary>Implementiert die Hausaufgabe 2 von Kapitel 3 des Iversity MOOCs Algorithmen und 
  /// Datenstrukturen. Ziel ist es eine Reihe von 1 bis zu einer angegeben Zahl auszugaben.</summary>
  // ===================================================================================================
  public sealed class Zahlenreihe
  {
    // -------------------------------------------------------------------------------------------------
    /// <summary>Führt die Aufgabe aus.</summary>
    // -------------------------------------------------------------------------------------------------
    public static void Main(String[] args)
    {
      var targetNumber = IO.ReadInt("Geben Sie eine natürliche Zahl > 1 an: ");
      if (targetNumber <= 1)
      {
        IO.Error("Die Zahl muss größer als 1 sein.");
      }

      for(var index = 1; index <= targetNumber; index++)
      {
        IO.PrintLine(index);
      }
    }
  }
}
