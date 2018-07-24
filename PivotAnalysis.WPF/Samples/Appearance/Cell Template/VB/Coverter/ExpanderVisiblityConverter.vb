Imports System.Windows.Data
Imports Syncfusion.PivotAnalysis.Base
Imports System.Windows
Imports System
Namespace CellTemplateDemo.Converter
    Class ExpanderVisiblityConverter
        Implements IValueConverter

        Public Function Convert(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.Convert
            Dim cellInfo = TryCast(value, PivotCellInfo)
            If Not (cellInfo Is Nothing) Then
                If cellInfo.CellType.ToString().Contains(PivotCellType.ExpanderCell.ToString()) Or cellInfo.Tag IsNot Nothing Then
                    Return Visibility.Visible
                Else
                    Return Visibility.Hidden
                End If
            End If
            Return Visibility.Hidden

        End Function

        Public Function ConvertBack(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.ConvertBack
            Throw New NotImplementedException()
        End Function
    End Class
End Namespace
