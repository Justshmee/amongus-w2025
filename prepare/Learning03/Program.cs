using System;

class Fraction
{
    private int _numerator;
    private int _denominator;

    public Fraction()
    {
        _numerator = 1;
        _denominator = 1;
    }

    public Fraction(int numerator)
    {
        _numerator = numerator;
        _denominator = 1;
    }

    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }
        _numerator = numerator;
        _denominator = denominator;
    }

    public int GetNumerator()
    {
        return _numerator;
    }

    public void SetNumerator(int numerator)
    {
        _numerator = numerator;
    }

    public int GetDenominator()
    {
        return _denominator;
    }
    
    public void SetDenominator(int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }
        _denominator = denominator;
    }
    
    public string GetFractionString()
    {
        return $"{_numerator}/{_denominator}";
    }
    
    public double GetDecimalValue()
    {
        return (double)_numerator / _denominator;
    }
}

public class Program
{
    public static void Main()
    {
        Fraction f1 = new Fraction();
        Console.WriteLine(f1.GetFractionString()); // 1/1
        Console.WriteLine(f1.GetDecimalValue());   // 1

        Fraction f2 = new Fraction(5);
        Console.WriteLine(f2.GetFractionString()); // 5/1
        Console.WriteLine(f2.GetDecimalValue());   // 5

        Fraction f3 = new Fraction(3, 4);
        Console.WriteLine(f3.GetFractionString()); // 3/4
        Console.WriteLine(f3.GetDecimalValue());   // 0.75

        Fraction f4 = new Fraction(1, 3);
        Console.WriteLine(f4.GetFractionString()); // 1/3
        Console.WriteLine(f4.GetDecimalValue());   // 0.3333333333333333
    }
}