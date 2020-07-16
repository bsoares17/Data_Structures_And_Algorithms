using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable_Final
{
    class Node
    {
        public Node next = null;
        public Node prev = null;
        private String firstName;
        private String lastName;

        public Node() { }

        public bool setFirstName(String s)
        {
            firstName = s;
            return true;
        }

        public String getFirstName()
        {
            return firstName;
        }

        public bool setLastName(String s)
        {
            lastName = s;
            return true;
        }

        public String getLastName()
        {
            return lastName;
        }
    }
}

