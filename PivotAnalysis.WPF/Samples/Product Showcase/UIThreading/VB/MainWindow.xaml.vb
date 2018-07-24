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

Namespace UIThreadingDemo
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()
			Me.DataContext = New ViewModel.ViewModel()
			AddHandler pivotGrid1.Loaded, AddressOf pivotGrid1_Loaded
		End Sub

		Private Sub pivotGrid1_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			' Loading asynchrounously on a background thread.
			Me.pivotGrid1.InternalGrid.LoadInBackground = True

		End Sub

		Private Sub clickButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			MessageBox.Show("Item Selected")
		End Sub
	End Class
End Namespace
