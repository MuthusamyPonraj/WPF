Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.ObjectModel
Imports System.Windows.Controls
Imports System.Windows.Interactivity
Imports System.Windows.Threading
Imports OnDemandLoadingDemo.ViewModel
Imports Syncfusion.PivotAnalysis.Base
Imports Syncfusion.Windows.Controls.PivotGrid

Namespace OnDemandLoadingDemo.Behaviour
	Public Class SampleBehavior
		Inherits Behavior(Of Grid)
		Private _pivotGrid As PivotGridControl
		Private _scrollViewer As ScrollViewer
		Private _startIndex As DateTime = DateTime.Now

		Protected Overrides Sub OnAttached()
			MyBase.OnAttached()
			AssociatedObject.DataContext = New ViewModel.ViewModel()
			_pivotGrid = TryCast(AssociatedObject.Children(2), PivotGridControl)
			_scrollViewer = TryCast(AssociatedObject.Children(3), ScrollViewer)
			If _pivotGrid IsNot Nothing Then
				_pivotGrid.AutoSizeOption = GridAutoSizeOption.None
				Dim m = New MonthComparer("MMM")
				_pivotGrid.PivotColumns.Add(New PivotItem With {.FieldHeader = "Month", .Comparer = m, .FieldMappingName = "Date", .TotalHeader = "Total", .Format = "MMM"})
				_pivotGrid.PivotEngine.UseIndexedEngine = True
				_pivotGrid.PivotEngine.EnableOnDemandCalculations = _pivotGrid.PivotEngine.UseIndexedEngine
                _pivotGrid.PivotEngine.GetValue = AddressOf Me.ItemObjectLookup
                Dim ItemsSourceObject As ObservableCollection(Of ItemObject) = (TryCast(AssociatedObject.DataContext, ViewModel.ViewModel)).ItemObjectCollection
                AddHandler _pivotGrid.PivotEngine.PivotSchemaChanged, AddressOf PivotEngine_PivotSchemaChanged
                _pivotGrid.ItemSource = ItemsSourceObject
			End If
		End Sub

		Private Sub PivotEngine_PivotSchemaChanged(ByVal sender As Object, ByVal e As PivotSchemaChangedArgs)
			_startIndex = DateTime.Now
			AssociatedObject.Dispatcher.BeginInvoke(DispatcherPriority.SystemIdle, New Action(Function() AnonymousMethod3()))
		End Sub
		
		Private Function AnonymousMethod3() As Object
			If Not _pivotGrid.IgnoreRefesh Then
				If (TryCast(_scrollViewer.Content, TextBlock)) IsNot Nothing Then
					TryCast(_scrollViewer.Content, TextBlock).Text = String.Empty
				End If
					CheckTime(_startIndex, "Initial part done in")
					ContinueLoadingAsynchonolously(_pivotGrid.PivotEngine.IndexEngine, _startIndex)
			End If
			Return Nothing
		End Function

		Private Sub ContinueLoadingAsynchonolously(ByVal engine As IndexEngine, ByVal startIndex As DateTime)
			AssociatedObject.Dispatcher.BeginInvoke(New Action(Function() AnonymousMethod4(engine, startIndex)), DispatcherPriority.SystemIdle) 'do it again...
		End Sub
		
		Private Function AnonymousMethod4(ByVal engine As IndexEngine, ByVal startIndex As DateTime) As Object
			If engine IsNot Nothing AndAlso engine.HighRowLevel < engine.RowCount - 1 Then
				Dim cutOff As Integer = Math.Min(engine.HighRowLevel + 800, engine.RowCount - 1)
				Dim o As Object = engine(cutOff, 0)
				If (TryCast(_scrollViewer.Content, TextBlock)) IsNot Nothing Then
					TryCast(_scrollViewer.Content, TextBlock).Text += String.Format(Constants.vbLf & "{0}/{1}", engine.HighRowLevel, engine.RowCount - 1)
					ContinueLoadingAsynchonolously(engine, startIndex)
				End If
			Else
				CheckTime(startIndex, "Load Completed")
			End If
			Return Nothing
		End Function

		Private Sub CheckTime(ByVal start As DateTime, ByVal label As String)
			If TryCast(_scrollViewer.Content, TextBlock) IsNot Nothing Then
				TryCast(_scrollViewer.Content, TextBlock).Text += String.Format(Constants.vbLf & "{0} {1:0.0000} seconds.", label, DateTime.Now.Subtract(start).TotalSeconds)
			End If
		End Sub

		Public Function ItemObjectLookup(ByVal o As Object, ByVal name As String) As IComparable
			Dim c As IComparable = Nothing
			Dim io = TryCast(o, ItemObject)
			If io IsNot Nothing Then
				Select Case name
					Case "Date"
						c = io.Date
					Case "Client"
						c = io.Client
					Case "Campaign"
						c = io.Campaign
					Case "Color"
						c = io.Color
					Case "Shape"
						c = io.Shape
					Case "Price"
						c = io.Price
					Case "Spend"
						c = io.Spend
					Case "ColH"
						c = io.ColH
					Case "ColI"
						c = io.ColI
					Case "ColJ"
						c = io.ColJ
				End Select
			End If

			Return c
		End Function
	End Class
End Namespace