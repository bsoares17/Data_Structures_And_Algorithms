using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable_Final
{
    class ControlTable
    {
        HashTable theHashTable = new HashTable();
        LinkedList theLinkedList;
        //private Node[] theLinkedListHeads = null;
        //HashTable ht = new HashTable();

        public ControlTable()
        {
            InputsAndOutputs IO = new InputsAndOutputs();
            String choice;

            String menu = "Hash Table\n";
            menu += "0 - exit\n";
            menu += "1 - add node to the table\n";
            menu += "2 - find a node in the hash table\n";
            menu += "3 - look at all the nodes in the hash table\n";

            while (true)
            {
                choice = IO.obtainStringInputFromUser(menu);

                switch (choice[0])
                {
                    case '0':
                        Environment.Exit(0);
                        break;
                    case '1':
                        addNodeToTheTable(IO);
                        break;
                    case '2':
                        theHashTable.findNodeInList(IO);
                        break;
                    case '3':
                        lookAtTheTheHeadsInTheTable();
                        break;
                }
            }
        }
      
        private void addNodeToTheTable(InputsAndOutputs IO)
        {
            HashingAlgorithm ha = new HashingAlgorithm();
            Node tempNode = new Node();
            initializeNode(tempNode, IO);
            int n = ha.hashThis(tempNode.getFirstName());
            theLinkedList = theHashTable.retrieveOneHashedList(n);

            theHashTable.addItemToTable(tempNode);
             
            //Node tempNode = new Node();
            //initializeNode(tempNode, IO);

            //theHashTable.addItemToTable(tempNode);
        }

        public void initializeNode(Node temp, InputsAndOutputs IO)
        {
            //ask for first name
            temp.setFirstName(IO.obtainStringInputFromUser("first name  "));
            //ask for last name
            temp.setLastName(IO.obtainStringInputFromUser("last name  "));
        }
        
        private void lookAtTheTheHeadsInTheTable()
        {
            new DisplayHashTable(theHashTable);
        }
    }
}
