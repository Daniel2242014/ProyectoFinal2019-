﻿Imports System.Windows.Forms
Imports Controladores

Public Class ListaDeTrasportes
    Dim lista As DataTable
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        If Controladores.Fachada.getInstancia.DevolverUsuarioActual.Rol = Controladores.Usuario.TIPO_ROL_TRANSPORTISTA Then
            lista = Controladores.Fachada.getInstancia.ListaDeTrasportesPorIdUsuario(Controladores.Fachada.getInstancia.DevolverUsuarioActual.ID_usuario)
        ElseIf Controladores.Fachada.getInstancia.DevolverUsuarioActual.Rol = Controladores.Usuario.TIPO_ROL_ADMINISTRADOR Then
            lista = Controladores.Fachada.getInstancia.ListaDeTrasportesDelSistema()
        End If

        trasportes.DataSource = lista
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Trasportes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles trasportes.CellClick
        Marco.getInstancia.CargarPanel(Of PanelTrasporte)(New PanelTrasporte(lista.Rows(e.RowIndex).Item(0)))
    End Sub
End Class