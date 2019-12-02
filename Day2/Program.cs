using System;
using System.Linq;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "1,0,0,3,1,1,2,3,1,3,4,3,1,5,0,3,2,6,1,19,1,5,19,23,2,9,23,27,1,6,27,31,1,31,9,35,2,35,10,39,1,5,39,43,2,43,9,47,1,5,47,51,1,51,5,55,1,55,9,59,2,59,13,63,1,63,9,67,1,9,67,71,2,71,10,75,1,75,6,79,2,10,79,83,1,5,83,87,2,87,10,91,1,91,5,95,1,6,95,99,2,99,13,103,1,103,6,107,1,107,5,111,2,6,111,115,1,115,13,119,1,119,2,123,1,5,123,0,99,2,0,14,0";

            var inputArray = input.Split(",").Select(i => int.Parse(i)).ToArray();
            PartOne(inputArray);
            PartTwo(inputArray);
        }

        private static void PartTwo(int[] inputArray)
        {
            var targetResult = 19690720;

            int result = 0;
            int correctNoun = 0;
            int correctVerb = 0;
            for (int noun = 0; noun <= 99; noun++)
            {
                for (int verb = 0; verb <= 99; verb++)
                {
                    result = GetProgramOutput(inputArray, noun, verb);
                    if (result == targetResult)
                    {
                        correctVerb = verb;
                        break;
                    }
                }    
                if (result == targetResult)
                {
                    correctNoun = noun;
                    break;
                }                
            }

            System.Console.WriteLine($"Noun: {correctNoun}, Verb: {correctVerb}");
            System.Console.WriteLine(100 * correctNoun + correctVerb);
        }

        private static void PartOne(int[] inputArray)
        {
            var result = GetProgramOutput(inputArray, 12, 2);

            System.Console.WriteLine(result);
        }

        private static int GetProgramOutput(int[] inputArray, int noun, int verb)
        {
            var workingArray = inputArray.Clone() as int[];


            workingArray[1] = noun;
            workingArray[2] = verb;

            var opCodePointer = 0;
            var opCode = 0;
            while (opCode != 99)
            {
                opCode = workingArray[opCodePointer];
                if (opCode != 99)
                {
                    if (opCode == 1)
                    {
                        workingArray[workingArray[opCodePointer + 3]] = workingArray[workingArray[opCodePointer + 1]] + workingArray[workingArray[opCodePointer + 2]];
                    }
                    else if (opCode == 2)
                    {
                        workingArray[workingArray[opCodePointer + 3]] = workingArray[workingArray[opCodePointer + 1]] * workingArray[workingArray[opCodePointer + 2]];
                    }

                    opCodePointer += 4;
                }
            }

            return workingArray[0];
        }
    }
}
