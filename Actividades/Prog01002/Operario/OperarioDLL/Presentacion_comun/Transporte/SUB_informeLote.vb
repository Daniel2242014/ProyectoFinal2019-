﻿Imports GMap.NET

Public Class SUB_informeLote
    Private _lote As Controladores.Lote
    Public Property Lote() As Controladores.Lote
        Get
            Return _lote
        End Get
        Set(ByVal value As Controladores.Lote)
            _lote = value
        End Set
    End Property
    Public Sub New(lote As Controladores.Lote)
        InitializeComponent()
        Me.Lote = lote
        nombre.Text = lote.Nombre
        origen.Text = lote.Origen.Nombre
        destino.Text = lote.Destino.Nombre
        numeroDeVehiculos.Text = lote.Vehiculos.Count

    End Sub

    Private _selecionado As Boolean
    Public ReadOnly Property Selecionado() As Boolean
        Get
            Return selecionar.Checked
        End Get
    End Property

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Marco.getInstancia.cargarPanel(Of PanelInfoLote)(New PanelInfoLote(Lote.Nombre))
    End Sub

    Private Sub destino_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles destino.LinkClicked
        Dim m As New Controladores.MapaPanelGrande(New PointLatLng(Lote.Destino.PosicionX, Lote.Destino.PosicionY))
        m.ShowDialog()
    End Sub

    Private Sub origen_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles origen.LinkClicked
        Dim m As New Controladores.MapaPanelGrande(New PointLatLng(Lote.Origen.PosicionX, Lote.Origen.PosicionY))
        m.ShowDialog()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim m As New Controladores.MapaPanelGrande(False, New PointLatLng(Lote.Origen.PosicionX, Lote.Origen.PosicionY), New PointLatLng(Lote.Destino.PosicionX, Lote.Destino.PosicionY))
        m.ShowDialog()
    End Sub
End Class