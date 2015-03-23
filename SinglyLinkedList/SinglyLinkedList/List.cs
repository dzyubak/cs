/*
 * Copyright (C) 2013, 2015 Dmytro Dzyubak
 * 
 * This file is part of SinglyLinkedList.
 * 
 * SinglyLinkedList is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * SinglyLinkedList is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with SinglyLinkedList. If not, see <http://www.gnu.org/licenses/>.
 */

using System;

namespace SinglyLinkedList
{
    /// <summary>
    /// This class describes a Singly linked list
    /// </summary>
    class List
    {
        Element first;
        
        public List()
        {
            first = null;
        }
        
        public List(int data)
        {
            first = new Element(data, null);
        }
        
        public List(List list)
        {
            if (list.first == null)
            {
                throw new ListException("Error! The list is empty. Nothing to copy.");
            }
            Element SourceCurrent = list.first;
            while (SourceCurrent != null)
            {
                insert(SourceCurrent.Data);
                SourceCurrent = SourceCurrent.Next;
            }
        }
        
        public int Length
        {
            get
            {
                Element current = first;
                int counter = 0;
                while (current != null)
                {
                    current = current.Next;
                    counter++;
                }
                return counter;
            }
            //set must not be implemented for Length property
        }
        
        public int this[int idx]
        {
            get
            {
                if (idx < 0)
                {
                    throw new ListException("Error! Indexer value can not be less then zero.");
                }
                if (first == null) { throw new ListException("The list is empty."); }
                Element current = first;
                for (int i = 0; current != null & i <= idx; i++, current = current.Next)
                {
                    if (i == idx) { return current.Data; }
                }
                throw new ListException("Error! Index out of range exception.");
            }
            //set { }
        }
        
        public int this[int idx1, int idx2]
        {
            get
            {
                if(idx1 < 0 || idx2 < 0)
                {
                    throw new ListException("Error! Indexer value can not be less then zero.");
                }
                int min;
                min = findMinValueBetweenIdx1Idx2(idx1, idx2);
                return min;
            }
            //set { }
        }
        
        private void swap(ref int i, ref int j)
        {
            int tmp;
            tmp = i;
            i = j;
            j = tmp;
        }
        
        private int findMinValueBetweenIdx1Idx2(int index1, int index2)
        {
            // "if (index1 == index2)" condition can be eliminated by using ...
            // ... "while (index1 > 0)" and "while (index2 >= 0)"
            if (index1 > index2)
            {
                Console.WriteLine("Warning! Index swapping has taken place.");
                swap(ref index1, ref index2);
            }
            // number of index1 iterations will already happen before index2 iterations
            index2 = index2 - index1;
            index2++;
            //
            Element current = first;
            while ( (current != null) & (index1 > 0) ) // loop through to the "find" position
            {
                current = current.Next;
                index1--;
            }
            if (current == null)
            {
                throw new ListException("Start number is greater,"
                                  + " then number of elements in the current list.");
            }
            // "current" is set to the start position now
            int min = Int32.MaxValue; // 2,147,483,647 OR 0x7FFFFFFF
            while ((current != null) & (index2 > 0)) // find min value from the "current" position
            {
                if (current.Data < min)
                {
                    min = current.Data;
                }
                current = current.Next;
                index2--;
            }
            if ((current == null) & (index2 != 0))
            {
                throw new ListException("End number is greater,"
                                  + " then number of elements in the current list.");
            }
            return min;
        }
        
        /// <summary>
        /// insert the first element, if the list is empty
        /// </summary>
        /// <remark>
        /// can also be: <c>return first = new Element(data, first);</c>
        /// </remark>
        private Element insertFirst(int data)
        {
            return first = new Element(data, null);
        }
        
        // insert element at the beginning of the list
        public Element insertBeginning(int data)
        {
            if (first == null) { return insertFirst(data); }
            else {
                return insertBeforeReference(data, first);
            }
        }
        
        public Element insertEnd(int data)
        {
            if (first == null) { return insertFirst(data); }
            Element current = first;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = new Element(data, null);
            return current.Next;
        }
        
