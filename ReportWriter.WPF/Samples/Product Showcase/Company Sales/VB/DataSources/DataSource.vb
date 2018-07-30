Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Collections

Namespace CompanySales
    Public Class AdventureWorks
        Public Property ProdCat() As String
            Get
                Return m_ProdCat
            End Get
            Set(value As String)
                m_ProdCat = Value
            End Set
        End Property
        Private m_ProdCat As String
        Public Property SubCat() As String
            Get
                Return m_SubCat
            End Get
            Set(value As String)
                m_SubCat = Value
            End Set
        End Property
        Private m_SubCat As String
        Public Property OrderYear() As String
            Get
                Return m_OrderYear
            End Get
            Set(value As String)
                m_OrderYear = Value
            End Set
        End Property
        Private m_OrderYear As String
        Public Property OrderQtr() As String
            Get
                Return m_OrderQtr
            End Get
            Set(value As String)
                m_OrderQtr = Value
            End Set
        End Property
        Private m_OrderQtr As String
        Public Property Sales() As Double
            Get
                Return m_Sales
            End Get
            Set(value As Double)
                m_Sales = Value
            End Set
        End Property
        Private m_Sales As Double
        Public Function GetData() As IList
            Dim AdventureWorksCollection As New List(Of AdventureWorks)()
            Dim AdventureWork As AdventureWorks = Nothing
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Accessories", _
               .SubCat = "Helmets", _
               .OrderYear = "2002", _
               .OrderQtr = "Q1", _
               .Sales = 4945.6925 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Components", _
               .SubCat = "Road Frames", _
               .OrderYear = "2002", _
               .OrderQtr = "Q3", _
               .Sales = 957715.1942 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Components", _
               .SubCat = "Forks", _
               .OrderYear = "2002", _
               .OrderQtr = "Q4", _
               .Sales = 23543.106 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Bikes", _
               .SubCat = "Road Bikes", _
               .OrderYear = "2002", _
               .OrderQtr = "Q1", _
               .Sales = 3171787.6112 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Accessories", _
               .SubCat = "Helmets", _
               .OrderYear = "2002", _
               .OrderQtr = "Q3", _
               .Sales = 33853.1033 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Components", _
               .SubCat = "Wheels", _
               .OrderYear = "2002", _
               .OrderQtr = "Q4", _
               .Sales = 163921.887 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Bikes", _
               .SubCat = "Road Bikes", _
               .OrderYear = "2003", _
               .OrderQtr = "Q2", _
               .Sales = 4119658.6506 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Clothing", _
               .SubCat = "Socks", _
               .OrderYear = "2003", _
               .OrderQtr = "Q3", _
               .Sales = 6968.6884 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Bikes", _
               .SubCat = "Road Bikes", _
               .OrderYear = "2003", _
               .OrderQtr = "Q4", _
               .Sales = 3734891.6389 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Components", _
               .SubCat = "Mountain Frames", _
               .OrderYear = "2002", _
               .OrderQtr = "Q3", _
               .Sales = 608352.8754 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Components", _
               .SubCat = "Handlebars", _
               .OrderYear = "2002", _
               .OrderQtr = "Q4", _
               .Sales = 18309.4452 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Components", _
               .SubCat = "Road Frames", _
               .OrderYear = "2003", _
               .OrderQtr = "Q4", _
               .Sales = 286591.8208 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Accessories", _
               .SubCat = "Tires and Tubes", _
               .OrderYear = "2003", _
               .OrderQtr = "Q3", _
               .Sales = 41940.3364 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Components", _
               .SubCat = "Mountain Frames", _
               .OrderYear = "2003", _
               .OrderQtr = "Q2", _
               .Sales = 440260.9831 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Components", _
               .SubCat = "Road Frames", _
               .OrderYear = "2003", _
               .OrderQtr = "Q2", _
               .Sales = 457688.8401 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Clothing", _
               .SubCat = "Vests", _
               .OrderYear = "2003", _
               .OrderQtr = "Q4", _
               .Sales = 66882.645 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Accessories", _
               .SubCat = "Pumps", _
               .OrderYear = "2002", _
               .OrderQtr = "Q4", _
               .Sales = 3226.386 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Clothing", _
               .SubCat = "Tights", _
               .OrderYear = "2003", _
               .OrderQtr = "Q2", _
               .Sales = 51600.619 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Components", _
               .SubCat = "Chains", _
               .OrderYear = "2003", _
               .OrderQtr = "Q3", _
               .Sales = 3476.0176 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Components", _
               .SubCat = "Handlebars", _
               .OrderYear = "2003", _
               .OrderQtr = "Q2", _
               .Sales = 17194.2146 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Components", _
               .SubCat = "Mountain Frames", _
               .OrderYear = "2003", _
               .OrderQtr = "Q4", _
               .Sales = 565229.881 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Clothing", _
               .SubCat = "Tights", _
               .OrderYear = "2003", _
               .OrderQtr = "Q4", _
               .Sales = 243.7175 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Components", _
               .SubCat = "Road Frames", _
               .OrderYear = "2002", _
               .OrderQtr = "Q2", _
               .Sales = 155311.4063 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Components", _
               .SubCat = "Mountain Frames", _
               .OrderYear = "2002", _
               .OrderQtr = "Q2", _
               .Sales = 220935.1648 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Accessories", _
               .SubCat = "Locks", _
               .OrderYear = "2003", _
               .OrderQtr = "Q4", _
               .Sales = 15.0 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Components", _
               .SubCat = "Mountain Frames", _
               .OrderYear = "2003", _
               .OrderQtr = "Q3", _
               .Sales = 827287.5234 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Accessories", _
               .SubCat = "Bike Racks", _
               .OrderYear = "2003", _
               .OrderQtr = "Q3", _
               .Sales = 75920.4 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Components", _
               .SubCat = "Bottom Brackets", _
               .OrderYear = "2003", _
               .OrderQtr = "Q3", _
               .Sales = 17453.64 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Bikes", _
               .SubCat = "Touring Bikes", _
               .OrderYear = "2003", _
               .OrderQtr = "Q3", _
               .Sales = 3298006.2858 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Components", _
               .SubCat = "Brakes", _
               .OrderYear = "2003", _
               .OrderQtr = "Q4", _
               .Sales = 18571.47 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Clothing", _
               .SubCat = "Tights", _
               .OrderYear = "2002", _
               .OrderQtr = "Q4", _
               .Sales = 56782.428 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Components", _
               .SubCat = "Pedals", _
               .OrderYear = "2003", _
               .OrderQtr = "Q3", _
               .Sales = 54185.2014 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Clothing", _
               .SubCat = "Jerseys", _
               .OrderYear = "2003", _
               .OrderQtr = "Q3", _
               .Sales = 173041.0492 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Clothing", _
               .SubCat = "Jerseys", _
               .OrderYear = "2002", _
               .OrderQtr = "Q2", _
               .Sales = 16931.2362 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Components", _
               .SubCat = "Headsets", _
               .OrderYear = "2002", _
               .OrderQtr = "Q3", _
               .Sales = 19701.9001 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Components", _
               .SubCat = "Road Frames", _
               .OrderYear = "2002", _
               .OrderQtr = "Q4", _
               .Sales = 458089.4246 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Clothing", _
               .SubCat = "Shorts", _
               .OrderYear = "2003", _
               .OrderQtr = "Q1", _
               .Sales = 11230.128 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Bikes", _
               .SubCat = "Road Bikes", _
               .OrderYear = "2002", _
               .OrderQtr = "Q4", _
               .Sales = 4189621.859 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Components", _
               .SubCat = "Brakes", _
               .OrderYear = "2003", _
               .OrderQtr = "Q3", _
               .Sales = 26659.08 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Components", _
               .SubCat = "Wheels", _
               .OrderYear = "2003", _
               .OrderQtr = "Q4", _
               .Sales = 83.2981 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Clothing", _
               .SubCat = "Vests", _
               .OrderYear = "2003", _
               .OrderQtr = "Q3", _
               .Sales = 81085.69 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Components", _
               .SubCat = "Cranksets", _
               .OrderYear = "2003", _
               .OrderQtr = "Q3", _
               .Sales = 80244.1372 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Clothing", _
               .SubCat = "Socks", _
               .OrderYear = "2003", _
               .OrderQtr = "Q4", _
               .Sales = 6183.1422 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Components", _
               .SubCat = "Wheels", _
               .OrderYear = "2003", _
               .OrderQtr = "Q2", _
               .Sales = 163929.9435 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Clothing", _
               .SubCat = "Tights", _
               .OrderYear = "2002", _
               .OrderQtr = "Q3", _
               .Sales = 67088.3037 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Clothing", _
               .SubCat = "Tights", _
               .OrderYear = "2003", _
               .OrderQtr = "Q3", _
               .Sales = 779.896 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Clothing", _
               .SubCat = "Socks", _
               .OrderYear = "2002", _
               .OrderQtr = "Q1", _
               .Sales = 1273.855 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Bikes", _
               .SubCat = "Road Bikes", _
               .OrderYear = "2002", _
               .OrderQtr = "Q3", _
               .Sales = 4930692.7825 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Clothing", _
               .SubCat = "Shorts", _
               .OrderYear = "2003", _
               .OrderQtr = "Q4", _
               .Sales = 84192.3708 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Clothing", _
               .SubCat = "Jerseys", _
               .OrderYear = "2002", _
               .OrderQtr = "Q3", _
               .Sales = 48901.7598 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Clothing", _
               .SubCat = "Shorts", _
               .OrderYear = "2002", _
               .OrderQtr = "Q3", _
               .Sales = 26207.2314 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Bikes", _
               .SubCat = "Road Bikes", _
               .OrderYear = "2002", _
               .OrderQtr = "Q2", _
               .Sales = 3478963.5378 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Clothing", _
               .SubCat = "Shorts", _
               .OrderYear = "2003", _
               .OrderQtr = "Q2", _
               .Sales = 21423.6288 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Components", _
               .SubCat = "Derailleurs", _
               .OrderYear = "2003", _
               .OrderQtr = "Q3", _
               .Sales = 25385.255 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Components", _
               .SubCat = "Handlebars", _
               .OrderYear = "2003", _
               .OrderQtr = "Q4", _
               .Sales = 21675.684 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Components", _
               .SubCat = "Bottom Brackets", _
               .OrderYear = "2003", _
               .OrderQtr = "Q4", _
               .Sales = 13339.182 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Clothing", _
               .SubCat = "Jerseys", _
               .OrderYear = "2003", _
               .OrderQtr = "Q2", _
               .Sales = 31334.6088 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Accessories", _
               .SubCat = "Helmets", _
               .OrderYear = "2002", _
               .OrderQtr = "Q2", _
               .Sales = 11638.8628 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Components", _
               .SubCat = "Headsets", _
               .OrderYear = "2003", _
               .OrderQtr = "Q2", _
               .Sales = 14102.2548 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Components", _
               .SubCat = "Handlebars", _
               .OrderYear = "2002", _
               .OrderQtr = "Q3", _
               .Sales = 35341.0863 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Bikes", _
               .SubCat = "Touring Bikes", _
               .OrderYear = "2003", _
               .OrderQtr = "Q4", _
               .Sales = 3766585.3623 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Components", _
               .SubCat = "Chains", _
               .OrderYear = "2003", _
               .OrderQtr = "Q4", _
               .Sales = 2217.8992 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Accessories", _
               .SubCat = "Locks", _
               .OrderYear = "2003", _
               .OrderQtr = "Q2", _
               .Sales = 3939.0 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Bikes", _
               .SubCat = "Road Bikes", _
               .OrderYear = "2003", _
               .OrderQtr = "Q3", _
               .Sales = 3844123.5588 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            AdventureWork = New AdventureWorks() With { _
               .ProdCat = "Components", _
               .SubCat = "Handlebars", _
               .OrderYear = "2003", _
               .OrderQtr = "Q3", _
               .Sales = 43624.0992 _
            }
            AdventureWorksCollection.Add(AdventureWork)
            ' AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Components",
            '                 SubCat = "Headsets",
            '                 OrderYear = "2002",
            '                 OrderQtr = "Q4",
            '                 Sales = "16382.0934"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Clothing",
            '                 SubCat = "Caps",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q1",
            '                 Sales = "1782.0812"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Accessories",
            '                 SubCat = "Bike Stands",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q3",
            '                 Sales = "6996.0000"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Clothing",
            '                 SubCat = "Bib-Shorts",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q1",
            '                 Sales = "21543.6060"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Clothing",
            '                 SubCat = "Socks",
            '                 OrderYear = "2002",
            '                 OrderQtr = "Q2",
            '                 Sales = "1899.6200"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Components",
            '                 SubCat = "Wheels",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q3",
            '                 Sales = "1677.9907"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Clothing",
            '                 SubCat = "Caps",
            '                 OrderYear = "2002",
            '                 OrderQtr = "Q1",
            '                 Sales = "921.2951"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Clothing",
            '                 SubCat = "Jerseys",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q1",
            '                 Sales = "18205.0206"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Accessories",
            '                 SubCat = "Bike Racks",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q4",
            '                 Sales = "60883.2000"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Components",
            '                 SubCat = "Wheels",
            '                 OrderYear = "2002",
            '                 OrderQtr = "Q3",
            '                 Sales = "288627.8321"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Components",
            '                 SubCat = "Mountain Frames",
            '                 OrderYear = "2002",
            '                 OrderQtr = "Q4",
            '                 Sales = "443599.2756"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Bikes",
            '                 SubCat = "Mountain Bikes",
            '                 OrderYear = "2002",
            '                 OrderQtr = "Q1",
            '                 Sales = "2497517.6260"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Clothing",
            '                 SubCat = "Shorts",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q3",
            '                 Sales = "97610.4518"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Clothing",
            '                 SubCat = "Jerseys",
            '                 OrderYear = "2002",
            '                 OrderQtr = "Q4",
            '                 Sales = "35495.3156"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Components",
            '                 SubCat = "Touring Frames",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q3",
            '                 Sales = "666977.0361"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Components",
            '                 SubCat = "Cranksets",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q4",
            '                 Sales = "44127.2820"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Accessories",
            '                 SubCat = "Locks",
            '                 OrderYear = "2002",
            '                 OrderQtr = "Q4",
            '                 Sales = "3780.0000"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Clothing",
            '                 SubCat = "Gloves",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q1",
            '                 Sales = "25691.7532"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Bikes",
            '                 SubCat = "Mountain Bikes",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q1",
            '                 Sales = "2517500.0531"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Clothing",
            '                 SubCat = "Gloves",
            '                 OrderYear = "2002",
            '                 OrderQtr = "Q3",
            '                 Sales = "52536.8767"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Clothing",
            '                 SubCat = "Gloves",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q4",
            '                 Sales = "23619.1700"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Clothing",
            '                 SubCat = "Gloves",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q2",
            '                 Sales = "41875.9919"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Clothing",
            '                 SubCat = "Jerseys",
            '                 OrderYear = "2002",
            '                 OrderQtr = "Q1",
            '                 Sales = "9517.3320"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Clothing",
            '                 SubCat = "Bib-Shorts",
            '                 OrderYear = "2002",
            '                 OrderQtr = "Q4",
            '                 Sales = "35322.8748"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Accessories",
            '                 SubCat = "Hydration Packs",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q3",
            '                 Sales = "31577.4576"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Accessories",
            '                 SubCat = "Cleaners",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q3",
            '                 Sales = "5137.4490"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Accessories",
            '                 SubCat = "Bottles and Cages",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q4",
            '                 Sales = "15968.1566"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Clothing",
            '                 SubCat = "Gloves",
            '                 OrderYear = "2002",
            '                 OrderQtr = "Q4",
            '                 Sales = "38360.2071"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Accessories",
            '                 SubCat = "Pumps",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q2",
            '                 Sales = "3382.3080"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Clothing",
            '                 SubCat = "Caps",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q2",
            '                 Sales = "2939.7072"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Clothing",
            '                 SubCat = "Caps",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q4",
            '                 Sales = "8518.6543"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Clothing",
            '                 SubCat = "Shorts",
            '                 OrderYear = "2002",
            '                 OrderQtr = "Q4",
            '                 Sales = "23176.5366"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Clothing",
            '                 SubCat = "Caps",
            '                 OrderYear = "2002",
            '                 OrderQtr = "Q2",
            '                 Sales = "1479.1897"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Accessories",
            '                 SubCat = "Cleaners",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q4",
            '                 Sales = "4724.3670"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Accessories",
            '                 SubCat = "Bottles and Cages",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q3",
            '                 Sales = "11854.2609"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Components",
            '                 SubCat = "Pedals",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q4",
            '                 Sales = "39900.6900"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Accessories",
            '                 SubCat = "Pumps",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q1",
            '                 Sales = "1763.1180"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Clothing",
            '                 SubCat = "Caps",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q3",
            '                 Sales = "8676.4288"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Accessories",
            '                 SubCat = "Helmets",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q1",
            '                 Sales = "11659.7222"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Components",
            '                 SubCat = "Headsets",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q1",
            '                 Sales = "10949.6362"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Accessories",
            '                 SubCat = "Fenders",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q4",
            '                 Sales = "11759.3000"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Clothing",
            '                 SubCat = "Caps",
            '                 OrderYear = "2002",
            '                 OrderQtr = "Q3",
            '                 Sales = "3990.6653"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Accessories",
            '                 SubCat = "Helmets",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q4",
            '                 Sales = "89595.0441"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Components",
            '                 SubCat = "Derailleurs",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q4",
            '                 Sales = "18974.0842"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Bikes",
            '                 SubCat = "Mountain Bikes",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q2",
            '                 Sales = "2908658.6684"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Bikes",
            '                 SubCat = "Mountain Bikes",
            '                 OrderYear = "2002",
            '                 OrderQtr = "Q3",
            '                 Sales = "3141467.2549"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Accessories",
            '                 SubCat = "Tires and Tubes",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q4",
            '                 Sales = "61948.1660"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Clothing",
            '                 SubCat = "Bib-Shorts",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q2",
            '                 Sales = "43457.9708"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Clothing",
            '                 SubCat = "Gloves",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q3",
            '                 Sales = "26944.8741"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Components",
            '                 SubCat = "Forks",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q2",
            '                 Sales = "18345.1020"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Bikes",
            '                 SubCat = "Mountain Bikes",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q3",
            '                 Sales = "3617011.7320"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Components",
            '                 SubCat = "Road Frames",
            '                 OrderYear = "2002",
            '                 OrderQtr = "Q1",
            '                 Sales = "47486.1204"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Components",
            '                 SubCat = "Mountain Frames",
            '                 OrderYear = "2002",
            '                 OrderQtr = "Q1",
            '                 Sales = "127557.6450"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Accessories",
            '                 SubCat = "Locks",
            '                 OrderYear = "2002",
            '                 OrderQtr = "Q3",
            '                 Sales = "6325.0000"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Components",
            '                 SubCat = "Saddles",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q4",
            '                 Sales = "12939.5836"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Components",
            '                 SubCat = "Forks",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q1",
            '                 Sales = "9913.9680"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Components",
            '                 SubCat = "Touring Frames",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q4",
            '                 Sales = "367783.3714"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Accessories",
            '                 SubCat = "Helmets",
            '                 OrderYear = "2002",
            '                 OrderQtr = "Q4",
            '                 Sales = "24870.7746"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Clothing",
            '                 SubCat = "Jerseys",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q4",
            '                 Sales = "140702.9585"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Components",
            '                 SubCat = "Forks",
            '                 OrderYear = "2002",
            '                 OrderQtr = "Q3",
            '                 Sales = "26166.7828"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Components",
            '                 SubCat = "Saddles",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q3",
            '                 Sales = "24908.2704"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Components",
            '                 SubCat = "Mountain Frames",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q1",
            '                 Sales = "236070.3535"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Components",
            '                 SubCat = "Road Frames",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q1",
            '                 Sales = "132691.6701"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Components",
            '                 SubCat = "Road Frames",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q3",
            '                 Sales = "755820.5967"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Accessories",
            '                 SubCat = "Hydration Packs",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q4",
            '                 Sales = "27109.5201"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Components",
            '                 SubCat = "Handlebars",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q1",
            '                 Sales = "6274.9870"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Clothing",
            '                 SubCat = "Caps",
            '                 OrderYear = "2002",
            '                 OrderQtr = "Q4",
            '                 Sales = "3075.5940"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Bikes",
            '                 SubCat = "Road Bikes",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q1",
            '                 Sales = "3584254.7760"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Accessories",
            '                 SubCat = "Locks",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q1",
            '                 Sales = "2205.0000"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Clothing",
            '                 SubCat = "Bib-Shorts",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q3",
            '                 Sales = "350.9610"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Bikes",
            '                 SubCat = "Mountain Bikes",
            '                 OrderYear = "2002",
            '                 OrderQtr = "Q4",
            '                 Sales = "2837646.7493"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Components",
            '                 SubCat = "Wheels",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q1",
            '                 Sales = "63185.8290"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Bikes",
            '                 SubCat = "Mountain Bikes",
            '                 OrderYear = "2002",
            '                 OrderQtr = "Q2",
            '                 Sales = "2416836.6144"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Accessories",
            '                 SubCat = "Helmets",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q2",
            '                 Sales = "25524.1452"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Bikes",
            '                 SubCat = "Mountain Bikes",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q4",
            '                 Sales = "3808655.5025"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Accessories",
            '                 SubCat = "Bike Stands",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q4",
            '                 Sales = "11925.0000"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Clothing",
            '                 SubCat = "Bib-Shorts",
            '                 OrderYear = "2002",
            '                 OrderQtr = "Q3",
            '                 Sales = "66859.8703"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Accessories",
            '                 SubCat = "Pumps",
            '                 OrderYear = "2002",
            '                 OrderQtr = "Q3",
            '                 Sales = "5157.0202"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Clothing",
            '                 SubCat = "Tights",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q1",
            '                 Sales = "27588.0711"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Accessories",
            '                 SubCat = "Helmets",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q3",
            '                 Sales = "81538.2467"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);
            '             AdventureWork = new AdventureWorks()
            '             {
            '                 ProdCat = "Accessories",
            '                 SubCat = "Fenders",
            '                 OrderYear = "2003",
            '                 OrderQtr = "Q3",
            '                 Sales = "7649.0400"
            '             };
            '             AdventureWorksCollection.Add(AdventureWork);

            Return AdventureWorksCollection
        End Function
    End Class

End Namespace
