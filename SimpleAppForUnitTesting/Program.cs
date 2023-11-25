using SimpleAppForUnitTesting;
using System.Net.WebSockets;

internal class Program
{
    private static int percent;

    private static void Main(string[] args)
    {
        var gradecalc = new gradeCalc();
        Console.WriteLine("Enter percentage :);
    
        var percent = Convert.ToInt32(Console.ReadLine());
        var grade = gradecalc.gradeCalcate(percent);
        Console.WriteLine(grade);
    }
}
//private static void Main(string[] args)
//{
//    Console.WriteLine("Hello, World!");

//}
