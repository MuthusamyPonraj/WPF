﻿#ExternalChecksum("..\..\Window1.xaml","{ff1816ec-aa5e-4d10-87f7-6f4963833460}","903C2AD3661342E85A6392896DE11A1AAF10FACF")
'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.Diagnostics
Imports System.Windows
Imports System.Windows.Automation
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Windows.Markup
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Media.Effects
Imports System.Windows.Media.Imaging
Imports System.Windows.Media.Media3D
Imports System.Windows.Media.TextFormatting
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Shell

Namespace SideBySideReport
    
    '''<summary>
    '''Window1
    '''</summary>
    <Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>  _
    Partial Public Class Window1
        Inherits System.Windows.Window
        Implements System.Windows.Markup.IComponentConnector
        
        
        #ExternalSource("..\..\Window1.xaml",11)
        <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
        Friend WithEvents image1 As System.Windows.Controls.Image
        
        #End ExternalSource
        
        
        #ExternalSource("..\..\Window1.xaml",31)
        <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
        Friend WithEvents image2 As System.Windows.Controls.Image
        
        #End ExternalSource
        
        
        #ExternalSource("..\..\Window1.xaml",35)
        <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
        Friend WithEvents excel As System.Windows.Controls.RadioButton
        
        #End ExternalSource
        
        
        #ExternalSource("..\..\Window1.xaml",36)
        <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
        Friend WithEvents word As System.Windows.Controls.RadioButton
        
        #End ExternalSource
        
        
        #ExternalSource("..\..\Window1.xaml",37)
        <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
        Friend WithEvents pdf As System.Windows.Controls.RadioButton
        
        #End ExternalSource
        
        Private _contentLoaded As Boolean
        
        '''<summary>
        '''InitializeComponent
        '''</summary>
        <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")>  _
        Public Sub InitializeComponent() Implements System.Windows.Markup.IComponentConnector.InitializeComponent
            If _contentLoaded Then
                Return
            End If
            _contentLoaded = true
            Dim resourceLocater As System.Uri = New System.Uri("/SideBySideReport;component/window1.xaml", System.UriKind.Relative)
            
            #ExternalSource("..\..\Window1.xaml",1)
            System.Windows.Application.LoadComponent(Me, resourceLocater)
            
            #End ExternalSource
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0"),  _
         System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never),  _
         System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes"),  _
         System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity"),  _
         System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")>  _
        Sub System_Windows_Markup_IComponentConnector_Connect(ByVal connectionId As Integer, ByVal target As Object) Implements System.Windows.Markup.IComponentConnector.Connect
            If (connectionId = 1) Then
                Me.image1 = CType(target,System.Windows.Controls.Image)
                Return
            End If
            If (connectionId = 2) Then
                
                #ExternalSource("..\..\Window1.xaml",23)
                AddHandler CType(target,System.Windows.Controls.Button).Click, New System.Windows.RoutedEventHandler(AddressOf Me.Button_Click)
                
                #End ExternalSource
                Return
            End If
            If (connectionId = 3) Then
                Me.image2 = CType(target,System.Windows.Controls.Image)
                Return
            End If
            If (connectionId = 4) Then
                Me.excel = CType(target,System.Windows.Controls.RadioButton)
                Return
            End If
            If (connectionId = 5) Then
                Me.word = CType(target,System.Windows.Controls.RadioButton)
                Return
            End If
            If (connectionId = 6) Then
                Me.pdf = CType(target,System.Windows.Controls.RadioButton)
                Return
            End If
            Me._contentLoaded = true
        End Sub
    End Class
End Namespace

