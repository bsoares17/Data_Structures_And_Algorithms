using System;

namespace HashTable_Final
{
    class DisplayHashTable
    {
        public DisplayHashTable(HashTable theHashTable)
        {
            Node[] theTable = theHashTable.getTheLinkedListHeads();

            Console.WriteLine("\n");

            if (theTable == null)
                Console.Write("Empty Table");
            else
                displayHashTable(theTable);

            Console.WriteLine("\n");
        }

        private void displayHashTable(Node[] theTable)
        {
            Console.WriteLine("key  value");

            for (int n = 0; n < theTable.Length; n++)
                if (theTable[n] != null)
                    Console.WriteLine(n + "    " + theTable[n].getFirstName() + " " + theTable[n].getLastName());
                else
                    Console.WriteLine(n);
        }
    }
}
