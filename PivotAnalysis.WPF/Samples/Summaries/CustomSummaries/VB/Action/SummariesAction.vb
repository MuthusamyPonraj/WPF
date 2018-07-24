Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows.Interactivity
Imports Syncfusion.Windows.Controls.PivotGrid
Imports System.Windows
Imports System.Windows.Controls
Imports Syncfusion.PivotAnalysis.Base
Imports CustomSummaryDemo.ViewModel

Namespace CustomSummaryDemo.Action
	Friend Class SummariesAction
		Inherits TargetedTriggerAction(Of PivotGridControl)
		Protected Overrides Sub Invoke(ByVal parameter As Object)
			If TypeOf parameter Is RoutedEventArgs Then
				Dim eventArgs As RoutedEventArgs = TryCast(parameter, RoutedEventArgs)
				If TypeOf eventArgs.OriginalSource Is CheckBox Then
					Dim sourceObject As CheckBox = TryCast(eventArgs.OriginalSource, CheckBox)
					Dim [me] As New MyCustomSummaryBase1()
					If sourceObject IsNot Nothing Then
						Select Case sourceObject.Content.ToString()
							Case "CustomSummary"
								If sourceObject.IsChecked.HasValue AndAlso sourceObject.IsChecked.Value Then
									Me.Target.PivotCalculations.Insert(0, New PivotComputationInfo With {.FieldHeader = "Shipped!", .FieldName = "Value1", .SummaryType = SummaryType.Custom, .Format = "#,##0.00", .Summary = [me]})
								Else
									Me.Target.PivotCalculations.RemoveAt(0)
								End If
							Case "DisplayIfDiscreteValuesEqualSummary"
								If sourceObject.IsChecked.HasValue AndAlso sourceObject.IsChecked.Value Then
									Me.Target.PivotCalculations.Insert(1, New PivotComputationInfo With {.FieldHeader = "Scrap!", .FieldName = "Value3", .SummaryType = SummaryType.DisplayIfDiscreteValuesEqual, .PadString = "***"})
								Else
									Me.Target.PivotCalculations.RemoveAt(1)
								End If
						End Select
					End If
				Else
					Dim sourceObject As ComboBox = TryCast(eventArgs.OriginalSource, ComboBox)
					Select Case sourceObject.SelectedIndex
						Case 0
							Me.Target.PivotCalculations(1).PadString = "***"
						Case 1
							Me.Target.PivotCalculations(1).PadString = "999"
					End Select
					If Me.Target.InternalGrid IsNot Nothing Then
						Me.Target.InternalGrid.Refresh(True)
					End If

				End If
			End If
		End Sub
	End Class
End Namespace