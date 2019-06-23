﻿Public Class trasladoInterno
    Private Sub l_posDis_Click(sender As Object, e As EventArgs) Handles l_posDis.Click

    End Sub

    Private lugar As String = Nothing

    Private vin As String

    Public Sub New(VIN As String)
        Me.vin = VIN
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        DeZona.Text = VRepo.Zona(VIN)
        deSubzona.Text = VRepo.Subzona(VIN)
        dePosicion.Text = VRepo.Posicion(VIN)

        lugar = VRepo.Lugar(VIN)

        haciaZona.Items.Clear()
        haciaZona.Items.AddRange(LRepo.ZonasEnLugar(lugar).ToArray)
    End Sub

    Private Sub haciaZona_SelectedIndexChanged(sender As Object, e As EventArgs) Handles haciaZona.SelectedIndexChanged
        haciaSubzona.Items.Clear()
        If haciaZona.SelectedIndex < 0 Then Return
        haciaSubzona.Items.AddRange(LRepo.SubzonasEnLugar(haciaZona.SelectedItem, lugar).ToArray)
    End Sub

    Private Sub haciaSubzona_SelectedIndexChanged(sender As Object, e As EventArgs) Handles haciaSubzona.SelectedIndexChanged
        haciaPosicion.Items.Clear()
        If haciaSubzona.SelectedIndex < 0 Then Return
        haciaPosicion.Items.Clear()
        For i = 0 To LRepo.CapacidadSubzona(haciaSubzona.SelectedItem, haciaZona.SelectedItem, URepo.ConectadoEn)
            haciaPosicion.Items.Add(i)
        Next
    End Sub

    Private Sub ingresar_Click(sender As Object, e As EventArgs)
        If VRepo.Posicion(Me.vin, haciaZona.SelectedItem, haciaSubzona.SelectedItem, Me.lugar, Me.haciaPosicion.SelectedItem) Then
            Me.Close()
        Else
            MsgBox("No se pudo ingresar el vehículo. Intente nuevamente o reporte a su administrador")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
End Class