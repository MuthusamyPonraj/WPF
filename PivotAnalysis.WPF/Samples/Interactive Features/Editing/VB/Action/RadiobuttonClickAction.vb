Imports System.Windows.Interactivity
Imports Syncfusion.Windows.Controls.PivotGrid
Imports System.Windows
Imports System.Windows.Controls
Imports Syncfusion.PivotAnalysis.Base
Imports PivotEditing.Model

Namespace PivotEditing.Action
    Public Class RadiobuttonClickAction
        Inherits TargetedTriggerAction(Of PivotGridControl)

        Protected Overrides Sub Invoke(parameter As Object)
            If TypeOf parameter Is RoutedEventArgs Then
                Dim eventArgs As RoutedEventArgs = TryCast(parameter, RoutedEventArgs)
                Dim sourceBox As RadioButton = TryCast(eventArgs.OriginalSource, RadioButton)
                If sourceBox Is Nothing Then
                Else
                    Select Case sourceBox.Content.ToString()
                        Case "Custom"
                            'User derived EditManager.
                            Me.Target.EditManager.Dispose() 'dispose the current one...
                            Me.Target.EditManager = New CustomEditManager(Me.Target) With {.HideExpanders = Me.Target.EditManager.HideExpanders} 'set the derived one...
                        Case "Built In"
                            'User built-in EditManager.
                            Me.Target.EditManager.Dispose() 'dispose the current one...
                            Me.Target.EditManager = New PivotEditingManager(Me.Target) With {.HideExpanders = Me.Target.EditManager.HideExpanders} 'set the derived one...
                        Case "List"
                            LoadList()
                        Case "DataTable"
                            LoadDataTable()
                    End Select
                End If
            End If
        End Sub


#Region "DataSource"
        ''' <summary>
        ''' Loads the DataTable as DataSource for PivotGridControl
        ''' </summary>
        Private Sub LoadDataTable()
            Me.Target.ItemSource = Nothing
            Me.Target.ResetPivotData()
            Me.Target.ItemSource = BusinessObjectsDataView.GetDataTable(200)

            Me.Target.PivotRows.Add(New PivotItem() With {.FieldMappingName = "Fruit", .FieldHeader = "Fruit", .TotalHeader = "Total"})
            Me.Target.PivotRows.Add(New PivotItem() With {.FieldMappingName = "Color", .FieldHeader = "Color", .TotalHeader = "Total"})

            Me.Target.PivotColumns.Add(New PivotItem() With {.FieldMappingName = "Shape", .FieldHeader = "Shape", .TotalHeader = "Total"})
            Me.Target.PivotColumns.Add(New PivotItem() With {.FieldMappingName = "Even", .FieldHeader = "Even", .TotalHeader = "Total"})

            Me.Target.PivotCalculations.Add(New PivotComputationInfo() With {.FieldName = "Count", .FieldHeader = "Count", .SummaryType = SummaryType.DoubleTotalSum})
            Me.Target.PivotCalculations.Add(New PivotComputationInfo() With {.FieldName = "Section", .FieldHeader = "Section", .SummaryType = SummaryType.DoubleTotalSum})
            Me.Target.PivotCalculations.Add(New PivotComputationInfo() With {.FieldName = "Weight", .FieldHeader = "Weight", .SummaryType = SummaryType.DoubleTotalSum})
        End Sub

        ''' <summary>
        ''' Loads the List as DataSource for PivotGridControl
        ''' </summary>
        Private Sub LoadList()
            Me.Target.ItemSource = Nothing
            Me.Target.ResetPivotData()
            Me.Target.ItemSource = BusinessObjectCollection.GetList(200)

            Me.Target.PivotRows.Add(New PivotItem() With {.FieldMappingName = "Fruit", .FieldHeader = "Fruit", .TotalHeader = "Total"})
            Me.Target.PivotRows.Add(New PivotItem() With {.FieldMappingName = "Color", .FieldHeader = "Color", .TotalHeader = "Total"})

            Me.Target.PivotColumns.Add(New PivotItem() With {.FieldMappingName = "Shape", .FieldHeader = "Shape", .TotalHeader = "Total"})
            Me.Target.PivotColumns.Add(New PivotItem() With {.FieldMappingName = "Even", .FieldHeader = "Even", .TotalHeader = "Total"})

            Me.Target.PivotCalculations.Add(New PivotComputationInfo() With {.FieldName = "Count", .FieldHeader = "Count", .SummaryType = SummaryType.DoubleTotalSum})
            Me.Target.PivotCalculations.Add(New PivotComputationInfo() With {.FieldName = "Section", .FieldHeader = "Section", .SummaryType = SummaryType.DoubleTotalSum})
            Me.Target.PivotCalculations.Add(New PivotComputationInfo() With {.FieldName = "Weight", .FieldHeader = "Weight", .SummaryType = SummaryType.DoubleTotalSum})

        End Sub
#End Region
    End Class
End Namespace

