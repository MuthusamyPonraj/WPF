Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows.Interactivity
Imports Syncfusion.Windows.Controls.PivotGrid
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media

Namespace PivotGridCustomizationDemo.Action
    Friend Class SubtotalVisibilityChangedAction
        Inherits TargetedTriggerAction(Of Grid)
        Private Shared count As Integer = 0
        Protected Overrides Sub Invoke(ByVal parameter As Object)
            Dim eventArgs As RoutedEventArgs = TryCast(parameter, RoutedEventArgs)
            Dim current As CheckBox = TryCast(eventArgs.OriginalSource, CheckBox)
            Dim pivot As PivotGridControl = TryCast(Me.Target.Children(2), PivotGridControl)
            Dim TabControlExt As TabControl = TryCast(VisualTreeHelper.GetChild(Target, 3), TabControl)
            Dim subtotalGroupBox As GroupBox = TryCast(TabControlExt.FindName("ShowSubTotalGroupBox"), GroupBox)
            Dim showAllSubTotals As CheckBox = TryCast((TryCast(subtotalGroupBox, GroupBox)).FindName("chkShowSubTotals"), CheckBox)
            Dim showProductSubTotals As CheckBox = TryCast((TryCast(subtotalGroupBox, GroupBox)).FindName("chkShowProductSubTotals"), CheckBox)
            Dim showDateSubTotals As CheckBox = TryCast((TryCast(subtotalGroupBox, GroupBox)).FindName("chkShowDateSubTotals"), CheckBox)
            Dim showCountrySubTotals As CheckBox = TryCast((TryCast(subtotalGroupBox, GroupBox)).FindName("chkShowCountrySubTotals"), CheckBox)
            Dim showStateSubTotals As CheckBox = TryCast((TryCast(subtotalGroupBox, GroupBox)).FindName("chkShowStateSubTotals"), CheckBox)

            Dim index As Integer = 0
            Select Case current.Content.ToString()
                Case "Show Product Subtotals"

                    If current.IsChecked = True Then
                        index = pivot.PivotRows.IndexOf(pivot.PivotRows.FirstOrDefault(Function(x) x.FieldMappingName = "Product"))
                        If index >= 0 Then
                            pivot.PivotRows(index).ShowSubTotal = True
                            count -= 1
                        Else
                            index = pivot.PivotColumns.IndexOf(pivot.PivotColumns.FirstOrDefault(Function(x) x.FieldMappingName = "Product"))
                            If index >= 0 Then
                                pivot.PivotColumns(index).ShowSubTotal = True
                                count -= 1
                            End If
                        End If
                    Else
                        index = pivot.PivotRows.IndexOf(pivot.PivotRows.FirstOrDefault(Function(x) x.FieldMappingName = "Product"))
                        If index >= 0 Then
                            pivot.PivotRows(index).ShowSubTotal = False
                            count += 1
                        Else
                            index = pivot.PivotColumns.IndexOf(pivot.PivotColumns.FirstOrDefault(Function(x) x.FieldMappingName = "Product"))
                            If index >= 0 Then
                                pivot.PivotColumns(index).ShowSubTotal = False
                                count += 1
                            End If
                        End If
                    End If
                    pivot.InvalidateCells()

                Case "Show Country Subtotals"
                    If current.IsChecked = True Then
                        index = pivot.PivotColumns.IndexOf(pivot.PivotColumns.FirstOrDefault(Function(x) x.FieldMappingName = "Country"))
                        If index >= 0 Then
                            pivot.PivotColumns(index).ShowSubTotal = True
                            count -= 1
                        Else
                            index = pivot.PivotRows.IndexOf(pivot.PivotRows.FirstOrDefault(Function(x) x.FieldMappingName = "Country"))
                            If index >= 0 Then
                                pivot.PivotRows(index).ShowSubTotal = True
                                count -= 1
                            End If
                        End If
                    Else
                        index = pivot.PivotColumns.IndexOf(pivot.PivotColumns.FirstOrDefault(Function(x) x.FieldMappingName = "Country"))
                        If index >= 0 Then
                            pivot.PivotColumns(index).ShowSubTotal = False
                            count += 1
                        Else
                            index = pivot.PivotRows.IndexOf(pivot.PivotRows.FirstOrDefault(Function(x) x.FieldMappingName = "Country"))
                            If index >= 0 Then
                                pivot.PivotRows(index).ShowSubTotal = False
                                count += 1
                            End If
                        End If
                    End If
                    pivot.InvalidateCells()
                Case "Show Date Subtotals"
                    If current.IsChecked = True Then
                        index = pivot.PivotRows.IndexOf(pivot.PivotRows.FirstOrDefault(Function(x) x.FieldMappingName = "Date"))
                        If index >= 0 Then
                            pivot.PivotRows(index).ShowSubTotal = True
                            count -= 1
                        Else
                            index = pivot.PivotColumns.IndexOf(pivot.PivotColumns.FirstOrDefault(Function(x) x.FieldMappingName = "Date"))
                            If index >= 0 Then
                                pivot.PivotColumns(index).ShowSubTotal = True
                                count -= 1
                            End If
                        End If
                    Else
                        index = pivot.PivotRows.IndexOf(pivot.PivotRows.FirstOrDefault(Function(x) x.FieldMappingName = "Date"))
                        If index >= 0 Then
                            pivot.PivotRows(index).ShowSubTotal = False
                            count += 1
                        Else
                            index = pivot.PivotColumns.IndexOf(pivot.PivotColumns.FirstOrDefault(Function(x) x.FieldMappingName = "Date"))
                            If index >= 0 Then
                                pivot.PivotColumns(index).ShowSubTotal = False
                                count += 1
                            End If
                        End If
                    End If
                    pivot.InvalidateCells()
                Case "Show State Subtotals"
                    If current.IsChecked = True Then
                        index = pivot.PivotColumns.IndexOf(pivot.PivotColumns.FirstOrDefault(Function(x) x.FieldMappingName = "State"))
                        If index >= 0 Then
                            pivot.PivotColumns(index).ShowSubTotal = True
                            count -= 1
                        Else
                            index = pivot.PivotRows.IndexOf(pivot.PivotRows.FirstOrDefault(Function(x) x.FieldMappingName = "State"))
                            If index >= 0 Then
                                pivot.PivotRows(index).ShowSubTotal = True
                                count -= 1
                            End If
                        End If
                    Else
                        index = pivot.PivotColumns.IndexOf(pivot.PivotColumns.FirstOrDefault(Function(x) x.FieldMappingName = "State"))
                        If index >= 0 Then
                            pivot.PivotColumns(index).ShowSubTotal = False
                            count += 1
                        Else
                            index = pivot.PivotRows.IndexOf(pivot.PivotRows.FirstOrDefault(Function(x) x.FieldMappingName = "State"))
                            If index >= 0 Then
                                pivot.PivotRows(index).ShowSubTotal = False
                                count += 1
                            End If
                        End If
                    End If
                    pivot.InvalidateCells()

                Case "Show Subtotals"
                    If current.IsChecked = True Then
                        pivot.ShowSubTotals = True
                        showProductSubTotals.IsChecked = True
                        showCountrySubTotals.IsChecked = True
                        showDateSubTotals.IsChecked = True
                        showStateSubTotals.IsChecked = True
                        count = 0
                    Else
                        pivot.ShowSubTotals = False
                        showProductSubTotals.IsChecked = False
                        showCountrySubTotals.IsChecked = False
                        showDateSubTotals.IsChecked = False
                        showStateSubTotals.IsChecked = False
                        count = 4
                    End If

                    pivot.InvalidateCells()
            End Select
            If count = 0 Then
                showAllSubTotals.IsChecked = True
            ElseIf count < 4 Then
                showAllSubTotals.IsChecked = Nothing
            ElseIf count = 4 Then
                showAllSubTotals.IsChecked = False
            End If
        End Sub
    End Class
End Namespace