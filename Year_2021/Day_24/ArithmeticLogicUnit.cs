using System.Numerics;
using System.Text;
using AdventToCode.Year_2021.Helper;

namespace AdventToCode.Year_2021.Day_24;

public static class ArithmeticLogicUnit
{
    private static long _largestValue = 99999999999999;
    private static BigInteger _w = 0;
    private static BigInteger _x = 0;
    private static BigInteger _y = 0;
    private static BigInteger _z = 0;

    private static readonly int[] _a = { 1,  1,  1,  1,  1, 26,  1,  26,  26,  1,  26, 26, 26, 26};
    private static readonly int[] _b = {10, 12, 13, 13, 14, -2, 11, -15, -10, 10, -10, -4, -1, -1};
    private static readonly int[] _c = { 0,  6,  4,  2,  9,  1, 10,   6,   4,  6,   3,  9, 15,  5};

    private static Stack<int> _inputNumbers = new();
    private static bool _withLogging = true;
    private static bool _withTextOutput = false;

    public static void Run(Queue<(string instruction, string first, string second)> instructions)
    {
        // RunUnoptimized(instructions);
        RunOptimized();
    }

    private static void RunOptimized()
    {
        do
        {
            InitializeQueue(_largestValue);
            var index = 0;
            ClearCache();
            while (_inputNumbers.Count > 0)
            {
                _w = _inputNumbers.Pop();
                _x = (BigInteger)(_z % 26 + _b[index] != _w ? 1 : 0);
                _z /= _a[index];
                _z *= 25 * _x + 1;
                _z += (_w + _c[index]) * _x;
                index++;   
            }

            Console.Write($"{_largestValue} -> ");
            if(_withTextOutput) FileWriter.WriteFile($"{_largestValue} -> ");
            Console.WriteLine($"{_w} {_x} {_y} {_z}");
            if(_withTextOutput) FileWriter.WriteLineFile($"{_w} {_x} {_y} {_z}");

            var printResult = _z == 0 ? "Success" : "Failure";
            if(_withLogging) Console.WriteLine(printResult);
            if(_withTextOutput) FileWriter.WriteLineFile(printResult);

            _largestValue--;
        
            if (_largestValue.ToString().Contains("0"))
            {
                _largestValue = ReplaceZero(_largestValue);
            } 
        //} while (false);
        } while (_z != 0);  
    }

    private static void RunUnoptimized(Queue<(string instruction, string first, string second)> instructions)
    {
        FileWriter.InitializieStreamWriter($"{_largestValue}.txt");

        do
        {
            ClearCache();
            var localInstructions = new Queue<(string instruction, string first, string second)>(instructions);
            InitializeQueue(_largestValue);
            while (localInstructions.Count > 0)
            {
            var instruction = localInstructions.Dequeue();

                if(_withLogging) Console.Write($"{instruction.instruction} {instruction.first} {instruction.second}: ");
                if(_withTextOutput) FileWriter.WriteFile($"{instruction.instruction} {instruction.first} {instruction.second}: ");
                
                switch (instruction.instruction)
                {
                    case "inp":
                        Input(instruction.first, _inputNumbers.Pop().ToString());
                        break;
                    case "add":
                        Add(instruction.first, instruction.second);
                        break;
                    case "mul":
                        Multiply(instruction.first, instruction.second);
                        break;
                    case "div":
                        Divide(instruction.first, instruction.second);
                        break;
                    case "mod":
                        Modulo(instruction.first, instruction.second);
                        break;
                    case "eql":
                        Equal(instruction.first, instruction.second);
                        break;
                    case "prt":
                        PrintValues();
                        break;
                } 
            }           
            Console.Write($"{_largestValue} -> ");
            FileWriter.WriteFile($"{_largestValue} -> ");
            Console.WriteLine($"{_w} {_x} {_y} {_z}");
            FileWriter.WriteLineFile($"{_w} {_x} {_y} {_z}");

            var printResult = _z == 0 ? "Success" : "Failure";
            if(_withLogging) Console.WriteLine(printResult);
            if(_withTextOutput) FileWriter.WriteLineFile(printResult);
            
            _largestValue--;
       
            if (_largestValue.ToString().Contains("0"))
            {
                _largestValue = ReplaceZero(_largestValue);
            }      
                                   
        } while (false);
        //} while (_z != 0);

        FileWriter.CloseStreamWriter();
    }

    private static void PrintValues()
    {
        if(_withLogging) Console.WriteLine($"{_w} {_x} {_y} {_z}");
        if(_withTextOutput) FileWriter.WriteLineFile($"{_w} {_x} {_y} {_z}");
    }

    private static void Input(string first, string second)
    { 
        SetVariable(first, second);
        if(_withLogging) Console.WriteLine($"{first} = {GetVariable(first)}");
        if(_withTextOutput) FileWriter.WriteLineFile($"{first} = {GetVariable(first)}");
    }

    private static void Add(string first, string second)
    {
        BigInteger firstInput = BigInteger.TryParse(first, out BigInteger firstValue) ? firstValue : GetVariable(first);
        BigInteger secondInput = BigInteger.TryParse(second, out BigInteger secondValue) ? secondValue : GetVariable(second);
        BigInteger result = firstInput + secondInput;
        SetVariable(first, result.ToString());

        if(_withLogging) Console.WriteLine($"({first}){firstInput} + ({second}){secondInput} = {firstInput + secondInput} in {first}");
        if(_withTextOutput) FileWriter.WriteLineFile($"({first}){firstInput} + ({second}){secondInput} = {firstInput + secondInput} in {first}");
    }

