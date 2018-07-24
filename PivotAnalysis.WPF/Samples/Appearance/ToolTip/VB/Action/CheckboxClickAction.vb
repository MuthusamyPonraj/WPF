Imports System.Windows.Controls
Imports System.Windows.Interactivity
Imports Syncfusion.Windows.Controls.PivotGrid
Imports System.Windows

Namespace ToolTipDemo.Action
    Public Class CheckboxClickAction
        Inherits TargetedTriggerAction(Of PivotGridControl)

        Protected Overrides Sub Invoke(parameter As Object)
            If TypeOf parameter Is RoutedEventArgs Then
                Dim eventArgs As RoutedEventArgs = TryCast(parameter, RoutedEventArgs)
                Dim current As CheckBox = TryCast(eventArgs.OriginalSource, CheckBox)
                Select Case current.Name.ToString()
                    Case "chkBoxEnableCustom_All"
                        If current.IsChecked.Value = True Then
                            Me.Target.CustomToolTipTemplateKey = "CustomTemplateTooltip"
                        Else
                            Me.Target.CustomToolTipTemplateKey = Nothing
                        End If
                    Case "chkBoxCustomColHeader"
                        If current.IsChecked.Value = True Then
                            Me.Target.ColumnHeaderCellStyle.CustomToolTipTemplateKey = "ColumnTemplateTooltip"
                        Else
                            Me.Target.ColumnHeaderCellStyle.CustomToolTipTemplateKey = Nothing
                        End If
                    Case "chkBoxCustomRowHeader"
                        If current.IsChecked.Value = True Then
                            Me.Target.RowHeaderCellStyle.CustomToolTipTemplateKey = "RowTemplateTooltip"
                        Else
                            Me.Target.RowHeaderCellStyle.CustomToolTipTemplateKey = Nothing
                        End If
                    Case "chkBoxCustomValCell"
                        If current.IsChecked.Value = True Then
                            Me.Target.ValueCellStyle.CustomToolTipTemplateKey = "ValueTemplateTooltip"
                        Else
                            Me.Target.ValueCellStyle.CustomToolTipTemplateKey = Nothing
                        End If
                    Case "chkBoxCustomSumHeader"
                        If current.IsChecked.Value = True Then
                            Me.Target.SummaryHeaderStyle.CustomToolTipTemplateKey = "SummaryHeaderTemplateTooltip"
                        Else
                            Me.Target.SummaryHeaderStyle.CustomToolTipTemplateKey = Nothing
                        End If
                    Case "chkBoxCustomSumCell"
                        If current.IsChecked.Value = True Then
                            Me.Target.SummaryCellStyle.CustomToolTipTemplateKey = "SummaryCellTemplateTooltip"
                        Else
                            Me.Target.SummaryCellStyle.CustomToolTipTemplateKey = Nothing
                        End If
                    Case Else
                End Select
            End If
            Me.Target.InvalidateCells()
        End Sub

    End Class
End Namespace
