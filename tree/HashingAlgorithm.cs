using System;
using System.Collections.Generic;
using System.Text;

namespace HashTable_Final
{
    class HashingAlgorithm
    {
        //the result of this algorithm can never be negative
        private int hashValue = -1;
        private int numPossibleHashValues = 10;

        public HashingAlgorithm() { }

        public HashingAlgorithm(int numValues)
        {
            numPossibleHashValues = numValues;
        }

        public int hashThis(String s)
        {
            setHashValue(s);

            return hashValue;
        }

        public int setHashValue(String itemToHash)
        {
            //make sure there is something to hash
            if (itemToHash == null || itemToHash.Length == 0)
                return hashValue;

            //initialize hashValue to remove the -1 signal that it is uninitialized
            hashValue = 0;

            //make hash value = sum of the unicode value of each char in the string
            for (int n = 0; n < itemToHash.Length; n++)
                hashValue += (int)itemToHash[n];

            //modulus hashValue to ensure the result will be between 0 and numPossibleHashValues-1
            hashValue = hashValue % numPossibleHashValues;

            return hashValue;
        }
    }
}
