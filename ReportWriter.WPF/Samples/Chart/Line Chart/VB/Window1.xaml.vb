Imports Microsoft.VisualBasic
#Region "Copyright Syncfusion Inc. 2001 - 2011"
' Copyright Syncfusion Inc. 2001 - 2011. All rights reserved.
' Use of this code is subject to the terms of our license.
' A copy of the current license can be obtained at any time by e-mailing
' licensing@syncfusion.com. Any infringement will be prosecuted under
' applicable laws. 
#End Region
Imports System.Windows
Imports System.Windows.Media
Imports Syncfusion.ReportWriter
Imports Syncfusion.Windows.Reports

Namespace LineChart
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>
	Partial Public Class Window1
		Inherits Window
		#Region "Constructor"
		''' <summary>
		''' Window constructor
		''' </summary>
		Public Sub New()
			InitializeComponent()
			Dim img As New ImageSourceConverter()
			Dim file As String = "..\..\..\..\..\..\..\..\Common\Images\XlsIO\reportwriter_header.png"
			Me.image1.Source = CType(img.ConvertFromString(file), ImageSource)
			Dim file2 As String = "..\..\..\..\..\..\..\..\Common\Images\XlsIO\xlsio_button.png"
			Me.image2.Source = CType(img.ConvertFromString(file2), ImageSource)
			Me.Icon = Me.image2.Source
		End Sub
		#End Region

		#Region "Events"
		''' <summary>
		''' Creates spreadsheet
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
        Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Try
                Dim reportPath As String = "..\..\..\..\..\..\..\..\Common\Data\ReportTemplate\LineCharts.rdl"

                Dim fileName As String = Nothing
                Dim format As WriterFormat

                'Step 1 : Instantiate the report writer with the parameter "ReportPath".
                Dim reportWriter As New ReportWriter(reportPath)
                'Step 2 : Save the report as Pdf or Word or Excel
                If pdf.IsChecked = True Then
                    fileName = "LineCharts.pdf"
                    format = WriterFormat.PDF
                ElseIf word.IsChecked = True Then
                    fileName = "LineCharts.doc"
                    format = WriterFormat.Word
                ElseIf excel.IsChecked = True Then
                    fileName = "LineCharts.xls"
                    format = WriterFormat.Excel
                Else
                    fileName = "LineCharts.html"
                    format = WriterFormat.HTML
                End If
                reportWriter.Save(fileName, format)
                'Message box confirmation to view the created report document.
                If MessageBox.Show("Do you want to view the " & format & " file?", "" & format & " report Created", MessageBoxButton.YesNo, MessageBoxImage.Information) = MessageBoxResult.Yes Then
                    'Launching the PDF file using the default Application.[Acrobat Reader]
                    System.Diagnostics.Process.Start(fileName)
                End If
            Catch ex As System.Exception
                MessageBox.Show(ex.Message)
            End Try
        End Sub
		#End Region
	End Class
End Namespace
