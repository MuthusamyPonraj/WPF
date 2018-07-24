Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports PivotEngineImpt.Model
Imports Syncfusion.PivotAnalysis.Base


Namespace PivotEngineImpt.ViewModel

	Public Class ViewModel
	   Private rw, clm As Integer
	   Private p As New PivotEngine()
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
