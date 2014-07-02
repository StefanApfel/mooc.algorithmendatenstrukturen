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
  /// <summary>Implementiert die Hausaufgabe 1 des Kapitel 5 des Iversity MOOCs Algorithmen und 
  /// Datenstrukturen. Ziel ist es hier eine Summen Matrix zu erstellen.</summary>
  // ===================================================================================================
  public sealed class ZeilenNummerNorm
  {
    // -------------------------------------------------------------------------------------------------
    /// <summary>Führt die Aufgabe aus.</summary>
    // -------------------------------------------------------------------------------------------------
    public static void Main(String[] args)
    {
      // Seitenlaenge der quadratischen Matrix einlesen
      var matrixLength = 0;
      do
      {
        matrixLength = IO.ReadInt("Bitte die Größe der Matrix: ");
      } 
      while(matrixLength < 1);

      // Erstelle das Array
      var matrix = new Int32[matrixLength, matrixLength];

      // Fuer jede Zeile ein Iterationsschritt
      for (var index = 0; index < matrixLength; index++)
      {
        Int32[] values = null;

        // Die Zeile in einem Schritt mit der passenden Laenge einlesen. Werden weniger Werte angegeben
        // als in eine Matrix Reihe sollen, wird die Zeile wiederholt bis es passt.
        do
        {
          values = IO.ReadInts("\rBitte Zeile " + (index + 1) + " der Matrix: ");
        }
        while (values.Length != matrixLength);

        // Übertrage die eingelesenen Werte in as Array.
        for(var valueIndex = 0; valueIndex < values.Length; valueIndex++)
        {
          matrix[index, valueIndex] = values[valueIndex];
        }
      }

      // Eingelesene Matrix ausgeben
      IO.PrintLine("\nDie eingegebene Matrix lautete:");
      for(var row = 0; row < matrixLength; row++)
      {
        for (var column = 0; column < matrixLength; column++)
        {
          IO.Print("{0,4}",matrix[row, column]);
        }
        IO.PrintLine();
      }

      // ENDE VORGEGEBENER CODE
      // Es ist hier garantiert, dass in matrix jetzt eine quadratische Matrix mit Seitenlaenge 
      // matrixLength enthalten ist.
      CalculateMatrix(matrix, matrixLength);
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary>Errechnet die Zeilen Summe der Matrix.</summary>
    /// <param name="matrix">Die Werte Matrix</param>
    /// <param name="matrixLength">Die Seitenlänge.</param>
    // -------------------------------------------------------------------------------------------------
    private static void CalculateMatrix(Int32[,] matrix, Int32 matrixLength)
    {
      var maxNorm = 0;
      for (var row = 0; row < matrixLength; row++)
      {
        var rowTotal = 0;

        // Summiert die absoluten Zellenwerte (also -2 wird zu +2)... 
        for (var column = 0; column < matrixLength; column++)
        {
          rowTotal += Math.Abs(matrix[row, column]);
        }

        // Wenn die aktuelle Zeilensummer größer ist als der maxNor Wert ersetzt er ihn.
        if(rowTotal > maxNorm)
        {
          maxNorm = rowTotal;
        }
      }

      IO.PrintLine("Die ZeilenNummerNorm beträgt: {0}", maxNorm);
    }
  }
}
