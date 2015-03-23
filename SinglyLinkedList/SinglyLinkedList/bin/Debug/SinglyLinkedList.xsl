<?xml version="1.0" encoding="UTF-8"?>
<!--
Copyright (C) 2013, 2015 Dmytro Dzyubak

This file is part of SinglyLinkedList.

SinglyLinkedList is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

SinglyLinkedList is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with SinglyLinkedList. If not, see <http://www.gnu.org/licenses/>.
-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="html"/>
  
  <xsl:template match="/">
  <html>
      <head>
        <title><xsl:value-of select="doc/assembly/name"/></title>
      </head>
      <body>
	    <h1>Project: <xsl:value-of select="doc/assembly/name"/></h1>
		<xsl:apply-templates select="doc/members/member"/>
      </body>
    </html>
  </xsl:template>

  <xsl:template match="member">
	<h2>Name: <xsl:value-of select="@name" /></h2>
    <xsl:apply-templates select="summary"/>
    <xsl:apply-templates select="remarks"/>
    <xsl:apply-templates select="c"/>
  </xsl:template>
  
  <xsl:template match="summary">
    <p><strong>Summary:</strong> <xsl:apply-templates/></p>
  </xsl:template>
  
  <xsl:template match="remarks">
    <p><strong>Remarks:</strong> <xsl:apply-templates/></p>
  </xsl:template>
  
  <xsl:template match="c">
    <code><xsl:apply-templates/></code>
  </xsl:template>
  
</xsl:stylesheet>