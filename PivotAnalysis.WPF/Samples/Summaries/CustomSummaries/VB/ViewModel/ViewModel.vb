Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports CustomSummaries.Model
Imports Syncfusion.PivotAnalysis.Base
Imports System.Collections.ObjectModel

Namespace CustomSummaryDemo.ViewModel
	Public Class ViewModel
		Private _data As List(Of DataPoint)

		Public Property Data() As List(Of DataPoint)
			Get
				_data = If(_data, New List(Of DataPoint)(New DataPoint() {New DataPoint(1, "Animals", "Turtle","India","Chennai", 10583.32D, 1000, 8000.22, 1583.10), New DataPoint(1, "Animals", "Cat","India","Chennai",10583.32D, 2000, 7000.22, 1583.10), New DataPoint(1, "Trees", "Dog","India","Chennai", 10583.32D, 3000, 6000.22, 1583.10), New DataPoint(1, "Trees", "Pig","India","Chennai", 10583.32D, 4000, 5000.22, 1583.10), New DataPoint(1, "Trees", "Dog","India","Bombay", 10583.32D, 3000, 6000.22, 1583.10), New DataPoint(1, "Trees", "Pig","India","Bombay", 10583.32D, 4000, 5000.22, 1583.10), New DataPoint(1, "Trees", "Dog","India","Bombay", 10583.32D, 3000, 6000.22, 1583.10), New DataPoint(1, "Trees", "Pig","India","Bombay", 10583.32D, 4000, 5000.22, 1583.10), New DataPoint(1, "Animals", "Pig","India","Chennai", 10583.32D, 4000, 5000.22, 1583.10), New DataPoint(1, "Animals", "Dog","India","Bombay", 10583.32D, 3000, 6000.22, 1583.10), New DataPoint(1, "Animals", "Pig","India","Bombay", 10583.32D, 4000, 5000.22, 1583.10), New DataPoint(1, "Animals", "Dog","India","Bombay", 10583.32D, 3000, 6000.22, 1583.10), New DataPoint(1, "Animals", "Pig","India","Bombay", 10583.32D, 4000, 5000.22, 1583.10), New DataPoint(1, "Animals", "Horse","India","Chennai", 10583.32D, 5000, 4000.22, 1583.10), New DataPoint(1, "Animals", "Cow","India","Chennai", 10583.32D, 6000, 3000.22, 1583.10), New DataPoint(1, "Animals", "Chicken?!","India","Chennai", 10583.32D, 7000, 2000.22, 1583.10), New DataPoint(1, "Trees", "Oak","India","Chennai", 10583.32D, 1500, 8000.22, 1683.10), New DataPoint(1, "Animals", "Cherry","England","Paris", 10583.32D, 1600, 8000.22, 1783.10), New DataPoint(1, "Trees", "Maple","England","Paris", 10583.32D, 1700, 8000.22, 1783.10), New DataPoint(1, "Animals", "Poplar","England","Paris", 10583.32D, 1800, 8000.22, 1383.10), New DataPoint(1, "Trees", "Cedar","England","Albania", 10583.32D, 1900, 8000.22, 1183.10), New DataPoint(1, "Animals", "Cherry","England","Albania", 10583.32D, 1600, 8000.22, 1783.10), New DataPoint(1, "Trees", "Maple","England","Albania", 10583.32D, 1700, 8000.22, 1783.10), New DataPoint(1, "Animals", "Poplar","England","Albania", 10583.32D, 1800, 8000.22, 1383.10), New DataPoint(1, "Trees", "Cedar","England","Albania", 10583.32D, 1900, 8000.22, 1183.10), New DataPoint(1, "Animals", "Birch","United States","Newyork", 10583.32D, 1010, 8000.22, 1383.10), New DataPoint(1, "Trees", "Pine","United States","Newyork", 10583.32D, 1200, 8000.22, 1783.10), New DataPoint(1, "Animals", "Spruce","United States","Newyork", 10583.32D, 1300, 8000.22, 1383.10), New DataPoint(1, "Trees", "Spruce","United States","Newyork", 3333.32D, 1600, 9000.22, 3453.10), New DataPoint(1, "Animals", "Spruce","United States","Newyork", 10583.32D, 1300, 8000.22, 1383.10), New DataPoint(1, "Trees", "Spruce","United States","Newyork", 3333.32D, 1600, 9000.22, 3453.10), New DataPoint(1, "Animals", "Birch","United States","Chicago", 10583.32D, 1010, 8000.22, 1383.10), New DataPoint(1, "Trees", "Pine","United States","Chicago", 10583.32D, 1200, 8000.22, 1783.10), New DataPoint(1, "Animals", "Spruce","United States","Chicago", 10583.32D, 1300, 8000.22, 1383.10), New DataPoint(1, "Trees", "Spruce","United States","Chicago", 3333.32D, 1600, 9000.22, 3453.10), New DataPoint(1, "Animals", "Spruce","United States","Chicago", 10583.32D, 1300, 8000.22, 1383.10), New DataPoint(1, "Trees", "Spruce","United States","Chicago", 3333.32D, 1600, 9000.22, 3453.10)}))
				Return _data
			End Get
			Set(ByVal value As List(Of DataPoint))
				_data = value
			End Set
		End Property


		Public ReadOnly Property CustomSummaryBaseClasses() As ObservableCollection(Of SummaryBase)
			Get
				Return New ObservableCollection(Of SummaryBase) (New SummaryBase() {New MyCustomSummaryBase2()})
			End Get
		End Property

	End Class
End Namespace
