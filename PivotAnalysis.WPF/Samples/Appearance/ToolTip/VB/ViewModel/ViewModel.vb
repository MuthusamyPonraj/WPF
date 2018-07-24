Imports ToolTipDemo.Model
Imports Syncfusion.Windows.Controls.PivotGrid
Imports System.Collections.Generic
Imports System
Imports System.Linq

Namespace ToolTipDemo.ViewModel
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

        Public ReadOnly Property ThemeList() As IEnumerable(Of String)
            Get
                Return From skin In [Enum](Of PivotGridVisualStyle).GetNames() Select skin Where skin <> PivotGridVisualStyle.Default.ToString()
            End Get
        End Property

    End Class
End Namespace

