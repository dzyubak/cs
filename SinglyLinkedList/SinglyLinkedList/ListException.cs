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
    /// This class describes a Singly linked list exception handling
    /// </summary>
    class ListException : ApplicationException
    {
        public ListException() : base() { }
        public ListException(string str) : base(str) { }
        
        // overriding ToString() method for ListException class
        public override string ToString()
        {
            return Message;
        }
    }
}