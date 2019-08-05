﻿Imports Operario.Logica

Public Class NuevoLote
    Private padre As nuevoVehiculo
    Private destinosPosibles As List(Of Controladores.Lugar)
    Public Sub New(padre As nuevoVehiculo)
        Me.padre = padre
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        StartPosition = FormStartPosition.CenterScreen
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        destino.Items.Clear()
        destinosPosibles = Controladores.Fachada.getInstancia.devolverPosiblesDestinos(Controladores.Fachada.getInstancia.TrabajaEnAcutual.Lugar, padre.Vehiculo)
        For Each l As Controladores.Lugar In destinosPosibles
            destino.Items.Add($"{l.Nombre}/{l.Tipo}")
        Next
        destino.SelectedIndex = 0
    End Sub

    Public Sub New(padre As nuevoVehiculo, oldlote As Controladores.Lote)
        Me.padre = padre
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        StartPosition = FormStartPosition.CenterScreen
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        destino.Items.Clear()
        destinosPosibles = Controladores.Fachada.getInstancia.devolverPosiblesDestinos(Controladores.Fachada.getInstancia.TrabajaEnAcutual.Lugar, padre.Vehiculo)
        Dim c As Integer = 0
        For Each l As Controladores.Lugar In destinosPosibles
            destino.Items.Add($"{l.Nombre}/{l.Tipo}")
            If l.IDLugar = oldlote.Destino.IDLugar Then
                destino.SelectedIndex = c
            End If
            c += 1
        Next
        nom.Text = oldlote.Destino.Nombre
    End Sub

    Private Sub ingresar_Click(sender As Object, e As EventArgs)
        Dim verif As Integer = 1

        If nom.Text.Length = 0 Then
            verif = 0
            l_nom.ForeColor = Color.FromArgb(180, 20, 20)
        Else
            l_nom.ForeColor = Color.FromArgb(35, 35, 35)
        End If

        If nom.Text.Length > 0 Then
            If nom.Text.Chars(0).Equals(" ") Then
                verif = 0
                l_nom.ForeColor = Color.FromArgb(180, 20, 20)
            End If
            l_nom.ForeColor = Color.FromArgb(35, 35, 35)
        End If



        If verif = 1 Then
            Dim lo As New Controladores.Lote With {.Nombre = nom.Text.Trim,
                                                    .Destino = destinosPosibles(destino.SelectedIndex),
                                                    .Estado = Controladores.Lote.TIPO_ESTADO_ABIERTO,
                                                    .Prioridad = Controladores.Lote.TIPO_PRIORIDAD_NORMAL,
                                                    .Origen = Controladores.Fachada.getInstancia.TrabajaEnAcutual.Lugar,
                                                    .Creador = Controladores.Fachada.getInstancia.DevolverUsuarioActual}
            padre.NotificarDeLote(lo)
            Me.Dispose()
        Else
            MsgBox("Error en la informacion ingresada", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub


End Class