﻿Imports System.Threading
Imports Controladores
Imports Controladores.Extenciones


Public Class Principal
    Private Shared initi As Principal

    Public Sub New(tipo As Integer)


        InitializeComponent()

        StartPosition = FormStartPosition.CenterScreen
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Select Case tipo
            Case 1

            Case 2

            Case 3

        End Select
        cargarPanel(Of Login)(New Login)
        initi = Me
    End Sub

    Public Shared Function CrearInstancia(tipo As Integer) As Principal
        initi = New Principal(tipo)
    End Function

    Public Shared Function getInstancia() As Principal
        If initi Is Nothing Then
            Throw New ArgumentException("En este Singleton la instancia se crea con el metodo CrearInstancia")
        End If
        Return initi
    End Function

    'Public Function cerrarPanel(Of T As Form)() As Boolean
    '    contenedorDePaneles.Controls.OfType(Of T).ForEach(Sub(x As Form)
    '                                                          x.Close()
    '                                                          contenedorDePaneles.Controls.Remove(x)
    '                                                      End Sub)
    '    Return True
    'End Function

    Public Function cargarPanel(Of T As Form)(obj As T) As T

        contenedorDePaneles.Controls.Clear()
        'Dim f As Form = contenedorDePaneles.Controls.OfType(Of T).FirstOrDefault 'Nos devuelve el panel si ya estaba dentro del control del panel

        'If f Is Nothing Then 'si no existe ningun panel de este tipo ingresado, nos devuelve nada, en cuyo caso se crea uno nuevo 

        obj.TopLevel = False
            obj.FormBorderStyle = FormBorderStyle.None
            obj.Dock = DockStyle.Fill
            contenedorDePaneles.Controls.Add(obj)
            contenedorDePaneles.Tag = obj
            obj.Show()
            obj.BringToFront()
            Return obj
        'Else
        '    f.Show()
        '    f.BringToFront()
        '    Return f
        'End If

    End Function

    Private Sub Principal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If Fachada.getInstancia.SeccionExsistente() Then
            Fachada.getInstancia.CerrarSeccion()
        End If

    End Sub
End Class
