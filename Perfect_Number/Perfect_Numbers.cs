using System;
using System.Linq;
using static System.Console;

internal class Program
{
  private static void Main(string[] args)
  {
    WriteLine("Sayı Giriniz...:");
    int nm = int.Parse(ReadLine());
    Console.WriteLine(perfecto(nm));
    Console.ReadLine();

    WriteLine(secondLARGE(new int[]{-1,-7,3,-5,0}));
  }

  private static string perfecto(int number)
  {
    int summ = 0, inc = 1;
    while(inc < number)
    {
      if(number % inc == 0)
        summ += inc;
      inc++;
    }

    if(summ == number)
      return "Perfect Number";
    else
      return "Not Perfect Number";
  }

  private static int secondLARGE(int[] numbers)
  {    
    int[] ord_numbers = new int[numbers.Length];
    int max = int.MinValue, max2 = int.MinValue;
    for(int i = 0; i < numbers.Length; i++)
    {
      if(numbers[i] > max)
      {
        max2 = max;
        max = numbers[i];
      }
      else if(numbers[i] > max2)
        max2 = numbers[i];
    }

    return max2;
  }
}