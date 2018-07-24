Imports System
Imports System.Windows.Controls
Imports System.Windows.Interactivity
Imports Syncfusion.Windows.Controls.PivotGrid
Imports System.Windows
Imports Microsoft.Win32
Imports Syncfusion.Windows.Controls.PivotGrid.Converter

Namespace ExportingDemo.Action
    Public Class ExportTriggerAction
        Inherits TargetedTriggerAction(Of PivotGridControl)
        Private Shared ExportAsPivotTable As Boolean

        Protected Overrides Sub Invoke(parameter As Object)

            If TypeOf parameter Is SelectionChangedEventArgs Then
                Dim eventArgs As SelectionChangedEventArgs = TryCast(parameter, SelectionChangedEventArgs)
                Dim comboBox As ComboBox = TryCast(eventArgs.OriginalSource, ComboBox)
                ExportAsPivotTable = If((comboBox.SelectedIndex = 1), True, False)
            ElseIf TypeOf parameter Is RoutedEventArgs Then
                Try
                    Dim eventArgs As RoutedEventArgs = TryCast(parameter, RoutedEventArgs)
                    Dim exportButton As Button = TryCast(eventArgs.OriginalSource, Button)
                    Dim savedialog As SaveFileDialog = New SaveFileDialog()
                    savedialog.AddExtension = True
                    savedialog.FileName = "Sample"
                    Select Case exportButton.Content.ToString()
                        Case "Export To Excel"
                            savedialog.DefaultExt = "xlsx"
                            savedialog.Filter = "Excel file (.xlsx)|*.xlsx"
                            If savedialog.ShowDialog() = True Then
                                Dim excelExport As GridExcelExport = New GridExcelExport(Me.Target, Syncfusion.XlsIO.ExcelVersion.Excel2007)
                                excelExport.ExportMode = If((ExportAsPivotTable), ExportModes.PivotTable, ExportModes.Cell)
                                excelExport.Export(savedialog.FileName)
                                MessageBox.Show("Excel sheet exported successfully!.")
                            End If
                        Case "Export To Word"
                            savedialog.DefaultExt = "Doc"
                            savedialog.Filter = "Word file (.Doc)|*.Doc"
                            If savedialog.ShowDialog() = True Then
                                Dim wordExport As GridWordExport = New GridWordExport(Me.Target)
                                wordExport.Export(savedialog.FileName)
                                MessageBox.Show("Word document exported successfully!.")
                            End If
                        Case "Export To PDF"
                            savedialog.DefaultExt = "pdf"
                            savedialog.Filter = "Pdf file (.pdf)|*.pdf"
                            If savedialog.ShowDialog() = True Then
                                Dim pdfExport As GridPdfExport = New GridPdfExport(Me.Target)
                                pdfExport.Export(savedialog.FileName)
                                MessageBox.Show("PDF document exported successfully!.")
                            End If
                        Case Else

                    End Select

                Catch ex As Exception
                    MessageBox.Show("Error while exporting." & Environment.NewLine & "Exception Message: " & ex.Message, "Error on export", MessageBoxButton.OK, MessageBoxImage.Error)
                End Try



            End If
        End Sub

    End Class
End Namespace

