﻿Imports System.Windows.Forms
Imports Controladores
Imports Controladores.Extenciones.Extensiones

Public Class ListaDeMediosAutorizados
    Dim dataTabla As New DataTable
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        If Fachada.getInstancia.DevolverUsuarioActual.Rol <> Usuario.TIPO_ROL_ADMINISTRADOR Then
            Button1.Visible = False
        End If
        Dim alfa As New Alfa(GetType(Controladores.MedioDeTransporte), GetType(Controladores.SUB_Medio), Sub(x) Controladores.Marco.getInstancia.CargarPanel(Of PanelMedioDeTrasporte)(New PanelMedioDeTrasporte(DirectCast(x, MedioDeTransporte).ID)))
        Me.Controls.Add(alfa)
        alfa.Size = New Drawing.Size(855, 565)
        alfa.Location = New Drawing.Point(13, 75)
        alfa.Anchor = (AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right)
        If Fachada.getInstancia.DevolverUsuarioActual.Rol = Usuario.TIPO_ROL_TRANSPORTISTA Then
            dataTabla = Controladores.Fachada.getInstancia.TablaDeMediosPorIDUsuario(Controladores.Fachada.getInstancia.DevolverUsuarioActual.ID_usuario)
        ElseIf Fachada.getInstancia.DevolverUsuarioActual.Rol = Usuario.TIPO_ROL_ADMINISTRADOR Then
            dataTabla = Fachada.getInstancia.TablaDeMedios()
        End If
        For Each r As DataRow In dataTabla.Rows
            Dim m As New Controladores.MedioDeTransporte() With {.ID = r.Item(0), .Nombre = r.Item(1), .Tipo = New Controladores.TipoMedioTransporte(r.Item(2))}
            alfa.Nuevo(m, False, True)
        Next
        alfa.render()
        Label2.Traducir
        Button1.Text = Controladores.Funciones_comunes.I18N("Nuevo medio", Controladores.Marco.getInstancia.Language)
    End Sub

    Private Sub Medios_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        Marco.getInstancia.CargarPanel(Of PanelMedioDeTrasporte)(New PanelMedioDeTrasporte(dataTabla.Rows(e.RowIndex).Item(0)))
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Marco.getInstancia.CargarPanel(Of NuevoMedio)(New NuevoMedio)
        Button1.Text = Controladores.Funciones_comunes.I18N("Nuevo medio", Controladores.Marco.getInstancia.Language)
    End Sub
End Class