        public Element insertEndRecursive(int data,
                                       Element current = null,
                                       bool flag = false)
        {
            if (first == null) { return insertFirst(data); }
            if (current == null & !flag)
            {
                current = first;
                flag = true;
            }
            // if we have reached the end of the list
            if (current.Next == null & flag)
            {
                current.Next = new Element(data, null); // insert new element at the end
                return current.Next;
            }
            return insertEndRecursive(data, current.Next, flag);
        }
        
        public Element insertBeginningSameAsEndRecursive(Element current = null,
                                                     bool flag = false)
        {
            if (first == null)
            {
                throw new ListException("Error! Can not get the last element,"
                                    + " because the list is empty.");
            }
            if (current == null & !flag)
            {
                current = first;
                flag = true;
            }
            // if we have reached the end of the list
            if (current.Next == null & flag) {
                return insertBeginning(current.Data);
            }
            return insertBeginningSameAsEndRecursive(current.Next, flag);
        }
        
        public Element insertAfterValue(int data, int key)
        {
            if (first == null)
            {
                Console.WriteLine("Warning! The list was empty."
                                  + " Element value \"" + key + "\" has not been used.");
                return insertFirst(data);
            }
            Element current = first;
            while (current.Next != null & current.Data != key)
            {
                current = current.Next;
            }
            // if the value was not found do not insert and throw exception
            if (current.Next == null & current.Data != key)
            {
                throw new ListException("Error! The key value was not found in the current list."
                                    + " Insertion of \"" + data + "\" has not happend.");
            }
            current.Next = new Element(data, current.Next);
            return current.Next;
        }
        
        public int insertAfterValueAll(int data, int key)
        {
            if (first == null)
            {
                throw new ListException("Error! The list is empty. Nothing to remove.");
            }
            int count = 0; // number of removed elements (counter)
            // in case the first element is the key
            if (first.Data == key)
            {
                first.Next = new Element(data, first.Next);
                count++;
            }
            // in case any other elements have keys
            Element current = first.Next;
            while (current.Next != null)
            {
                if (current.Data == key)
                {
                    current.Next = new Element(data, current.Next);
                    count++;
                }
                current = current.Next;
            }
            // in case the last element of the list is the key
            if (current.Data == key)
            {
                current.Next = new Element(data, current.Next);
                count++;
            }
            return count;
        }
        
        public Element insertAfterReference(int data, Element key)
        {
            if (first == null)
            {
                Console.WriteLine("Warning! The list was empty."
                                  + " Element reference has not been used.");
                return insertFirst(data);
            }
            Element current = first;
            while (current.Next != null & current != key)
            {
                current = current.Next;
            }
            // if the element was not found do not insert and throw exception
            if (current.Next == null & current != key)
            {
                throw new ListException("Error! The key reference was not found in the current list."
                                    + " Insertion of \"" + data + "\" has not happend.");
            }
            current.Next = new Element(data, current.Next);
            return current.Next;
        }
        
        public Element insertBeforeValue(int data, int key)
        {
            if (first == null)
            {
                Console.WriteLine("Warning! The list was empty. \"" + data
                                  + "\" has been inserted as the first element.");
                return insertFirst(data);
            }
            if (first.Data == key) // if first element is the key
            {
                first = insertBeginning(data);
                return first;
            }
            Element current = first;
            while (current.Next.Next != null & current.Next.Data != key)
            {
                current = current.Next;
            }
            // if the value was not found do not insert and throw exception
            if (current.Next.Next == null & current.Next.Data != key)
            {
                throw new ListException("Error! The key value was not found in the current list."
                                    + " Insertion of \"" + data + "\" has not happend.");
            }
            current.Next = new Element(data, current.Next);
            return current.Next;
        }
        
        public Element insertBeforeReference(int data, Element key)
        {
            if (first == null)
            {
                Console.WriteLine("Warning! The list was empty."
                                  + " Element reference has not been used.");
                return insertFirst(data);
            }
            if (first == key) // if first element is the key
            {
                first = new Element(data, first);
                return first;
            }
            Element current = first;
            while (current.Next != null & current.Next != key)
            {
                current = current.Next;
            }
            // if the value was not found do not insert and throw exception
            if (current.Next == null & current.Next != key)
            {
                throw new ListException("Error! Element was not found in the current list."
                                    + " Insertion of \"" + data + "\" has not happend.");
            }
            current.Next = new Element(data, current.Next);
            return current.Next;
        }
        
