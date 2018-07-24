Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports Syncfusion.Windows.Controls
Imports PivotEngineImpt.ViewModel
Imports Syncfusion.PivotAnalysis.Base
Namespace DrillThroughDemo
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()
			Me.DataContext = New ViewModel()
			Me.pivotGridControl1.ValueCellStyle.IsHyperlinkCell = True
			Me.pivotGridControl1.SummaryCellStyle.IsHyperlinkCell = True

		End Sub
	End Class
End Namespace
