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
    /// This class describes an element of a Singly linked list
    /// </summary>
    /// <remarks>
    /// <c>int data;</c> can be used instead of automatic properties
    /// <c>Element next;</c> can be used instead of automatic properties
    /// </remarks>
    class Element
    {
        public Element(int data)
        {
            this.Data = data;
            this.Next = null;
        }
        
        public Element(int data, Element next)
        {
            this.Data = data;
            this.Next = next;
        }
        
        public Element(Element element)
        {
            this.Data = element.Data;
            this.Next = element.Next;
        }
        
        /// <remarks>
        /// automatic properties (C# 3.0)
        /// </remarks>
        public int Data { get; set; }
        
        /// <remarks>
        /// automatic properties (C# 3.0)
        /// </remarks>
        public Element Next { get; set; }
    }
}