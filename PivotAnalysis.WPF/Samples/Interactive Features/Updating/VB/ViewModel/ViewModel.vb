Imports PivotUpdating.Model
Imports Syncfusion.Windows.Shared
Imports System.Collections.Generic
Imports System.Windows.Threading
Imports System

Namespace PivotUpdating.ViewModel
    Public Class ViewModel
        Inherits Syncfusion.Windows.Shared.NotificationObject

        Dim timer As DispatcherTimer
        Dim updateRate As Integer = 200 'msecs
        Dim updateCount As Integer = 20 'updates per tick event
        Dim rand As Random = New Random(123123)

        Private _productSalesData As ProductSales.ProductSalesCollection
        Public Property ProductSalesData() As ProductSales.ProductSalesCollection
            Get
                If _productSalesData Is Nothing Then
                    _productSalesData = ProductSales.GetSalesData()
                End If
                Return _productSalesData
            End Get
            Set(ByVal value As ProductSales.ProductSalesCollection)
                _productSalesData = value
                RaisePropertyChanged("ProductSalesData")
            End Set
        End Property

        Private _timerActivationCommand As DelegateCommand(Of Object)
        Public Property TimerActivationCommand() As DelegateCommand(Of Object)
            Get
                If _timerActivationCommand Is Nothing Then
                    _timerActivationCommand = New DelegateCommand(Of Object)(AddressOf DoTimerActivation)
                End If
                Return _timerActivationCommand
            End Get
            Set(ByVal value As DelegateCommand(Of Object))
                _timerActivationCommand = value
            End Set
        End Property

        Private _updateSourceCommand As DelegateCommand(Of Object)
        Public Property UpdateSourceCommand() As DelegateCommand(Of Object)
            Get
                If _updateSourceCommand Is Nothing Then
                    _updateSourceCommand = New DelegateCommand(Of Object)(AddressOf UpdateItemSource)
                End If
                Return _updateSourceCommand
            End Get
            Set(ByVal value As DelegateCommand(Of Object))
                _updateSourceCommand = value
            End Set
        End Property

        Public ReadOnly Property ThrottleUpdateRates() As List(Of Integer)
            Get
                Dim listOfThrottle As List(Of Integer) = New List(Of Integer)
                listOfThrottle.Add(0)
                listOfThrottle.Add(300)
                listOfThrottle.Add(500)
                listOfThrottle.Add(1000)
                listOfThrottle.Add(2000)
                Return listOfThrottle
            End Get
        End Property


        Private Sub DoTimerActivation(parm As Object)
            If TypeOf parm Is Boolean Then
                If timer Is Nothing Then
                    timer = New DispatcherTimer()
                    AddHandler timer.Tick, AddressOf timer_Tick
                    timer.Interval = TimeSpan.FromMilliseconds(updateRate)
                End If
                If DirectCast(parm, Boolean) Then
                    timer.Start()
                Else
                    timer.Stop()
                End If
            End If
        End Sub

        Private Sub UpdateItemSource(parm As Object)
            Dim dr As ProductSales = Nothing
            Select Case parm.ToString()
                Case "Add at Top"
                    dr = New ProductSales() With {.Country = "Canada", .State = "Brunswick", .Product = "Bike", .Date = "FY 2003", .Quantity = 1, .Amount = 100.0R}
                Case "Add at Middle"
                    dr = New ProductSales() With {.Country = "Canada", .State = "Brunswick", .Product = "Bike", .Date = "FY 2007", .Quantity = 1, .Amount = 200.0R}
                Case "Add at Bottom"
                    dr = New ProductSales() With {.Country = "Canada", .State = "Brunswick", .Product = "Bike", .Date = "FY 2010", .Quantity = 1, .Amount = 300.0R}
            End Select
            _productSalesData.Add(dr)
        End Sub

        Private Sub timer_Tick(ByVal sender As Object, ByVal e As EventArgs)
            For i As Integer = 0 To updateCount - 1
                ChangeOneValue(1)
            Next i
        End Sub

        Private Sub ChangeOneValue(ByVal loc As Integer)
            Dim old As Double = CDbl(_productSalesData(loc).Amount)
            _productSalesData(loc).Amount = rand.Next(1000)
        End Sub
    End Class
End Namespace

