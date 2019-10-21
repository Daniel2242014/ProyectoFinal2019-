﻿Imports Controladores
Imports Controladores.Extenciones
Public Class Home
    Public Sub New() 'me tiene que pasar un objeto de tipo usuario


        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        For Each p In Me.Controls.OfType(Of Panel)
            For Each l In p.Controls.Cast(Of Control)
                l.Traducir
            Next
        Next
        For Each l In Me.Controls.Cast(Of Control)
            l.Traducir
        Next
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Fachada.getInstancia.CargarDataBaseDelUsuario()
        Dim data As Usuario = Fachada.getInstancia.DevolverUsuarioActual
        NombreCompleto.Text = data.Nombre + " " + data.Apellido
        nombreUsuario.Text = data.NombreDeUsuario
        rolUsuario.Text = data.Rol
        If Fachada.getInstancia.TrabajaEnAcutual IsNot Nothing Then
            Dim numA As Integer = Fachada.getInstancia.TrabajaEnAcutual.Conexiones.Count
            nAccesos.Text = numA
            If numA = 0 Then
                anteriorIngreso.Text = "Nunca"
            Else
                anteriorIngreso.Text = Funciones_comunes.DarFormato(Fachada.getInstancia.TrabajaEnAcutual.ultimaConexcion.Item1)
            End If
        End If
        'autosAlteados.Text = Fachada.getInstancia.NumeroDeVehiculosAgregadosPorElUsuarioActual
        ' lotesCreados.Text = Fachada.getInstancia.NumeroDeLotesCreadorPorElUsuarioActual
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        MsgBox("¡Sin implementar!")
    End Sub

    Private Sub Home_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        Panel1.Width = (Me.Width - 90) / 2
        Panel1.Location = New Point(30, 100)
        Panel2.Width = (Me.Width - 90) / 2
        Panel2.Location = New Point((Me.Width / 2) + 15, 100)
    End Sub
End Class