Imports Syncfusion.Windows.Controls.PivotGrid
Imports Syncfusion.PivotAnalysis.Base
Namespace PivotEditing.Action
    Public Class CustomEditManager
        Inherits PivotEditingManager
        Public Sub New(ByVal pg As PivotGridControl)
            MyBase.New(pg)
        End Sub

        Protected Overrides Sub ChangeValue(ByVal oldValue As Object, ByVal newValue As Object, ByVal row1 As Integer, ByVal col1 As Integer, ByVal pi As PivotCellInfo)
            'do the base change
            MyBase.ChangeValue(oldValue, newValue, row1, col1, pi)

            'mark all the adjusted cell contents
            pi.FormattedText &= "*"
        End Sub
    End Class
End Namespace
