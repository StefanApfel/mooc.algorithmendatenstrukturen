//
//
//
//
//
namespace StefanApfel.Learning.AlgorithemDataStructures
{
  using System;

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
