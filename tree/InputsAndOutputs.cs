using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable_Final
{
    class InputsAndOutputs
    {
        public InputsAndOutputs() { }

        public void displayMessageFromProgram(String message)
        {
            Console.WriteLine("\n" + message + "\n");
        }

        public String obtainStringInputFromUser(String message)
        {
            Console.Write("\n" + message + "  ");
            return Console.ReadLine();
        }
    }
}
