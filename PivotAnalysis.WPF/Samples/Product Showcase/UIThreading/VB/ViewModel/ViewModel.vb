Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Collections.ObjectModel
Imports Syncfusion.Windows.Shared

Namespace UIThreadingDemo.ViewModel
	Friend Class ViewModel
		Inherits NotificationObject
		#Region "Private Variable"
'INSTANT VB NOTE: The variable salesCollection was renamed since Visual Basic does not allow class members with the same name:
		Private salesCollection_Renamed As ObservableCollection(Of ProductModel)
		#End Region

		#Region "Public Properties"
		''' <summary>
		''' Gets or Sets the Sales Collection
		''' </summary>
		Public Property SalesCollection() As ObservableCollection(Of ProductModel)
			Get
				Return salesCollection_Renamed
			End Get
			Set(ByVal value As ObservableCollection(Of ProductModel))
				salesCollection_Renamed = value
				RaisePropertyChanged(Function() SalesCollection)
			End Set
		End Property

		#End Region

		#Region "Method"

		''' <summary>
		''' Initializes the ViewModel class
		''' </summary>
		Public Sub New()
			SalesCollection = UIThreadingDemo.Model.ProductSales.GetSalesData()
		End Sub

		#End Region
	End Class
End Namespace
