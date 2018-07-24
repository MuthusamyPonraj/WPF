Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Collections.ObjectModel
Imports System.IO
Imports System.ComponentModel

Namespace RowPivotsOnlyDemo
	Public NotInheritable Class DataProvider(Of T As New)
	   Private Sub New()
	   End Sub
	   Public Shared Function GetData() As ObservableCollection(Of T)
			Dim fileName As String = "..\..\DataFile\data.csv"
			Dim lines As New List(Of String)()

			Using reader As StreamReader = File.OpenText(fileName)
				Do While Not reader.EndOfStream
					lines.Add(reader.ReadLine())
				Loop
			End Using

			Dim dataSource = New ObservableCollection(Of T)()
			SetFileData(lines, dataSource)
			Return dataSource
	   End Function


	   Private Shared r As New Random(12312)

		Private Shared Sub SetFileData(ByVal lines As List(Of String), ByVal dataSource As ObservableCollection(Of T))
			Dim pdc As PropertyDescriptorCollection = TypeDescriptor.GetProperties(GetType(T))
			For i As Integer = 1 To lines.Count - 1
				Dim cols() As String = lines(i).Split(New Char() { ","c })
				Dim bo As New T()
				Dim k As Integer = 0

				For Each pd As PropertyDescriptor In pdc
					If pd.Name = "PID_CLR_SIZ" Then
						Continue For 'skip this on as it is a composite column
					End If
					If Not pd.Name.StartsWith("Test") Then 'skip added test fields that are not in the data
						ProcessLine(bo, cols(k), pd)
						k += 1
					ElseIf TypeOf bo Is BO Then

						Select Case pd.Name
							Case "TestInt"
								pd.SetValue(bo, (TryCast(bo, BO)).Color)
							Case "TestStr"
								pd.SetValue(bo, "S" & (TryCast(bo, BO)).Color.ToString())
							Case "TestDouble"
							   ' Console.WriteLine(1d + r.NextDouble() / 5d);
								pd.SetValue(bo, 1R + r.NextDouble()/ 5R)
							  '  pd.SetValue(bo,(double) ((bo as BO).Color) );
							Case "TestSortA"
								' Console.WriteLine(1d + r.NextDouble() / 5d);
								pd.SetValue(bo, r.Next(2))
								'  pd.SetValue(bo,(double) ((bo as BO).Color) );
							Case "TestSortB"
								' Console.WriteLine(1d + r.NextDouble() / 5d);
								pd.SetValue(bo, r.Next(3))
								'  pd.SetValue(bo,(double) ((bo as BO).Color) );
							Case "TestSortC"
								' Console.WriteLine(1d + r.NextDouble() / 5d);
								pd.SetValue(bo, r.Next(4))
								'  pd.SetValue(bo,(double) ((bo as BO).Color) );

							Case Else
						End Select

					End If
				Next pd
				dataSource.Add(bo)
			Next i
		End Sub

		Private Shared Sub ProcessLine(ByVal bo As T, ByVal val As String, ByVal pd As PropertyDescriptor)

			If pd.PropertyType Is GetType(Integer) Then
				If val = String.Empty Then
					'don't set it
				Else
					pd.SetValue(bo, Integer.Parse(val))
				End If
			ElseIf pd.PropertyType Is GetType(Double) Then
				If val.TrimEnd().EndsWith("%") Then
					pd.SetValue(bo, Double.Parse(val.Replace("%", "")) / 100R)
				ElseIf val = String.Empty Then
					'dont set it
				Else
					pd.SetValue(bo, Double.Parse(val))
				End If
			ElseIf pd.PropertyType Is GetType(DateTime) Then
				pd.SetValue(bo, DateTime.Parse(val))
			Else
				pd.SetValue(bo, val)
			End If
		End Sub
	End Class
End Namespace
