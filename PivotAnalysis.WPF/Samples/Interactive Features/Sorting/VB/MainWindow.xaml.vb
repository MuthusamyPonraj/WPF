Imports Microsoft.VisualBasic
#Region "Copyright Syncfusion Inc. 2001 - 2012"
' Copyright Syncfusion Inc. 2001 - 2012. All rights reserved.
' Use of this code is subject to the terms of our license.
' A copy of the current license can be obtained at any time by e-mailing
' licensing@syncfusion.com. Any infringement will be prosecuted under
' applicable laws. 
#End Region
Imports System.Windows
Imports Syncfusion.Windows.Controls.PivotGrid


Namespace SortingDemo
	Partial Public Class MainWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()
			AddHandler btnSortAll.Click, AddressOf btnSortAll_Click
			AddHandler btnSortNone.Click, AddressOf btnSortNone_Click
			AddHandler btnSortColumn.Click, AddressOf btnSortColumn_Click
			AddHandler btnSortGrandTotal.Click, AddressOf btnSortGrandTotal_Click
			AddHandler btnSortTotal.Click, AddressOf btnSortTotal_Click
		End Sub

		Private Sub btnSortTotal_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Me.pivotGrid1.SortOption = PivotSortOption.TotalSorting
		End Sub

		Private Sub btnSortGrandTotal_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Me.pivotGrid1.SortOption = PivotSortOption.GrandTotalSorting
		End Sub

		Private Sub btnSortColumn_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Me.pivotGrid1.SortOption = PivotSortOption.ColumnSorting
		End Sub

		Private Sub btnSortNone_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Me.pivotGrid1.SortOption = PivotSortOption.None

		End Sub

		Private Sub btnSortAll_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Me.pivotGrid1.SortOption = PivotSortOption.All
		End Sub
	End Class
End Namespace
