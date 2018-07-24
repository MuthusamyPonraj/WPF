Imports PivotGridCustomizationDemo.Model
Imports System.Collections.Generic
Imports System.Windows.Media
Imports System.Reflection

Namespace PivotGridCustomizationDemo.ViewModel
    Public Class ViewModel

        Private _productSalesData As Object
        Public Property ProductSalesData() As Object
            Get
                If _productSalesData Is Nothing Then
                    _productSalesData = ProductSales.GetSalesData()
                End If
                Return _productSalesData
            End Get
            Set(ByVal value As Object)
                _productSalesData = value
            End Set
        End Property


        Public ReadOnly Property BrushNames() As List(Of String)
            Get
                Dim listOfBrushes As List(Of String) = New List(Of String)
                Dim brush As System.Type = GetType(Brushes)
                For Each member As MemberInfo In brush.GetMembers()
                    If TypeOf member Is PropertyInfo Then
                        Dim pi As PropertyInfo = TryCast(member, PropertyInfo)
                        listOfBrushes.Add(pi.Name)
                    End If
                Next
                Return listOfBrushes
            End Get
        End Property

    End Class
End Namespace

