Imports System.Data

Namespace PivotEditing.ViewModel
    Public Class ViewModel
        Private _dataTableViewSource As DataView
        Public Property BusinessObjectAsDataView() As DataView
            Get
                If _dataTableViewSource Is Nothing Then
                    _dataTableViewSource = Model.BusinessObjectsDataView.GetDataTable(200)
                End If
                Return _dataTableViewSource
            End Get
            Set(ByVal value As DataView)
                _dataTableViewSource = value
            End Set
        End Property
    End Class
End Namespace

