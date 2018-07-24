Imports Microsoft.VisualBasic
Imports Syncfusion.Windows.Shared
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Collections.ObjectModel

Namespace OnDemandLoadingDemo.ViewModel
	Friend Class ViewModel
		Inherits NotificationObject
		#Region "Private Variable"
'INSTANT VB NOTE: The variable itemObjectCollection was renamed since Visual Basic does not allow class members with the same name:
		Private itemObjectCollection_Renamed As ObservableCollection(Of OnDemandLoadingDemo.ItemObject)

		#End Region


		#Region "Public Properties"
		Public Property ItemObjectCollection() As ObservableCollection(Of OnDemandLoadingDemo.ItemObject)
			Get
				Return itemObjectCollection_Renamed
			End Get
			Set(ByVal value As ObservableCollection(Of OnDemandLoadingDemo.ItemObject))
				itemObjectCollection_Renamed = value
				RaisePropertyChanged(Function() ItemObjectCollection)
			End Set
		End Property



		#End Region

		#Region "Method"

		''' <summary>
		''' Initializes the ViewModel class
		''' </summary>
		Public Sub New()
            itemObjectCollection_Renamed = OnDemandLoadingDemo.ItemObjects.GetList()
		End Sub

		#End Region

	End Class
	Public Class MonthComparer
		Implements IComparer
		Private lookUp As Dictionary(Of String, Integer) = Nothing
		Private fmt As String = String.Empty
		Public Sub New(ByVal format As String)
			fmt = String.Format("{{0:{0}}}", format)
			lookUp = New Dictionary(Of String, Integer)()
			Dim dt0 As DateTime = DateTime.Now
			For i As Integer = 1 To 12
				Dim dt As DateTime = dt0.AddMonths(i - dt0.Month)
				lookUp.Add(String.Format(fmt, dt), i)
			Next i
		End Sub

		Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
			Dim x1, y1 As DateTime
			If DateTime.TryParse(x.ToString(), x1) AndAlso DateTime.TryParse(y.ToString(), y1) Then
				x = String.Format(fmt, x1)
				y = String.Format(fmt, y1)
			End If

			Return lookUp(x.ToString()).CompareTo(lookUp(y.ToString()))
		End Function
	End Class

End Namespace
