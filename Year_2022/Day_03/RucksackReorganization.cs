using System;

namespace AdventToCode.Year_2022.Day_03;

public static class RucksackReorganization
{
    // ASCII A = 65 / Z = 90 -> Priority 27 / 52
    // ASCII a = 97 / z = 122 -> Priority 1 / 26
    // Lowercase = Char(ASCII) - 96
    // Uppercase = Char(ASCII) - 64 + 26 = 38

    const Int32 offset_Lowercase = 96;
    const Int32 offset_Uppercase = 38;

    public static Int32 Calculate(List<String> inputs)
    {
        var result = 0;

        String compartmentLeft = String.Empty;
        String compartmentRight = String.Empty;

        foreach (var input in inputs)
        {
            var length = input.Length / 2;

            compartmentLeft = input[0..(length)];
            compartmentRight = input[length..input.Length];

            foreach (var part in compartmentLeft)
            {
                if (compartmentRight.Contains(part))
                {       
                    if (part >= 'a' && part <= 'z')
                    {
                        result += part - offset_Lowercase;
                    }

                    if (part >= 'A' && part <= 'Z')
                    {
                        result += part - offset_Uppercase;
                    }

                    break;
                }
            }
        }

        return result;
    }

    public static Int32 Calculate2(List<String> inputs)
    {
        var result = 0;

        String compartmentOne = String.Empty;
        String compartmentTwo = String.Empty;
        String compartmentThree = String.Empty;

        for (int i = 0; i < inputs.Count / 3; i++)
        {
            compartmentOne = inputs[i * 3 + 0];
            compartmentTwo = inputs[i * 3 + 1];
            compartmentThree = inputs[i * 3 + 2];

            foreach (var part in compartmentOne)
            {
                if (compartmentTwo.Contains(part) && compartmentThree.Contains(part))
                {
                    if (part >= 'a' && part <= 'z')
                    {
                        result += part - offset_Lowercase;
                    }

                    if (part >= 'A' && part <= 'Z')
                    {
                        result += part - offset_Uppercase;
                    }

                    break;
                }
            }
        }

        return result;
    }

}

