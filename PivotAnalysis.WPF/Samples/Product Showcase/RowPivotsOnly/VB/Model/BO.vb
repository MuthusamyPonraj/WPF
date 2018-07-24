Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace RowPivotsOnlyDemo
	Public Class BO
		 'Location	Vendor	MarkStyle	Region	Class	PID	Color	ColorDesc	Size	Units	Retail	Cost
		Private privateLocation As Integer
		Public Property Location() As Integer
			Get
				Return privateLocation
			End Get
			Set(ByVal value As Integer)
				privateLocation = value
			End Set
		End Property
		Private privateVendor As Integer
		Public Property Vendor() As Integer
			Get
				Return privateVendor
			End Get
			Set(ByVal value As Integer)
				privateVendor = value
			End Set
		End Property
		Private privateMarkStyle As Integer
		Public Property MarkStyle() As Integer
			Get
				Return privateMarkStyle
			End Get
			Set(ByVal value As Integer)
				privateMarkStyle = value
			End Set
		End Property
		Private privateRegion As String
		Public Property Region() As String
			Get
				Return privateRegion
			End Get
			Set(ByVal value As String)
				privateRegion = value
			End Set
		End Property
		Private privateClass As Integer
		Public Property [Class]() As Integer
			Get
				Return privateClass
			End Get
			Set(ByVal value As Integer)
				privateClass = value
			End Set
		End Property
		Private privatePID As Integer
		Public Property PID() As Integer
			Get
				Return privatePID
			End Get
			Set(ByVal value As Integer)
				privatePID = value
			End Set
		End Property
		Private privateColor As Integer
		Public Property Color() As Integer
			Get
				Return privateColor
			End Get
			Set(ByVal value As Integer)
				privateColor = value
			End Set
		End Property
		Private privateColorDesc As String
		Public Property ColorDesc() As String
			Get
				Return privateColorDesc
			End Get
			Set(ByVal value As String)
				privateColorDesc = value
			End Set
		End Property
		Private privateSize As String
		Public Property Size() As String
			Get
				Return privateSize
			End Get
			Set(ByVal value As String)
				privateSize = value
			End Set
		End Property
		Private privateUnits As Integer
		Public Property Units() As Integer
			Get
				Return privateUnits
			End Get
			Set(ByVal value As Integer)
				privateUnits = value
			End Set
		End Property
		Private privateRetail As Double
		Public Property Retail() As Double
			Get
				Return privateRetail
			End Get
			Set(ByVal value As Double)
				privateRetail = value
			End Set
		End Property
		Private privateCost As Double
		Public Property Cost() As Double
			Get
				Return privateCost
			End Get
			Set(ByVal value As Double)
				privateCost = value
			End Set
		End Property
		Private privateid As Integer
		Public Property id() As Integer
			Get
				Return privateid
			End Get
			Set(ByVal value As Integer)
				privateid = value
			End Set
		End Property
		Private privateTestStr As String
		Public Property TestStr() As String
			Get
				Return privateTestStr
			End Get
			Set(ByVal value As String)
				privateTestStr = value
			End Set
		End Property
		Private privateTestInt As Integer
		Public Property TestInt() As Integer
			Get
				Return privateTestInt
			End Get
			Set(ByVal value As Integer)
				privateTestInt = value
			End Set
		End Property
		Private privateTestDouble As Double
		Public Property TestDouble() As Double
			Get
				Return privateTestDouble
			End Get
			Set(ByVal value As Double)
				privateTestDouble = value
			End Set
		End Property

	End Class
End Namespace
