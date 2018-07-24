#Region "Copyright Syncfusion Inc. 2001 - 2012"
' Copyright Syncfusion Inc. 2001 - 2012. All rights reserved.
' Use of this code is subject to the terms of our license.
' A copy of the current license can be obtained at any time by e-mailing
' licensing@syncfusion.com. Any infringement will be prosecuted under
' applicable laws. 
#End Region

Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Data
Imports System.ComponentModel

Namespace PivotEditing.Model
    Friend Class BusinessObjectsDataView
        Inherits DataView
        Public Shared Function GetDataTable(ByVal count As Integer) As DataView
            Dim dt As New DataTable("BusinessObjectsDataTable")
            Dim pdc As PropertyDescriptorCollection = TypeDescriptor.GetProperties(GetType(BusinessObject))
            For Each pd As PropertyDescriptor In pdc
                dt.Columns.Add(New DataColumn(pd.Name, pd.PropertyType))
            Next pd
            Dim list As BusinessObjectCollection = BusinessObjectCollection.GetList(count)
            For Each bo As BusinessObject In list
                Dim dr As DataRow = dt.NewRow()
                For Each pd As PropertyDescriptor In pdc
                    dr(pd.Name) = pd.GetValue(bo)
                Next pd
                dt.Rows.Add(dr)
            Next bo
            Return dt.DefaultView
        End Function
    End Class

    Friend Class BusinessObjectCollection
        Inherits List(Of BusinessObject)
        Public Shared Function GetList(ByVal count As Integer) As BusinessObjectCollection
            Dim list As New BusinessObjectCollection()

            Dim Fruits As New List(Of String)(New String() {"cherry", "mango", "orange", "grape", "Persimmon", "plum", "fig", "apple", "lime", "gooseberry", "strawberry", "rasberry"})
            Dim Colors As New List(Of String)(New String() {"red", "green", "blue", "yellow", "orange", "pink", "crimson", "almond", "white", "black", "aqua", "beige"})

            Dim r As New Random(123123)
            Dim shapeCount As Integer = System.Enum.GetNames(GetType(Shape)).Count()

            For i As Integer = 0 To count - 1
                Dim bo As New BusinessObject() With {.Fruit = Fruits(r.Next(Fruits.Count)), .Shape = CType(r.Next(shapeCount), Shape), .Color = Colors(r.Next(Colors.Count)), .Weight = (CInt(Fix(r.NextDouble() * 1000))) / 10.0R, .Even = r.Next(2) = 0, .Count = r.Next(4) + 1, .Section = r.Next(6)}
                list.Add(bo)
            Next i
            Return list
        End Function
    End Class

    Friend Class BusinessObject
        Private privateFruit As String
        Public Property Fruit() As String
            Get
                Return privateFruit
            End Get
            Set(ByVal value As String)
                privateFruit = value
            End Set
        End Property
        Private privateColor As String
        Public Property Color() As String
            Get
                Return privateColor
            End Get
            Set(ByVal value As String)
                privateColor = value
            End Set
        End Property
        Private privateShape As Shape
        Public Property Shape() As Shape
            Get
                Return privateShape
            End Get
            Set(ByVal value As Shape)
                privateShape = value
            End Set
        End Property
        Private privateEven As Boolean
        Public Property Even() As Boolean
            Get
                Return privateEven
            End Get
            Set(ByVal value As Boolean)
                privateEven = value
            End Set
        End Property
        Private privateSection As Integer
        Public Property Section() As Integer
            Get
                Return privateSection
            End Get
            Set(ByVal value As Integer)
                privateSection = value
            End Set
        End Property
        Private privateWeight As Double
        Public Property Weight() As Double
            Get
                Return privateWeight
            End Get
            Set(ByVal value As Double)
                privateWeight = value
            End Set
        End Property
        Private privateCount As Integer
        Public Property Count() As Integer
            Get
                Return privateCount
            End Get
            Set(ByVal value As Integer)
                privateCount = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return String.Format("Fruit=[{0}] Color=[{1}] Shape=[{2}] Even=[{3}] Section=[{4}] Weight=[{5:0.0}] Count=[{6}]", Fruit, Color, Shape, Even, Section, Weight, Count)
        End Function

    End Class

    Friend Enum Shape
        Point
        Line
        Triangle
        Square
        Rectangle
        Trapezoid
        Pentagon
    End Enum


End Namespace
