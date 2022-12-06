using AdventOfCode.Extensions;

namespace AdventOfCode.Year_2021.Day_03;

public static class BinaryDiagnostic
{
    public static int Calculate(List<string> inputs)
    {
        var countZeros = new int[inputs[0].Length];
        var countOnes = new int[inputs[0].Length];

        foreach(var input in inputs)
        {
            foreach(int i in 0..input.Length)
            {
                if(input[i] == '0')
                {
                    countZeros[i]++;
                }
                else
                {
                    countOnes[i]++;
                }
            }
        }
        
        var gammaResultBinary = new int[inputs[0].Length];

        for (int i = 0; i < countOnes.Length; i++)
        {
            gammaResultBinary[i] = countZeros[i] > countOnes[i] ? 0 : 1;
        }

        var gammaResult = 0;
        for (int i = gammaResultBinary.Length - 1; i >= 0; i--)
        {
            var reverseIndex = (double)gammaResultBinary.Length - 1 - i;
            gammaResult += (int)(Math.Pow(2.0, reverseIndex) * gammaResultBinary[i]);
        }

        var epsilonResultBinary = new int[inputs[0].Length];

        foreach (int i in 0..countOnes.Length)
        {
            epsilonResultBinary[i] = countZeros[i] < countOnes[i] ? 0 : 1;
        }

        var epsilonResult = 0;
        for (int i = epsilonResultBinary.Length - 1; i >= 0; i--)
        {
            var reverseIndex = (double)epsilonResultBinary.Length - 1 - i;
            epsilonResult += (int)(Math.Pow(2.0, reverseIndex) * epsilonResultBinary[i]);
        }

        return gammaResult * epsilonResult;
    }

    public static void Verify(List<string> inputs)
    {
        Console.WriteLine("Verifying Oxygen");
        
        var firstNumbersOxygen = GetAmountOfNumberForOxygen(inputs, 0);
        var secondNumbersOxygen = GetAmountOfNumberForOxygen(firstNumbersOxygen, 1);
        var thirdNumbersOxygen = GetAmountOfNumberForOxygen(secondNumbersOxygen, 2);
        var fourthNumbersOxygen = GetAmountOfNumberForOxygen(thirdNumbersOxygen, 3);
        var fifthNumbersOxygen = GetAmountOfNumberForOxygen(fourthNumbersOxygen, 4);
        var sixthNumbersOxygen = GetAmountOfNumberForOxygen(fifthNumbersOxygen, 5);
        var seventhNumbersOxygen = GetAmountOfNumberForOxygen(sixthNumbersOxygen, 6);
        var eighthNumbersOxygen = GetAmountOfNumberForOxygen(seventhNumbersOxygen, 7);
        var ninthNumbersOxygen = GetAmountOfNumberForOxygen(eighthNumbersOxygen, 8);
        var tenthNumbersOxygen = GetAmountOfNumberForOxygen(ninthNumbersOxygen, 9);
        var eleventhNumbersOxygen = GetAmountOfNumberForOxygen(tenthNumbersOxygen, 10);
        var twelfthNumbersOxygen = GetAmountOfNumberForOxygen(eleventhNumbersOxygen, 11);

        var oxygenBinary = BinaryToDecimal(twelfthNumbersOxygen[0]);

        Console.WriteLine("Verifying CarbonDioxide");
        var firstNumberCarbonDioxide = GetAmountOfNumberForCarbonDioxide(inputs, 0);
        var secondNumberCarbonDioxide = GetAmountOfNumberForCarbonDioxide(firstNumberCarbonDioxide, 1);
        var thirdNumberCarbonDioxide = GetAmountOfNumberForCarbonDioxide(secondNumberCarbonDioxide, 2);
        var fourthNumberCarbonDioxide = GetAmountOfNumberForCarbonDioxide(thirdNumberCarbonDioxide, 3);
        var fifthNumberCarbonDioxide = GetAmountOfNumberForCarbonDioxide(fourthNumberCarbonDioxide, 4);
        var sixthNumberCarbonDioxide = GetAmountOfNumberForCarbonDioxide(fifthNumberCarbonDioxide, 5);
        var seventhNumberCarbonDioxide = GetAmountOfNumberForCarbonDioxide(sixthNumberCarbonDioxide, 6);
        var eighthNumberCarbonDioxide = GetAmountOfNumberForCarbonDioxide(seventhNumberCarbonDioxide, 7);
        var ninthNumberCarbonDioxide = GetAmountOfNumberForCarbonDioxide(eighthNumberCarbonDioxide, 8);
        // var tenthNumberCarbonDioxide = GetAmountOfNumberForCarbonDioxide(ninthNumberCarbonDioxide, 9);
        // var eleventhNumberCarbonDioxide = GetAmountOfNumberForCarbonDioxide(tenthNumberCarbonDioxide, 10);
        // var twelfthNumberCarbonDioxide = GetAmountOfNumberForCarbonDioxide(eleventhNumberCarbonDioxide, 11);

        var carbonDioxideBinary = BinaryToDecimal(ninthNumberCarbonDioxide[0]);

        var result = oxygenBinary * carbonDioxideBinary;
    }

    private static List<string> GetAmountOfNumberForOxygen(List<string> inputs, int index)
    {
        var countZeros = 0;
        var Zeros = new List<string>();
        var countOnes = 0;
        var Ones = new List<string>();

        foreach(int i in 0..inputs.Count)
        {
            if(inputs[i][index] == '0')
            {
                countZeros++;
                Zeros.Add(inputs[i]);
            }
            else
            {
                countOnes++;
                Ones.Add(inputs[i]);
            }
        }      

        Console.WriteLine($"Amount of 0s for the index {index}: {countZeros}");
        Console.WriteLine($"Amount of 1s for the index {index}: {countOnes}");

        if(Ones.Count >= Zeros.Count)
        {
            Console.WriteLine("Ones is bigger");
        }
        else
        {
            Console.WriteLine("Zeros is bigger");
        }
        
        Console.WriteLine(new string('-', 20));
        return Ones.Count >= Zeros.Count ? Ones : Zeros;
    }

    private static List<string> GetAmountOfNumberForCarbonDioxide(List<string> inputs, int index)
    {
        var countZeros = 0;
        var Zeros = new List<string>();
        var countOnes = 0;
        var Ones = new List<string>();

        for(int i = 0; i < inputs.Count;i++)
        {
            if(inputs[i][index] == '0')
            {
                countZeros++;
                Zeros.Add(inputs[i]);
            }
            else
            {
                countOnes++;
                Ones.Add(inputs[i]);
            }
        }      

        Console.WriteLine($"Amount of 0s for the index {index}: {countZeros}");
        Console.WriteLine($"Amount of 1s for the index {index}: {countOnes}");

        if(Zeros.Count <= Ones.Count)
        {
            Console.WriteLine("Zeros is lesser");
        }
        else
        {
            Console.WriteLine("Ones is lesser");
        }

        Console.WriteLine(new string('-', 20));

        return Zeros.Count <= Ones.Count ? Zeros : Ones;
    }

    private static int BinaryToDecimal(string binary)
    {
        var result = 0;
        for (int i = 0; i < binary.Length; i++)
        {
            var reverseIndex = (double)binary.Length - 1 - i;
            result += (int)(Math.Pow(2.0, reverseIndex) * (binary[i] - '0'));
        }

        return result;
    }
}