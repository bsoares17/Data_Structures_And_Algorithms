using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable_Final
{
    class LinkedList
    {
        private Node head;

        public LinkedList()
        {
            head = null;
        }

        public LinkedList(Node theHead)
        {
            head = theHead;
        }

        public Node getHead()
        {
            return head;
        }

        public void addNodeToList(Node newNode)
        {
            if (newNode == null)
                return;

            if (head == null)
                addHeadToList(newNode);
            else
                addNewNodeToList(newNode);
        }

        private void addHeadToList(Node newNode)
        {
            head = newNode;
        }

        private void addNewNodeToList(Node newNode)
        {
            Node ip = findInsertionPoint(newNode);

            if (ip == null)
                return;
            else
            {
                newNode.next = ip;
                newNode.prev = ip.prev;
                ip.prev.next = newNode;
                ip.prev = newNode;
            }
        }
      
        public Node findInsertionPoint(Node newNode)
        {
            Node temp = null;

            //newNode goes before existing head;
            if(newNode.getFirstName().CompareTo(head.getFirstName()) < 0)
            {
                newNode.next = head;
                head.prev = newNode;
                head = newNode;
                return null;
            }

            temp = findLastNode();
            //if new node goes after last node
            if (newNode.getFirstName().CompareTo(temp.getFirstName()) > 0)
            {
                temp.next = newNode;
                newNode.prev = temp;
                return null;
            }

            //newNode goes in the middle
            DivideAndConquer dc = new DivideAndConquer(head, newNode);

            return dc.findIP(head, newNode);
        }

        private Node findLastNode()
        {
            Node temp = head;

            while (temp.next != null)
            {
                temp = temp.next;
            }

            return temp;
        }
    }
}