    private static void Multiply(string first, string second)
    {
        BigInteger firstInput = BigInteger.TryParse(first, out BigInteger firstValue) ? firstValue : GetVariable(first);
        BigInteger secondInput = BigInteger.TryParse(second, out BigInteger secondValue) ? secondValue : GetVariable(second);
        BigInteger result = firstInput * secondInput;
        SetVariable(first, result.ToString());

        if(_withLogging) Console.WriteLine($"({first}){firstInput} * ({second}){secondInput} = {firstInput * secondInput} in {first}");
        if(_withTextOutput) FileWriter.WriteLineFile($"({first}){firstInput} * ({second}){secondInput} = {firstInput * secondInput} in {first}");
    }

    private static void Divide(string first, string second)
    {
        BigInteger firstInput = BigInteger.TryParse(first, out BigInteger firstValue) ? firstValue : GetVariable(first);
        BigInteger secondInput = BigInteger.TryParse(second, out BigInteger secondValue) ? secondValue : GetVariable(second);
        if(secondInput > 0)
        {
            if(_withLogging) Console.WriteLine($"({first}){firstInput} / ({second}){secondInput} = {firstInput / secondInput} in {first}");
            if(_withTextOutput) FileWriter.WriteLineFile($"({first}){firstInput} / ({second}){secondInput} = {firstInput / secondInput} in {first}");

            BigInteger result = firstInput / secondInput;
            SetVariable(first, result.ToString());
        }
        else
        {
            if(_withLogging) Console.WriteLine("Division by zero");
            if(_withTextOutput) FileWriter.WriteLineFile("Division by zero");
        }
    }

    private static void Modulo(string first, string second)
    {
        BigInteger firstInput = BigInteger.TryParse(first, out BigInteger firstValue) ? firstValue : GetVariable(first);
        BigInteger secondInput = BigInteger.TryParse(second, out BigInteger secondValue) ? secondValue : GetVariable(second);

        if (firstInput > 0 && secondInput > 0)
        {
            BigInteger result = firstInput % secondInput;
            SetVariable(first, result.ToString());

            if(_withLogging) Console.WriteLine($"({first}){firstInput} % ({second}){secondInput} = {firstInput % secondInput} in {first}");
            if(_withTextOutput) FileWriter.WriteLineFile($"({first}){firstInput} % ({second}){secondInput} = {firstInput % secondInput} in {first}");
        }
        else
        {
            if(_withLogging) Console.WriteLine("Modulo by zero");
            if(_withTextOutput) FileWriter.WriteLineFile("Modulo by zero");
        }
    }

    private static void Equal(string first, string second)
    {
        BigInteger firstInput = BigInteger.TryParse(first, out BigInteger firstValue) ? firstValue : GetVariable(first);
        BigInteger secondInput = BigInteger.TryParse(second, out BigInteger secondValue) ? secondValue : GetVariable(second);

        if (firstInput == secondInput)
        {
            SetVariable(first, "1");

            if(_withLogging) Console.WriteLine($"({first}){firstInput} == ({second}){secondInput}. Set {first} to 1");
            if(_withTextOutput) FileWriter.WriteLineFile($"({first}){firstInput} == ({second}){secondInput}. Set {first} to 1");
        }
        else
        {
            SetVariable(first, "0");

            if(_withLogging) Console.WriteLine($"({first}){firstInput} != ({second}){secondInput}. Set {first} to 0");
            if(_withTextOutput) FileWriter.WriteLineFile($"({first}){firstInput} != ({second}){secondInput}. Set {first} to 0");
        }
    }

    private static void SetVariable(string variable, string value)
    {
        _ = variable switch
        {
            "w" => _w = BigInteger.Parse(value),
            "x" => _x = BigInteger.Parse(value),
            "y" => _y = BigInteger.Parse(value),
            "z" => _z = BigInteger.Parse(value),
            _ => 0
        };
    }

    private static BigInteger GetVariable(string variable)
    {
        return variable switch
        {
            "w" => _w,
            "x" => _x,
            "y" => _y,
            "z" => _z,
            _ => 0
        };
    }
    
    private static void InitializeQueue(long input)
    {
        _inputNumbers.Clear();
        while (input > 0)
        {
            var number = input % 10;
            _inputNumbers.Push((int)number);
            input /= 10;
        }
    }

    private static long ReplaceZero(long value)
    {
        var valueAsStringBuilder = new StringBuilder(value.ToString());
                int indexOfZero = 0; 

                for(int i = 0; i < valueAsStringBuilder.Length; i++)
                {
                    if (valueAsStringBuilder[i] == '0')
                    {
                        indexOfZero = i;
                        valueAsStringBuilder[i] = '9';
                        valueAsStringBuilder[i - 1] = (char)(valueAsStringBuilder[i - 1] - 1);
                        break;
                    }
                }
        return long.Parse(valueAsStringBuilder.ToString());
    }

    private static void ClearCache()
    {
        _w = 0;
        _x = 0;
        _y = 0;
        _z = 0;
    }
}
