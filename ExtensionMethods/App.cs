using System.Diagnostics;

namespace ExtensionMethods;

public class App
{
    public void Run()
    {
        var aString = "some random text here";
        Console.WriteLine(aString.ContainsTest("text"));
        Console.WriteLine(aString.ContainsTest("test"));
        Console.WriteLine(aString.Contains("text"));
        Console.WriteLine(aString.Contains("test"));
        var stopwatch1 = new Stopwatch();
        stopwatch1.Start();
        for (int i = 0; i < 100000; i++)
        {
            aString.ContainsTest("text");
            aString.ContainsTest("test");
        }
        stopwatch1.Stop();
        Console.WriteLine("Elapsed Time is {0} ms", stopwatch1.ElapsedMilliseconds);
        var stopwatch2 = new Stopwatch();
        stopwatch2.Start();
        for (int i = 0; i < 100000; i++)
        {
            aString.Contains("text");
            aString.Contains("test");
        }
        stopwatch2.Stop();
        Console.WriteLine("Elapsed Time is {0} ms", stopwatch2.ElapsedMilliseconds);
    }


}
public static class Extensions
{
    public static bool ContainsTest(this string str, string strC)
    {
        if (string.IsNullOrEmpty(strC)) { return false; }
        var strArray = str.ToArray();
        var itemArray = strC.ToArray();
        var index = 0;
        var countMatched = 0;
        var isMatch = false;
        foreach (var s in strArray)
        {
            if (s != itemArray[index])
            {
                countMatched = 0;
                index = 0;
            }
            else
            {
                countMatched++;
                index++;
            }
            if (countMatched == itemArray.Length)
            {
                isMatch = true;
                break;
            }
        }
        return isMatch;
    }
}