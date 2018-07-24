Imports System.Windows

#Region "Copyright Syncfusion Inc. 2001 - 2012"
' Copyright Syncfusion Inc. 2001 - 2012. All rights reserved.
' Use of this code is subject to the terms of our license.
' A copy of the current license can be obtained at any time by e-mailing
' licensing@syncfusion.com. Any infringement will be prosecuted under
' applicable laws. 
#End Region


Namespace LocalizationDemo_2010
    Partial Public Class MainWindow
        Inherits Window
        Public Sub New()

            'Set the current thread culture to load the localization resource file added .

            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("de-DE")

            'Me.pivotGrid1.ItemSource = ProductSales.GetSalesData()

            InitializeComponent()
        End Sub
    End Class
End Namespace
