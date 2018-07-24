Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows.Interactivity
Imports Syncfusion.Windows.Controls.PivotGrid
Imports System.Windows
Imports System.Windows.Controls
Imports Syncfusion.PivotAnalysis.Base

Namespace FilteringDemo.Action
    Friend Class FilteringOptions
        Inherits TargetedTriggerAction(Of PivotGridControl)
        Protected Overrides Sub Invoke(ByVal parameter As Object)
            If TypeOf parameter Is RoutedEventArgs Then
                Dim eventArgs As RoutedEventArgs = TryCast(parameter, RoutedEventArgs)

                Dim current As Button = TryCast(eventArgs.OriginalSource, Button)
                Select Case current.Name.ToString()
                    Case "button1"
                        If current.IsEnabled = True Then
                            Me.Target.Filters.Add(New FilterExpression("Product"))
                        End If

                    Case "button2"
                        If current.IsEnabled = True Then

                            Me.Target.Filters.Remove(Me.Target.Filters.Where(Function(i) i.DimensionName = "Product").FirstOrDefault())
							Me.Target.Filters.Remove(Me.Target.Filters.Where(Function(i) i.Name = "Product").FirstOrDefault())
                        End If
                    Case "button3"
                        If current.IsEnabled = True Then
                            Me.Target.Filters.Insert(0, New FilterExpression("State"))
                        End If
                    Case "button4"
                        If current.IsEnabled = True Then
                            If Me.Target.Filters.Count >= 1 Then
                                Me.Target.Filters.RemoveAt(0)
                            Else
                                MessageBox.Show("Please add the item before remove")
                            End If
                        End If

                    Case "button5"
                        If current.IsEnabled = True Then
                            Me.Target.Filters.Clear()
                        End If

                    Case Else
                End Select
            End If
            Me.Target.InvalidateCells()
        End Sub
    End Class
End Namespace