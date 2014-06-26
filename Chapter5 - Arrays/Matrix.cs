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
  /// <summary>Implementiert die Kapitel 5.3 des Iversity MOOCs Algorithmen und Datenstrukturen. 
  /// Ziel zwei multidimensionale Arrays mit Werte miteinander zu multiplizieren.</summary>
  // ===================================================================================================
  public sealed class Matrix : IConsoleMenuCommand
  {
    // -------------------------------------------------------------------------------------------------
    /// <summary>Gibt den Namen der Unit zurück.</summary>
    // -------------------------------------------------------------------------------------------------
    public String Name
    {
      get { return "Array von Daten"; }
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary>Führt die Aufgabe aus.</summary>
    // -------------------------------------------------------------------------------------------------
    public void Run()
    {
      // Initialisiere Matrix 1
      var matrix1 = new Int32[,] {{  1,  2,  3,  4}, 
                                  {  5,  6,  7,  8},
                                  {  9, 10, 11, 12},
                                  { 13, 14, 15, 16}};
      
      // Initialisiere Matrix 2
      var matrix2 = new Int32[,] {{ 17, 18, 19, 20}, 
                                  { 21, 22, 23, 24},
                                  { 25, 26, 27, 28},
                                  { 29, 30, 31, 32}};

      // Funktioniert natürlich nur mit quadratischen Matrixen.
      var depth = 4;
      var targetMatrix = new Int32[depth, depth];

      for (var row = 0; row < depth; row++)
      {
        for (var column = 0; column < depth; column++)
        {
          targetMatrix[row, column] = matrix1[row, column] * matrix2[row, column];
        }
      }

      // Gebe Ergebnis aus...
      PrintMatrix("Matrix 1:", matrix1);
      PrintMatrix("Matrix 2:", matrix2);
      PrintMatrix("Multiplikations Matrix:", targetMatrix);
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary>Gibt ein Multidimensionales Array aus.</summary>
    /// <param name="name">Name der Matrix.</param>
    /// <param name="matrix">Werte Matrix</param>
    // -------------------------------------------------------------------------------------------------
    private void PrintMatrix(String name, Int32[,] matrix)
    {
      var depth = matrix.Length / matrix.GetLength(0);

      IO.PrintLine(name);
      for (var row = 0; row < depth; row++)
      {
        for (var column = 0; column < depth; column++)
        {
          IO.Print("|{0}", matrix[row, column].ToString().PadLeft(4, ' '));
        }
        IO.PrintLine();
      }
      IO.PrintLine();
    }
  }
}
