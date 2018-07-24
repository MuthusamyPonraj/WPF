Imports System.Windows.Controls
Imports System.Windows.Interactivity

Namespace HyperlinkCellDemo.Action
    Public Class CheckboxUncheckedAction
        Inherits TargetedTriggerAction(Of ListBox)

        Protected Overrides Sub Invoke(parameter As Object)
            Me.Target.Items.Clear()
        End Sub

    End Class
End Namespace

