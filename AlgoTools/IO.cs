//
//
//
//
//
namespace AlgoTools
{
  using System;

  // ===================================================================================================
  /// <summary>Die Klasse ist eine lose C# Implementierung der Java Bibliothek AlgoTools.IO welches hier
  /// https://www.iwi.hs-karlsruhe.de/lab/info01/Tutorial/download/AlgoTools/AlgoTools.IO.html herunter
  /// geladen werden kann. Im wesentlichen Kapselt die Klasse Aufrufe der C# Klasse Console mit Checks
  /// oder weiteren Verarbeitungsschritten (z.B. ReadInts wandelt einen String in ein Integer Array).
  /// Die Klasse orientiert sich an den .NET Bennenungsrichtlinien.</summary>
  // ===================================================================================================
  public static class IO
  {
    #region Eingabe

    public static Int32 ReadInt(String prompt = null)
    {
      if (!String.IsNullOrEmpty(prompt))
      {
        Console.Write(prompt);
      }

      Int32 value = 0;
      String input = Console.ReadLine();
      if(!Int32.TryParse(input, out value))
      {
        Error("'{0}' ist keine gültige Zahl.", input);
      }

      return value;
    }

    public static Int32[] ReadInts(String prompt=null)
    {
      if(!String.IsNullOrEmpty(prompt))
      {
        Console.WriteLine(prompt);
      }

      var input = Console.ReadLine();

      if(String.IsNullOrEmpty(input))
      {
        return new Int32[] { };
      }

      var split = input.Split(' ');
      var returnValue = new Int32[split.Length];
      for(var index = 0; index < returnValue.Length; index++)
      {
        returnValue[index] = Int32.Parse(split[index].Trim());
      }
      return returnValue;
    }
    #endregion

    #region Ausgabe

    public static void PrintLine()
    {
      Console.WriteLine();
    }

    public static void Print(String text, params Object[] args)
    {
      Console.Write(text, args);
    }

    
    public static void PrintLine(Int32 value)
    {
      Console.WriteLine(value);
    }
    public static void PrintLine(String text, params Object[] args)
    {
      Console.WriteLine(text, args);
    }

    public static void PrintLine<ArrayType>(ArrayType[] array)
    {
      Console.WriteLine(String.Join<ArrayType>(" ", array));
    }
    #endregion

    #region Fehler

    public static void Error(String text, params Object[] args)
    {
      throw new Exception(String.Format(text, args));
    }
    #endregion
  }
}