        public Element insert(int data)
        {
            if (first == null)
            {
                //Console.WriteLine("list is empty");            // use for debugging
                //Console.WriteLine("first element is created"); // use for debugging
                return insertFirst(data);
            }
            else
            {
            	//Console.WriteLine("element is inserted to the end of the list");
                return insertEnd(data);
            }
        }
        
        /// <summary>
        /// returns number of removed elements
        /// </summary>
        public int removeAllByValue(int key)
        {
            if (first == null)
            {
                throw new ListException("Error! The list is empty. Nothing to remove.");
            }
            int count = 0; // number of removed elements (counter)
            // in case the first element should be removed
            while (first.Data == key & first != null)
            {
                first = first.Next;
                count++;
                // in case all elements have been removed, now the list is empty
                if (first == null) { return count; }
            }
            // in case any other elements should be removed
            Element current = first;
            while (current.Next != null)
            {
                // in case several elements in a row should be removed
                while (current.Next.Data == key)
                {
                    current.Next = current.Next.Next;
                    count++;
                    // in case the last element has been removed
                    if (current.Next == null) { return count; }
                }
                current = current.Next;
            }
            return count;
        }
        
        /// <summary>
        /// returns number of removed elements
        /// </summary>
        public int removeAllByValueRecursive(int key,
                                           Element current = null,
                                           // number of removed elements (counter)
                                           int count = 0,
                                           bool flag = false)
        {
            if (first == null)
            {
                throw new ListException("Error! The list is empty. Nothing to remove.");
            }
            if (current == null & !flag)
            {
                // in case the first element should be removed
                while (first.Data == key & first != null)
                {
                    first = first.Next;
                    count++;
                    // in case all elements have been removed, now the list is empty
                    if (first == null) { return count; }
                }
                // in case any other elements should be removed
                current = first;
                flag = true;
            }
            // if we have reached the end of the list
            if (current.Next == null & flag) { return count; }
            // in case several elements in a row should be removed
            while (current.Next.Data == key)
            {
                current.Next = current.Next.Next;
                count++;
                // in case the last element has been removed
                if (current.Next == null) { return count; }
            }
            count = removeAllByValueRecursive(key, current.Next, count, flag);
            return count;
        }
        
        public void removeByReference(Element key)
        {
            if (first == null)
            {
                throw new ListException("Error! The list is empty. Nothing to remove.");
            }
            // in case this was the first element
            if (first == key)
            {
                first = first.Next;
                return;
            }
            // in all other cases
            Element current = first;
            while (current.Next != null & current.Next != key)
            {
                current = current.Next;
            }
            // throw exception, if the element was not found and there is nothing to remove
            if (current.Next == null & current.Next != key)
            {
                throw new ListException("Error! Element was not found in the current list."
                                    + " Thus, there is nothing to remove.");
            }
            current.Next = current.Next.Next;
        }
        
        /// <summary>
        /// returns number of negative elements that have been removed
        /// </summary>
        public int removeAllNegative()
        {
            if (first == null)
            {
                throw new ListException("Error! The list is empty. Nothing to remove.");
            }
            int count = 0; // number of removed negative elements (counter)
            // in case first element is negative
            while (first.Data < 0 & first != null)
            {
                first = first.Next;
                count++;
                // in case the last element was negative
                // all elements in the list were negative, now the list is empty
                if (first == null) { return count; }
            }
            // in case any other elements are negative
            Element current = first;
            while (current.Next != null)
            {
                // in case several elements in a row are negative
                while (current.Next.Data < 0)
                {
                    current.Next = current.Next.Next;
                    count++;
                    // in case the last element was negative
                    if (current.Next == null) { return count; }
                }
                current = current.Next;
            }
            return count;
        }
        
