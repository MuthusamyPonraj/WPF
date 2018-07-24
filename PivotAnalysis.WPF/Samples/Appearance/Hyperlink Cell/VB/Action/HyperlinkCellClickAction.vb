Imports System.Windows.Controls
Imports System.Windows.Interactivity
Imports Syncfusion.Windows.Controls.PivotGrid
Imports System

Namespace HyperlinkCellDemo.Action

    Public Class HyperlinkCellClickAction
        Inherits TargetedTriggerAction(Of ListBox)

        Protected Overrides Sub Invoke(parameter As Object)
            If TypeOf parameter Is HyperlinkCellClickEventArgs Then
                Dim eventArgs As HyperlinkCellClickEventArgs = TryCast(parameter, HyperlinkCellClickEventArgs)
                Me.Target.Items.Add("Value: " & eventArgs.PivotCellInfo.Value.ToString() & Environment.NewLine & "RowIndex: " & eventArgs.RowColumnIndex.RowIndex.ToString() & Environment.NewLine & "ColumnIndex: " & eventArgs.RowColumnIndex.ColumnIndex.ToString())

                Me.Target.ScrollIntoView(Me.Target.Items(Me.Target.Items.Count - 1))
            End If
        End Sub

    End Class
End Namespace
