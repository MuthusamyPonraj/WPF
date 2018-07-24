Imports ContextMenuDemo.Model
Imports System.Collections.Generic

Namespace ContextMenuDemo.ViewModel
    Public Class ViewModel
        Inherits Syncfusion.Windows.Shared.NotificationObject
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

        Public ReadOnly Property ProductList() As List(Of String)
            Get
                Dim listOfProdcut As List(Of String) = New List(Of String)()
                listOfProdcut.Add("Bike")
                listOfProdcut.Add("Car")
                Return listOfProdcut
            End Get
        End Property

        Public ReadOnly Property CountryList() As List(Of String)
            Get
                Dim listOfCountry As List(Of String) = New List(Of String)()
                listOfCountry.Add("Canada")
                listOfCountry.Add("France")
                Return listOfCountry
            End Get
        End Property
    End Class
End Namespace

