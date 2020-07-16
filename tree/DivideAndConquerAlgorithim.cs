using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable_Final
{
    class DivideAndConquer
    {
        private Node[] quicklist;
        private int nodeCount;

        public DivideAndConquer(Node head, Node newNode)
        {
            nodeCount = countNodes(head);
        }

        private void makeArray(Node begin, Node end)
        {
            Node temp = begin;
            int n = 0;
            quicklist = new Node[nodeCount];
            quicklist[n++] = begin;

            do
            {
                temp = temp.next;
                quicklist[n++] = temp;
            } while (temp!=null && end != temp);//stop if temp is null or if temp.prev=end
        }

        private int countNodes(Node begin)
        {
            Node temp = begin;
            int count = 0;

            do
            {
                temp = temp.next;
                count++;
            } while (temp != null);

            return count;
        }

        private int countNodes(Node begin, Node end)
        {
            Node temp = begin;
            int count = 1;

            do
            {
                temp = temp.next;
                count++;
            } while (temp != null && temp != end);

            return count;
        }

        public Node findIP(Node begin, Node newNode)
        {
            Node end = findLastNode(begin);

            if(nodeCount < 4)
                return binarySearch(begin, end, newNode);

            quicklist = new Node[nodeCount];
            makeArray(begin, end);

            int start = 0;
            int finish = quicklist.Length-1;
            int mid = quicklist.Length / 2;

            while (true)
            {
                if (newNode.getFirstName().CompareTo(quicklist[mid].getFirstName()) < 0)//match is in the first half of quicklist
                    finish = mid;
                else
                    start = mid;

                nodeCount = countNodes(quicklist[start], quicklist[finish]);// begin, end);

                makeArray(quicklist[start], quicklist[finish]);

                if (start - finish < 4)
                   return  binarySearch(quicklist[0], quicklist[nodeCount-1], newNode);
            }
        }

        private Node binarySearch(Node begin, Node end, Node newNode)
        {
            Node temp = begin;

            do
            {
                if (newNode.getFirstName().CompareTo(temp.getFirstName()) < 0)
                    return temp;
                temp = temp.next;
            } while (temp !=null && temp.prev != end);

            return null;
        }

        private Node findLastNode(Node begin)
        {
            Node temp = begin;

            while (temp.next != null)
            {
                temp = temp.next;
            } 

            return temp;
        }
    }
}
