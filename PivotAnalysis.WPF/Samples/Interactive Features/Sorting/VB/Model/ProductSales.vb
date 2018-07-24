Imports Microsoft.VisualBasic
#Region "Copyright Syncfusion Inc. 2001 - 2012"
' Copyright Syncfusion Inc. 2001 - 2012. All rights reserved.
' Use of this code is subject to the terms of our license.
' A copy of the current license can be obtained at any time by e-mailing
' licensing@syncfusion.com. Any infringement will be prosecuted under
' applicable laws. 
#End Region
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace SortingDemo.Model
	Friend Class ProductSales
		Private privateProduct As String
		Public Property Product() As String
			Get
				Return privateProduct
			End Get
			Set(ByVal value As String)
				privateProduct = value
			End Set
		End Property

		Private privateDate As String
		Public Property [Date]() As String
			Get
				Return privateDate
			End Get
			Set(ByVal value As String)
				privateDate = value
			End Set
		End Property

		Private privateCountry As String
		Public Property Country() As String
			Get
				Return privateCountry
			End Get
			Set(ByVal value As String)
				privateCountry = value
			End Set
		End Property

		Private privateState As String
		Public Property State() As String
			Get
				Return privateState
			End Get
			Set(ByVal value As String)
				privateState = value
			End Set
		End Property

		Private privateQuantity As Integer
		Public Property Quantity() As Integer
			Get
				Return privateQuantity
			End Get
			Set(ByVal value As Integer)
				privateQuantity = value
			End Set
		End Property

		Private privateAmount As Double
		Public Property Amount() As Double
			Get
				Return privateAmount
			End Get
			Set(ByVal value As Double)
				privateAmount = value
			End Set
		End Property

		Public Shared Function GetSalesData() As ProductSalesCollection
			''' Geography
			Dim countries() As String = { "Australia", "Canada", "France", "Germany", "United Kingdom", "United States" }
			Dim ausStates() As String = { "New South Wales", "Queensland", "South Australia", "Tasmania", "Victoria" }
			Dim canadaStates() As String = { "Alberta", "British Columbia", "Brunswick", "Manitoba", "Ontario", "Quebec" }
			Dim franceStates() As String = { "Charente-Maritime", "Essonne", "Garonne (Haute)", "Gers" }
			Dim germanyStates() As String = { "Bayern", "Brandenburg", "Hamburg", "Hessen", "Nordrhein-Westfalen", "Saarland" }
			Dim ukStates() As String = { "England" }
			Dim ussStates() As String = { "New York", "North Carolina", "Alabama", "California", "Colorado", "New Mexico", "South Carolina" }

			''' Time
			Dim dates() As String = { "FY 2005", "FY 2006", "FY 2007", "FY 2008", "FY 2009" }

			''' Products
			Dim products() As String = { "Bike", "Car", "Bus", "Van" }
			Dim r As New Random(123345345)

			Dim numberOfRecords As Integer = 2000
			Dim listOfProductSales As New ProductSalesCollection()
			For i As Integer = 0 To numberOfRecords - 1
				Dim sales As New ProductSales()
				sales.Country = countries(r.Next(1, countries.GetLength(0)))
				sales.Quantity = r.Next(1, 12)
				''' 1 percent discount for 1 quantity
				Dim discount As Double = (30000 * sales.Quantity) * (Double.Parse(sales.Quantity.ToString()) / 100)
				sales.Amount = (30000 * sales.Quantity) - discount
				sales.Date = dates(r.Next(r.Next(dates.GetLength(0) + 1)))
				sales.Product = products(r.Next(r.Next(products.GetLength(0) + 1)))
				Select Case sales.Country
					Case "Australia"
							sales.State = ausStates(r.Next(ausStates.GetLength(0)))
							Exit Select
					Case "Canada"
							sales.State = canadaStates(r.Next(canadaStates.GetLength(0)))
							Exit Select
					Case "France"
							sales.State = franceStates(r.Next(franceStates.GetLength(0)))
							Exit Select
					Case "Germany"
							sales.State = germanyStates(r.Next(germanyStates.GetLength(0)))
							Exit Select
					Case "United Kingdom"
							sales.State = ukStates(r.Next(ukStates.GetLength(0)))
							Exit Select
					Case "United States"
							sales.State = ussStates(r.Next(ussStates.GetLength(0)))
							Exit Select
				End Select
				listOfProductSales.Add(sales)
			Next i

			Return listOfProductSales
		End Function

		Public Overrides Function ToString() As String
			Return String.Format("{0}-{1}-{2}", Me.Country, Me.State, Me.Product)
		End Function

		Public Class ProductSalesCollection
			Inherits List(Of ProductSales)
		End Class
	End Class

End Namespace
