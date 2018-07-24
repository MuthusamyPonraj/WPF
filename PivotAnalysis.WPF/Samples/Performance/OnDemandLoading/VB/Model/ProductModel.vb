Imports Microsoft.VisualBasic
Imports System

Namespace OnDemandLoadingDemo
	Public Class ItemObject
		Private Shared r As New Random(123123)
'INSTANT VB NOTE: The variable client was renamed since Visual Basic does not allow class members with the same name:
		Private client_Renamed As String = String.Empty

		Public Property Client() As String
			Get
				Return client_Renamed
			End Get
			Set(ByVal value As String)
				client_Renamed = value
				OnPropertyChanged("Client")
			End Set
		End Property
'INSTANT VB NOTE: The variable campaign was renamed since Visual Basic does not allow class members with the same name:
		Private campaign_Renamed As String = String.Empty

		Public Property Campaign() As String
			Get
				Return campaign_Renamed
			End Get
			Set(ByVal value As String)
				campaign_Renamed = value
				OnPropertyChanged("Campaign")
			End Set
		End Property

'INSTANT VB NOTE: The variable date was renamed since Visual Basic does not allow class members with the same name:
		Private date_Renamed As DateTime = DateTime.Now

		Public Property [Date]() As DateTime
			Get
				Return date_Renamed
			End Get
			Set(ByVal value As DateTime)
				date_Renamed = value
				OnPropertyChanged("Date")
			End Set
		End Property

'INSTANT VB NOTE: The variable date1 was renamed since Visual Basic does not allow class members with the same name:
		Private date1_Renamed As DateTime = DateTime.Now

		Public Property Date1() As DateTime
			Get
				Return date1_Renamed
			End Get
			Set(ByVal value As DateTime)
				date1_Renamed = value
				OnPropertyChanged("Date1")
			End Set
		End Property

'INSTANT VB NOTE: The variable color was renamed since Visual Basic does not allow class members with the same name:
		Private color_Renamed As String = String.Empty

		Public Property Color() As String
			Get
				Return color_Renamed
			End Get
			Set(ByVal value As String)
				color_Renamed = value
				OnPropertyChanged("Color")
			End Set
		End Property
'INSTANT VB NOTE: The variable shape was renamed since Visual Basic does not allow class members with the same name:
		Private shape_Renamed As String = String.Empty

		Public Property Shape() As String
			Get
				Return shape_Renamed
			End Get
			Set(ByVal value As String)
				shape_Renamed = value
				OnPropertyChanged("Shape")
			End Set
		End Property


'INSTANT VB NOTE: The variable colH was renamed since Visual Basic does not allow class members with the same name:
		Private colH_Renamed As String = String.Empty

		Public Property ColH() As String
			Get
				Return colH_Renamed
			End Get
			Set(ByVal value As String)
				colH_Renamed = value
				OnPropertyChanged("ColH")
			End Set
		End Property
'INSTANT VB NOTE: The variable colI was renamed since Visual Basic does not allow class members with the same name:
		Private colI_Renamed As String = String.Empty

		Public Property ColI() As String
			Get
				Return colI_Renamed
			End Get
			Set(ByVal value As String)
				colI_Renamed = value
				OnPropertyChanged("ColI")
			End Set
		End Property
'INSTANT VB NOTE: The variable colJ was renamed since Visual Basic does not allow class members with the same name:
		Private colJ_Renamed As String = String.Empty

		Public Property ColJ() As String
			Get
				Return colJ_Renamed
			End Get
			Set(ByVal value As String)
				colJ_Renamed = value
				OnPropertyChanged("ColJ")
			End Set
		End Property

'INSTANT VB NOTE: The variable price was renamed since Visual Basic does not allow class members with the same name:
		Private price_Renamed As Double = 0R

		Public Property Price() As Double
			Get
				Return price_Renamed
			End Get
			Set(ByVal value As Double)
				price_Renamed = value
				OnPropertyChanged("Price")
			End Set
		End Property
'INSTANT VB NOTE: The variable spend was renamed since Visual Basic does not allow class members with the same name:
		Private spend_Renamed As Double = 0R

		Public Property Spend() As Double
			Get
				Return spend_Renamed
			End Get
			Set(ByVal value As Double)
				spend_Renamed = value
				OnPropertyChanged("Spend")
			End Set
		End Property
'INSTANT VB NOTE: The variable quantity was renamed since Visual Basic does not allow class members with the same name:
		Private quantity_Renamed As Integer = 0

		Public Property Quantity() As Integer
			Get
				Return quantity_Renamed
			End Get
			Set(ByVal value As Integer)
				quantity_Renamed = value
				OnPropertyChanged("Quantity")
			End Set
		End Property

'INSTANT VB NOTE: The variable id was renamed since Visual Basic does not allow class members with the same name:
		Private id_Renamed As Integer = 0

		Public Property Id() As Integer
			Get
				Return id_Renamed
			End Get
			Set(ByVal value As Integer)
				id_Renamed = value
				OnPropertyChanged("Id")
			End Set
		End Property

		Protected Overridable Sub OnPropertyChanged(ByVal name As String)
			'if (PropertyChanged != null)
			'{
			'    PropertyChanged(this, new PropertyChangedEventArgs(name));
			'}
		End Sub
		'public event PropertyChangedEventHandler PropertyChanged;
	End Class

	Friend Class ProductModel
		 ''' <summary>
		''' Gets or Sets the Product
		''' </summary>
		Private privateProduct As String
		Public Property Product() As String
			Get
				Return privateProduct
			End Get
			Set(ByVal value As String)
				privateProduct = value
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
		''' Gets or Sets the Quantity
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
			Return String.Format("{0}-{1}-{2}", Me.Country, Me.State, Me.Product)
		End Function
	End Class

End Namespace
