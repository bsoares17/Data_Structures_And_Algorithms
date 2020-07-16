using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HashTable_Final
{
    class HashTable
    {
        private InputsAndOutputs IO = new InputsAndOutputs();
        private Node[] theLinkedListHeads = null;
        private const int numberHashValues = 100;//determines number of index in table
        private LinkedList[] hashedList = new LinkedList[numberHashValues];

        public HashTable()
        {
            theLinkedListHeads = new Node[numberHashValues];  
        }

        public LinkedList retrieveOneHashedList(int n)
        {
            return hashedList[n];
        }

        public Node[] getTheLinkedListHeads()
        {
            return theLinkedListHeads;
        }

        public void addItemToTable(Node temp)
        {
            HashingAlgorithm ha = new HashingAlgorithm(numberHashValues);
            int hashedValue = 0;

            hashedValue = ha.hashThis(temp.getFirstName());   // hash key value in node by calling HashingAlgorithm

            if (theLinkedListHeads[hashedValue] == null)//unique new value
            {//this is where you assign head for hashedValue to the new node, temp
                IO.displayMessageFromProgram(temp.getFirstName() + " is a unique value");

                theLinkedListHeads[hashedValue] = temp; //put node in hash table at location theLinkedListHeads[hashedValue]
            }
            else
            {//this is where you add the node to the ordered linked list
                IO.displayMessageFromProgram(temp.getFirstName() + " replicates a hash value already in the table, "
                    + theLinkedListHeads[hashedValue].getFirstName());

                LinkedList thisList = new LinkedList(theLinkedListHeads[hashedValue]);
                thisList.addNodeToList(temp);

                theLinkedListHeads[hashedValue] = thisList.getHead();//resets head
            }
        }

        public void findNodeInList(InputsAndOutputs IO)
        {
            HashingAlgorithm ha = new HashingAlgorithm(numberHashValues);
            String findName = IO.obtainStringInputFromUser("what first name should we find?");

            int findHash = ha.hashThis(findName);

            //needs to be something in the head to find it
            if (theLinkedListHeads[findHash].getFirstName().Equals(findName))
                IO.displayMessageFromProgram("found " + findName + " in the table at hash value " + findHash);
            else
                IO.displayMessageFromProgram(findName + " is not in the table");
        }
    }
}
