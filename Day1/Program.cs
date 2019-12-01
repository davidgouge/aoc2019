using System;
using System.Linq;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = @"148623
147663
67990
108663
62204
140999
123277
52459
143331
71135
76282
69509
72977
120407
62278
136882
131667
146225
112216
108600
127267
149149
72977
149639
101527
70059
124825
69539
141444
64138
71145
68178
134752
79431
126342
134161
135424
95647
54507
104852
100164
118799
57387
93136
133359
144942
89337
60441
131825
93943
98142
108306
55355
115813
83431
125883
101115
107938
103484
61174
123502
73670
91619
136860
93268
149648
105328
53194
115351
130953
85611
71134
141663
106590
56437
147797
98484
60851
121252
66898
56502
103796
86497
121534
70914
122642
53151
131939
108394
128239
103490
122304
113810
141469
79176
108002
91942
84400
101217
116287";

            PartOne(input);
            PartTwo(input);
        }

        private static void PartTwo(string input)
        {
            var listOfMass = input.Split(Environment.NewLine).Select(s => int.Parse(s));

            var totalFuel = listOfMass.Sum(mass => CalculateFuelPartTwo(mass));
            
            System.Console.WriteLine($"Part Two result: {totalFuel}");
        }

        private static int CalculateFuelPartTwo(int mass)
        {
            var fuelRequired = CalculateFuel(mass);
            var totalModuleFuel = 0;
            while (fuelRequired > 0)
            {
                totalModuleFuel += fuelRequired;
                fuelRequired = CalculateFuel(fuelRequired);
            }
            return totalModuleFuel;
        }

        private static void PartOne(string input)
        {
            var result = input.Split(Environment.NewLine)
                .Select(s => int.Parse(s)).Sum(mass => CalculateFuel(mass));

            System.Console.WriteLine($"Part One result: {result}");
        }

        private static int CalculateFuel(int mass)
        {
            return Math.Abs(mass / 3) - 2;
        }
    }
}
