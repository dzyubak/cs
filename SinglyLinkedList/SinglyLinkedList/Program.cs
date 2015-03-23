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
	class Program
	{
		public static void Main(string[] args)
		{
			try
            {
                List list = new List(-3);
                list.insert(2);
                list.insert(30);
                list.insert(-3);
                Console.WriteLine(list.listToString());

                Console.WriteLine("Number of elements added: "
                                  + list.insertAfterValueAll(100, -3));
                Console.WriteLine("Number of elements added: "
                                  + list.insertAfterValueAll(300, 2));

                Console.WriteLine(list.listToString() + "\r\n");

                list.printListToStringReverseRecursiveColumn();
                
                list.sortDescending();
                Console.WriteLine("\r\n" + list.listToString() + "\r\n");
                
                Console.WriteLine("min value (list2[0, 5]): " + list[0, 5]);
                Console.WriteLine("min value (list2[5, 5]): " + list[5, 5]);
                Console.WriteLine("min value (list2[2, 2]): " + list[2, 2]);
                Console.WriteLine("min value (list2[4, 2]): " + list[4, 2] + "\r\n");
                
                Console.WriteLine(list.listToStringNaturalReverseRecursive() + "\r\n");

                Console.WriteLine(list.listToStringReverseRecursiveColumn());
                
                //list.insertBeforeValue(30, 20); // Error! Value "20" is not in the list yet.
                list.insert(20);
                list.insert(9);
                list.insert(9);
                list.insert(3);
                list.insert(-5);
                list.insert(11);
                
                list.insertBeforeValue(30, 11);
                list.insert(-8);
                list.insert(-7);
                list.insert(9);
                list.insert(-9);
                list.insert(35);
                list.insert(0);
                list.insert(-10);
                
                list.insertBeginning(77);
                list.insert(-20);
                list.insertEndRecursive(7);
                list.insert(-30);
                list.insertBeginningSameAsEndRecursive();
                
                Console.WriteLine(list.listToString() + "\r\n");
                
                Console.WriteLine("Copying \"list\" to \"list2\" using constructor.\r\n");
                List list2 = new List(list);
                
                Console.WriteLine("Number of negative elements that have been removed: "
                                  + list.removeAllNegative());
                Console.WriteLine(list.listToString() + "\r\n");
                
                int del_number = 9;
                Console.WriteLine("Removing element(s) by value \"" + del_number
                        + "\". Number of removed elements: "
                        + list.removeAllByValueRecursive(del_number));
                del_number = 99;
                Console.WriteLine("Removing element(s) by value \"" + del_number
                        + "\". Number of removed elements: "
                        + list.removeAllByValueRecursive(del_number) + "\r\n");
                
                Console.WriteLine(list.listToStringNaturalReverseRecursive() + "\r\n");
                Console.WriteLine(list.listToStringReverseRecursiveColumn() + "\r\n");
                
                Console.Write("Sort Descending: ");
                list.sortDescending();
                Console.WriteLine(list.listToString() + "\r\n");
                
                Console.WriteLine("list: "  + list.listToString());
                Console.WriteLine("list2: " + list2.listToString() + "\r\n");
                
                Console.WriteLine("min value (list2[2, 5]): " + list2[2, 5]);
                Console.WriteLine("min value (list2[2, 2]): " + list2[2, 2]);
                Console.WriteLine("min value (list2[3, 1]):");
                Console.WriteLine(list2[3, 1] + "\r\n");
                
                List list3 = new List();
                list3.insert(-8);
                list3.insert(-7);
                list3.insert(-9);
                Console.WriteLine(list3.listToString());
                Console.WriteLine("Number of negative elements that have been removed: "
                                  + list3.removeAllNegative());
                Console.WriteLine(list3.listToString());
                Console.WriteLine();
                
                Element ref1;
                Element ref2;
                Element ref3;
                List list4 = new List();
                list4.insert(5);
                list4.insert(5);
                list4.insert(5);
                list4.insert(1);
                list4.insert(5);
                list4.insert(5);
                list4.insert(5);
                ref1 = list4.insert(3);
                ref2 = list4.insertAfterReference(7, ref1);
                ref3 = list4.insertBeforeReference(8, ref1);
                Console.WriteLine("getElementByReference: " + list4.getElementByReference(ref2));
                Console.WriteLine("getIndexByReference: " + list4.getIndexByReference(ref3));
                ref1 = list4.insert(2);
                ref2 = list4.insertAfterValue(9, 2);
                ref3 = list4.insertBeforeValue(11, 2);
                Console.WriteLine("getElementByReference: " + list4.getElementByReference(ref2));
                Console.WriteLine("getIndexByReference: " + list4.getIndexByReference(ref3));
                //list4.removeByReference(ref1);
                list4.insert(5);
                list4.insert(5);
                list4.insert(5);
                Console.WriteLine("list4: " + list4.listToString());
                Console.WriteLine("Number of negative elements that have been removed: "
                                  + list4.removeAllNegative());
                Console.WriteLine("list4[0]: " + list4[0]);
                Console.WriteLine("list4[3]: " + list4[3]);
                
                Console.WriteLine("list4: " + list4.listToString());
                
                Console.WriteLine("Copying list4 to list5 using constructor.");
                List list5 = new List(list4);
                //list5 = list4; // assignment operator can not be overloaded in C#
                //Console.WriteLine("Number of removed elements: " + list4.removeAllByValue(5));
                //Console.WriteLine("Number of removed elements: " + list4.removeAllByValue(99));
                //
                del_number = 5;
                Console.WriteLine("Removing number \"" + del_number
                        + "\". Number of removed elements: "
                        + list4.removeAllByValueRecursive(del_number));
                
                Console.WriteLine("list4: " + list4.listToString());
                Console.WriteLine("list5: " + list5.listToString());
                list5.insert(99);
                ref3 = list5.insertBeginningSameAsEndRecursive();
                Console.WriteLine("getIndexByReference: " + list5.getIndexByReference(ref3));
                Console.WriteLine("list5: " + list5.listToString());
                Console.WriteLine();
            }
            catch (ListException exc) // ListException
            {
                Console.WriteLine(exc);
            }
            catch (Exception exc)     // default Exception
            {
                Console.WriteLine(exc.Message);
            }
            
            Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}