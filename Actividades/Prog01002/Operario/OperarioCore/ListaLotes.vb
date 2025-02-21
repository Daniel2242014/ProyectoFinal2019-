﻿Imports Controladores
Imports System.Windows.Forms
Public Class ListaLotes
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Cargar()


        lote.Columns.Item(0).HeaderText = Funciones_comunes.I18N("ID Lote", Marco.Language)
        lote.Columns.Item(1).HeaderText = Funciones_comunes.I18N("Nombre del lote", Marco.Language)

    End Sub

    Private Sub Cargar()
        Select Case Fachada.getInstancia.DevolverUsuarioActual.Rol
            Case Usuario.TIPO_ROL_ADMINISTRADOR
                Me.LugarCBox.Items.Clear()
                Me.LugarCBox.Items.AddRange(Fachada.getInstancia.LugaresObjetos)
            Case Usuario.TIPO_ROL_OPERARIO
                Me.LugarCBox.Items.Clear()
                Me.LugarCBox.Items.Add(Fachada.getInstancia.TrabajaEnAcutual.Lugar)
            Case Else
                Throw New InvalidStateException(Of Marco)("Solo administradores y operarios pueden acceder a la lista de lotes", Marco.getInstancia)
        End Select
        Me.LugarCBox.Enabled = (Fachada.getInstancia.DevolverUsuarioActual.Rol = Usuario.TIPO_ROL_ADMINISTRADOR)
        LugarCBox.SelectedIndex = 0
    End Sub


    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles lote.CellClick
        'LLAMA AL PANEL DE INFORMACION
        If e.RowIndex < 0 Then
            Return
        End If
        Marco.getInstancia.CargarPanel(New PanelInfoLote(CType(lote.Rows(e.RowIndex).Cells(1).Value, String)))
    End Sub

    Private Sub LugarCBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LugarCBox.SelectedIndexChanged
        Dim r = Fachada.getInstancia.LotesEnLugar(LugarCBox.SelectedItem)
        lote.Rows.Clear()
        For Each t In r.Item1
            lote.Rows.Add(t.Item1.IDLote, t.Item1.Nombre, t.Item1.Estado, t.Item2, t.Item1.Destino.Nombre, t.Item3)
        Next
        For i = 0 To r.Item2.Count - 1
            lote.Columns(i).HeaderText = r.Item2(i)
        Next
    End Sub

End Class