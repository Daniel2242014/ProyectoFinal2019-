﻿Imports System.Windows.Forms
Imports Controladores

Public Class PanelTrasporteEnAccion
    Dim listaDeSUBLote As List(Of ContenedorLote)
    Dim elementosSelecionados As List(Of Integer)
    Dim transporte As Controladores.Trasporte

    Public Sub New(listaLotes As List(Of Controladores.Lote), medio As Controladores.MedioDeTransporte)
        InitializeComponent()
        Marco.getInstancia.Bloquear()
        listaDeSUBLote = New List(Of ContenedorLote)

        elementosSelecionados = New List(Of Integer)
        transporte = New Controladores.Trasporte() With {.Trasportista = Controladores.Fachada.getInstancia.DevolverUsuarioActual,
                                                         .FechaCreacion = DateTime.Now,
                                                         .MedioDeTrasporte = medio,
                                                         .Lotes = listaLotes}
        Marco.getInstancia.cerrarPanel(Of PanelTrasporteEnAccion)()
        CargarPanales()
        crearTransporte()
        Timer2.Start()
    End Sub

    Private Sub crearTransporte()
        transporte.ID = Controladores.Fachada.getInstancia.NuevoTransporteConSusLotes(transporte)
    End Sub

    Private Sub CargarPanales()

        Dim destinos As New List(Of Tuple(Of Controladores.Lugar, List(Of Controladores.Lote)))
        For Each l As Controladores.Lote In transporte.Lotes
            If Not destinos.Select(Function(x) x.Item1.Nombre).ToList.Contains(l.Destino.Nombre) Then
                destinos.Add(New Tuple(Of Controladores.Lugar, List(Of Controladores.Lote))(l.Destino, New List(Of Controladores.Lote)))
            End If
            destinos.Where(Function(x) x.Item1.Nombre.Equals(l.Destino.Nombre)).Single.Item2.Add(l)
        Next

        For Each d As Tuple(Of Controladores.Lugar, List(Of Controladores.Lote)) In destinos
            listaDeSUBLote.Add(New ContenedorLote() With {.Lotes = d.Item2})
            ListaDestinos.Items.Add(d.Item1.Nombre)
        Next



    End Sub

    Private Sub ListaDestinos_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles ListaDestinos.ItemCheck
        If verificarcancelacion() Then
            Return
        End If

        If e.CurrentValue = CheckState.Checked Then
            e.NewValue = CheckState.Checked
            MsgBox("Los lotes de dicho destino ya fueron entregados", MsgBoxStyle.Critical)
            Return
        End If

        If e.CurrentValue = CheckState.Unchecked Then
            If MsgBox("¿Esta seguro que desea confirmar la entrega del lote?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                e.NewValue = CheckState.Checked
                listaDeSUBLote(e.Index).Selecionado = True
                For Each l As Controladores.Lote In listaDeSUBLote(e.Index).Lotes
                    Controladores.Fachada.getInstancia().cambiarEstadoDelTransporta(l, transporte, "Exitoso")
                Next

                If Not listaDeSUBLote.Select(Function(x) x.Selecionado).ToList.Contains(False) Then
                    tiempo1.Stop()
                    Marco.getInstancia.Desbloquear()
                    MsgBox("Todos los lotes han sido entregados, entonces el transporte se da por finalizado")
                    Dim noti As New Notificacion(Notificacion.TIPO_NOTIFICACION_NUEVA_ENTREGA) With {.Ref1 = transporte.ID, .Ref2 = Controladores.Fachada.getInstancia.DevolverUsuarioActual.ID_usuario}
                    Controladores.Fachada.getInstancia.NuevaNotificacion(noti)
                    Marco.getInstancia.CargarPanel(Of Lista_de_trasportes)(New Lista_de_trasportes)
                    Me.Close()
                    Me.Dispose()
                End If

            Else
                e.NewValue = CheckState.Unchecked
            End If
        End If


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click 'DevolverPosicionActual
        If verificarcancelacion() Then
            Return
        End If

        Controladores.Fachada.getInstancia.comenzarTransporte(transporte)
        For Each su As ContenedorLote In listaDeSUBLote
            For Each l As Controladores.Lote In su.Lotes
                For Each v As Controladores.Vehiculo In l.Vehiculos
                    Controladores.Fachada.getInstancia.AnularAnteriorPosicion(v.IdVehiculo)
                Next
            Next
        Next
        transporte.FechaSalida = DateTime.Now
        ListaDestinos.Enabled = True
        Button3.Enabled = False
        emergencia.Visible = True
        inicio.Text = DateTime.Now.ToString("HH:mm:ss")
        tiempo1.Start()
    End Sub

    Private Sub Cancelar_Click(sender As Object, e As EventArgs) Handles cancelar.Click
        'CAMBIAR EL TEXTO A TERMINADO

        If verificarcancelacion() Then
            Return
        End If

        If MsgBox("¿Esta seguro que desea cancelar el transporte?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            For Each l As ContenedorLote In listaDeSUBLote
                If Not l.Selecionado Then
                    For Each lote As Controladores.Lote In l.Lotes
                        Controladores.Fachada.getInstancia().cambiarEstadoDelTransporta(lote, transporte, "Cancelado")
                        Controladores.Fachada.getInstancia.cambiarBajarProridadLote(lote.IDLote)
                        If Not inicio.Text.Equals("INDETERMINADO") Then
                            For Each v As Controladores.Vehiculo In lote.Vehiculos
                                Dim jau = Controladores.Fachada.getInstancia.DevolverPosicionActual(v.IdVehiculo)
                                jau.Vehiculo = v
                                Controladores.Fachada.getInstancia.AsignarNuevaPosicion(jau, False)
                            Next
                        End If
                    Next
                End If
            Next
        End If
        Marco.getInstancia.CargarPanel(Of Lista_de_trasportes)(New Lista_de_trasportes)
        Marco.getInstancia.Desbloquear()

    End Sub

    Private Sub Tiempo1_Tick(sender As Object, e As EventArgs) Handles tiempo1.Tick
        tiempo.Text = (DateTime.Now - transporte.FechaSalida).ToString("dd\.hh\:mm\:ss")
    End Sub

    Private Sub emergencia_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles emergencia.LinkClicked
        If verificarcancelacion() Then
            Return
        End If

        If MsgBox("¿Esta seguro que desea reportar un fallo que imposibilite?, Si ingresa que si estos lotes seran publicados para demas transportitas. NO PODRA CANCELAR", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            If Fachada.getInstancia.FalloTransporte(transporte) Then
                Dim lotes As New List(Of Lote)
                For Each l As ContenedorLote In listaDeSUBLote
                    If Not l.Selecionado Then
                        For Each lote As Controladores.Lote In l.Lotes
                            lotes.Add(lote)
                        Next
                    End If
                Next
                Dim noti As New Notificacion(Notificacion.TIPO_NOTIFICACION_TRANSPORTE_FALLIDO) With {.Ref2 = transporte.ID, .Ref1 = Controladores.Fachada.getInstancia.DevolverUsuarioActual.ID_usuario}
                Controladores.Fachada.getInstancia.NuevaNotificacion(noti)
                Dim d As New PanelDeFalloEstatus(lotes, transporte)
                d.ShowDialog()


                cancelar.Enabled = False
                emergencia.Enabled = False
                Button3.Enabled = False
                ListaDestinos.Enabled = False
            End If
        End If

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        verificarcancelacion()
    End Sub

    Private Function verificarcancelacion()
        If Controladores.Fachada.getInstancia.comprobarCancelacionTransporte(transporte.ID) Then
            Timer2.Stop()
            tiempo1.Stop()
            MsgBox("Su transporte ha sido cancelado por un administrador", MsgBoxStyle.Critical)
            Marco.getInstancia.CargarPanel(Of Lista_de_trasportes)(New Lista_de_trasportes)
            Marco.getInstancia.Desbloquear()
            Marco.getInstancia.cerrarPanel(Of PanelTrasporteEnAccion)()
            Return True
        End If
        Return False
    End Function

End Class

Public Class ContenedorLote
    Private _selecionado As Boolean
    Public Property Selecionado() As Boolean
        Get
            Return _selecionado
        End Get
        Set(ByVal value As Boolean)
            _selecionado = value
        End Set
    End Property

    Private _lotes As List(Of Controladores.Lote)
    Public Property Lotes() As List(Of Controladores.Lote)
        Get
            Return _lotes
        End Get
        Set(ByVal value As List(Of Controladores.Lote))
            _lotes = value
        End Set
    End Property

    Public Sub New()
        _selecionado = False
    End Sub

End Class