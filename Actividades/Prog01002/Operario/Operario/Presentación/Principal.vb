﻿Public Class Principal
    Private Shared initi As Principal

    Private Sub New()

        ' Esta llamada es exigida por el diseñador.
        Constantes.LRepo = New FLugarRepo
        Constantes.URepo = New FUsuarioRepo
        Constantes.VRepo = New FVehiculoRepo
        InitializeComponent()
        StartPosition = FormStartPosition.CenterScreen
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        cargarPanel(Of Login)(New Login)
    End Sub

    Public Shared Function getInstancia() As Principal
        If initi Is Nothing Then
            initi = New Principal
        End If
        Return initi
    End Function

    Public Function cerrarPanel(Of T As Form)() As Boolean
        contenedorDePaneles.Controls.OfType(Of T).ForEach(Sub(x)
                                                              x.Close()
                                                              contenedorDePaneles.Controls.Remove(x)
                                                          End Sub)
    End Function

    Public Function cargarPanel(Of T As Form)(obj As T) As T

        Dim f As Form = contenedorDePaneles.Controls.OfType(Of T).FirstOrDefault 'Nos devuelve el panel si ya estaba dentro del control del panel

        If f Is Nothing Then 'si no existe ningun panel de este tipo ingresado, nos devuelve nada, en cuyo caso se crea uno nuevo 

            obj.TopLevel = False
            obj.FormBorderStyle = FormBorderStyle.None
            obj.Dock = DockStyle.Fill
            contenedorDePaneles.Controls.Add(obj)
            contenedorDePaneles.Tag = obj
            obj.Show()
            obj.BringToFront()
            Return obj
        Else
            f.BringToFront()
            Return f
        End If

    End Function

    Private Sub Principal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
    End Sub

    Private Sub contenedorDePaneles_Paint(sender As Object, e As PaintEventArgs) Handles contenedorDePaneles.Paint

    End Sub
End Class