        /// <summary>
        /// get Element Value by reference
        /// </summary>
        public int getElementByReference(Element key)
        {
            if (first == null)
            {
                throw new ListException("Error! The list is empty.");
            }
            Element current = first;
            while (current.Next != null && current != key)
            {
                current = current.Next;
            }
            if (current.Next == null && current != key)
            {
                throw new ListException("Error! Element was not found in the current list.");
            }
            return current.Data;
        }
        
        /// <summary>
        /// get Element Index by reference
        /// </summary>
        public int getIndexByReference(Element key)
        {
            if (first == null)
            {
                throw new ListException("Error! The list is empty.");
            }
            int index = 0;
            Element current = first;
            while (current.Next != null && current != key)
            {
                current = current.Next;
                index++;
            }
            if (current.Next == null && current != key)
            {
                throw new ListException("Error! Element was not found in the current list.");
            }
            return index;
        }
        
        public string listToString()
        {
            if(first == null)
            {
                return "The list is empty.";
            }
            string str = "";
            Element current = first;
            while (current != null)
            {
                str += current.Data + " ";
                current = current.Next;
            }
            return str.Trim();
        }
        
        /// <summary>
        /// method returns "reverse order"
        /// </summary>
        public string listToStringReverseRecursiveColumn(string reverse = "",
                                                   Element current = null,
                                                   bool flag = false)
        {
            if (first == null)
            {
                return "The list is empty.";
            }
            if (current == null & !flag)
            {
                current = first;
                flag = true;
            }
            // if we have reached the end of the list
            if (current == null & flag) { return ""; }
            reverse +=
                    listToStringReverseRecursiveColumn(reverse, current.Next, flag)
                    + String.Format("{0,5}\r\n", current.Data);
            return reverse;
        }
        
        public void printListToStringReverseRecursiveColumn(string reverse = "",
                                                   Element current = null,
                                                   bool flag = false)
        {
            if (first == null)
            {
                return;
            }
            if (current == null & !flag)
            {
                current = first;
                flag = true;
            }
            // if we have reached the end of the list
            if (current == null & flag) { return; }
            printListToStringReverseRecursiveColumn(reverse, current.Next, flag);
            Console.WriteLine("{0,5}", current.Data);
            /*reverse +=
                    printListToStringReverseRecursiveColumn(reverse, current.Next, flag)
                    + String.Format("{0,5}\r\n", current.Data);
            */
            return;
        }
        
        /// <summary>
        /// method returns "natural order" + "\r\n" + "reverse order"
        /// </summary>
        /// <remarks>
        /// "Stack Overflow Exception" can be created easily, if "flag" won't be set
        /// to "true" or if "flag" won't be passed as a parameter in the recursive call.
        /// </remarks>
        public string listToStringNaturalReverseRecursive(
                                            string natural = "", string reverse = "",
                                            Element current = null, bool flag = false)
        {
            if (first == null)
            {
                return "The list is empty.";
            }
            if (current == null & !flag) {
                current = first;
                flag = true;
            }
            // if we have reached the end of the list
            if (current == null & flag) { return ""; }
            natural = current.Data + " ";
            // if next method call will reach the end of the list ...
            // ... trim the last space and add newline character
            if (current.Next == null)
            {
                // "\r\n" is the divider that can be used to split the two strings
                natural = natural.Trim() + "\r\n";
            }
            reverse +=
                    listToStringNaturalReverseRecursive(natural, reverse,
                                                 current.Next, flag)
                    + current.Data + " "; // "current.Data" adds reverse string here
            // if current returned back to first, this is the last digit in a row, ...
            // ... thus trim the last space
            if (current == first) { reverse = reverse.Trim(); }
            return natural + reverse;
        }
        
        public void sortDescending()
        {
            if ( (first == null) || (first.Next == null) ) // 0 or 1 element, nothing to sort
            {
            	return;
            }
            Element current = first;
            int tmp;
            for (int i = 0; i < Length; i++)
            {
                while (current.Next != null)
                {
                    if (current.Data < current.Next.Data) // swap Data
                    {
                        tmp = current.Data;
                        current.Data = current.Next.Data;
                        current.Next.Data = tmp;
                    }
                    //else { } // do nothing
                    current = current.Next;
                }
                current = first;
            }
        }
    }
}