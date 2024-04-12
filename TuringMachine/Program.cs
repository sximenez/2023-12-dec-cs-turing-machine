namespace TuringMachine
{
    class TuringMachine
    {
        private class TuringMachine1
        {
            // Input: the machine receives a ribbonLength, an initial index and state.
            public static void Machine(int ribbonLength, int index, int state)
            {
                // , , , , , , , , , , , , , , , , , , ,
                int?[] ribbon = new int?[ribbonLength];
                Console.WriteLine(string.Join(", ", ribbon));

                // Instructions: based on the state, the machine writes a value on the ribbon.
                while (index < ribbon.Length)
                {
                    if (state == 1)
                    {
                        if (ribbon[index] == null)
                        {
                            // Operation 1.
                            ribbon[index] = 1;
                            index += 1;
                            state = 2;
                        }
                    }
                    else if (state == 2)
                    {
                        if (ribbon[index] == null)
                        {
                            // Operation 2.
                            ribbon[index] = 0;
                            index += 1;
                            state = 1;
                        }
                    }
                    else
                    {
                        // Avoid an endless loop.
                        index = ribbon.Length;
                    }
                }

                // Output: final state.
                // 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0
                Console.WriteLine(string.Join(", ", ribbon));
            }
        }

        private class TuringMachine2
        {
            // New function containing the abstracted instructions.
            public static int TransitionTable(int?[] ribbon, int index, int state)
            {
                if (state == 1)
                {
                    if (ribbon[index] == null)
                    {
                        ribbon[index] = 1;
                        state = 2;
                    }
                }
                else if (state == 2)
                {
                    if (ribbon[index] == null)
                    {
                        ribbon[index] = 0;
                        state = 1;
                    }
                }
                else
                {
                    // Avoid an endless loop.
                    index = ribbon.Length;
                }

                return state;
            }

            public static void Machine(int ribbonLength, int index, int state)
            {
                // , , , , , , , , , , , , , , , , , , ,
                int?[] ribbon = new int?[ribbonLength];
                Console.WriteLine(string.Join(", ", ribbon));

                while (index < ribbon.Length)
                {
                    state = TransitionTable(ribbon, index, state);
                    index += 1;
                }

                // 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0
                Console.WriteLine(string.Join(", ", ribbon));
            }
        }

        private class TuringMachine3
        {
            public static int TransitionTable(int?[] ribbon, int index, int state)
            {
                if (state == 1)
                {
                    if (ribbon[index] == null)
                    {
                        ribbon[index] = 1;
                        state = 2;
                    }
                }
                else if (state == 2)
                {
                    if (ribbon[index] == null)
                    {
                        ribbon[index] = 0;
                        state = 1;
                    }
                }
                else
                {
                    index = ribbon.Length;
                }

                return state;
            }

            public static int?[] Machine(int?[] ribbon, int index, int state)
            {
                // Avoid an endless loop.
                if (index < ribbon.Length)
                {
                    state = TransitionTable(ribbon, index, state);
                    
                    // Recursive operation.
                    Machine(ribbon, index + 1, state);
                }

                return ribbon;
            }
        }

        public static void Main()
        {
            TuringMachine1.Machine(20, 0, 1);
            TuringMachine2.Machine(20, 0, 1);

            // , , , , , , , , , , , , , , , , , , ,
            int?[] input = new int?[20];
            Console.WriteLine(string.Join(", ", input));
            
            int?[] output = TuringMachine3.Machine(input, 0, 1);
            
            // 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0
            Console.WriteLine(string.Join(", ", output));
        }
    }
}