Imports Microsoft.VisualBasic
Imports SortingDemo.Model
Imports System.Collections.Generic
Imports Syncfusion.Windows.Controls.PivotGrid
Imports System
Imports System.Linq

Namespace SortingDemo.ViewModel
	Public Class ViewModel
		Private _productSalesData As Object

		Public Property ProductSalesData() As Object
			Get
				_productSalesData = If(_productSalesData, ProductSales.GetSalesData())
				Return _productSalesData
			End Get
			Set(ByVal value As Object)
				_productSalesData = value
			End Set
		End Property
	End Class
End Namespace
