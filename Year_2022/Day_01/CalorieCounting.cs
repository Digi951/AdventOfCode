using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventToCode.Extensions;

namespace AdventToCode.Year_2022.Day_01;

public static class CalorieCounting
{
    public static Int32 Calculate(List<String> input)
    {
        Int32 output = 0;
        Int32 temp = 0;

        foreach (Int32 i in  0..input.Count)
        {
            if(i + 1 < input.Count && input[i] != String.Empty)
            {
                temp += Int32.Parse(input[i]);
            }

            if (input[i] == String.Empty)
            {
                if(temp > output)
                {
                    output = temp;
                }
                
                temp = 0;
            }
        }

        return output;
    }

    public static Int32 CalculateTopThree(List<String> input)
    {
        var output = new Int32[3];

        var temp = 0;

        foreach (Int32 i in 0..input.Count)
        {
            if(i + 1 < input.Count && input[i] != String.Empty)
            {
                temp += Int32.Parse(input[i]);
            }

            if (input[i] == String.Empty)
            {
                if(temp > output[0])
                {
                    output[2] = output[1];
                    output[1] = output[0];
                    output[0] = temp;
                }

                if(temp < output[0] && temp > output[1])
                {
                    output[2] = output[1];
                    output[1] = temp;
                }

                if(temp < output[1] && temp > output[2])
                {
                    output[2] = temp;
                }
                
                temp = 0;
            }
        }

        return output[0] + output[1] + output[2];
    }
}