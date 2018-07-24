Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows.Interactivity
Imports Syncfusion.Windows.Controls.PivotGrid
Imports System.Windows
Imports System.Windows.Controls
Imports Syncfusion.PivotAnalysis.Base

Namespace SortingDemo.Action
	Friend Class SortingOptions
		Inherits TargetedTriggerAction(Of PivotGridControl)
		Protected Overrides Sub Invoke(ByVal parameter As Object)
			If TypeOf parameter Is RoutedEventArgs Then
				Dim eventArgs As RoutedEventArgs = TryCast(parameter, RoutedEventArgs)

				Dim current As RadioButton = TryCast(eventArgs.OriginalSource, RadioButton)
				Select Case current.Name.ToString()
					Case "btnSortAll"
						If current.IsEnabled = True Then
							Me.Target.SortOption = PivotSortOption.All
						End If

					Case "btnSortColumn"
						If current.IsEnabled = True Then
							Me.Target.SortOption = PivotSortOption.ColumnSorting
						End If
					Case "btnSortTotal"
						If current.IsEnabled = True Then
							Me.Target.SortOption = PivotSortOption.TotalSorting
						End If
					Case "btnSortGrandTotal"
						If current.IsEnabled = True Then
							Me.Target.SortOption = PivotSortOption.GrandTotalSorting
						End If
					Case "btnSortNone"
						If current.IsEnabled = True Then
							Me.Target.SortOption = PivotSortOption.None
						End If

					Case Else
				End Select
			End If
			Me.Target.InvalidateCells()
		End Sub
	End Class
End Namespace
