//
//
//
//
//
namespace StefanApfel.Learning.AlgorithemDataStructures.Recursion
{
  using AlgoTools;
  using System;

  // ===================================================================================================
  /// <summary></summary>
  // ===================================================================================================
  public sealed class TuermeVonHanoi
  {
    // -------------------------------------------------------------------------------------------------
    /// <summary>Führt die Aufgabe aus.</summary>
    // -------------------------------------------------------------------------------------------------
    public static void Main(String[] args)
    {
      var value = IO.ReadInt("Geben Sie die Anzahl von Steinen des Turmes an: ");
      MoveStones(value, 'A', 'B', 'C');
    }

    // -------------------------------------------------------------------------------------------------
    /// <summary>Verschiebt einen Stein vom einen auf den anderen Stapel. Dabei wird immer ein Stein von
    /// links nach rechts über den Zwischenstapel verschoben.</summary>
    /// <param name="stoneCount">Aktueller Stein.</param>
    /// <param name="left">Linker Stapel.</param>
    /// <param name="center">Zwischenstapel</param>
    /// <param name="right">Rechter Stapel.</param>
    // -------------------------------------------------------------------------------------------------
    private static void MoveStones(Int32 stoneCount, Char left, Char center, Char right)
    {
      if (stoneCount > 0)
      {
        MoveStones(stoneCount - 1, left, right, center);
        IO.PrintLine("Verschiebe Scheibe {0} von {1} nach {2}.", stoneCount, left, right);
        MoveStones(stoneCount - 1, center, left, right);
      }
    }
  }
}
