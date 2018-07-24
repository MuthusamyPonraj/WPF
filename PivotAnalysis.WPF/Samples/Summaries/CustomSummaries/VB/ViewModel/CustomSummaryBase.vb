Imports Microsoft.VisualBasic
#Region "Copyright Syncfusion Inc. 2001 - 2012"
' Copyright Syncfusion Inc. 2001 - 2012. All rights reserved.
' Use of this code is subject to the terms of our license.
' A copy of the current license can be obtained at any time by e-mailing
' licensing@syncfusion.com. Any infringement will be prosecuted under
' applicable laws. 
#End Region
Imports System
Imports Syncfusion.PivotAnalysis.Base
Imports CustomSummaries

Namespace CustomSummaryDemo.ViewModel
	Public Class MyCustomSummaryBase1
		Inherits SummaryBase
		Public Sub New()
		End Sub
		Private mTotalValue As Double

		Public Overrides Sub Combine(ByVal other As Object)
			mTotalValue += CDbl(other)
		End Sub

		Public Overrides Sub CombineSummary(ByVal other As SummaryBase)
			Dim dpsb As MyCustomSummaryBase1 = TryCast(other, MyCustomSummaryBase1)

			If Nothing IsNot dpsb Then
				mTotalValue += dpsb.mTotalValue
			End If
		End Sub

		Public Overrides Function GetInstance() As SummaryBase
			Return New MyCustomSummaryBase1()
		End Function

		Public Overrides Function GetResult() As Object
			Return mTotalValue / 3.33333
		End Function

		Public Overrides Sub Reset()
			mTotalValue = 0
		End Sub
	End Class


	Public Class MyCustomSummaryBase2
		Inherits SummaryBase
		Private mTotalValue As Double

		Public Overrides Sub Combine(ByVal other As Object)
			mTotalValue += CDbl(other)
		End Sub

		Public Overrides Sub CombineSummary(ByVal other As SummaryBase)
			Dim dpsb As MyCustomSummaryBase2 = TryCast(other, MyCustomSummaryBase2)

			If Nothing IsNot dpsb Then
				mTotalValue += dpsb.mTotalValue
			End If
		End Sub

		Public Overrides Function GetInstance() As SummaryBase
			Return New MyCustomSummaryBase2()
		End Function

		Public Overrides Function GetResult() As Object
			Return mTotalValue / 5.5555
		End Function

		Public Overrides Sub Reset()
			mTotalValue = 0
		End Sub
	End Class
End Namespace
