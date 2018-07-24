Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace UIThreadingDemo
	Friend Class ProductModel
		''' <summary>
		''' Gets or Sets the TwoWheeler
		''' </summary>
		Private privateTwoWheeler As String
		Public Property TwoWheeler() As String
			Get
				Return privateTwoWheeler
			End Get
			Set(ByVal value As String)
				privateTwoWheeler = value
			End Set
		End Property
		''' <summary>
		''' Gets or Sets the ThreeWheeler
		''' </summary>
		Private privateThreeWheeler As String
		Public Property ThreeWheeler() As String
			Get
				Return privateThreeWheeler
			End Get
			Set(ByVal value As String)
				privateThreeWheeler = value
			End Set
		End Property
		''' <summary>
		''' Gets or Sets the FourWheeler
		''' </summary>
		Private privateFourWheeler As String
		Public Property FourWheeler() As String
			Get
				Return privateFourWheeler
			End Get
			Set(ByVal value As String)
				privateFourWheeler = value
			End Set
		End Property

		''' <summary>
		''' Gets or Sets the Date
		''' </summary>
		Private privateDate As String
		Public Property [Date]() As String
			Get
				Return privateDate
			End Get
			Set(ByVal value As String)
				privateDate = value
			End Set
		End Property

		''' <summary>
		''' Gets or Sets the Country
		''' </summary>
		Private privateCountry As String
		Public Property Country() As String
			Get
				Return privateCountry
			End Get
			Set(ByVal value As String)
				privateCountry = value
			End Set
		End Property

		''' <summary>
		''' Gets or Sets the State
		''' </summary>
		Private privateState As String
		Public Property State() As String
			Get
				Return privateState
			End Get
			Set(ByVal value As String)
				privateState = value
			End Set
		End Property

		''' <summary>
		''' Gets or Sets the Qunatity
		''' </summary>
		Private privateQuantity As Integer
		Public Property Quantity() As Integer
			Get
				Return privateQuantity
			End Get
			Set(ByVal value As Integer)
				privateQuantity = value
			End Set
		End Property

		''' <summary>
		''' Gets or Sets the Amount
		''' </summary>
		Private privateAmount As Double
		Public Property Amount() As Double
			Get
				Return privateAmount
			End Get
			Set(ByVal value As Double)
				privateAmount = value
			End Set
		End Property

		Public Overrides Function ToString() As String
			Return String.Format("{0}-{1}-{2}", Me.Country, Me.State, Me.FourWheeler,Me.ThreeWheeler,Me.TwoWheeler)
		End Function
	End Class
End Namespace
