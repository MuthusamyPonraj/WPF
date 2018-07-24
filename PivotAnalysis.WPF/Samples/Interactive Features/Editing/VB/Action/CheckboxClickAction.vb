Imports System.Windows.Interactivity
Imports Syncfusion.Windows.Controls.PivotGrid
Imports System.Windows
Imports System.Windows.Controls

Namespace PivotEditing.Action
    Public Class CheckboxClickAction
        Inherits TargetedTriggerAction(Of PivotGridControl)

        Protected Overrides Sub Invoke(parameter As Object)
            If TypeOf parameter Is RoutedEventArgs Then
                Dim eventArgs As RoutedEventArgs = TryCast(parameter, RoutedEventArgs)
                Dim sourceBox As CheckBox = TryCast(eventArgs.OriginalSource, CheckBox)
                If sourceBox Is Nothing Then
                Else
                    Select Case sourceBox.Content.ToString()
                        Case "Edit Total Cells"
                            If sourceBox.IsChecked.HasValue AndAlso sourceBox.IsChecked.Value Then
                                Me.Target.EditManager.AllowEditingOfTotalCells = True
                            Else
                                Me.Target.EditManager.AllowEditingOfTotalCells = False
                            End If
                        Case "HideExpanders"
                            If sourceBox.IsChecked.HasValue AndAlso sourceBox.IsChecked.Value Then
                                Me.Target.EditManager.HideExpanders = True
                            Else
                                Me.Target.EditManager.HideExpanders = False
                            End If
                    End Select
                    Me.Target.InvalidateCells()
                End If
            End If
        End Sub

    End Class
End Namespace

