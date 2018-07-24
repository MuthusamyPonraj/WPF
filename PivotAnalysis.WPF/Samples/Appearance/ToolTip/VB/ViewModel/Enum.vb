Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System
Imports System.Reflection
Namespace ToolTipDemo.ViewModel

    ''' <summary>
    ''' Common Enum Class
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    Public Class [Enum](Of T)
        ''' <summary>
        ''' Gets the names.
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function GetNames() As IEnumerable(Of String)
            Dim type = GetType(T)
            If Not type.IsEnum Then
                Throw New ArgumentException("Type '" & type.Name & "' is not an enum")
            End If
            Return (From field In type.GetFields(System.Reflection.BindingFlags.Public Or System.Reflection.BindingFlags.Static) Where field.IsLiteral Select field.Name).ToList()
        End Function
    End Class

End Namespace

