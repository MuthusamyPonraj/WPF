Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.ObjectModel

Namespace OnDemandLoadingDemo
	#Region "ItemObject"

	Public Class ItemObjects
        Private Shared r As New Random(1123)

        Public Shared Function GetList() As ObservableCollection(Of ItemObject)
            Dim list As New ObservableCollection(Of ItemObject)()
            Dim date0 As DateTime = DateTime.Now
            Dim date1 As DateTime = DateTime.Now
            Dim k As Integer = 0
            Dim clientCount As Integer = 245
            Dim campaignCount As Integer = 5
            Dim yearCount As Integer = 1
            Dim colorCount As Integer = 5
            Dim shapeCount As Integer = 5
            For i As Integer = 0 To 29999
                ' Campaign = string.Format("cam_{0}", r.Next(campaignCount)),
                'ColA = string.Format("A_{0}", r.Next(100)),
                'ColB = string.Format("B_{0}", r.Next(100)),
                'ColC = string.Format("C_{0}", r.Next(100)),
                'ColD = string.Format("D_{0}", r.Next(100)),
                'ColE = string.Format("E_{0}", r.Next(100)),
                'ColF = string.Format("F_{0}", r.Next(100)),
                'ColG = string.Format("G_{0}", r.Next(100)),
                list.Add(New ItemObject() With {.Id = i, .Client = String.Format("cli_{0}", k = r.Next(clientCount)), .Campaign = String.Format("cam_{0}", k + r.Next(campaignCount)), .Date = date1, .Date1 = date1, .Color = String.Format("col_{0}", r.Next(colorCount)), .Shape = String.Format("col_{0}", r.Next(shapeCount)), .ColH = String.Format("H_{0}", r.Next(100)), .ColI = String.Format("I_{0}", r.Next(100)), .ColJ = String.Format("J_{0}", r.Next(100)), .Price = (CInt(Fix(100000 * r.NextDouble()))) / 100, .Spend = (CInt(Fix(100000 * r.NextDouble()))) / 100, .Quantity = r.Next(1000) + 100})
            Next i
            Return list
        End Function

		Public Shared Function GetList(ByVal count As Integer, ByVal clientCount As Integer, ByVal campaignCount As Integer, ByVal yearCount As Integer, ByVal colorCount As Integer, ByVal shapeCount As Integer) As ObservableCollection(Of ItemObject)
			Dim Hs As Integer = 5
			Dim list As New ObservableCollection(Of ItemObject)()

			Dim k As Integer = 0
			For i As Integer = 0 To count - 1
				list.Add(New ItemObject() With {.Id = i, .Client = String.Format("cli_{0}", k = r.Next(clientCount)), .Campaign = String.Format("cam_{0}", r.Next(campaignCount)), .Color = String.Format("col_{0}", r.Next(colorCount)), .Shape = String.Format("sha_{0}", r.Next(shapeCount)), .Date = DateTime.Now.Date.AddDays(-r.Next(600)), .ColH = String.Format("H_{0}", r.Next(Hs)), .ColI = String.Format("I_{0}", r.Next(Hs)), .ColJ = String.Format("J_{0}", r.Next(Hs)), .Price = (CInt(Fix(100000 * r.NextDouble()))) / 100, .Spend = (CInt(Fix(100000 * r.NextDouble()))) / 100, .Quantity = r.Next(1000) + 100})
			Next i
			Return list
		End Function

	End Class

	#End Region
End Namespace
