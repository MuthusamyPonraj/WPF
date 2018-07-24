Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Syncfusion.Windows.Controls.PivotGrid
Imports System.Windows.Interactivity
Imports System.Windows.Documents
Imports Syncfusion.PivotAnalysis.Base
Imports Syncfusion.Windows.Controls.Grid

Namespace DrillThroughDemo.Action
	Public Class HyperLinkAction
		Inherits TargetedTriggerAction(Of GridDataControl)
		Protected Overrides Sub Invoke(ByVal parameter As Object)
			If TypeOf parameter Is HyperlinkCellClickEventArgs Then
				Dim eventArgs As HyperlinkCellClickEventArgs = TryCast(parameter, HyperlinkCellClickEventArgs)
				Me.Target.ItemsSource = (TryCast(Me.AssociatedObject, PivotGridControl)).PivotEngine.GetRawItemsFor(eventArgs.RowColumnIndex.RowIndex, eventArgs.RowColumnIndex.ColumnIndex)
			End If
		End Sub
	End Class
End Namespace
