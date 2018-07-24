Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows.Interactivity
Imports System.Windows
Imports System.Windows.Controls
Imports Syncfusion.Windows.Controls.PivotGrid
Imports Syncfusion.PivotAnalysis.Base

Namespace RowPivotsOnlyDemo.Action
	Public Class Functions
		Inherits TargetedTriggerAction(Of PivotGridControl)
		Protected Overrides Sub Invoke(ByVal parameter As Object)
			If TypeOf parameter Is RoutedEventArgs Then
				Dim eventArgs As RoutedEventArgs = TryCast(parameter, RoutedEventArgs)

				Dim current As CheckBox = TryCast(eventArgs.OriginalSource, CheckBox)
				Select Case current.Name.ToString()
					Case "MouseHyperLinks"
						Me.Target.EnableHyperlinkOnMouseOver = current.IsChecked.GetValueOrDefault()
						For i As Integer = 0 To Me.Target.PivotEngine.PivotCalculations.Count - 1
							Me.Target.PivotEngine.PivotCalculations(i).EnableHyperlinks = current.IsChecked.GetValueOrDefault()
						Next i
					Case "ContextMenu"
						Me.Target.ColumnHeaderCellStyle.EnableContextMenu = current.IsChecked.GetValueOrDefault()
						Me.Target.RowHeaderCellStyle.EnableContextMenu = current.IsChecked.GetValueOrDefault()
					Case "Filtering"
						For i As Integer = 0 To Me.Target.PivotEngine.PivotCalculations.Count - 1
							Me.Target.PivotEngine.PivotCalculations(i).AllowFilter = current.IsChecked.GetValueOrDefault()
						Next i
					Case "Sorting"
						For i As Integer = 0 To Me.Target.PivotEngine.PivotCalculations.Count - 1
							Me.Target.PivotEngine.PivotCalculations(i).AllowSort = current.IsChecked.GetValueOrDefault()
						Next i
					Case "InnerMostPivotsOnly"
						If current.IsChecked = True Then
							For i As Integer = 0 To Me.Target.PivotEngine.PivotCalculations.Count - 1
								Me.Target.PivotEngine.PivotCalculations(i).InnerMostComputationsOnly = Syncfusion.PivotAnalysis.Base.SummaryDisplayLevel.InnerMostOnly
							Next i
						Else
							For i As Integer = 0 To Me.Target.PivotEngine.PivotCalculations.Count - 1
								Me.Target.PivotEngine.PivotCalculations(i).InnerMostComputationsOnly = Syncfusion.PivotAnalysis.Base.SummaryDisplayLevel.All
							Next i
						End If
					Case "PadString"
						If current.IsChecked = True Then
							For i As Integer = 0 To Me.Target.PivotCalculations.Count - 1
								Me.Target.InternalGrid.SetValueColumnVisibility(i, True)
							Next i
						Else
							For i As Integer = 0 To Me.Target.PivotCalculations.Count - 1
								Me.Target.InternalGrid.SetValueColumnVisibility(i, False)
							Next i
						End If
				End Select
				Me.Target.InvalidateCells()
			End If
		End Sub
	End Class
End Namespace
