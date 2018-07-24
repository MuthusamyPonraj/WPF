#Region "Copyright Syncfusion Inc. 2001 - 2012"
' Copyright Syncfusion Inc. 2001 - 2012. All rights reserved.
' Use of this code is subject to the terms of our license.
' A copy of the current license can be obtained at any time by e-mailing
' licensing@syncfusion.com. Any infringement will be prosecuted under
' applicable laws. 
#End Region
Imports System
Imports System.ComponentModel
Imports System.Collections.ObjectModel

Namespace PivotUpdating.Model
    Public Class ProductSales
        Implements INotifyPropertyChanged, INotifyPropertyChanging

        Private product_Renamed As String = ""

        Private date_Renamed As String = ""

        Private country_Renamed As String = ""

        Private state_Renamed As String = ""

        Private quantity_Renamed As Integer = 0

        Private amount_Renamed As Double = 0

        Private extra_Renamed As Integer = 0

        Private date2_Renamed As DateTime



        Public Property Product() As String
            Get
                Return product_Renamed
            End Get
            Set(ByVal value As String)
                If product_Renamed <> value Then
                    OnPropertyChanging("Product")
                    product_Renamed = value
                    OnPropertyChanged("Product")
                End If
            End Set
        End Property

        Public Property [Date]() As String
            Get
                Return date_Renamed
            End Get
            Set(ByVal value As String)
                If date_Renamed <> value Then
                    OnPropertyChanging("Date")
                    date_Renamed = value
                    OnPropertyChanged("Date")
                End If
            End Set
        End Property

        Public Property Country() As String
            Get
                Return country_Renamed
            End Get
            Set(ByVal value As String)
                If country_Renamed <> value Then
                    OnPropertyChanging("Country")
                    country_Renamed = value
                    OnPropertyChanged("Country")
                End If
            End Set
        End Property

        Public Property State() As String
            Get
                Return state_Renamed
            End Get
            Set(ByVal value As String)
                If state_Renamed <> value Then
                    OnPropertyChanging("State")
                    state_Renamed = value
                    OnPropertyChanged("State")
                End If
            End Set
        End Property

        Public Property Quantity() As Integer
            Get
                Return quantity_Renamed
            End Get
            Set(ByVal value As Integer)
                If quantity_Renamed <> value Then
                    OnPropertyChanging("Quantity")
                    quantity_Renamed = value
                    OnPropertyChanged("Quantity")
                End If
            End Set
        End Property

        Public Property Amount() As Double
            Get
                Return amount_Renamed
            End Get
            Set(ByVal value As Double)
                If amount_Renamed <> value Then
                    OnPropertyChanging("Amount")
                    amount_Renamed = value
                    OnPropertyChanged("Amount")
                End If
            End Set
        End Property

        Public Property Extra() As Integer
            Get
                Return extra_Renamed
            End Get
            Set(ByVal value As Integer)
                If extra_Renamed <> value Then
                    OnPropertyChanging("Extra")
                    extra_Renamed = value
                    OnPropertyChanged("Extra")
                End If
            End Set
        End Property

        Public Property Date2() As DateTime
            Get
                Return date2_Renamed
            End Get
            Set(ByVal value As DateTime)
                If date2_Renamed <> value Then
                    OnPropertyChanging("Date2")
                    date2_Renamed = value
                    OnPropertyChanged("Date2")
                End If
            End Set
        End Property

        Public Shared count As Integer = 2000
        Private Shared singleListDataSource As ProductSalesCollection = Nothing

        Public Shared Function GetSalesData() As ProductSalesCollection
            If singleListDataSource IsNot Nothing Then
                Return singleListDataSource
            End If

            ''' Geography
            Dim countries() As String = {"Australia", "Canada", "France", "Germany", "United Kingdom", "United States"}
            Dim ausStates() As String = {"New South Wales", "Queensland", "South Australia", "Tasmania", "Victoria"}
            Dim canadaStates() As String = {"Alberta", "British Columbia", "Brunswick", "Manitoba", "Ontario", "Quebec"}
            Dim franceStates() As String = {"Charente-Maritime", "Essonne", "Garonne (Haute)", "Gers"}
            Dim germanyStates() As String = {"Bayern", "Brandenburg", "Hamburg", "Hessen", "Nordrhein-Westfalen", "Saarland"}
            Dim ukStates() As String = {"England"}
            Dim ussStates() As String = {"New York", "North Carolina", "Alabama", "California", "Colorado", "New Mexico", "South Carolina"}

            ''' Time
            Dim dates() As String = {"FY 2005", "FY 2006", "FY 2008", "FY 2009"}
            Dim date0 As New DateTime(2005, 1, 1)
            ''' Products
            Dim products() As String = {"Bike", "Car", "Truck", "Scooters"}
            products = New String() {"Bike", "Car"}
            Dim r As New Random(123345345)

            Dim numberOfRecords As Integer = ProductSales.count
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
                sales.Extra = i Mod 2
                sales.Date2 = date0.AddDays(r.Next(1500))
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
            singleListDataSource = listOfProductSales
            Return listOfProductSales
        End Function

        Public Overrides Function ToString() As String
            Return String.Format("{0}-{1}-{2}", Me.Country, Me.State, Me.Product)
        End Function

        Public Class ProductSalesCollection
            Inherits ObservableCollection(Of ProductSales)
            Protected Overrides Sub OnCollectionChanged(ByVal e As System.Collections.Specialized.NotifyCollectionChangedEventArgs)
                MyBase.OnCollectionChanged(e)
            End Sub
        End Class

#Region "INotifyPropertyChanged Members"

        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged


        Protected Overridable Sub OnPropertyChanged(ByVal name As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(name))
        End Sub
#End Region

#Region "INotifyPropertyChanging Members"

        Public Event PropertyChanging As PropertyChangingEventHandler Implements INotifyPropertyChanging.PropertyChanging

        Protected Overridable Sub OnPropertyChanging(ByVal name As String)
            RaiseEvent PropertyChanging(Me, New PropertyChangingEventArgs(name))
        End Sub
#End Region
    End Class
End Namespace
