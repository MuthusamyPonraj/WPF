Imports System.Windows.Interactivity
Imports System.Windows.Controls

Namespace CellSelectionDemo.Action
    Public Class CheckboxUncheckedAction
        Inherits TargetedTriggerAction(Of ListBox)
        Protected Overrides Sub Invoke(parameter As Object)
            Me.Target.ItemsSource = Nothing
        End Sub
    End Class
End Namespace

