Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Collections
Imports System.Collections.ObjectModel

Namespace RowPivotsOnlyDemo
	Friend Class RowPivotsOnlyDemoModel
'INSTANT VB NOTE: The variable data was renamed since Visual Basic does not allow class members with the same name:
		Private data_Renamed As IList
		Public Property Data() As IList
			Get
				data_Renamed = If(data_Renamed, DataProvider(Of BO).GetData())
				Return data_Renamed
			End Get
			Set(ByVal value As IList)
				data_Renamed = value
			End Set
		End Property
	End Class
End Namespace
