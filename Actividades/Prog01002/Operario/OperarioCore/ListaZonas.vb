﻿Imports Controladores
Imports Controladores.Extenciones
Imports System.Windows.Forms

Public Class ListaZonas
    Private lugar As Lugar

    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Label3.Traducir
        Label4.Traducir
        Label5.Traducir
        Label1.Traducir
        Label6.Traducir
        Label7.Traducir
        Label8.Traducir
        Label9.Traducir
        Label10.Traducir
        Label11.Traducir

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        cargarZonas(Fachada.getInstancia.TrabajaEnAcutual.Lugar)
    End Sub

    Public Sub New(idlugar As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.lugar = Fachada.getInstancia.LugarZonasySubzonas(idlugar)
        cargarZonas(lugar)
        Label3.Traducir
        Label4.Traducir
        Label5.Traducir
        Label1.Traducir
        Label6.Traducir
        Label7.Traducir
        Label8.Traducir
        Label9.Traducir
        Label10.Traducir
        Label11.Traducir
    End Sub

    Private Sub cargarZonas(lugar As Lugar)
        Dim zonaslist = Fachada.getInstancia.LugarZonasySubzonas(-1, lugar).Zonas
        zonas.Items.Clear()
        zonas.Items.AddRange(zonaslist.ToArray)
    End Sub

    Private subzonaslist As List(Of Subzona)

    Private Sub CargarSubzonas(zona As Zona)
        subzonas.Items.Clear()
        subzonaslist = zona.Subzonas
        subzonas.Items.AddRange(subzonaslist.ToArray)
    End Sub

    Private Sub zonas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles zonas.SelectedIndexChanged
        CargarSubzonas(zonas.SelectedItem)
        subzonas.SelectedIndex = 0
        zonaNombre.Text = zonas.SelectedItem.ToString
        zonaCapasidad.Text = CType(zonas.SelectedItem, Zona).Capacidad
        Try
            zonaUso.Text = Persistencia.getInstancia.PosicionesOcupadasEnLugar(CType(zonas.SelectedItem, Zona).IDZona)
        Catch ex As Exception
            zonaUso.Text = "0"
        End Try

    End Sub

    Private Sub subzonas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles subzonas.SelectedIndexChanged
        subnombre.Text = subzonas.SelectedItem.ToString
        subcapasidad.Text = CType(subzonas.SelectedItem, Subzona).Capasidad
        Try
            subUso.Text = Persistencia.getInstancia.PosicionesOcupadasEnLugar(CType(subzonas.SelectedItem, Subzona).IDSubzona)
        Catch ex As Exception
            subUso.Text = "0"
        End Try
        cargarTablaVehiculos(subzonas.SelectedItem)
    End Sub

    Private Sub cargarTablaVehiculos(subzona As Subzona)

        Dim r As DataTable = Persistencia.getInstancia.DatosBasicosParaListarVehiculosPorSubzona(subzona.IDSubzona)

        vehi.DataSource = r
    End Sub

    Private Sub vehi_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles vehi.CellClick
        If e.RowIndex >= 0 Then
            Dim vin = vehi.Rows(e.RowIndex).Cells(1).Value
            Marco.getInstancia.CargarPanel(New panelInfoVehiculo(vin))
        End If
    End Sub

End Class