Imports Microsoft.VisualBasic
#Region "Copyright Syncfusion Inc. 2001 - 2011"
' Copyright Syncfusion Inc. 2001 - 2011. All rights reserved.
' Use of this code is subject to the terms of our license.
' A copy of the current license can be obtained at any time by e-mailing
' licensing@syncfusion.com. Any infringement will be prosecuted under
' applicable laws. 
#End Region
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
Imports Syncfusion.Windows.Reports
Imports System.Collections

Namespace GroupingAggregate
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
                Dim reportPath As String = "../../../../../../../../Common/Data/ReportTemplate/RDLC/GroupingAgg.rdlc"

                Dim fileName As String = Nothing
                Dim format As WriterFormat

                Dim dataSources As New ReportDataSourceCollection()
                dataSources.Add(New ReportDataSource With {.Name = "Sales", .Value = SalesDetails.GetData()})

                'Step 1 : Instantiate the report writer with the parameter "ReportPath".
                Dim reportWriter As New ReportWriter(reportPath, dataSources)
                'Step 2 : Save the report as Pdf or Word or Excel
                If pdf.IsChecked = True Then
                    fileName = "GroupingAggregate.pdf"
                    format = WriterFormat.PDF
                ElseIf word.IsChecked = True Then
                    fileName = "GroupingAggregate.doc"
                    format = WriterFormat.Word
                ElseIf excel.IsChecked = True Then
                    fileName = "GroupingAggregate.xls"
                    format = WriterFormat.Excel
                Else
                    fileName = "GroupingAggregate.html"
                    format = WriterFormat.HTML
                End If

                reportWriter.Save(fileName, format)
                'Message box confirmation to view the created report document.
                If MessageBox.Show("Do you want to view the " & format & " file?", "" & format & " report Created", MessageBoxButton.YesNo, MessageBoxImage.Information) = MessageBoxResult.Yes Then
                    'Launching the PDF file using the default Application.[Acrobat Reader]
                    System.Diagnostics.Process.Start(fileName)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Sub
		#End Region
	End Class

	#Region "Sales"

	Public Class SalesDetails
		Private privateProdCat As String
		Public Property ProdCat() As String
			Get
				Return privateProdCat
			End Get
			Set(ByVal value As String)
				privateProdCat = value
			End Set
		End Property
		Private privateSubCat As String
		Public Property SubCat() As String
			Get
				Return privateSubCat
			End Get
			Set(ByVal value As String)
				privateSubCat = value
			End Set
		End Property
		Private privateOrderYear? As Double
		Public Property OrderYear() As Double?
			Get
				Return privateOrderYear
			End Get
			Set(ByVal value? As Double)
				privateOrderYear = value
			End Set
		End Property
		Private privateOrderQtr As String
		Public Property OrderQtr() As String
			Get
				Return privateOrderQtr
			End Get
			Set(ByVal value As String)
				privateOrderQtr = value
			End Set
		End Property
		Private privateSales? As Double
		Public Property Sales() As Double?
			Get
				Return privateSales
			End Get
			Set(ByVal value? As Double)
				privateSales = value
			End Set
		End Property
		Public Shared Function GetData() As IList
			Dim datas As New List(Of SalesDetails)()
			Dim data As SalesDetails = Nothing
			data = New SalesDetails() With {.ProdCat = "Accessories", .SubCat = "Helmets", .OrderYear = 2002, .OrderQtr = "Q1", .Sales = 4945.6925}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Components", .SubCat = "Road Frames", .OrderYear = 2002, .OrderQtr = "Q3", .Sales = 957715.1942}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Components", .SubCat = "Forks", .OrderYear = 2002, .OrderQtr = "Q4", .Sales = 23543.1060}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Bikes", .SubCat = "Road Bikes", .OrderYear = 2002, .OrderQtr = "Q1", .Sales = 3171787.6112}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Accessories", .SubCat = "Helmets", .OrderYear = 2002, .OrderQtr = "Q3", .Sales = 33853.1033}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Components", .SubCat = "Wheels", .OrderYear = 2002, .OrderQtr = "Q4", .Sales = 163921.8870}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Bikes", .SubCat = "Road Bikes", .OrderYear = 2003, .OrderQtr = "Q2", .Sales = 4119658.6506}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Clothing", .SubCat = "Socks", .OrderYear = 2003, .OrderQtr = "Q3", .Sales = 6968.6884}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Bikes", .SubCat = "Road Bikes", .OrderYear = 2003, .OrderQtr = "Q4", .Sales = 3734891.6389}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Components", .SubCat = "Mountain Frames", .OrderYear = 2002, .OrderQtr = "Q3", .Sales = 608352.8754}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Components", .SubCat = "Handlebars", .OrderYear = 2002, .OrderQtr = "Q4", .Sales = 18309.4452}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Components", .SubCat = "Road Frames", .OrderYear = 2003, .OrderQtr = "Q4", .Sales = 286591.8208}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Accessories", .SubCat = "Tires and Tubes", .OrderYear = 2003, .OrderQtr = "Q3", .Sales = 41940.3364}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Components", .SubCat = "Mountain Frames", .OrderYear = 2003, .OrderQtr = "Q2", .Sales = 440260.9831}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Components", .SubCat = "Road Frames", .OrderYear = 2003, .OrderQtr = "Q2", .Sales = 457688.8401}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Clothing", .SubCat = "Vests", .OrderYear = 2003, .OrderQtr = "Q4", .Sales = 66882.6450}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Accessories", .SubCat = "Pumps", .OrderYear = 2002, .OrderQtr = "Q4", .Sales = 3226.3860}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Clothing", .SubCat = "Tights", .OrderYear = 2003, .OrderQtr = "Q2", .Sales = 51600.6190}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Components", .SubCat = "Chains", .OrderYear = 2003, .OrderQtr = "Q3", .Sales = 3476.0176}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Components", .SubCat = "Handlebars", .OrderYear = 2003, .OrderQtr = "Q2", .Sales = 17194.2146}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Components", .SubCat = "Mountain Frames", .OrderYear = 2003, .OrderQtr = "Q4", .Sales = 565229.8810}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Clothing", .SubCat = "Tights", .OrderYear = 2003, .OrderQtr = "Q4", .Sales = 243.7175}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Components", .SubCat = "Road Frames", .OrderYear = 2002, .OrderQtr = "Q2", .Sales = 155311.4063}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Components", .SubCat = "Mountain Frames", .OrderYear = 2002, .OrderQtr = "Q2", .Sales = 220935.1648}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Accessories", .SubCat = "Locks", .OrderYear = 2003, .OrderQtr = "Q4", .Sales = 15.0000}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Components", .SubCat = "Mountain Frames", .OrderYear = 2003, .OrderQtr = "Q3", .Sales = 827287.5234}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Accessories", .SubCat = "Bike Racks", .OrderYear = 2003, .OrderQtr = "Q3", .Sales = 75920.4000}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Components", .SubCat = "Bottom Brackets", .OrderYear = 2003, .OrderQtr = "Q3", .Sales = 17453.6400}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Bikes", .SubCat = "Touring Bikes", .OrderYear = 2003, .OrderQtr = "Q3", .Sales = 3298006.2858}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Components", .SubCat = "Brakes", .OrderYear = 2003, .OrderQtr = "Q4", .Sales = 18571.4700}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Clothing", .SubCat = "Tights", .OrderYear = 2002, .OrderQtr = "Q4", .Sales = 56782.4280}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Components", .SubCat = "Pedals", .OrderYear = 2003, .OrderQtr = "Q3", .Sales = 54185.2014}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Clothing", .SubCat = "Jerseys", .OrderYear = 2003, .OrderQtr = "Q3", .Sales = 173041.0492}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Clothing", .SubCat = "Jerseys", .OrderYear = 2002, .OrderQtr = "Q2", .Sales = 16931.2362}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Components", .SubCat = "Headsets", .OrderYear = 2002, .OrderQtr = "Q3", .Sales = 19701.9001}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Components", .SubCat = "Road Frames", .OrderYear = 2002, .OrderQtr = "Q4", .Sales = 458089.4246}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Clothing", .SubCat = "Shorts", .OrderYear = 2003, .OrderQtr = "Q1", .Sales = 11230.1280}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Bikes", .SubCat = "Road Bikes", .OrderYear = 2002, .OrderQtr = "Q4", .Sales = 4189621.8590}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Components", .SubCat = "Brakes", .OrderYear = 2003, .OrderQtr = "Q3", .Sales = 26659.0800}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Components", .SubCat = "Wheels", .OrderYear = 2003, .OrderQtr = "Q4", .Sales = 83.2981}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Clothing", .SubCat = "Vests", .OrderYear = 2003, .OrderQtr = "Q3", .Sales = 81085.6900}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Components", .SubCat = "Cranksets", .OrderYear = 2003, .OrderQtr = "Q3", .Sales = 80244.1372}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Clothing", .SubCat = "Socks", .OrderYear = 2003, .OrderQtr = "Q4", .Sales = 6183.1422}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Components", .SubCat = "Wheels", .OrderYear = 2003, .OrderQtr = "Q2", .Sales = 163929.9435}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Clothing", .SubCat = "Tights", .OrderYear = 2002, .OrderQtr = "Q3", .Sales = 67088.3037}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Clothing", .SubCat = "Tights", .OrderYear = 2003, .OrderQtr = "Q3", .Sales = 779.8960}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Clothing", .SubCat = "Socks", .OrderYear = 2002, .OrderQtr = "Q1", .Sales = 1273.8550}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Bikes", .SubCat = "Road Bikes", .OrderYear = 2002, .OrderQtr = "Q3", .Sales = 4930692.7825}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Clothing", .SubCat = "Shorts", .OrderYear = 2003, .OrderQtr = "Q4", .Sales = 84192.3708}
			datas.Add(data)
			data = New SalesDetails() With {.ProdCat = "Clothing", .SubCat = "Jerseys", .OrderYear = 2002, .OrderQtr = "Q3", .Sales = 48901.7598}
			datas.Add(data)
			Return datas
		End Function
	End Class
	#End Region
End Namespace
