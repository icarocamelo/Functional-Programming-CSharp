using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

namespace ConsoleApplication2

{

class Program1

{

static void Main(string[] args)

{

string str = "ABCDE";

string result = string.Empty;

System.Diagnostics.Stopwatch w = new System.Diagnostics.Stopwatch();

w.Start();

for (int i = 0; i < 1000000; i++)

{

result = RevertString(str);

}

w.Stop();

Console.WriteLine("Finished: " + w.Elapsed.Seconds + "." + w.Elapsed.Milliseconds + "s");

Console.WriteLine(result);

Console.ReadKey();

w = new System.Diagnostics.Stopwatch();

w.Start();

for (int i = 0; i < 1000000; i++)

{

result = RevertStringWithChars(str);

}

w.Stop();

Console.WriteLine("Finished: " + w.Elapsed.Seconds + "." + w.Elapsed.Milliseconds + "s");

//Using a functional approach

Run(RevertString, str, 1000);

Run(RevertStringWithChars, str, 1000);

Console.ReadKey();

}

#region Reverse String

/// <summary>

/// Automate functions executions and evaluating theirs performance

/// </summary>

/// <param name="function"></param>

/// <param name="p1"></param>

/// <param name="times"></param>

public static void Run(Func<string, string> function, string p1, int times)

{

System.Diagnostics.Stopwatch w = new System.Diagnostics.Stopwatch();

w.Start();

for (int i = 0; i < times; i++)

{

function.Invoke(p1);

}

w.Stop();

Console.WriteLine(function.Method.Name + " - " + w.Elapsed.Seconds + "." + w.Elapsed.Milliseconds + "s");

}

/// <summary>

/// Algorithm #2

/// </summary>

/// <param name="str"></param>

/// <returns></returns>

public static string RevertString(string str)

{

string result = string.Empty;

for (int i = str.Length; i > 0; i--)

{

result += str.Substring(i - 1, 1);

}

return result;

}

/// <summary>

/// Algorithm #1

/// </summary>

/// <param name="str"></param>

/// <returns></returns>

public static string RevertStringWithChars(string str)

{

var characteres = str.ToCharArray();

char[] chars = new char[characteres.Length];

for (int i = characteres.Length; i > 0; i--)

{

chars.SetValue(characteres[i - 1], characteres.Length - i);

}

return new String(chars);

}

#endregion

}

}

