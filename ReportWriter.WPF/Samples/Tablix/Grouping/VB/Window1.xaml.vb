﻿Imports Microsoft.VisualBasic
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

Namespace Grouping
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
                Dim reportPath As String = "../../../../../../../../Common/Data/ReportTemplate/RDLC/Grouping.rdlc"

                Dim fileName As String = Nothing
                Dim format As WriterFormat

                Dim dataSources As New ReportDataSourceCollection()
                dataSources.Add(New ReportDataSource With {.Name = "Customers", .Value = Customers.GetData()})

                'Step 1 : Instantiate the report writer with the parameter "ReportPath".
                Dim reportWriter As New ReportWriter(reportPath, dataSources)
                'Step 2 : Save the report as Pdf or Word or Excel
                If pdf.IsChecked = True Then
                    fileName = "Grouping.pdf"
                    format = WriterFormat.PDF
                ElseIf word.IsChecked = True Then
                    fileName = "Grouping.doc"
                    format = WriterFormat.Word
                ElseIf excel.IsChecked = True Then
                    fileName = "Grouping.xls"
                    format = WriterFormat.Excel
                Else
                    fileName = "Grouping.html"
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

	#Region "Customer details"

	Public Class Customers
		Private privateSalesOrderNumber As String
		Public Property SalesOrderNumber() As String
			Get
				Return privateSalesOrderNumber
			End Get
			Set(ByVal value As String)
				privateSalesOrderNumber = value
			End Set
		End Property
		Private privateStore As String
		Public Property Store() As String
			Get
				Return privateStore
			End Get
			Set(ByVal value As String)
				privateStore = value
			End Set
		End Property
		Private privateOrderDate As DateTime
		Public Property OrderDate() As DateTime
			Get
				Return privateOrderDate
			End Get
			Set(ByVal value As DateTime)
				privateOrderDate = value
			End Set
		End Property
		Private privateSalesFirstName As String
		Public Property SalesFirstName() As String
			Get
				Return privateSalesFirstName
			End Get
			Set(ByVal value As String)
				privateSalesFirstName = value
			End Set
		End Property
		Private privateSalesLastName As String
		Public Property SalesLastName() As String
			Get
				Return privateSalesLastName
			End Get
			Set(ByVal value As String)
				privateSalesLastName = value
			End Set
		End Property
		Private privateSalesTitle As String
		Public Property SalesTitle() As String
			Get
				Return privateSalesTitle
			End Get
			Set(ByVal value As String)
				privateSalesTitle = value
			End Set
		End Property
		Private privatePurchaseOrderNumber As String
		Public Property PurchaseOrderNumber() As String
			Get
				Return privatePurchaseOrderNumber
			End Get
			Set(ByVal value As String)
				privatePurchaseOrderNumber = value
			End Set
		End Property
		Private privateShipMethod As String
		Public Property ShipMethod() As String
			Get
				Return privateShipMethod
			End Get
			Set(ByVal value As String)
				privateShipMethod = value
			End Set
		End Property
		Private privateBillAddress1 As String
		Public Property BillAddress1() As String
			Get
				Return privateBillAddress1
			End Get
			Set(ByVal value As String)
				privateBillAddress1 = value
			End Set
		End Property
		Private privateBillAddress2 As String
		Public Property BillAddress2() As String
			Get
				Return privateBillAddress2
			End Get
			Set(ByVal value As String)
				privateBillAddress2 = value
			End Set
		End Property
		Private privateBillCity As String
		Public Property BillCity() As String
			Get
				Return privateBillCity
			End Get
			Set(ByVal value As String)
				privateBillCity = value
			End Set
		End Property
		Private privateBillPostalCode As String
		Public Property BillPostalCode() As String
			Get
				Return privateBillPostalCode
			End Get
			Set(ByVal value As String)
				privateBillPostalCode = value
			End Set
		End Property
		Private privateBillStateProvince As String
		Public Property BillStateProvince() As String
			Get
				Return privateBillStateProvince
			End Get
			Set(ByVal value As String)
				privateBillStateProvince = value
			End Set
		End Property
		Private privateBillCountryRegion As String
		Public Property BillCountryRegion() As String
			Get
				Return privateBillCountryRegion
			End Get
			Set(ByVal value As String)
				privateBillCountryRegion = value
			End Set
		End Property
		Private privateShipAddress1 As String
		Public Property ShipAddress1() As String
			Get
				Return privateShipAddress1
			End Get
			Set(ByVal value As String)
				privateShipAddress1 = value
			End Set
		End Property
		Private privateShipAddress2 As String
		Public Property ShipAddress2() As String
			Get
				Return privateShipAddress2
			End Get
			Set(ByVal value As String)
				privateShipAddress2 = value
			End Set
		End Property
		Private privateShipCity As String
		Public Property ShipCity() As String
			Get
				Return privateShipCity
			End Get
			Set(ByVal value As String)
				privateShipCity = value
			End Set
		End Property
		Private privateShipPostalCode As String
		Public Property ShipPostalCode() As String
			Get
				Return privateShipPostalCode
			End Get
			Set(ByVal value As String)
				privateShipPostalCode = value
			End Set
		End Property
		Private privateShipStateProvince As String
		Public Property ShipStateProvince() As String
			Get
				Return privateShipStateProvince
			End Get
			Set(ByVal value As String)
				privateShipStateProvince = value
			End Set
		End Property
		Private privateShipCountryRegion As String
		Public Property ShipCountryRegion() As String
			Get
				Return privateShipCountryRegion
			End Get
			Set(ByVal value As String)
				privateShipCountryRegion = value
			End Set
		End Property
		Private privateCustPhone As String
		Public Property CustPhone() As String
			Get
				Return privateCustPhone
			End Get
			Set(ByVal value As String)
				privateCustPhone = value
			End Set
		End Property
		Private privateCustFirstName As String
		Public Property CustFirstName() As String
			Get
				Return privateCustFirstName
			End Get
			Set(ByVal value As String)
				privateCustFirstName = value
			End Set
		End Property
		Private privateCustLastName As String
		Public Property CustLastName() As String
			Get
				Return privateCustLastName
			End Get
			Set(ByVal value As String)
				privateCustLastName = value
			End Set
		End Property
		Public Shared Function GetData() As IList
			Dim datas As New List(Of Customers)()
			Dim data As Customers = Nothing
			data = New Customers() With {.SalesOrderNumber = "SO43666", .Store = "Wheel Gallery", .OrderDate = New DateTime(2001, 7, 1, 0, 0, 0), .SalesFirstName = "Linda", .SalesLastName = "Mitchell", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO16008173883", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "9920 Bridgepointe Parkway", .BillAddress2 = "", .BillCity = "San Mateo", .BillPostalCode = "94404", .BillStateProvince = "California", .BillCountryRegion = "United States", .ShipAddress1 = "9920 Bridgepointe Parkway", .ShipAddress2 = "", .ShipCity = "San Mateo", .ShipPostalCode = "94404", .ShipStateProvince = "California", .ShipCountryRegion = "United States", .CustPhone = "926-555-0136", .CustFirstName = "Abraham", .CustLastName = "Swearengin"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43672", .Store = "Red Bicycle Company", .OrderDate = New DateTime(2001, 7, 1, 0, 0, 0), .SalesFirstName = "José", .SalesLastName = "Saraiva", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO13862153537", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "99, Rue Saint-pierre", .BillAddress2 = "", .BillCity = "Pnot-Rouge", .BillPostalCode = "J1E 2T7", .BillStateProvince = "Quebec", .BillCountryRegion = "Canada", .ShipAddress1 = "99, Rue Saint-pierre", .ShipAddress2 = "", .ShipCity = "Pnot-Rouge", .ShipPostalCode = "J1E 2T7", .ShipStateProvince = "Quebec", .ShipCountryRegion = "Canada", .CustPhone = "667-555-0112", .CustFirstName = "Phyllis", .CustLastName = "Thomas"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43685", .Store = "Simple Bike Parts", .OrderDate = New DateTime(2001, 7, 1, 0, 0, 0), .SalesFirstName = "Tsvi", .SalesLastName = "Reiter", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO4176124783", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "Silver Sands Factory Outlet", .BillAddress2 = "", .BillCity = "Destin", .BillPostalCode = "32541", .BillStateProvince = "Florida", .BillCountryRegion = "United States", .ShipAddress1 = "Silver Sands Factory Outlet", .ShipAddress2 = "", .ShipCity = "Destin", .ShipPostalCode = "32541", .ShipStateProvince = "Florida", .ShipCountryRegion = "United States", .CustPhone = "317-555-0163", .CustFirstName = "Abe", .CustLastName = "Tramel"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43843", .Store = "Catalog Store", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Michael", .SalesLastName = "Blythe", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO19923118772", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "855 East Main Avenue", .BillAddress2 = "", .BillCity = "Zeeland", .BillPostalCode = "49464", .BillStateProvince = "Michigan", .BillCountryRegion = "United States", .ShipAddress1 = "855 East Main Avenue", .ShipAddress2 = "", .ShipCity = "Zeeland", .ShipPostalCode = "49464", .ShipStateProvince = "Michigan", .ShipCountryRegion = "United States", .CustPhone = "440-555-0132", .CustFirstName = "David", .CustLastName = "Liu"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43844", .Store = "Two-Wheeled Transit Company", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "José", .SalesLastName = "Saraiva", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO19691138342", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "P.O. Box 44000", .BillAddress2 = "", .BillCity = "Winnipeg", .BillPostalCode = "R3", .BillStateProvince = "Manitoba", .BillCountryRegion = "Canada", .ShipAddress1 = "P.O. Box 44000", .ShipAddress2 = "", .ShipCity = "Winnipeg", .ShipPostalCode = "R3", .ShipStateProvince = "Manitoba", .ShipCountryRegion = "Canada", .CustPhone = "700-555-0155", .CustFirstName = "Joan", .CustLastName = "Campbell"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43845", .Store = "New and Used Bicycles", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Tsvi", .SalesLastName = "Reiter", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO19546184286", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "3990 Silas Creek Parkway", .BillAddress2 = "", .BillCity = "Winston-Salem", .BillPostalCode = "27104", .BillStateProvince = "North Carolina", .BillCountryRegion = "United States", .ShipAddress1 = "3990 Silas Creek Parkway", .ShipAddress2 = "", .ShipCity = "Winston-Salem", .ShipPostalCode = "27104", .ShipStateProvince = "North Carolina", .ShipCountryRegion = "United States", .CustPhone = "895-555-0160", .CustFirstName = "Brannon", .CustLastName = "Jones"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43846", .Store = "First-Rate Outlet", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Garrett", .SalesLastName = "Vargas", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO19430112391", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "25537 Hillside Avenue", .BillAddress2 = "", .BillCity = "Victoria", .BillPostalCode = "V8V", .BillStateProvince = "British Columbia", .BillCountryRegion = "Canada", .ShipAddress1 = "25537 Hillside Avenue", .ShipAddress2 = "", .ShipCity = "Victoria", .ShipPostalCode = "V8V", .ShipStateProvince = "British Columbia", .ShipCountryRegion = "Canada", .CustPhone = "277-555-0169", .CustFirstName = "Ann", .CustLastName = "Beebe"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43847", .Store = "Gasless Cycle Shop", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Garrett", .SalesLastName = "Vargas", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO19227161888", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "25 First Canadian Place", .BillAddress2 = "", .BillCity = "Toronto", .BillPostalCode = "M4B 1V5", .BillStateProvince = "Ontario", .BillCountryRegion = "Canada", .ShipAddress1 = "25 First Canadian Place", .ShipAddress2 = "", .ShipCity = "Toronto", .ShipPostalCode = "M4B 1V5", .ShipStateProvince = "Ontario", .ShipCountryRegion = "Canada", .CustPhone = "584-555-0192", .CustFirstName = "Josh", .CustLastName = "Barnhill"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43848", .Store = "Suburban Cycle Shop", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "David", .SalesLastName = "Campbell", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO18908190536", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "994 Sw Cherry Park Rd", .BillAddress2 = "", .BillCity = "Troutdale", .BillPostalCode = "97060", .BillStateProvince = "Oregon", .BillCountryRegion = "United States", .ShipAddress1 = "994 Sw Cherry Park Rd", .ShipAddress2 = "", .ShipCity = "Troutdale", .ShipPostalCode = "97060", .ShipStateProvince = "Oregon", .ShipCountryRegion = "United States", .CustPhone = "706-555-0140", .CustFirstName = "Cindy", .CustLastName = "Dodd"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43849", .Store = "Brakes and Gears", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Stephen", .SalesLastName = "Jiang", .SalesTitle = "North American Sales Manager", .PurchaseOrderNumber = "PO18676186169", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "9927 N. Main St.", .BillAddress2 = "", .BillCity = "Tooele", .BillPostalCode = "84074", .BillStateProvince = "Utah", .BillCountryRegion = "United States", .ShipAddress1 = "9927 N. Main St.", .ShipAddress2 = "", .ShipCity = "Tooele", .ShipPostalCode = "84074", .ShipStateProvince = "Utah", .ShipCountryRegion = "United States", .CustPhone = "774-555-0133", .CustFirstName = "Roger", .CustLastName = "Harui"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43850", .Store = "Non-Slip Pedal Company", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "José", .SalesLastName = "Saraiva", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO18415143340", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "258 King Street East", .BillAddress2 = "", .BillCity = "Toronto", .BillPostalCode = "M4B 1V7", .BillStateProvince = "Ontario", .BillCountryRegion = "Canada", .ShipAddress1 = "258 King Street East", .ShipAddress2 = "", .ShipCity = "Toronto", .ShipPostalCode = "M4B 1V7", .ShipStateProvince = "Ontario", .ShipCountryRegion = "Canada", .CustPhone = "303-555-0117", .CustFirstName = "Sandra", .CustLastName = "Kitt"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43851", .Store = "Retail Sales and Service", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Michael", .SalesLastName = "Blythe", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO18386167654", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "Lake Region Factory Outlet", .BillAddress2 = "", .BillCity = "Tilton", .BillPostalCode = "03276", .BillStateProvince = "New Hampshire", .BillCountryRegion = "United States", .ShipAddress1 = "Lake Region Factory Outlet", .ShipAddress2 = "", .ShipCity = "Tilton", .ShipPostalCode = "03276", .ShipStateProvince = "New Hampshire", .ShipCountryRegion = "United States", .CustPhone = "607-555-0193", .CustFirstName = "Michael", .CustLastName = "Allen"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43852", .Store = "Economy Center", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "José", .SalesLastName = "Saraiva", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO17864179720", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "6th Floor, 25st Canadian Place", .BillAddress2 = "", .BillCity = "Toronto", .BillPostalCode = "M4B 1V5", .BillStateProvince = "Ontario", .BillCountryRegion = "Canada", .ShipAddress1 = "6th Floor, 25st Canadian Place", .ShipAddress2 = "", .ShipCity = "Toronto", .ShipPostalCode = "M4B 1V5", .ShipStateProvince = "Ontario", .ShipCountryRegion = "Canada", .CustPhone = "555-555-0162", .CustFirstName = "Curtis", .CustLastName = "Howard"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43853", .Store = "Sharp Bikes", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "José", .SalesLastName = "Saraiva", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO18270155899", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "52560 Free Street", .BillAddress2 = "", .BillCity = "Toronto", .BillPostalCode = "M4B 1V7", .BillStateProvince = "Ontario", .BillCountryRegion = "Canada", .ShipAddress1 = "52560 Free Street", .ShipAddress2 = "", .ShipCity = "Toronto", .ShipPostalCode = "M4B 1V7", .ShipStateProvince = "Ontario", .ShipCountryRegion = "Canada", .CustPhone = "926-555-0159", .CustFirstName = "Katherine", .CustLastName = "Harding"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43854", .Store = "Professional Cyclists", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "José", .SalesLastName = "Saraiva", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO17777139245", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "2545 King Street West", .BillAddress2 = "", .BillCity = "Toronto", .BillPostalCode = "M4B 1V7", .BillStateProvince = "Ontario", .BillCountryRegion = "Canada", .ShipAddress1 = "2545 King Street West", .ShipAddress2 = "", .ShipCity = "Toronto", .ShipPostalCode = "M4B 1V7", .ShipStateProvince = "Ontario", .ShipCountryRegion = "Canada", .CustPhone = "154-555-0115", .CustFirstName = "Steve", .CustLastName = "Masters"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43855", .Store = "National Manufacturing", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Garrett", .SalesLastName = "Vargas", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO17748116016", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "630 University Avenue", .BillAddress2 = "", .BillCity = "Toronto", .BillPostalCode = "M4B 1V7", .BillStateProvince = "Ontario", .BillCountryRegion = "Canada", .ShipAddress1 = "630 University Avenue", .ShipAddress2 = "", .ShipCity = "Toronto", .ShipPostalCode = "M4B 1V7", .ShipStateProvince = "Ontario", .ShipCountryRegion = "Canada", .CustPhone = "493-555-0134", .CustFirstName = "Linda", .CustLastName = "Leste"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43856", .Store = "Sixth Bike Store", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "José", .SalesLastName = "Saraiva", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO17313123131", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "Suite 25800 3401 - 10810th Avenue", .BillAddress2 = "", .BillCity = "Surrey", .BillPostalCode = "V3T 4W3", .BillStateProvince = "British Columbia", .BillCountryRegion = "Canada", .ShipAddress1 = "Suite 25800 3401 - 10810th Avenue", .ShipAddress2 = "", .ShipCity = "Surrey", .ShipPostalCode = "V3T 4W3", .ShipStateProvince = "British Columbia", .ShipCountryRegion = "Canada", .CustPhone = "428-555-0176", .CustFirstName = "Dorothy", .CustLastName = "Contreras"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43857", .Store = "Tenth Bike Store", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "José", .SalesLastName = "Saraiva", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO16733124458", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "Depot 80", .BillAddress2 = "", .BillCity = "Sillery", .BillPostalCode = "G1T", .BillStateProvince = "Quebec", .BillCountryRegion = "Canada", .ShipAddress1 = "Depot 80", .ShipAddress2 = "", .ShipCity = "Sillery", .ShipPostalCode = "G1T", .ShipStateProvince = "Quebec", .ShipCountryRegion = "Canada", .CustPhone = "744-555-0123", .CustFirstName = "Yuping", .CustLastName = "Tian"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43858", .Store = "Exotic Bikes", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Michael", .SalesLastName = "Blythe", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO16791124272", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "6900 William Richardson Ct.", .BillAddress2 = "", .BillCity = "South Bend", .BillPostalCode = "46601", .BillStateProvince = "Indiana", .BillCountryRegion = "United States", .ShipAddress1 = "6900 William Richardson Ct.", .ShipAddress2 = "", .ShipCity = "South Bend", .ShipPostalCode = "46601", .ShipStateProvince = "Indiana", .ShipCountryRegion = "United States", .CustPhone = "415-555-0147", .CustFirstName = "John", .CustLastName = "Long"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43859", .Store = "Highway Bike Shop", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Linda", .SalesLastName = "Mitchell", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO16762199940", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "Simi @ The Plaza", .BillAddress2 = "", .BillCity = "Simi Valley", .BillPostalCode = "93065", .BillStateProvince = "California", .BillCountryRegion = "United States", .ShipAddress1 = "Simi @ The Plaza", .ShipAddress2 = "", .ShipCity = "Simi Valley", .ShipPostalCode = "93065", .ShipStateProvince = "California", .ShipCountryRegion = "United States", .CustPhone = "199-555-0135", .CustFirstName = "Lucio", .CustLastName = "Iallo"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43860", .Store = "A Bike Store", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Pamela", .SalesLastName = "Ansman-Wolfe", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO16646146654", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "2251 Elliot Avenue", .BillAddress2 = "", .BillCity = "Seattle", .BillPostalCode = "98104", .BillStateProvince = "Washington", .BillCountryRegion = "United States", .ShipAddress1 = "2251 Elliot Avenue", .ShipAddress2 = "", .ShipCity = "Seattle", .ShipPostalCode = "98104", .ShipStateProvince = "Washington", .ShipCountryRegion = "United States", .CustPhone = "245-555-0173", .CustFirstName = "Orlando", .CustLastName = "Gee"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43861", .Store = "Qualified Sales and Repair Services", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Tsvi", .SalesLastName = "Reiter", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO16327172067", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "Savannah Festival Outlet", .BillAddress2 = "", .BillCity = "Savannah", .BillPostalCode = "31401", .BillStateProvince = "Georgia", .BillCountryRegion = "United States", .ShipAddress1 = "Savannah Festival Outlet", .ShipAddress2 = "", .ShipCity = "Savannah", .ShipPostalCode = "31401", .ShipStateProvince = "Georgia", .ShipCountryRegion = "United States", .CustPhone = "475-555-0188", .CustFirstName = "Hanying", .CustLastName = "Feng"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43862", .Store = "Unified Sports Company", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Tsvi", .SalesLastName = "Reiter", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO16211194171", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "9876 Fruitville Rd", .BillAddress2 = "", .BillCity = "Sarasota", .BillPostalCode = "34236", .BillStateProvince = "Florida", .BillCountryRegion = "United States", .ShipAddress1 = "9876 Fruitville Rd", .ShipAddress2 = "", .ShipCity = "Sarasota", .ShipPostalCode = "34236", .ShipStateProvince = "Florida", .ShipCountryRegion = "United States", .CustPhone = "296-555-0171", .CustFirstName = "Gloria", .CustLastName = "Lesko"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43863", .Store = "Social Activities Club", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Jillian", .SalesLastName = "Carson", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO15747169584", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "23025 S.W. Military Rd.", .BillAddress2 = "", .BillCity = "San Antonio", .BillPostalCode = "78204", .BillStateProvince = "Texas", .BillCountryRegion = "United States", .ShipAddress1 = "23025 S.W. Military Rd.", .ShipAddress2 = "", .ShipCity = "San Antonio", .ShipPostalCode = "78204", .ShipStateProvince = "Texas", .ShipCountryRegion = "United States", .CustPhone = "596-555-0153", .CustFirstName = "John", .CustLastName = "Ford"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43864", .Store = "Sparkling Paint and Finishes", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Linda", .SalesLastName = "Mitchell", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO16037151094", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "San Diego Factory", .BillAddress2 = "", .BillCity = "San Ysidro", .BillPostalCode = "92173", .BillStateProvince = "California", .BillCountryRegion = "United States", .ShipAddress1 = "San Diego Factory", .ShipAddress2 = "", .ShipCity = "San Ysidro", .ShipPostalCode = "92173", .ShipStateProvince = "California", .ShipCountryRegion = "United States", .CustPhone = "787-555-0128", .CustFirstName = "Clarence", .CustLastName = "Tatman"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43865", .Store = "Totes & Baskets Company", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Jillian", .SalesLastName = "Carson", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO15689147174", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "72540 Blanco Rd.", .BillAddress2 = "", .BillCity = "San Antonio", .BillPostalCode = "78204", .BillStateProvince = "Texas", .BillCountryRegion = "United States", .ShipAddress1 = "72540 Blanco Rd.", .ShipAddress2 = "", .ShipCity = "San Antonio", .ShipPostalCode = "78204", .ShipStateProvince = "Texas", .ShipCountryRegion = "United States", .CustPhone = "560-555-0171", .CustFirstName = "Robert", .CustLastName = "Vessa"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43866", .Store = "Moderately-Priced Bikes Store", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Pamela", .SalesLastName = "Ansman-Wolfe", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO14529112624", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "67 Rainer Ave S", .BillAddress2 = "", .BillCity = "Renton", .BillPostalCode = "98055", .BillStateProvince = "Washington", .BillCountryRegion = "United States", .ShipAddress1 = "67 Rainer Ave S", .ShipAddress2 = "", .ShipCity = "Renton", .ShipPostalCode = "98055", .ShipStateProvince = "Washington", .ShipCountryRegion = "United States", .CustPhone = "763-555-0145", .CustFirstName = "Gabriel", .CustLastName = "Bockenkamp"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43867", .Store = "Raw Materials Inc", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Pamela", .SalesLastName = "Ansman-Wolfe", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO14471123403", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "Bldg. 9n/99298", .BillAddress2 = "", .BillCity = "Redmond", .BillPostalCode = "98052", .BillStateProvince = "Washington", .BillCountryRegion = "United States", .ShipAddress1 = "Bldg. 9n/99298", .ShipAddress2 = "", .ShipCity = "Redmond", .ShipPostalCode = "98052", .ShipStateProvince = "Washington", .ShipCountryRegion = "United States", .CustPhone = "962-555-0166", .CustFirstName = "Ted", .CustLastName = "Bremer"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43868", .Store = "Major Cycling", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "José", .SalesLastName = "Saraiva", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO14848158712", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "46990 Viking Way", .BillAddress2 = "", .BillCity = "Richmond", .BillPostalCode = "V6B 3P7", .BillStateProvince = "British Columbia", .BillCountryRegion = "Canada", .ShipAddress1 = "46990 Viking Way", .ShipAddress2 = "", .ShipCity = "Richmond", .ShipPostalCode = "V6B 3P7", .ShipStateProvince = "British Columbia", .ShipCountryRegion = "Canada", .CustPhone = "512-555-0122", .CustFirstName = "Ruby Sue", .CustLastName = "Styles"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43869", .Store = "Permanent Finish Products", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Linda", .SalesLastName = "Mitchell", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO14500145975", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "62500 Neil Road", .BillAddress2 = "", .BillCity = "Reno", .BillPostalCode = "89502", .BillStateProvince = "Nevada", .BillCountryRegion = "United States", .ShipAddress1 = "62500 Neil Road", .ShipAddress2 = "", .ShipCity = "Reno", .ShipPostalCode = "89502", .ShipStateProvince = "Nevada", .ShipCountryRegion = "United States", .CustPhone = "265-555-0143", .CustFirstName = "Margaret", .CustLastName = "Vanderkamp"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43870", .Store = "Wholesale Bikes", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Michael", .SalesLastName = "Blythe", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO14326149236", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "58 Teed Drive", .BillAddress2 = "", .BillCity = "Randolph", .BillPostalCode = "02368", .BillStateProvince = "Massachusetts", .BillCountryRegion = "United States", .ShipAddress1 = "58 Teed Drive", .ShipAddress2 = "", .ShipCity = "Randolph", .ShipPostalCode = "02368", .ShipStateProvince = "Massachusetts", .ShipCountryRegion = "United States", .CustPhone = "652-555-0115", .CustFirstName = "Aaron", .CustLastName = "Con"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43871", .Store = "Fun Times Club", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Shu", .SalesLastName = "Ito", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO13572145817", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "8525 South Parker Road", .BillAddress2 = "", .BillCity = "Parker", .BillPostalCode = "80138", .BillStateProvince = "Colorado", .BillCountryRegion = "United States", .ShipAddress1 = "8525 South Parker Road", .ShipAddress2 = "", .ShipCity = "Parker", .ShipPostalCode = "80138", .ShipStateProvince = "Colorado", .ShipCountryRegion = "United States", .CustPhone = "847-555-0184", .CustFirstName = "Diane", .CustLastName = "Tibbott"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43872", .Store = "Wire Baskets and Parts", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Linda", .SalesLastName = "Mitchell", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO12557127067", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "Mall Of Orange", .BillAddress2 = "", .BillCity = "Orange", .BillPostalCode = "92867", .BillStateProvince = "California", .BillCountryRegion = "United States", .ShipAddress1 = "Mall Of Orange", .ShipAddress2 = "", .ShipCity = "Orange", .ShipPostalCode = "92867", .ShipStateProvince = "California", .ShipCountryRegion = "United States", .CustPhone = "103-555-0179", .CustFirstName = "Jessie", .CustLastName = "Valerio"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43873", .Store = "Preferred Bikes", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Linda", .SalesLastName = "Mitchell", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO12499138177", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "Incom Sports Center", .BillAddress2 = "", .BillCity = "Ontario", .BillPostalCode = "91764", .BillStateProvince = "California", .BillCountryRegion = "United States", .ShipAddress1 = "Incom Sports Center", .ShipAddress2 = "", .ShipCity = "Ontario", .ShipPostalCode = "91764", .ShipStateProvince = "California", .ShipCountryRegion = "United States", .CustPhone = "819-555-0186", .CustFirstName = "Stefan", .CustLastName = "Delmarco"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43874", .Store = "Travel Systems", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Jillian", .SalesLastName = "Carson", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO12122162917", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "2505 Gateway Drive", .BillAddress2 = "", .BillCity = "North Sioux City", .BillPostalCode = "57049", .BillStateProvince = "South Dakota", .BillCountryRegion = "United States", .ShipAddress1 = "2505 Gateway Drive", .ShipAddress2 = "", .ShipCity = "North Sioux City", .ShipPostalCode = "57049", .ShipStateProvince = "South Dakota", .ShipCountryRegion = "United States", .CustPhone = "121-555-0121", .CustFirstName = "Linda", .CustLastName = "Burnett"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43696", .Store = "Retail Toy Store", .OrderDate = New DateTime(2001, 7, 1, 0, 0, 0), .SalesFirstName = "Tsvi", .SalesLastName = "Reiter", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO9947131800", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "Dadeland Mall, Space 25090", .BillAddress2 = "", .BillCity = "Miami", .BillPostalCode = "33127", .BillStateProvince = "Florida", .BillCountryRegion = "United States", .ShipAddress1 = "Dadeland Mall, Space 25090", .ShipAddress2 = "", .ShipCity = "Miami", .ShipPostalCode = "33127", .ShipStateProvince = "Florida", .ShipCountryRegion = "United States", .CustPhone = "140-555-0188", .CustFirstName = "Barbara", .CustLastName = "Hoffman"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43695", .Store = "Sports Sales and Rental", .OrderDate = New DateTime(2001, 7, 1, 0, 0, 0), .SalesFirstName = "Tsvi", .SalesLastName = "Reiter", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO10179176559", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "100 Fifth Drive", .BillAddress2 = "", .BillCity = "Millington", .BillPostalCode = "38054", .BillStateProvince = "Tennessee", .BillCountryRegion = "United States", .ShipAddress1 = "100 Fifth Drive", .ShipAddress2 = "", .ShipCity = "Millington", .ShipPostalCode = "38054", .ShipStateProvince = "Tennessee", .ShipCountryRegion = "United States", .CustPhone = "284-555-0185", .CustFirstName = "Run", .CustLastName = "Liu"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43694", .Store = "Juvenile Sports Equipment", .OrderDate = New DateTime(2001, 7, 1, 0, 0, 0), .SalesFirstName = "Tsvi", .SalesLastName = "Reiter", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO9657130250", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "78025 E. Mercy Island Cswy", .BillAddress2 = "", .BillCity = "Merritt Island", .BillPostalCode = "32952", .BillStateProvince = "Florida", .BillCountryRegion = "United States", .ShipAddress1 = "78025 E. Mercy Island Cswy", .ShipAddress2 = "", .ShipCity = "Merritt Island", .ShipPostalCode = "32952", .ShipStateProvince = "Florida", .ShipCountryRegion = "United States", .CustPhone = "843-555-0175", .CustFirstName = "Shane", .CustLastName = "Belli"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43693", .Store = "Clamps & Brackets Co.", .OrderDate = New DateTime(2001, 7, 1, 0, 0, 0), .SalesFirstName = "Michael", .SalesLastName = "Blythe", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO8120182325", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "Leesburg Premium Outlet Centre", .BillAddress2 = "", .BillCity = "Leesburg", .BillPostalCode = "20176", .BillStateProvince = "Virginia", .BillCountryRegion = "United States", .ShipAddress1 = "Leesburg Premium Outlet Centre", .ShipAddress2 = "", .ShipCity = "Leesburg", .ShipPostalCode = "20176", .ShipStateProvince = "Virginia", .ShipCountryRegion = "United States", .CustPhone = "107-555-0138", .CustFirstName = "Carla", .CustLastName = "Adams"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43692", .Store = "Bike Dealers Association", .OrderDate = New DateTime(2001, 7, 1, 0, 0, 0), .SalesFirstName = "Shu", .SalesLastName = "Ito", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO7859187017", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "9952 E. Lohman Ave.", .BillAddress2 = "", .BillCity = "Las Cruces", .BillPostalCode = "88001", .BillStateProvince = "New Mexico", .BillCountryRegion = "United States", .ShipAddress1 = "9952 E. Lohman Ave.", .ShipAddress2 = "", .ShipCity = "Las Cruces", .ShipPostalCode = "88001", .ShipStateProvince = "New Mexico", .ShipCountryRegion = "United States", .CustPhone = "993-555-0179", .CustFirstName = "Sandra", .CustLastName = "Maynard"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43691", .Store = "Grease and Oil Products Company", .OrderDate = New DateTime(2001, 7, 1, 0, 0, 0), .SalesFirstName = "Jillian", .SalesLastName = "Carson", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO6409111675", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "9903 Highway 6 South", .BillAddress2 = "", .BillCity = "Houston", .BillPostalCode = "77003", .BillStateProvince = "Texas", .BillCountryRegion = "United States", .ShipAddress1 = "9903 Highway 6 South", .ShipAddress2 = "", .ShipCity = "Houston", .ShipPostalCode = "77003", .ShipStateProvince = "Texas", .ShipCountryRegion = "United States", .CustPhone = "126-555-0172", .CustFirstName = "Michael", .CustLastName = "Blythe"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43690", .Store = "Small Cycle Store", .OrderDate = New DateTime(2001, 7, 1, 0, 0, 0), .SalesFirstName = "Michael", .SalesLastName = "Blythe", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO6235146326", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "Horizon Outlet Center", .BillAddress2 = "", .BillCity = "Holland", .BillPostalCode = "49423", .BillStateProvince = "Michigan", .BillCountryRegion = "United States", .ShipAddress1 = "Horizon Outlet Center", .ShipAddress2 = "", .ShipCity = "Holland", .ShipPostalCode = "49423", .ShipStateProvince = "Michigan", .ShipCountryRegion = "United States", .CustPhone = "583-555-0130", .CustFirstName = "Douglas", .CustLastName = "Baldwin"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43689", .Store = "Fitness Toy Store", .OrderDate = New DateTime(2001, 7, 1, 0, 0, 0), .SalesFirstName = "Jillian", .SalesLastName = "Carson", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO5626159507", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "220 Mercy Drive", .BillAddress2 = "", .BillCity = "Garland", .BillPostalCode = "75040", .BillStateProvince = "Texas", .BillCountryRegion = "United States", .ShipAddress1 = "220 Mercy Drive", .ShipAddress2 = "", .ShipCity = "Garland", .ShipPostalCode = "75040", .ShipStateProvince = "Texas", .ShipCountryRegion = "United States", .CustPhone = "351-555-0131", .CustFirstName = "Stacey", .CustLastName = "Cereghino"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43688", .Store = "Weekend Tours", .OrderDate = New DateTime(2001, 7, 1, 0, 0, 0), .SalesFirstName = "Michael", .SalesLastName = "Blythe", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO5365136389", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "42522 Northrupp", .BillAddress2 = "", .BillCity = "Fort Wayne", .BillPostalCode = "46807", .BillStateProvince = "Indiana", .BillCountryRegion = "United States", .ShipAddress1 = "42522 Northrupp", .ShipAddress2 = "", .ShipCity = "Fort Wayne", .ShipPostalCode = "46807", .ShipStateProvince = "Indiana", .ShipCountryRegion = "United States", .CustPhone = "754-555-0134", .CustFirstName = "John", .CustLastName = "Donovan"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43687", .Store = "Curbside Universe", .OrderDate = New DateTime(2001, 7, 1, 0, 0, 0), .SalesFirstName = "Michael", .SalesLastName = "Blythe", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO4959110829", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "25264 E. 260th", .BillAddress2 = "", .BillCity = "Euclid", .BillPostalCode = "44119", .BillStateProvince = "Ohio", .BillCountryRegion = "United States", .ShipAddress1 = "25264 E. 260th", .ShipAddress2 = "", .ShipCity = "Euclid", .ShipPostalCode = "44119", .ShipStateProvince = "Ohio", .ShipCountryRegion = "United States", .CustPhone = "131-555-0171", .CustFirstName = "Deanna", .CustLastName = "Buskirk"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43686", .Store = "Fifth Bike Store", .OrderDate = New DateTime(2001, 7, 1, 0, 0, 0), .SalesFirstName = "David", .SalesLastName = "Campbell", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO5075125561", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "2502 Evergreen Ste E", .BillAddress2 = "", .BillCity = "Everett", .BillPostalCode = "98201", .BillStateProvince = "Washington", .BillCountryRegion = "United States", .ShipAddress1 = "2502 Evergreen Ste E", .ShipAddress2 = "", .ShipCity = "Everett", .ShipPostalCode = "98201", .ShipStateProvince = "Washington", .ShipCountryRegion = "United States", .CustPhone = "652-555-0132", .CustFirstName = "Karren", .CustLastName = "Burkhardt"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43684", .Store = "Daring Rides", .OrderDate = New DateTime(2001, 7, 1, 0, 0, 0), .SalesFirstName = "Tsvi", .SalesLastName = "Reiter", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO3393188842", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "Bay Area Outlet Mall", .BillAddress2 = "", .BillCity = "Clearwater", .BillPostalCode = "33755", .BillStateProvince = "Florida", .BillCountryRegion = "United States", .ShipAddress1 = "Bay Area Outlet Mall", .ShipAddress2 = "", .ShipCity = "Clearwater", .ShipPostalCode = "33755", .ShipStateProvince = "Florida", .ShipCountryRegion = "United States", .CustPhone = "871-555-0159", .CustFirstName = "Russell", .CustLastName = "King"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43683", .Store = "Great Bikes ", .OrderDate = New DateTime(2001, 7, 1, 0, 0, 0), .SalesFirstName = "David", .SalesLastName = "Campbell", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO2552113807", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "Eastridge Mall", .BillAddress2 = "", .BillCity = "Casper", .BillPostalCode = "82601", .BillStateProvince = "Wyoming", .BillCountryRegion = "United States", .ShipAddress1 = "Eastridge Mall", .ShipAddress2 = "", .ShipCity = "Casper", .ShipPostalCode = "82601", .ShipStateProvince = "Wyoming", .ShipCountryRegion = "United States", .CustPhone = "571-555-0128", .CustFirstName = "François", .CustLastName = "Ferrier"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43682", .Store = "Convenient Bike Shop", .OrderDate = New DateTime(2001, 7, 1, 0, 0, 0), .SalesFirstName = "Michael", .SalesLastName = "Blythe", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO1566124200", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "Tree Plaza", .BillAddress2 = "", .BillCity = "Braintree", .BillPostalCode = "02184", .BillStateProvince = "Massachusetts", .BillCountryRegion = "United States", .ShipAddress1 = "Tree Plaza", .ShipAddress2 = "", .ShipCity = "Braintree", .ShipPostalCode = "02184", .ShipStateProvince = "Massachusetts", .ShipCountryRegion = "United States", .CustPhone = "721-555-0163", .CustFirstName = "Judith", .CustLastName = "Frazier"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43681", .Store = "Bike Rims Company", .OrderDate = New DateTime(2001, 7, 1, 0, 0, 0), .SalesFirstName = "Tsvi", .SalesLastName = "Reiter", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO1189177803", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "Edgewater Mall", .BillAddress2 = "", .BillCity = "Biloxi", .BillPostalCode = "39530", .BillStateProvince = "Mississippi", .BillCountryRegion = "United States", .ShipAddress1 = "Edgewater Mall", .ShipAddress2 = "", .ShipCity = "Biloxi", .ShipPostalCode = "39530", .ShipStateProvince = "Mississippi", .ShipCountryRegion = "United States", .CustPhone = "334-555-0146", .CustFirstName = "Charles", .CustLastName = "Christensen"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43680", .Store = "Area Bike Accessories", .OrderDate = New DateTime(2001, 7, 1, 0, 0, 0), .SalesFirstName = "Shu", .SalesLastName = "Ito", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO10730130087", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "6900 Sisk Road", .BillAddress2 = "", .BillCity = "Modesto", .BillPostalCode = "95354", .BillStateProvince = "California", .BillCountryRegion = "United States", .ShipAddress1 = "6900 Sisk Road", .ShipAddress2 = "", .ShipCity = "Modesto", .ShipPostalCode = "95354", .ShipStateProvince = "California", .ShipCountryRegion = "United States", .CustPhone = "991-555-0183", .CustFirstName = "Frances", .CustLastName = "Adams"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43679", .Store = "General Bike Corporation", .OrderDate = New DateTime(2001, 7, 1, 0, 0, 0), .SalesFirstName = "Garrett", .SalesLastName = "Vargas", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO10527142759", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "69251 Creditview Road", .BillAddress2 = "", .BillCity = "Mississauga", .BillPostalCode = "L5B 3V4", .BillStateProvince = "Ontario", .BillCountryRegion = "Canada", .ShipAddress1 = "69251 Creditview Road", .ShipAddress2 = "", .ShipCity = "Mississauga", .ShipPostalCode = "L5B 3V4", .ShipStateProvince = "Ontario", .ShipCountryRegion = "Canada", .CustPhone = "994-555-0194", .CustFirstName = "Susan", .CustLastName = "French"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43678", .Store = "Separate Parts Corporation", .OrderDate = New DateTime(2001, 7, 1, 0, 0, 0), .SalesFirstName = "Shu", .SalesLastName = "Ito", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO10817150168", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "440 West Huntington Dr.", .BillAddress2 = "", .BillCity = "Monrovia", .BillPostalCode = "91016", .BillStateProvince = "California", .BillCountryRegion = "United States", .ShipAddress1 = "440 West Huntington Dr.", .ShipAddress2 = "", .ShipCity = "Monrovia", .ShipPostalCode = "91016", .ShipStateProvince = "California", .ShipCountryRegion = "United States", .CustPhone = "207-555-0129", .CustFirstName = "Jean", .CustLastName = "Jordan"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43677", .Store = "Superb Sales and Repair", .OrderDate = New DateTime(2001, 7, 1, 0, 0, 0), .SalesFirstName = "Garrett", .SalesLastName = "Vargas", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO11049174786", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "990th Floor 700 De La GauchetiSre Ou", .BillAddress2 = "", .BillCity = "Montreal", .BillPostalCode = "H1Y 2H3", .BillStateProvince = "Quebec", .BillCountryRegion = "Canada", .ShipAddress1 = "990th Floor 700 De La GauchetiSre Ou", .ShipAddress2 = "", .ShipCity = "Montreal", .ShipPostalCode = "H1Y 2H3", .ShipStateProvince = "Quebec", .ShipCountryRegion = "Canada", .CustPhone = "393-555-0167", .CustFirstName = "Brenda", .CustLastName = "Heaney"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43676", .Store = "Trusted Catalog Store", .OrderDate = New DateTime(2001, 7, 1, 0, 0, 0), .SalesFirstName = "Michael", .SalesLastName = "Blythe", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO11861165059", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "9920 Picketts Line Road", .BillAddress2 = "", .BillCity = "Newport News", .BillPostalCode = "23607", .BillStateProvince = "Virginia", .BillCountryRegion = "United States", .ShipAddress1 = "9920 Picketts Line Road", .ShipAddress2 = "", .ShipCity = "Newport News", .ShipPostalCode = "23607", .ShipStateProvince = "Virginia", .ShipCountryRegion = "United States", .CustPhone = "497-555-0147", .CustFirstName = "Mark", .CustLastName = "Hanson"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43675", .Store = "First Bike Store", .OrderDate = New DateTime(2001, 7, 1, 0, 0, 0), .SalesFirstName = "Jillian", .SalesLastName = "Carson", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO12412186464", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "Kansas City Factory Outlet", .BillAddress2 = "", .BillCity = "Odessa", .BillPostalCode = "64076", .BillStateProvince = "Missouri", .BillCountryRegion = "United States", .ShipAddress1 = "Kansas City Factory Outlet", .ShipAddress2 = "", .ShipCity = "Odessa", .ShipPostalCode = "64076", .ShipStateProvince = "Missouri", .ShipCountryRegion = "United States", .CustPhone = "859-555-0140", .CustFirstName = "Valerie", .CustLastName = "Hendricks"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43674", .Store = "Requisite Part Supply", .OrderDate = New DateTime(2001, 7, 1, 0, 0, 0), .SalesFirstName = "José", .SalesLastName = "Saraiva", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO12760141756", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "600 Slater Street", .BillAddress2 = "", .BillCity = "Ottawa", .BillPostalCode = "K4B 1S2", .BillStateProvince = "Ontario", .BillCountryRegion = "Canada", .ShipAddress1 = "600 Slater Street", .ShipAddress2 = "", .ShipCity = "Ottawa", .ShipPostalCode = "K4B 1S2", .ShipStateProvince = "Ontario", .ShipCountryRegion = "Canada", .CustPhone = "644-555-0114", .CustFirstName = "Eric", .CustLastName = "Brumfield"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43673", .Store = "Seventh Bike Store", .OrderDate = New DateTime(2001, 7, 1, 0, 0, 0), .SalesFirstName = "Michael", .SalesLastName = "Blythe", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO13775141242", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "Stateline Plaza", .BillAddress2 = "", .BillCity = "Plaistow", .BillPostalCode = "03865", .BillStateProvince = "New Hampshire", .BillCountryRegion = "United States", .ShipAddress1 = "Stateline Plaza", .ShipAddress2 = "", .ShipCity = "Plaistow", .ShipPostalCode = "03865", .ShipStateProvince = "New Hampshire", .ShipCountryRegion = "United States", .CustPhone = "860-555-0119", .CustFirstName = "Nancy", .CustLastName = "Hirota"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43671", .Store = "Basic Bike Company", .OrderDate = New DateTime(2001, 7, 1, 0, 0, 0), .SalesFirstName = "David", .SalesLastName = "Campbell", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO13978119376", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "15 East Main", .BillAddress2 = "", .BillCity = "Port Orchard", .BillPostalCode = "98366", .BillStateProvince = "Washington", .BillCountryRegion = "United States", .ShipAddress1 = "15 East Main", .ShipAddress2 = "", .ShipCity = "Port Orchard", .ShipPostalCode = "98366", .ShipStateProvince = "Washington", .ShipCountryRegion = "United States", .CustPhone = "170-555-0189", .CustFirstName = "Peggy", .CustLastName = "Justice"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43670", .Store = "Historic Bicycle Sales", .OrderDate = New DateTime(2001, 7, 1, 0, 0, 0), .SalesFirstName = "Michael", .SalesLastName = "Blythe", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO14384116310", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "Redford Plaza", .BillAddress2 = "", .BillCity = "Redford", .BillPostalCode = "48239", .BillStateProvince = "Michigan", .BillCountryRegion = "United States", .ShipAddress1 = "Redford Plaza", .ShipAddress2 = "", .ShipCity = "Redford", .ShipPostalCode = "48239", .ShipStateProvince = "Michigan", .ShipCountryRegion = "United States", .CustPhone = "264-555-0143", .CustFirstName = "Mae", .CustLastName = "Black"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43669", .Store = "The Bike Shop", .OrderDate = New DateTime(2001, 7, 1, 0, 0, 0), .SalesFirstName = "David", .SalesLastName = "Campbell", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO14123169936", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "3250 South Meridian", .BillAddress2 = "", .BillCity = "Puyallup", .BillPostalCode = "98371", .BillStateProvince = "Washington", .BillCountryRegion = "United States", .ShipAddress1 = "3250 South Meridian", .ShipAddress2 = "", .ShipCity = "Puyallup", .ShipPostalCode = "98371", .ShipStateProvince = "Washington", .ShipCountryRegion = "United States", .CustPhone = "957-555-0125", .CustFirstName = "Carolyn", .CustLastName = "Farino"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43668", .Store = "Retail Mall", .OrderDate = New DateTime(2001, 7, 1, 0, 0, 0), .SalesFirstName = "José", .SalesLastName = "Saraiva", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO14732180295", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "254480 River Rd", .BillAddress2 = "", .BillCity = "Richmond", .BillPostalCode = "V6B 3P7", .BillStateProvince = "British Columbia", .BillCountryRegion = "Canada", .ShipAddress1 = "254480 River Rd", .ShipAddress2 = "", .ShipCity = "Richmond", .ShipPostalCode = "V6B 3P7", .ShipStateProvince = "British Columbia", .ShipCountryRegion = "Canada", .CustPhone = "726-555-0155", .CustFirstName = "Ryan", .CustLastName = "Calafato"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43667", .Store = "Yellow Bicycle Company", .OrderDate = New DateTime(2001, 7, 1, 0, 0, 0), .SalesFirstName = "Jillian", .SalesLastName = "Carson", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO15428132599", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "St. Louis Marketplace", .BillAddress2 = "", .BillCity = "Saint Louis", .BillPostalCode = "63103", .BillStateProvince = "Missouri", .BillCountryRegion = "United States", .ShipAddress1 = "St. Louis Marketplace", .ShipAddress2 = "", .ShipCity = "Saint Louis", .ShipPostalCode = "63103", .ShipStateProvince = "Missouri", .ShipCountryRegion = "United States", .CustPhone = "470-555-0171", .CustFirstName = "Scott", .CustLastName = "MacDonald"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43665", .Store = "Latest Sports Equipment", .OrderDate = New DateTime(2001, 7, 1, 0, 0, 0), .SalesFirstName = "David", .SalesLastName = "Campbell", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO16588191572", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "4251 First Avenue", .BillAddress2 = "", .BillCity = "Seattle", .BillPostalCode = "98104", .BillStateProvince = "Washington", .BillCountryRegion = "United States", .ShipAddress1 = "4251 First Avenue", .ShipAddress2 = "", .ShipCity = "Seattle", .ShipPostalCode = "98104", .ShipStateProvince = "Washington", .ShipCountryRegion = "United States", .CustPhone = "340-555-0131", .CustFirstName = "Richard", .CustLastName = "Bready"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43664", .Store = "Capable Sales and Service", .OrderDate = New DateTime(2001, 7, 1, 0, 0, 0), .SalesFirstName = "Pamela", .SalesLastName = "Ansman-Wolfe", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO16617121983", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "765 Delridge Way Sw", .BillAddress2 = "", .BillCity = "Seattle", .BillPostalCode = "98104", .BillStateProvince = "Washington", .BillCountryRegion = "United States", .ShipAddress1 = "765 Delridge Way Sw", .ShipAddress2 = "", .ShipCity = "Seattle", .ShipPostalCode = "98104", .ShipStateProvince = "Washington", .ShipCountryRegion = "United States", .CustPhone = "928-555-0117", .CustFirstName = "Sandeep", .CustLastName = "Katyal"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43663", .Store = "World Bike Discount Store", .OrderDate = New DateTime(2001, 7, 1, 0, 0, 0), .SalesFirstName = "Linda", .SalesLastName = "Mitchell", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO18009186470", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "3065 Santa Margarita Parkway", .BillAddress2 = "", .BillCity = "Trabuco Canyon", .BillPostalCode = "92679", .BillStateProvince = "California", .BillCountryRegion = "United States", .ShipAddress1 = "3065 Santa Margarita Parkway", .ShipAddress2 = "", .ShipCity = "Trabuco Canyon", .ShipPostalCode = "92679", .ShipStateProvince = "California", .ShipCountryRegion = "United States", .CustPhone = "992-555-0111", .CustFirstName = "Jimmy", .CustLastName = "Bischoff"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43662", .Store = "Health Spa, Limited", .OrderDate = New DateTime(2001, 7, 1, 0, 0, 0), .SalesFirstName = "José", .SalesLastName = "Saraiva", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO18444174044", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "2500 University Avenue", .BillAddress2 = "", .BillCity = "Toronto", .BillPostalCode = "M4B 1V5", .BillStateProvince = "Ontario", .BillCountryRegion = "Canada", .ShipAddress1 = "2500 University Avenue", .ShipAddress2 = "", .ShipCity = "Toronto", .ShipPostalCode = "M4B 1V5", .ShipStateProvince = "Ontario", .ShipCountryRegion = "Canada", .CustPhone = "431-555-0153", .CustFirstName = "Robin", .CustLastName = "McGuigan"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43661", .Store = "Original Bicycle Supply Company", .OrderDate = New DateTime(2001, 7, 1, 0, 0, 0), .SalesFirstName = "José", .SalesLastName = "Saraiva", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO18473189620", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "2573 Dufferin Street", .BillAddress2 = "", .BillCity = "Toronto", .BillPostalCode = "M4B 1V5", .BillStateProvince = "Ontario", .BillCountryRegion = "Canada", .ShipAddress1 = "2573 Dufferin Street", .ShipAddress2 = "", .ShipCity = "Toronto", .ShipPostalCode = "M4B 1V5", .ShipStateProvince = "Ontario", .ShipCountryRegion = "Canada", .CustPhone = "185-555-0190", .CustFirstName = "Jauna", .CustLastName = "Elson"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43660", .Store = "Pedals Warehouse", .OrderDate = New DateTime(2001, 7, 1, 0, 0, 0), .SalesFirstName = "Tsvi", .SalesLastName = "Reiter", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO18850127500", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "6055 Shawnee Industrial Way", .BillAddress2 = "", .BillCity = "Suwanee", .BillPostalCode = "30024", .BillStateProvince = "Georgia", .BillCountryRegion = "United States", .ShipAddress1 = "6055 Shawnee Industrial Way", .ShipAddress2 = "", .ShipCity = "Suwanee", .ShipPostalCode = "30024", .ShipStateProvince = "Georgia", .ShipCountryRegion = "United States", .CustPhone = "987-555-0126", .CustFirstName = "Takiko", .CustLastName = "Collins"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43659", .Store = "Better Bike Shop", .OrderDate = New DateTime(2001, 7, 1, 0, 0, 0), .SalesFirstName = "Tsvi", .SalesLastName = "Reiter", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO522145787", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "42525 Austell Road", .BillAddress2 = "", .BillCity = "Austell", .BillPostalCode = "30106", .BillStateProvince = "Georgia", .BillCountryRegion = "United States", .ShipAddress1 = "42525 Austell Road", .ShipAddress2 = "", .ShipCity = "Austell", .ShipPostalCode = "30106", .ShipStateProvince = "Georgia", .ShipCountryRegion = "United States", .CustPhone = "967-555-0129", .CustFirstName = "James", .CustLastName = "Hendergart"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43875", .Store = "Tread Industries", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Tsvi", .SalesLastName = "Reiter", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO12586178184", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "25631 Florida Mall Ave.", .BillAddress2 = "", .BillCity = "Orlando", .BillPostalCode = "32804", .BillStateProvince = "Florida", .BillCountryRegion = "United States", .ShipAddress1 = "9707 Coldwater Drive", .ShipAddress2 = "", .ShipCity = "Orlando", .ShipPostalCode = "32804", .ShipStateProvince = "Florida", .ShipCountryRegion = "United States", .CustPhone = "965-555-0112", .CustFirstName = "Joseph", .CustLastName = "Cantoni"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43876", .Store = "Active Transport Inc.", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Michael", .SalesLastName = "Blythe", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO12006119347", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "225200 Miles Ave.", .BillAddress2 = "", .BillCity = "North Randall", .BillPostalCode = "44128", .BillStateProvince = "Ohio", .BillCountryRegion = "United States", .ShipAddress1 = "225200 Miles Ave.", .ShipAddress2 = "", .ShipCity = "North Randall", .ShipPostalCode = "44128", .ShipStateProvince = "Ohio", .ShipCountryRegion = "United States", .CustPhone = "526-555-0155", .CustFirstName = "Lynn", .CustLastName = "Tsoflias"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43877", .Store = "Outdoor Sports Supply", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Pamela", .SalesLastName = "Ansman-Wolfe", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO11919119101", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "Great Northwestern", .BillAddress2 = "", .BillCity = "North Bend", .BillPostalCode = "98045", .BillStateProvince = "Washington", .BillCountryRegion = "United States", .ShipAddress1 = "Great Northwestern", .ShipAddress2 = "", .ShipCity = "North Bend", .ShipPostalCode = "98045", .ShipStateProvince = "Washington", .ShipCountryRegion = "United States", .CustPhone = "107-555-0132", .CustFirstName = "Margaret", .CustLastName = "Krupka"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43878", .Store = "Only Bikes and Accessories", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Michael", .SalesLastName = "Blythe", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO11716136854", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "123 Union Square South", .BillAddress2 = "", .BillCity = "New York", .BillPostalCode = "10007", .BillStateProvince = "New York", .BillCountryRegion = "United States", .ShipAddress1 = "123 Union Square South", .ShipAddress2 = "", .ShipCity = "New York", .ShipPostalCode = "10007", .ShipStateProvince = "New York", .ShipCountryRegion = "United States", .CustPhone = "539-555-0142", .CustFirstName = "Gina", .CustLastName = "Clark"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43879", .Store = "Designated Distributors", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "José", .SalesLastName = "Saraiva", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO11600128380", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "254 Colonnade Road", .BillAddress2 = "", .BillCity = "Nepean", .BillPostalCode = "K2J 2W5", .BillStateProvince = "Ontario", .BillCountryRegion = "Canada", .ShipAddress1 = "254 Colonnade Road", .ShipAddress2 = "", .ShipCity = "Nepean", .ShipPostalCode = "K2J 2W5", .ShipStateProvince = "Ontario", .ShipCountryRegion = "Canada", .CustPhone = "699-555-0155", .CustFirstName = "Cecil", .CustLastName = "Allison"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43880", .Store = "Primary Bike Distributors", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Garrett", .SalesLastName = "Vargas", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO11020127453", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "965 De La Gauchetiere West", .BillAddress2 = "", .BillCity = "Montreal", .BillPostalCode = "H1Y 2H8", .BillStateProvince = "Quebec", .BillCountryRegion = "Canada", .ShipAddress1 = "965 De La Gauchetiere West", .ShipAddress2 = "", .ShipCity = "Montreal", .ShipPostalCode = "H1Y 2H8", .ShipStateProvince = "Quebec", .ShipCountryRegion = "Canada", .CustPhone = "495-555-0161", .CustFirstName = "Brian", .CustLastName = "Goldstein"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43881", .Store = "Great Bicycle Supply", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Jillian", .SalesLastName = "Carson", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO10759119626", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "455 256th St.", .BillAddress2 = "", .BillCity = "Moline", .BillPostalCode = "61265", .BillStateProvince = "Illinois", .BillCountryRegion = "United States", .ShipAddress1 = "455 256th St.", .ShipAddress2 = "", .ShipCity = "Moline", .ShipPostalCode = "61265", .ShipStateProvince = "Illinois", .ShipCountryRegion = "United States", .CustPhone = "810-555-0160", .CustFirstName = "Ranjit", .CustLastName = "Varkey Chudukatil"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43882", .Store = "Scratch-Resistant Finishes Company", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "José", .SalesLastName = "Saraiva", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO10469165208", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "5700 Explorer Drive", .BillAddress2 = "", .BillCity = "Mississauga", .BillPostalCode = "L4W 5J3", .BillStateProvince = "Ontario", .BillCountryRegion = "Canada", .ShipAddress1 = "5700 Explorer Drive", .ShipAddress2 = "", .ShipCity = "Mississauga", .ShipPostalCode = "L4W 5J3", .ShipStateProvince = "Ontario", .ShipCountryRegion = "Canada", .CustPhone = "156-555-0111", .CustFirstName = "John", .CustLastName = "Berger"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43883", .Store = "Lease-a-Bike Shop", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Michael", .SalesLastName = "Blythe", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO10121175623", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "Connecticut Post Mall", .BillAddress2 = "", .BillCity = "Milford", .BillPostalCode = "06460", .BillStateProvince = "Connecticut", .BillCountryRegion = "United States", .ShipAddress1 = "Connecticut Post Mall", .ShipAddress2 = "", .ShipCity = "Milford", .ShipPostalCode = "06460", .ShipStateProvince = "Connecticut", .ShipCountryRegion = "United States", .CustPhone = "158-555-0188", .CustFirstName = "Bernard", .CustLastName = "Duerr"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43884", .Store = "Hardware Components", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Jillian", .SalesLastName = "Carson", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO10440182311", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "City Center", .BillAddress2 = "", .BillCity = "Minneapolis", .BillPostalCode = "55402", .BillStateProvince = "Minnesota", .BillCountryRegion = "United States", .ShipAddress1 = "99 Front Street", .ShipAddress2 = "", .ShipCity = "Minneapolis", .ShipPostalCode = "55402", .ShipStateProvince = "Minnesota", .ShipCountryRegion = "United States", .CustPhone = "153-555-0195", .CustFirstName = "Phyllis", .CustLastName = "Huntsman"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43885", .Store = "Basic Sports Equipment", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Linda", .SalesLastName = "Mitchell", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO609186449", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "3250 Baldwin Park Blvd", .BillAddress2 = "", .BillCity = "Baldwin Park", .BillPostalCode = "91706", .BillStateProvince = "California", .BillCountryRegion = "United States", .ShipAddress1 = "3250 Baldwin Park Blvd", .ShipAddress2 = "", .ShipCity = "Baldwin Park", .ShipPostalCode = "91706", .ShipStateProvince = "California", .ShipCountryRegion = "United States", .CustPhone = "768-555-0125", .CustFirstName = "Garth", .CustLastName = "Fort"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43886", .Store = "Finer Riding Supplies", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "José", .SalesLastName = "Saraiva", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO1827149671", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "#9900 2700 Production Way", .BillAddress2 = "", .BillCity = "Burnaby", .BillPostalCode = "V5A 4X1", .BillStateProvince = "British Columbia", .BillCountryRegion = "Canada", .ShipAddress1 = "#9900 2700 Production Way", .ShipAddress2 = "", .ShipCity = "Burnaby", .ShipPostalCode = "V5A 4X1", .ShipStateProvince = "British Columbia", .ShipCountryRegion = "Canada", .CustPhone = "767-555-0151", .CustFirstName = "Jacob", .CustLastName = "Dean"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43887", .Store = "New Bikes Company", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Tsvi", .SalesLastName = "Reiter", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO1276169981", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "Hilton Head Factory Outlets No. 25", .BillAddress2 = "", .BillCity = "Bluffton", .BillPostalCode = "29910", .BillStateProvince = "South Carolina", .BillCountryRegion = "United States", .ShipAddress1 = "Hilton Head Factory Outlets No. 25", .ShipAddress2 = "", .ShipCity = "Bluffton", .ShipPostalCode = "29910", .ShipStateProvince = "South Carolina", .ShipCountryRegion = "United States", .CustPhone = "453-555-0165", .CustFirstName = "Ronald", .CustLastName = "Adina"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43888", .Store = "Wholesale Parts", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "José", .SalesLastName = "Saraiva", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO2088113013", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "655-4th Ave S.W.", .BillAddress2 = "", .BillCity = "Calgary", .BillPostalCode = "T2P 2G8", .BillStateProvince = "Alberta", .BillCountryRegion = "Canada", .ShipAddress1 = "655-4th Ave S.W.", .ShipAddress2 = "", .ShipCity = "Calgary", .ShipPostalCode = "T2P 2G8", .ShipStateProvince = "Alberta", .ShipCountryRegion = "Canada", .CustPhone = "674-555-0187", .CustFirstName = "Derek", .CustLastName = "Graham"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43889", .Store = "General Department Stores", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Garrett", .SalesLastName = "Vargas", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO2030112412", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "253131 Lake Frasier Drive, Office No. 2", .BillAddress2 = "", .BillCity = "Calgary", .BillPostalCode = "T2P 2G8", .BillStateProvince = "Alberta", .BillCountryRegion = "Canada", .ShipAddress1 = "253131 Lake Frasier Drive, Office No. 2", .ShipAddress2 = "", .ShipCity = "Calgary", .ShipPostalCode = "T2P 2G8", .ShipStateProvince = "Alberta", .ShipCountryRegion = "Canada", .CustPhone = "143-555-0129", .CustFirstName = "Kari", .CustLastName = "Hensien"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43890", .Store = "Serious Cycles", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Garrett", .SalesLastName = "Vargas", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO2146115360", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "Suite 99320 255 - 510th Avenue S.W.", .BillAddress2 = "", .BillCity = "Calgary", .BillPostalCode = "T2P 2G8", .BillStateProvince = "Alberta", .BillCountryRegion = "Canada", .ShipAddress1 = "Suite 99320 255 - 510th Avenue S.W.", .ShipAddress2 = "", .ShipCity = "Calgary", .ShipPostalCode = "T2P 2G8", .ShipStateProvince = "Alberta", .ShipCountryRegion = "Canada", .CustPhone = "614-555-0134", .CustFirstName = "Maxwell", .CustLastName = "Amland"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43891", .Store = "Cross-Country Riding Supplies", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "José", .SalesLastName = "Saraiva", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO2726163521", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "Station E", .BillAddress2 = "", .BillCity = "Chalk Riber", .BillPostalCode = "K0J 1J0", .BillStateProvince = "Ontario", .BillCountryRegion = "Canada", .ShipAddress1 = "Station E", .ShipAddress2 = "", .ShipCity = "Chalk Riber", .ShipPostalCode = "K0J 1J0", .ShipStateProvince = "Ontario", .ShipCountryRegion = "Canada", .CustPhone = "344-555-0144", .CustFirstName = "Bryan", .CustLastName = "Hamilton"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43892", .Store = "Farthermost Bike Shop", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Shu", .SalesLastName = "Ito", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO2523117473", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "99000 S. Avalon Blvd. Suite 750", .BillAddress2 = "", .BillCity = "Carson", .BillPostalCode = "90746", .BillStateProvince = "California", .BillCountryRegion = "United States", .ShipAddress1 = "99000 S. Avalon Blvd. Suite 750", .ShipAddress2 = "", .ShipCity = "Carson", .ShipPostalCode = "90746", .ShipStateProvince = "California", .ShipCountryRegion = "United States", .CustPhone = "156-555-0187", .CustFirstName = "Blaine", .CustLastName = "Dockter"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43893", .Store = "Acceptable Sales & Service", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "José", .SalesLastName = "Saraiva", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO2204129382", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "6400, 888 - 3rd Avenue", .BillAddress2 = "", .BillCity = "Calgary", .BillPostalCode = "T2P 2G8", .BillStateProvince = "Alberta", .BillCountryRegion = "Canada", .ShipAddress1 = "6400, 888 - 3rd Avenue", .ShipAddress2 = "", .ShipCity = "Calgary", .ShipPostalCode = "T2P 2G8", .ShipStateProvince = "Alberta", .ShipCountryRegion = "Canada", .CustPhone = "656-555-0173", .CustFirstName = "Elizabeth", .CustLastName = "Keyser"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43894", .Store = "Some Discount Store", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Pamela", .SalesLastName = "Ansman-Wolfe", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO2958194987", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "Frontier Mall", .BillAddress2 = "", .BillCity = "Cheyenne", .BillPostalCode = "82001", .BillStateProvince = "Wyoming", .BillCountryRegion = "United States", .ShipAddress1 = "Frontier Mall", .ShipAddress2 = "", .ShipCity = "Cheyenne", .ShipPostalCode = "82001", .ShipStateProvince = "Wyoming", .ShipCountryRegion = "United States", .CustPhone = "158-555-0123", .CustFirstName = "Nkenge", .CustLastName = "McLin"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43895", .Store = "Vast Bike Sales and Rental", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Pamela", .SalesLastName = "Ansman-Wolfe", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO2900121738", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "Lewis County Mall", .BillAddress2 = "", .BillCity = "Chehalis", .BillPostalCode = "98532", .BillStateProvince = "Washington", .BillCountryRegion = "United States", .ShipAddress1 = "Lewis County Mall", .ShipAddress2 = "", .ShipCity = "Chehalis", .ShipPostalCode = "98532", .ShipStateProvince = "Washington", .ShipCountryRegion = "United States", .CustPhone = "554-555-0124", .CustFirstName = "Twanna", .CustLastName = "Evans"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43896", .Store = "Rental Bikes", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Jillian", .SalesLastName = "Carson", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO3857154341", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "99828 Routh Street, Suite 825", .BillAddress2 = "", .BillCity = "Dallas", .BillPostalCode = "75201", .BillStateProvince = "Texas", .BillCountryRegion = "United States", .ShipAddress1 = "99828 Routh Street, Suite 825", .ShipAddress2 = "", .ShipCity = "Dallas", .ShipPostalCode = "75201", .ShipStateProvince = "Texas", .ShipCountryRegion = "United States", .CustPhone = "367-555-0124", .CustFirstName = "Richard", .CustLastName = "Irwin"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43897", .Store = "Resale Services", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Linda", .SalesLastName = "Mitchell", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO3799116239", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "Fox Hills", .BillAddress2 = "", .BillCity = "Culver City", .BillPostalCode = "90232", .BillStateProvince = "California", .BillCountryRegion = "United States", .ShipAddress1 = "Fox Hills", .ShipAddress2 = "", .ShipCity = "Culver City", .ShipPostalCode = "90232", .ShipStateProvince = "California", .ShipCountryRegion = "United States", .CustPhone = "226-555-0146", .CustFirstName = "Thomas", .CustLastName = "Armstrong"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43898", .Store = "Rewarding Activities Company", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Garrett", .SalesLastName = "Vargas", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO4901196283", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "25575 The Queensway", .BillAddress2 = "", .BillCity = "Etobicoke", .BillPostalCode = "M9W 3P3", .BillStateProvince = "Ontario", .BillCountryRegion = "Canada", .ShipAddress1 = "25575 The Queensway", .ShipAddress2 = "", .ShipCity = "Etobicoke", .ShipPostalCode = "M9W 3P3", .ShipStateProvince = "Ontario", .ShipCountryRegion = "Canada", .CustPhone = "752-555-0185", .CustFirstName = "Della", .CustLastName = "Demott Jr"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43899", .Store = "District Mall", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Jillian", .SalesLastName = "Carson", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO5191115657", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "25095 W. Florissant", .BillAddress2 = "", .BillCity = "Ferguson", .BillPostalCode = "63135", .BillStateProvince = "Missouri", .BillCountryRegion = "United States", .ShipAddress1 = "25095 W. Florissant", .ShipAddress2 = "", .ShipCity = "Ferguson", .ShipPostalCode = "63135", .ShipStateProvince = "Missouri", .ShipCountryRegion = "United States", .CustPhone = "249-555-0179", .CustFirstName = "Imtiaz", .CustLastName = "Khan"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43900", .Store = "Consolidated Sales", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Tsvi", .SalesLastName = "Reiter", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO5568199700", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "Carolina Factory Shops", .BillAddress2 = "", .BillCity = "Gaffney", .BillPostalCode = "29340", .BillStateProvince = "South Carolina", .BillCountryRegion = "United States", .ShipAddress1 = "Carolina Factory Shops", .ShipAddress2 = "", .ShipCity = "Gaffney", .ShipPostalCode = "29340", .ShipStateProvince = "South Carolina", .ShipCountryRegion = "United States", .CustPhone = "762-555-0110", .CustFirstName = "Samuel", .CustLastName = "Johnson"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43901", .Store = "Sturdy Toys", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Linda", .SalesLastName = "Mitchell", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO5684189260", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "Pacific West Outlet", .BillAddress2 = "", .BillCity = "Gilroy", .BillPostalCode = "95020", .BillStateProvince = "California", .BillCountryRegion = "United States", .ShipAddress1 = "Pacific West Outlet", .ShipAddress2 = "", .ShipCity = "Gilroy", .ShipPostalCode = "95020", .ShipStateProvince = "California", .ShipCountryRegion = "United States", .CustPhone = "330-555-0116", .CustFirstName = "John", .CustLastName = "Kelly"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43902", .Store = "eCommerce Bikes", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Tsvi", .SalesLastName = "Reiter", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO5858178400", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "Gulfport Factory Shops", .BillAddress2 = "", .BillCity = "Gulfport", .BillPostalCode = "39501", .BillStateProvince = "Mississippi", .BillCountryRegion = "United States", .ShipAddress1 = "Gulfport Factory Shops", .ShipAddress2 = "", .ShipCity = "Gulfport", .ShipPostalCode = "39501", .ShipStateProvince = "Mississippi", .ShipCountryRegion = "United States", .CustPhone = "695-555-0111", .CustFirstName = "Phyllis", .CustLastName = "Allen"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43903", .Store = "Metro Bike Mart", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Tsvi", .SalesLastName = "Reiter", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO5800178059", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "Po Box 2257", .BillAddress2 = "", .BillCity = "Greensboro", .BillPostalCode = "27412", .BillStateProvince = "North Carolina", .BillCountryRegion = "United States", .ShipAddress1 = "Po Box 2257", .ShipAddress2 = "", .ShipCity = "Greensboro", .ShipPostalCode = "27412", .ShipStateProvince = "North Carolina", .ShipCountryRegion = "United States", .CustPhone = "565-555-0181", .CustFirstName = "Helen", .CustLastName = "Lutes"}
			datas.Add(data)
			data = New Customers() With {.SalesOrderNumber = "SO43904", .Store = "Swift Cycles", .OrderDate = New DateTime(2001, 8, 1, 0, 0, 0), .SalesFirstName = "Jillian", .SalesLastName = "Carson", .SalesTitle = "Sales Representative", .PurchaseOrderNumber = "PO6351158788", .ShipMethod = "CARGO TRANSPORT 5", .BillAddress1 = "25500 Old Spanish Trail", .BillAddress2 = "", .BillCity = "Houston", .BillPostalCode = "77003", .BillStateProvince = "Texas", .BillCountryRegion = "United States", .ShipAddress1 = "25500 Old Spanish Trail", .ShipAddress2 = "", .ShipCity = "Houston", .ShipPostalCode = "77003", .ShipStateProvince = "Texas", .ShipCountryRegion = "United States", .CustPhone = "184-555-0187", .CustFirstName = "Sunil", .CustLastName = "Uppal"}
			datas.Add(data)
			Return datas
		End Function
	End Class


	#End Region
End Namespace
