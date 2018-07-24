Imports FieldListDemo.Model

Namespace FieldListDemo.ViewModel
    Public Class ViewModel
        Inherits Syncfusion.Windows.Shared.NotificationObject
        Private _productSalesData As Object
        Public Property ProductSalesData() As Object
            Get
                If _productSalesData Is Nothing Then
                    _productSalesData = ProductSales.GetSalesData()
                End If
                Return _productSalesData
            End Get
            Set(ByVal value As Object)
                _productSalesData = value
            End Set
        End Property
    End Class
End Namespace

