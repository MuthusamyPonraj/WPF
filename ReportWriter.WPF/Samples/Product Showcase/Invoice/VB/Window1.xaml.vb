#Region "Copyright Syncfusion Inc. 2001 - 2011"
' Copyright Syncfusion Inc. 2001 - 2011. All rights reserved.
' Use of this code is subject to the terms of our license.
' A copy of the current license can be obtained at any time by e-mailing
' licensing@syncfusion.com. Any infringement will be prosecuted under
' applicable laws. 
#End Region

Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports Syncfusion.ReportWriter


Class Window1

#Region "Constructor"
    ''' <summary>
    ''' Window constructor
    ''' </summary>
    Public Sub New()
        InitializeComponent()
        Dim img As ImageSourceConverter = New ImageSourceConverter()
        Dim file As String = "..\..\..\..\..\..\..\..\Common\Images\XlsIO\reportwriter_header.png"
        Me.image1.Source = CType(img.ConvertFromString(file), ImageSource)
        Dim file2 As String = "..\..\..\..\..\..\..\..\Common\Images\XlsIO\xlsio_button.png"
            Me.image2.Source = CType(img.ConvertFromString(file2), ImageSource)
            Me.Icon = Me.image2.Source
    End Sub
#End Region

#Region "Events"
    ''' <summary>
    ''' Generates the report
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        Try
            Dim reportPath As String = "..\..\..\..\..\..\..\..\Common\Data\ReportTemplate\InvoiceTemplate.rdl"

            'Step 1 : Instantiate the report writer (PdfWriter) with the parameter "ReportPath".
            Dim engine As New PdfWriter(reportPath)

            'Step 2 : Save the report as Pdf
            engine.Save("Sample.pdf")

            'Message box confirmation to view the created PDF report.
            If MessageBox.Show("Do you want to view the PDF file?", "PDF report Created", MessageBoxButton.YesNo, MessageBoxImage.Information) = MessageBoxResult.Yes Then
                'Launching the PDF file using the default Application.[Acrobat Reader]
                System.Diagnostics.Process.Start("Sample.pdf")
                Me.Close()
            Else
                ' Exit
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region

End Class
