﻿Imports System.Drawing
Imports System.Windows.Forms
Imports Controladores
Imports GMap.NET
Imports GMap.NET.MapProviders

Public Class panelInfoVehiculo
    Implements NotificacionLote

    Private ListaInformes As New List(Of Controladores.InformeDeDaños)
    Private vin As String
    Private vehiculo As Controladores.Vehiculo
    Private informeActual As Integer = 0
    Private registroActual As Integer = 0
    Private actualImagen As Integer = 0
    Private loteTemp As Controladores.Lote
    Private todosLosLotesDisponibles As List(Of Controladores.Lote)
    Private loteActual As Controladores.Lote
    Private qrcode As Bitmap
    Private superpepe As Boolean
    Public Sub New(VIN As String, Optional editarLotes As Boolean = True)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        superpepe = False
        MarcaLbl.Text = Funciones_comunes.I18N("Marca", Marco.Language) + ":"
        ModeloLbl.Text = Funciones_comunes.I18N("Modelo", Marco.Language) + ":"
        ClienteLbl.Text = Funciones_comunes.I18N("Cliente", Marco.Language) + ":"
        YearLbl.Text = Funciones_comunes.I18N("Año", Marco.Language) + ":"
        TipoLbl.Text = Funciones_comunes.I18N("Tipo", Marco.Language) + ":"
        ZonaLbl.Text = Funciones_comunes.I18N("Zona", Marco.Language) + ":"
        Sublbl.Text = Funciones_comunes.I18N("Subzona", Marco.Language) + ":"
        LugarLbl.Text = Funciones_comunes.I18N("Lugar", Marco.Language) + ":"
        PosLbl.Text = Funciones_comunes.I18N("Posicion", Marco.Language) + ":"
        LoteLbl.Text = Funciones_comunes.I18N("Lote", Marco.Language) + ":"
        SaveButton.Text = Funciones_comunes.I18N("Guardar código", Marco.Language)
        vermasLote.Text = Funciones_comunes.I18N("Ver más", Marco.Language)
        cambiarGuardarLote.Text = Funciones_comunes.I18N("Cambiar lote", Marco.Language)
        nuevoLote.Text = Funciones_comunes.I18N("Nuevo lote", Marco.Language)
        EliminarLoteSelecion.Text = Funciones_comunes.I18N("Eliminar selección", Marco.Language)
        Cancelar.Text = Funciones_comunes.I18N("Cancelar", Marco.Language)


        'HAY QUE CARGAR EL LUGAR ACTUAL DEL VEHICULO
        LoteCombo.Enabled = False
        Me.vin = VIN
        TipoCombo.Items.Clear()
        TipoCombo.Items.AddRange(Controladores.Vehiculo.TIPOS_VEHICULOS)
        RegularTamañoColumnas()
        TomarValores()
        Dim ultPosVehiculo As DataRow = Fachada.getInstancia.UltimaPosicionVehiculo(vehiculo.VIN)
        If ultPosVehiculo IsNot Nothing Then
            Dim lugarPadreUltLugar As Lugar = Fachada.getInstancia.MaximoAncestro(ultPosVehiculo(0))
            Dim aqui = Fachada.getInstancia.DevolverUsuarioActual.Rol = Usuario.TIPO_ROL_ADMINISTRADOR OrElse (Fachada.getInstancia.TrabajaEnAcutual.Lugar.IDLugar = lugarPadreUltLugar.IDLugar)
            If Not aqui OrElse Persistencia.getInstancia.ExisteBaja(vehiculo.IdVehiculo) Then
                bajaButton.Visible = False
                Button2.Visible = False
                Button4.Visible = False
            ElseIf Not Fachada.getInstancia.TieneInformeEnLugar(vehiculo, lugarPadreUltLugar) Then
                bajaButton.Visible = False
            End If
        Else
            bajaButton.Visible = False
            Button2.Visible = False
            Button4.Visible = False
        End If

        'If Controladores.Fachada.getInstancia.ExistenciaDevehiculoPrecargado(vehiculo.VIN) OrElse Controladores.Fachada.getInstancia.conformarvehiculoentregado(vehiculo.IdVehiculo) Then
        '    vermasLote.Visible = False
        '    cambiarGuardarLote.Visible = False
        'ElseIf Controladores.Fachada.getInstancia.DevolverUsuarioActual.Rol.Equals(Usuario.TIPO_ROL_OPERARIO) AndAlso Not Controladores.Fachada.getInstancia.lugaridactualDelVehiculo(vehiculo.IdVehiculo).IDLugar.Equals(Fachada.getInstancia.TrabajaEnAcutual.Lugar.IDLugar) Then
        '    vermasLote.Visible = False
        '    cambiarGuardarLote.Visible = False
        'End If

        If Not editarLotes Then
            vermasLote.Visible = False
            cambiarGuardarLote.Visible = False
        End If

    End Sub

    Private Sub TomarValores()
        VINBox.Text = vin
        vehiculo = Controladores.Fachada.getInstancia.InfoVehiculos(vin).SingleOrDefault
        If vehiculo Is Nothing Then
            MsgBox("No se encontró el vehículo con VIN " + vin + ", reporte este error")
            Close()
        End If
        id.Text = vehiculo.IdVehiculo
        MarcaBox.Text = vehiculo.Marca
        ModeloBox.Text = vehiculo.Modelo
        ClienteBox.Text = vehiculo.Cliente.Nombre
        AñoBox.Text = vehiculo.Año
        TipoCombo.SelectedItem = vehiculo.Tipo
        Panel1.BackColor = vehiculo.Color
        Me.vehiculo = vehiculo
        CargarMiLote()
        CargarTraslados()
        CargarLugares()
        PosicionOEstado()
        ListaInformes = Controladores.Fachada.getInstancia.devolverTodosLosInformesYregistrosCompletos(vehiculo)
        Dim estadoultimo = Controladores.Fachada.getInstancia.UltimoEstadoTransportePorIdVehiculo(vehiculo.IdVehiculo)
        If estadoultimo IsNot Nothing AndAlso (estadoultimo.Equals(Controladores.Trasporte.TIPO_ESTADO_FALLO) OrElse estadoultimo.Equals(Controladores.Trasporte.TIPO_ESTADO_PROSESO)) Then
            datosEnTransporte()
        End If

        If ListaInformes.Count = 0 Then

            visualizarElementosRegistro(False, False)

        Else
            If ListaInformes.Count = 1 Then
                SinInformes.Enabled = False
            End If
            SinInformes.Visible = False
            CargarInformes()
        End If
        Dim qrGenerator As New QRCoder.QRCodeGenerator
        Dim qrData = qrGenerator.CreateQrCode(vin, QRCoder.QRCodeGenerator.ECCLevel.H)
        Dim qrCode As New QRCoder.QRCode(qrData)
        Me.qrcode = qrCode.GetGraphic(15)
        Me.QR.Image = New Bitmap(Me.qrcode, New Size(Me.QR.Width, Me.QR.Height))
    End Sub

    Private Sub PosicionOEstado()
        Dim ultpos = Controladores.Fachada.getInstancia.UltimaPosicionVehiculo(vin)
        If Persistencia.getInstancia.ExisteBaja(vehiculo.IdVehiculo) Then
            ZonaLabel.Text = "Fuera del sistema"
            SubzonaLabel.Visible = False
            PosicionLabel.Visible = False
            lugarLabel.Visible = False
            Sublbl.Visible = False
            PosLbl.Visible = False
            LugarLbl.Visible = False
            ZonaLbl.Visible = False
        ElseIf ultpos IsNot Nothing Then
            SubzonaLabel.Text = ultpos.Item(1)
            Dim zona = Controladores.Persistencia.getInstancia.PadreDeLugar(ultpos.Item(0))
            ZonaLabel.Text = zona.Item(0)
            PosicionLabel.Text = ultpos.Item(2) & " desde " & Funciones_comunes.DarFormato(CType(ultpos.Item(3), Date?))
            Dim lugar = Controladores.Persistencia.getInstancia.PadreDeLugar(zona.Item(1))
            lugarLabel.Text = lugar.Item(0)
        End If
    End Sub

    Public Sub CargarLotes()
        todosLosLotesDisponibles = Controladores.Fachada.getInstancia.LotesDisponiblesPorLugaryPorVin(Controladores.Fachada.getInstancia.lugaridactualDelVehiculo(vehiculo.IdVehiculo), vehiculo.VIN)
        LoteCombo.Items.Clear()
        For Each l As Controladores.Lote In todosLosLotesDisponibles
            LoteCombo.Items.Add($"ID: {l.IDLote} / NOM: {l.Nombre}")
        Next
        If todosLosLotesDisponibles.Count > 0 Then
            LoteCombo.SelectedIndex = 0
        End If

    End Sub

    Public Sub CargarMiLote()
        loteActual = Fachada.getInstancia.LoteVehiculo(vehiculo.VIN)
        LoteCombo.Items.Clear()
        If loteActual Is Nothing Then Return
        LoteCombo.Items.Add($"ID: {loteActual.IDLote} / NOM: {loteActual.Nombre}")
        LoteCombo.SelectedIndex = 0
    End Sub

    Private Sub CargarLugares()
        lugares.Columns.Clear()
        lugares.DataSource = Controladores.Fachada.getInstancia.lugaresDelVehiculo(vin)
        Dim datatable As DataTable = lugares.DataSource
        lugares.Columns.Cast(Of DataGridViewColumn).Last.HeaderText = "Transportado por"
        posicionEnMapa.MapProvider = GMapProviders.GoogleMap
        Dim mapOverlay As New WindowsForms.GMapOverlay("ubicaciones")
        Dim prevLugar As DataRow = Nothing
        For Each l As DataRow In datatable.Rows
            mapOverlay.Markers.Add(New WindowsForms.Markers.GMarkerGoogle(New PointLatLng(l(2), l(3)), WindowsForms.Markers.GMarkerGoogleType.red) With {
                .ToolTipText = l(0)
            })
            prevLugar = l
        Next
        If mapOverlay.Markers.Count > 0 Then
            mapOverlay.Routes.Add(New WindowsForms.GMapRoute(mapOverlay.Markers.Select(Function(x) x.Position), "transito"))
        End If
        posicionEnMapa.Overlays.Add(mapOverlay)
        posicionEnMapa.ZoomAndCenterMarkers("ubicaciones")
        posicionEnMapa.MinZoom = 5
        posicionEnMapa.MaxZoom = 20
    End Sub

    Private Sub CargarTraslados()
        Dim ultpos = Controladores.Fachada.getInstancia.UltimaPosicionVehiculo(vin)
        If ultpos Is Nothing Then
            Return
        End If
        Dim zona = Controladores.Persistencia.getInstancia.PadreDeLugar(ultpos.Item(0))
        traslados.Columns.Clear()
        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn("Lugar"))
        dt.Columns.Add(New DataColumn("Posicion"))
        dt.Columns.Add(New DataColumn("Desde"))
        dt.Columns.Add(New DataColumn("Hasta"))
        dt.Columns.Add(New DataColumn("Por"))
        Dim list As List(Of Posicion)
        If Controladores.Fachada.getInstancia.DevolverUsuarioActual.Rol <> Usuario.TIPO_ROL_ADMINISTRADOR Then
            list = Fachada.getInstancia.TodasLasPosicionesPorLugar(vehiculo.IdVehiculo, Fachada.getInstancia.TrabajaEnAcutual.Lugar.IDLugar)
        Else
            list = Fachada.getInstancia.TodasLasPosiciones(vehiculo.IdVehiculo)
        End If
        For Each pos As Posicion In list
            Dim r As DataRow = dt.NewRow
            r.Item(0) = pos.Subzona.ZonaPadre.LugarPadre.Nombre
            r.Item(1) = pos.Posicion
            r.Item(2) = pos.Desde
            r.Item(4) = pos.IngresadoPor.NombreDeUsuario
            r.Item(3) = If(pos.Hasta = DateTime.MinValue, DBNull.Value, pos.Hasta)
            dt.Rows.Add(r)
        Next
        traslados.DataSource = dt
    End Sub

    Public Sub actualizarTrasportesDeFormaExterna()
        CargarTraslados()
    End Sub

    Public Sub ActualizarLotesExternos()
        ListaInformes = Controladores.Fachada.getInstancia.devolverTodosLosInformesYregistrosCompletos(vehiculo)
        informeActual = 0
        registroActual = 0
        actualImagen = 0
        sigienteInforme.Enabled = True
        CargarInformes()
    End Sub

    Public Sub CargarInformes()
        Dim info As Controladores.InformeDeDaños = ListaInformes(informeActual)

        numeroInforme.Text = info.ID
        NomCreador.Text = info.Creador.Nombre
        fechaCreacionInforme.Text = info.Fecha
        descrip_Informe.Text = info.Descripcion
        If info.Registros.Count > 0 Then
            visualizarElementosRegistro(True, True)
            If info.Registros.Count = 1 Then
                SigienteRegistro.Enabled = False
            Else
                SigienteRegistro.Enabled = True
            End If
            CargarRegistros()
        Else
            visualizarElementosRegistro(False, True)
        End If
    End Sub

    Public Sub CargarRegistros()
        Dim reg As Controladores.RegistroDaños = ListaInformes(informeActual).Registros(registroActual)
        numRegistro.Text = reg.ID
        descrip_registro.Text = reg.Descripcion
        tipoRegistro.Text = reg.TipoActualizacion
        If reg.TipoActualizacion.Equals(Controladores.RegistroDaños.TIPO_ACTUALIZACION_REGULAR) Then
            idinformepadre.Text = "SIN INFORMACION"
            idregistropadre.Text = "Sin INFORMACION"
        Else
            idinformepadre.Text = reg.Actualiza.InformePadre.ID
            idregistropadre.Text = reg.Actualiza.ID
        End If
        cargarImgReg()
    End Sub

    Public Sub cargarImgReg()
        Dim reg As Controladores.RegistroDaños = ListaInformes(informeActual).Registros(registroActual)
        If reg.Imagenes.Count = 0 Then
            imagen.Image = OperarioCore.My.Resources.sinContenidoFotografico
            SigienteImagen.Visible = False
            AnteriorImagen.Visible = False

        Else
            If reg.Imagenes.Count = 1 Then
                SigienteImagen.Enabled = False
                AnteriorImagen.Enabled = False
            Else
                SigienteImagen.Enabled = True
            End If
            SigienteImagen.Visible = True
            AnteriorImagen.Visible = True
            imagen.Image = reg.Imagenes(actualImagen)
        End If
    End Sub

    Private Sub visualizarElementosRegistro(j As Boolean, j2 As Boolean)
        sinregistros.Visible = Not j
        Label17.Visible = j
        numRegistro.Visible = j
        Label19.Visible = j
        idregistropadre.Visible = j
        idinformepadre.Visible = j
        Label20.Visible = j
        Label18.Visible = j
        tipoRegistro.Visible = j
        anteriorRegistro.Visible = j
        AnteriorImagen.Visible = j
        SigienteRegistro.Visible = j
        SigienteImagen.Visible = j
        Label21.Visible = j
        descrip_registro.Visible = j
        imagen.Visible = j
        modificar.Visible = j
        Label11.Visible = j2
        numeroInforme.Visible = j2
        NomCreador.Visible = j2
        Label15.Visible = j2
        Label16.Visible = j2
        Label14.Visible = j2
        fechaCreacionInforme.Visible = j2
        anteriorInforme.Visible = j2
        sigienteInforme.Visible = j2
        descrip_Informe.Visible = j2
        SinInformes.Visible = Not j2

    End Sub

    Public Sub RegularTamañoColumnas()

        Me.Height = 3000

        traslados.Columns(0).Width = 200
        traslados.Columns(1).Width = 200
        traslados.Columns(2).Width = 175
        traslados.Columns(3).Width = 175
        traslados.Columns(4).Width = 175
        traslados.Columns(5).Width = 225

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim permitido = False
        If permitido Then
            ModeloBox.Enabled = Not ModeloBox.Enabled
            MarcaBox.Enabled = Not MarcaBox.Enabled
            AñoBox.Enabled = Not AñoBox.Enabled
            TipoCombo.Enabled = Not TipoCombo.Enabled
            LoteCombo.Enabled = Not LoteCombo.Enabled
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim estadoultimo = Controladores.Fachada.getInstancia.UltimoEstadoTransportePorIdVehiculo(vehiculo.IdVehiculo)
        If estadoultimo IsNot Nothing AndAlso (estadoultimo.Equals(Controladores.Trasporte.TIPO_ESTADO_FALLO) OrElse estadoultimo.Equals(Controladores.Trasporte.TIPO_ESTADO_PROSESO)) Then
            datosEnTransporte()
            Return
        End If
        Dim tInterno = New TrasladoInterno(vehiculo.IdVehiculo, Me)
        tInterno.ShowDialog()
    End Sub

    Private Sub informes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        'Marco.getInstancia.cargarPanel(Of crearInformaDeDaños)(New crearInformaDeDaños(DirectCast(informes.Rows()(e.RowIndex).Cells()(0).Value, Integer)))
    End Sub

    Private _changedTB2 As Boolean = False
    Private _changedTB3 As Boolean = False
    Private _changedTB4 As Boolean = False
    Private _changedTB5 As Boolean = False
    Private _changedCB1 As Boolean = False



    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles MarcaBox.TextChanged
        _changedTB2 = True
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles ModeloBox.TextChanged
        _changedTB3 = True
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles ClienteBox.TextChanged
        _changedTB4 = True
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles AñoBox.TextChanged
        If AñoBox.Text.Where(Function(x) x >= "0" And x <= "9").Count <> AñoBox.Text.Count Then
            AñoBox.ForeColor = Color.Red
        Else
            AñoBox.ForeColor = Color.Black
            _changedTB5 = True
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TipoCombo.SelectedIndexChanged
        _changedCB1 = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim estadoultimo = Fachada.getInstancia.UltimoEstadoTransportePorIdVehiculo(vehiculo.IdVehiculo)
        If estadoultimo IsNot Nothing AndAlso (estadoultimo.Equals(Controladores.Trasporte.TIPO_ESTADO_FALLO) OrElse estadoultimo.Equals(Controladores.Trasporte.TIPO_ESTADO_PROSESO)) Then
            datosEnTransporte()
            Return
        End If

        Marco.getInstancia.CargarPanel(Of crearInformaDeDaños)(
            New crearInformaDeDaños(New Controladores.InformeDeDaños(vehiculo) With {.Creador = Fachada.getInstancia.DevolverUsuarioActual,
                                                                                     .Lugar = Fachada.getInstancia.DevolverPosicionActual(vehiculo.IdVehiculo).Subzona.ZonaPadre.LugarPadre,
                                                                                     .Fecha = DateTime.Now}, True, Me) With {.ListaDeTodosLosInformes = ListaInformes})
    End Sub




    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles nuevoLote.LinkClicked
        LoteCombo.Enabled = False
        Dim nl As NuevoLote
        If loteTemp Is Nothing Then
            Dim p = Controladores.Fachada.getInstancia.DevolverPosicionActual(vehiculo.IdVehiculo)
            nl = New NuevoLote(Me, p.Subzona.ZonaPadre.LugarPadre)
        Else
            nl = New NuevoLote(Me, loteTemp)
        End If
        nl.ShowDialog()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles vermasLote.LinkClicked
        Marco.getInstancia.CargarPanel(New PanelInfoLote(loteActual.Nombre))
    End Sub

    Private Sub SigienteInforme_Click(sender As Object, e As EventArgs) Handles sigienteInforme.Click
        If informeActual + 1 < ListaInformes.Count Then
            informeActual += 1
            registroActual = 0
            actualImagen = 0
            If informeActual + 1 = ListaInformes.Count Then
                sigienteInforme.Enabled = False
            End If
            anteriorInforme.Enabled = True
        End If
        CargarInformes()
    End Sub

    Private Sub AnteriorInforme_Click(sender As Object, e As EventArgs) Handles anteriorInforme.Click
        If informeActual > 0 Then
            informeActual -= 1
            registroActual = 0
            actualImagen = 0
            If informeActual = 0 Then
                anteriorInforme.Enabled = False
            End If
            sigienteInforme.Enabled = True
        End If
        CargarInformes()
    End Sub

    Private Sub AnteriorRegistro_Click(sender As Object, e As EventArgs) Handles anteriorRegistro.Click
        If registroActual > 0 Then
            registroActual -= 1
            actualImagen = 0
            If registroActual = 0 Then
                anteriorRegistro.Enabled = False
            End If
            SigienteRegistro.Enabled = True
        End If
        CargarRegistros()
    End Sub

    Private Sub SigienteRegistro_Click(sender As Object, e As EventArgs) Handles SigienteRegistro.Click
        If registroActual + 1 < ListaInformes(informeActual).Registros.Count Then
            registroActual += 1
            actualImagen = 0
            If registroActual + 1 = ListaInformes(informeActual).Registros.Count Then
                SigienteRegistro.Enabled = False
            End If
            anteriorRegistro.Enabled = True
        End If
        CargarRegistros()
    End Sub

    Private Sub SigienteImagen_Click(sender As Object, e As EventArgs) Handles SigienteImagen.Click
        If actualImagen + 1 < ListaInformes(informeActual).Registros(registroActual).Imagenes.Count Then
            actualImagen += 1
            If actualImagen + 1 = ListaInformes(informeActual).Registros(registroActual).Imagenes.Count Then
                SigienteImagen.Enabled = False
            End If
            AnteriorImagen.Enabled = True
        End If
        cargarImgReg()
    End Sub

    Private Sub AnteriorImagen_Click(sender As Object, e As EventArgs) Handles AnteriorImagen.Click
        If actualImagen > 0 Then
            actualImagen -= 1
            If actualImagen = 0 Then
                AnteriorImagen.Enabled = False
            End If
            SigienteImagen.Enabled = True
        End If
        cargarImgReg()
    End Sub

    Private Sub Modificar_Click(sender As Object, e As EventArgs) Handles modificar.Click
        If Fachada.getInstancia.DevolverUsuarioActual.ID_usuario = ListaInformes(informeActual).Creador.ID_usuario Then
            'COMPROBAR QUE NO HAYA PASADO MAS DE 2 DIAS 
            If ListaInformes.Count - 1 = informeActual Then
                Marco.getInstancia.CargarPanel(Of crearInformaDeDaños)(New crearInformaDeDaños(ListaInformes(informeActual), False, Me) With {.ListaDeTodosLosInformes = ListaInformes})
            Else
                MsgBox("Solo se puede modificar el ultimo informe", MsgBoxStyle.Critical)
            End If
        Else
            MsgBox("Solo el creador puede modificar este informe", MsgBoxStyle.Critical)
        End If


    End Sub

    Public Sub NotificarLote(lote As Lote) Implements NotificacionLote.NotificarLote
        loteTemp = lote
        Me.LoteCombo.Enabled = False
        nuevoLote.Text = "Modificar"
        EliminarLoteSelecion.Enabled = True
    End Sub

    Public Function dameVehiculoalLote() As Object Implements NotificacionLote.dameVehiculoalLote
        Return vehiculo
    End Function

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles EliminarLoteSelecion.LinkClicked
        loteTemp = Nothing
        EliminarLoteSelecion.Enabled = False
        nuevoLote.Text = "Nuevo lote"
    End Sub

    Private Sub datosEnTransporte()
        cambiarGuardarLote.Enabled = False
        Entransporte.Visible = True
        bajaButton.Enabled = False
        Button4.Enabled = False
        Button2.Enabled = False
    End Sub

    Private Sub CambiarGuardarLote_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles cambiarGuardarLote.LinkClicked
        Dim estadoultimo = Controladores.Fachada.getInstancia.UltimoEstadoTransportePorIdVehiculo(vehiculo.IdVehiculo)
        If estadoultimo IsNot Nothing AndAlso (estadoultimo.Equals(Controladores.Trasporte.TIPO_ESTADO_FALLO) OrElse estadoultimo.Equals(Controladores.Trasporte.TIPO_ESTADO_PROSESO)) Then
            datosEnTransporte()
            Return
        End If
        If Not superpepe Then
            superpepe = True
            CargarLotes()
            cambiarGuardarLote.Text = "Guardar"
            nuevoLote.Visible = True
            EliminarLoteSelecion.Visible = True
            Cancelar.Visible = True
            EliminarLoteSelecion.Enabled = False
            LoteCombo.Enabled = True
            vermasLote.Enabled = False
        Else
            superpepe = False
            cambiarGuardarLote.Text = "Cambiar lote"
            nuevoLote.Visible = False
            EliminarLoteSelecion.Visible = False
            Cancelar.Visible = False
            vermasLote.Enabled = True
            LoteCombo.Enabled = False

            If loteTemp IsNot Nothing Then
                Dim idlote As Integer = Fachada.getInstancia.nuevoLote(loteTemp)
                loteTemp.IDLote = idlote
                Fachada.getInstancia.insertIntegra(loteTemp, vehiculo, Fachada.getInstancia.DevolverUsuarioActual, True)
            Else
                Fachada.getInstancia.insertIntegra(todosLosLotesDisponibles(LoteCombo.SelectedIndex), vehiculo, Fachada.getInstancia.DevolverUsuarioActual, True)
            End If



            If loteActual IsNot Nothing Then
                Fachada.getInstancia.eliminarLoteSiNoTieneVehiculos(loteActual)
            Else
                Extenciones.MsgBoxI18N("Este vehículo no tiene lote. Esto no debería suceder, por lo cual debe haber un error en el programa o alguna manipulación de la base de datos. Por favor, reporte esto a su DBA así como a los desarrolladores.", MsgBoxStyle.Critical)
            End If

            Fachada.getInstancia.invalidarLotesSinEvhciulosdelSistema()

            CargarMiLote()
            loteTemp = Nothing
        End If
    End Sub

    Private Sub Cancelar_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Cancelar.LinkClicked
        cambiarGuardarLote.Text = "Cambiar lote "
        nuevoLote.Visible = False
        EliminarLoteSelecion.Visible = False
        Cancelar.Visible = False
        LoteCombo.Enabled = False
        vermasLote.Enabled = True
        CargarMiLote()
        loteTemp = Nothing
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles SaveButton.Click
        Dim sfd As New SaveFileDialog With {
            .Filter = "Imagen PNG|*.png",
            .AddExtension = True
        }
        If sfd.ShowDialog = DialogResult.OK Then
            Dim fs = sfd.OpenFile
            Me.qrcode.Save(fs, Imaging.ImageFormat.Png)
        End If
    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles bajaButton.Click
        Dim estadoultimo = Controladores.Fachada.getInstancia.UltimoEstadoTransportePorIdVehiculo(vehiculo.IdVehiculo)
        If estadoultimo IsNot Nothing AndAlso (estadoultimo.Equals(Trasporte.TIPO_ESTADO_FALLO) OrElse estadoultimo.Equals(Trasporte.TIPO_ESTADO_PROSESO)) Then
            datosEnTransporte()
            Return
        End If

        Dim BV = New BajaVehiculo(Me.vehiculo)
        BV.ShowDialog()
    End Sub

    Private Sub Button1_Click_3(sender As Object, e As EventArgs) Handles Button1.Click
        Dim estadoultimo = Controladores.Fachada.getInstancia.UltimoEstadoTransportePorIdVehiculo(vehiculo.IdVehiculo)
        If estadoultimo IsNot Nothing AndAlso (estadoultimo.Equals(Trasporte.TIPO_ESTADO_CANCELADO) OrElse estadoultimo.Equals(Trasporte.TIPO_ESTADO_EXISTOSO)) Then
            Dim punto As PointF = Fachada.getInstancia.cordanadasPoscionActualDelvehiculo(vehiculo.IdVehiculo)
            Dim ss As New MapaPanelGrande(New PointLatLng(punto.X, punto.Y))
            ss.ShowDialog()
        ElseIf estadoultimo IsNot Nothing AndAlso (estadoultimo.Equals(Trasporte.TIPO_ESTADO_PROSESO)) Then
            Dim link As String = Controladores.Fachada.getInstancia.linkTransportistaPortransporteIdvehiculo(vehiculo.IdVehiculo)
            If link IsNot Nothing Then
                If Controladores.Funciones_comunes.URLExist(link) Then
                    Dim ss As New Controladores.TiempoRealGooglePlex(link)
                    ss.ShowDialog()
                Else
                    MsgBox("La direcion URL no es valida", MsgBoxStyle.Critical)
                End If
            Else
                MsgBox("El transportista no tiene link de rastreo activo. No se puede mostrar su ubicacion", MsgBoxStyle.Critical)
            End If
        End If
    End Sub
End Class