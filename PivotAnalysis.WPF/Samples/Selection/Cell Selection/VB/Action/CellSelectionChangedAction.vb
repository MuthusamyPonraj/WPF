Imports System.Windows.Interactivity
Imports System.Windows.Controls
Imports Syncfusion.Windows.Controls.PivotGrid

Namespace CellSelectionDemo.Action
    Public Class CellSelectionChangedAction
        Inherits TargetedTriggerAction(Of ListBox)
        Protected Overrides Sub Invoke(parameter As Object)
            Dim eventArgs As PivotGridSelectionChangedEventArgs = TryCast(parameter, PivotGridSelectionChangedEventArgs)
            If eventArgs Is Nothing Then
            Else
                Me.Target.ItemsSource = eventArgs.SelectedItems
            End If
        End Sub
    End Class
End Namespace

