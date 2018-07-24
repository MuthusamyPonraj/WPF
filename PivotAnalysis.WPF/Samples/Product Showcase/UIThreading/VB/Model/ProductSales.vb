Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Collections.ObjectModel

Namespace UIThreadingDemo.Model
	Friend Class ProductSales

		''' <summary>
		''' Sales Data Collection
		''' </summary>
		''' <returns></returns>
		Public Shared Function GetSalesData() As ObservableCollection(Of ProductModel)
			''' Geography
			Dim countries() As String = { "Australia", "Canada", "France", "Germany", "United Kingdom", "United States" }
			Dim ausStates() As String = { "New South Wales", "Queensland", "South Australia", "Tasmania", "Victoria", "New South Wales2", "Queensla2nd", "South Australi2a", "Tasmani2a", "Victori2a", "New South Wales3", "Queensland3", "South Australia3", "Tasmania12", "Victoria3" }
			Dim canadaStates() As String = { "Alberta", "British Columbia", "Brunswick", "Manitoba", "Ontario", "Quebec" }
			Dim franceStates() As String = { "Charente Maritime", "Essonne", "Garonne (Haute)", "Gers" }
			Dim germanyStates() As String = { "Bayern", "Brandenburg", "Hamburg", "Hessen", "Nordrhein Westfalen", "Saarland" }
			Dim ukStates() As String = { "England" }
			Dim ussStates() As String = { "New York", "North Carolina", "Alabama", "California", "Colorado", "New Mexico", "South Carolina" }

			''' Time
			Dim dates() As String = { "FY 2005", "FY 2006", "FY 2007", "FY 2008", "FY 2009" }

			''' Products
			Dim twowheelerproducts() As String = { "Bike", "Car" }
			Dim threewheelerproducts() As String = { "Auto", "Tri-Cycle" }
			Dim fourwheelerproducts() As String = { "Car", "Van" }
			Dim r As New Random(123345345)

			Dim numberOfRecords As Integer = 100000
			Dim listOfProductSales As New ObservableCollection(Of ProductModel)()
			For i As Integer = 0 To numberOfRecords - 1
				Dim sales As New ProductModel()
				sales.Country = countries(r.Next(0, countries.GetLength(0)))
				sales.Quantity = r.Next(0, 12)
				''' 1 percent discount for 1 quantity
				Dim discount As Double = (30000 * sales.Quantity) * (Double.Parse(sales.Quantity.ToString()) / 100)
				sales.Amount = (30000 * sales.Quantity) - discount
				sales.Date = dates(r.Next(0, dates.GetLength(0))) ' (r.Next(dates.GetLength(0) + 1))];
				sales.TwoWheeler = twowheelerproducts(r.Next(0, twowheelerproducts.GetLength(0))) '(r.Next(products.GetLength(0) + 1))];
				sales.ThreeWheeler = threewheelerproducts(r.Next(0, threewheelerproducts.GetLength(0)))
				sales.FourWheeler = fourwheelerproducts(r.Next(0, fourwheelerproducts.GetLength(0)))
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
	End Class
End Namespace
