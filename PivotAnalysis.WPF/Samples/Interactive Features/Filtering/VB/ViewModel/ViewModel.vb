Imports Microsoft.VisualBasic
Imports System
Imports FilteringDemo.Model

Namespace FilteringDemo.ViewModel
	Public Class ViewModel
		Inherits Syncfusion.Windows.Shared.NotificationObject
		Private _productSalesData As Object

		''' <summary>
		''' Gets or sets the product sales data.
		''' </summary>
		''' <value>The product sales data.</value>
		Public Property ProductSalesData() As Object
			Get
				_productSalesData = If(_productSalesData, ProductSales.GetSalesData())
				Return _productSalesData
			End Get
			Set(ByVal value As Object)
				_productSalesData = value
				RaisePropertyChanged("ProductSalesData")
			End Set
		End Property
	End Class
End Namespace
