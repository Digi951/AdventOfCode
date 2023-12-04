namespace AdventOfCode.Year_2023.Day_04;

public static class ScratchCards
{
 public static Int32 Calculate(List<String> lines)
 { 
     Int32 result = 0;

     foreach (var line in lines)
     {
         var scratchCards = line.Split(':')[1];

         var winningNumbers = scratchCards
             .Split('|')[0]
             .Split(' ')
             .Where(numString => int.TryParse(numString, out _))
             .Select(int.Parse)
             .ToList();
         
         var numbersIHave = scratchCards
             .Split('|')[1]
             .Split(' ')
             .Where(numString => int.TryParse(numString, out _))
             .Select(int.Parse)
             .ToList();

         Int32 matches = winningNumbers.Intersect(numbersIHave).Count();

         Int32 value = matches == 0 ? 0 : (Int32)Math.Pow(2, matches - 1);

         result += value;
     }

     return result;
 }
 
 public static Int32 CalculatePartTwo(List<String> lines)
 {
     Int32[] cardCount = Enumerable.Repeat(1, lines.Count).ToArray();

     for (var i = 0; i < lines.Count; i++)
     {
         var line = lines[i];
         var scratchCards = line.Split(':')[1];

         var winningNumbers = scratchCards
             .Split('|')[0]
             .Split(' ')
             .Where(numString => int.TryParse(numString, out _))
             .Select(int.Parse)
             .ToList();

         var numbersIHave = scratchCards
             .Split('|')[1]
             .Split(' ')
             .Where(numString => int.TryParse(numString, out _))
             .Select(int.Parse)
             .ToList();

         Int32 matches = winningNumbers.Intersect(numbersIHave).Count();

         for (int j = 0; j < matches; j++)
         {
             cardCount[i + 1 + j] += cardCount[i];
         } 
     }

     return cardCount.Sum();
 }
}