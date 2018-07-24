Imports Microsoft.VisualBasic
#Region "Copyright Syncfusion Inc. 2001 - 2012"
' Copyright Syncfusion Inc. 2001 - 2012. All rights reserved.
' Use of this code is subject to the terms of our license.
' A copy of the current license can be obtained at any time by e-mailing
' licensing@syncfusion.com. Any infringement will be prosecuted under
' applicable laws. 
#End Region
Imports System

Namespace CustomSummaries.Model
	Public Class DataPoint
		Private privateID As Integer
		Public Property ID() As Integer
			Get
				Return privateID
			End Get
			Private Set(ByVal value As Integer)
				privateID = value
			End Set
		End Property
		Private privateCountry As String
		Public Property Country() As String
			Get
				Return privateCountry
			End Get
			Private Set(ByVal value As String)
				privateCountry = value
			End Set
		End Property
		Private privateState As String
		Public Property State() As String
			Get
				Return privateState
			End Get
			Private Set(ByVal value As String)
				privateState = value
			End Set
		End Property
		Private privateCategory As String
		Public Property Category() As String
			Get
				Return privateCategory
			End Get
			Private Set(ByVal value As String)
				privateCategory = value
			End Set
		End Property
		Private privateItem As String
		Public Property Item() As String
			Get
				Return privateItem
			End Get
			Private Set(ByVal value As String)
				privateItem = value
			End Set
		End Property
		Private privateCurrency As Decimal
		Public Property Currency() As Decimal
			Get
				Return privateCurrency
			End Get
			Private Set(ByVal value As Decimal)
				privateCurrency = value
			End Set
		End Property
		Private privateValue1 As Double
		Public Property Value1() As Double
			Get
				Return privateValue1
			End Get
			Private Set(ByVal value As Double)
				privateValue1 = value
			End Set
		End Property
		Private privateValue2 As Double
		Public Property Value2() As Double
			Get
				Return privateValue2
			End Get
			Private Set(ByVal value As Double)
				privateValue2 = value
			End Set
		End Property
		Private privateValue3 As Double
		Public Property Value3() As Double
			Get
				Return privateValue3
			End Get
			Private Set(ByVal value As Double)
				privateValue3 = value
			End Set
		End Property

		Public Sub New(ByVal id As Integer, ByVal category As String, ByVal item As String, ByVal country As String, ByVal state As String, ByVal currency As Decimal, ByVal value1 As Double, ByVal value2 As Double, ByVal value3 As Double)
			Me.ID = id
			Me.Category = category
			Me.Item = item
			Me.Country = country
			Me.State = state
			Me.Currency = currency
			Me.Value1 = value1
			Me.Value2 = value2
			Me.Value3 = value3
		End Sub
	End Class
End Namespace
