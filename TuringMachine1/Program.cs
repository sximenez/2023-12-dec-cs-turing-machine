namespace TuringMachine1
{
    public static class TuringMachine
    {
        // Input: the machine receives a ribbonLength, an initial index and state
        public static void Machine(int ribbonLength, int index, int state)
        {
            // , , , , , , , , , , , , , , , , , , ,
            int?[] ribbon = new int?[ribbonLength];
            Console.WriteLine(string.Join(", ", ribbon));

            // Instructions: based on the state, the machine writes a value on the ribbon
            while (index < ribbon.Length)
            {
                if (state == 1)
                {
                    if (ribbon[index] == null)
                    {
                        // Operation 1
                        ribbon[index] = 1;
                        index += 1;
                        state = 2;
                    }
                }

                else if (state == 2)
                {
                    if (ribbon[index] == null)
                    {
                        // Operation 2
                        ribbon[index] = 0;
                        index += 1;
                        state = 1;
                    }
                }

                else
                {
                    // If error, terminate the program
                    index = ribbon.Length;
                }

            }

            // Output: final state
            // 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0
            Console.WriteLine(string.Join(", ", ribbon));
        }

        public static void Main()
        {
            Machine(20, 0, 1);
        }
    }
}