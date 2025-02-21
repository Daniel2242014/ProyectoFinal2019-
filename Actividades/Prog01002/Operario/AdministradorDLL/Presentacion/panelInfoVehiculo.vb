﻿Imports Controladores
Imports Operario



Public Class panelInfoVehiculo
    Implements NotificacionLote

    Private informesElementos As New List(Of Controladores.InformeDeDaños)
    Private vin As String
    Private vehiculo As Controladores.Vehiculo
    Private actualInfore As Integer = 0
    Private actualRegistro As Integer = 0
    Private actualImagen As Integer = 0
    Private loteTemp As Controladores.Lote
    Private todosLosLotesDisponibles As List(Of Controladores.Lote)
    Private loteActual As Controladores.Lote
    Private qrcode As Bitmap
    Public Sub New(VIN As String, aqui As Boolean)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        'HAY QUE CARGAR EL LUGAR ACTUAL DEL VEHICULO 
        If Not aqui Then
            Button2.Visible = False
            Button4.Visible = False
        End If
        LoteCombo.Enabled = False
        Me.vin = VIN
        TipoCombo.Items.Clear()
        TipoCombo.Items.AddRange(Controladores.Vehiculo.TIPOS_VEHICULOS)
        RegularTamañoColumnas()
        TomarValores()
    End Sub

    Private Sub TomarValores()
        VINBox.Text = vin
        Dim vehiculo = Controladores.Fachada.getInstancia.InfoVehiculos(vin).SingleOrDefault
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
        Dim ultpos = Controladores.Fachada.getInstancia.UltimaPosicionVehiculo(vin)
        If ultpos IsNot Nothing Then
            SubzonaLabel.Text = ultpos.Item(1)
            Dim zona = Controladores.Persistencia.getInstancia.PadreDeLugar(ultpos.Item(0))
            ZonaLabel.Text = zona.Item(0)
            PosicionLabel.Text = ultpos.Item(2) & " desde " & Funciones_comunes.DarFormato(CType(ultpos.Item(3), Date?))
            Dim lugar = Controladores.Persistencia.getInstancia.PadreDeLugar(zona.Item(1))
            lugarLabel.Text = lugar.Item(0)
        End If

        informesElementos = Controladores.Fachada.getInstancia.devolverTodosLosInformesYregistrosCompletos(vehiculo)
        If informesElementos.Count = 0 Then

            visualizarElementosRegistro(False, False)

        Else
            If informesElementos.Count = 1 Then
                SinInformes.Enabled = False
            End If
            SinInformes.Visible = False
            cargarInformes()
        End If
        Me.vehiculo = vehiculo
        cargarMiLote()
        CargarTrasportes()
        Dim qrGenerator As New QRCoder.QRCodeGenerator
        Dim qrData = qrGenerator.CreateQrCode(vin, QRCoder.QRCodeGenerator.ECCLevel.H)
        Dim qrCode As New QRCoder.QRCode(qrData)
        Me.qrcode = qrCode.GetGraphic(15)
        Me.QR.Image = New Bitmap(Me.qrcode, New Size(Me.QR.Width, Me.QR.Height))
    End Sub

    Public Sub cargarLotes()
        todosLosLotesDisponibles = Controladores.Fachada.getInstancia.LotesDisponiblesPorLugarActual
        LoteCombo.Items.Clear()
        For Each l As Controladores.Lote In todosLosLotesDisponibles
            LoteCombo.Items.Add($"ID: {l.IDLote} / NOM: {l.Nombre}")
        Next
        If todosLosLotesDisponibles.Count > 0 Then
            LoteCombo.SelectedIndex = 0
        End If

    End Sub

    Public Sub cargarMiLote()
        'loteActual = Fachada.getInstancia.LoteVehiculo(vehiculo, Fachada.getInstancia.TrabajaEnAcutual.Lugar)
        'LoteCombo.Items.Clear()
        'LoteCombo.Items.Add($"ID: {loteActual.IDLote} / NOM: {loteActual.Nombre}")
        'LoteCombo.SelectedIndex = 0
    End Sub

    Private Sub CargarTrasportes()
        'Dim ultpos = Controladores.Fachada.getInstancia.UltimaPosicionVehiculoEnLugar(vin, Controladores.Persistencia.getInstancia.TrabajaEn.Lugar.Nombre)
        'SubzonaLabel.Text = ultpos.Item(1)
        'Dim zona = Controladores.Persistencia.getInstancia.PadreDeLugar(ultpos.Item(0))
        'ZonaLabel.Text = zona.Item(0)
        'PosicionLabel.Text = ultpos.Item(2) & " desde " & Controladores.Funciones_comunes.DarFormato(CType(ultpos.Item(3), Date?))
        'traslados.Columns.Clear()
        'Dim dt As New DataTable
        'dt.Columns.Add(New DataColumn("Lugar"))
        'dt.Columns.Add(New DataColumn("Posicion"))
        'dt.Columns.Add(New DataColumn("Desde"))
        'dt.Columns.Add(New DataColumn("Hasta"))
        'dt.Columns.Add(New DataColumn("Por"))
        'For Each pos As Posicion In Controladores.Fachada.getInstancia.TodasLasPosicionesPorLugar(vehiculo.IdVehiculo, Controladores.Fachada.getInstancia.TrabajaEnAcutual.Lugar.IDLugar)
        '    Dim r As DataRow = dt.NewRow
        '    r.Item(0) = pos.Subzona.ZonaPadre.LugarPadre.Nombre
        '    r.Item(1) = pos.Posicion
        '    r.Item(2) = pos.Desde
        '    r.Item(4) = pos.IngresadoPor.NombreDeUsuario
        '    r.Item(3) = If(pos.Hasta = DateTime.MinValue, DBNull.Value, pos.Hasta)
        '    dt.Rows.Add(r)
        'Next
        'traslados.DataSource = dt
    End Sub

    Public Sub actualizarTrasportesDeFormaExterna()
        CargarTrasportes()
    End Sub

    Public Sub ActualizarLotesExternos()
        informesElementos = Controladores.Fachada.getInstancia.devolverTodosLosInformesYregistrosCompletos(vehiculo)
        actualInfore = 0
        actualRegistro = 0
        actualImagen = 0
        sigienteInforme.Enabled = True
        cargarInformes()
    End Sub

    Public Sub cargarInformes()
        Dim info As Controladores.InformeDeDaños = informesElementos(actualInfore)

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
            Cargaregistros()
        Else
            visualizarElementosRegistro(False, True)
        End If
    End Sub

    Public Sub Cargaregistros()
        Dim reg As Controladores.RegistroDaños = informesElementos(actualInfore).Registros(actualRegistro)
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
        Dim reg As Controladores.RegistroDaños = informesElementos(actualInfore).Registros(actualRegistro)
        If reg.Imagenes.Count = 0 Then
            imagen.Image = Administrador.My.Resources.sinContenidoFotografico
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
        verReferencia.Visible = j
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

    Private dtlugares As DataTable
    Public Sub RegularTamañoColumnas()

        Me.Height = 3000

        traslados.Columns(0).Width = 200
        traslados.Columns(1).Width = 200
        traslados.Columns(2).Width = 175
        traslados.Columns(3).Width = 175
        traslados.Columns(4).Width = 175
        traslados.Columns(5).Width = 225

        lugares.Columns(0).Width = 170
        lugares.Columns(1).Width = 170
        lugares.Columns(2).Width = 170
        lugares.Columns(3).Width = 170
        lugares.Columns(4).Width = 170
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
        Dim tInterno = New trasladoInterno(vehiculo.IdVehiculo, Me)
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
        'Marco.getInstancia.cargarPanel(Of crearInformaDeDaños)(New crearInformaDeDaños(New Controladores.InformeDeDaños(vehiculo) With {.Creador = Fachada.getInstancia.TrabajaEnAcutual.Usuario,
        '                                                                                                                                .Lugar = Fachada.getInstancia.TrabajaEnAcutual.Lugar,
        '                                                                                                                                .Fecha = DateTime.Now}, True, Me) With {.ListaDeTodosLosInformes = informesElementos})

    End Sub




    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles nuevoLote.LinkClicked
        LoteCombo.Enabled = False
        Dim nl As NuevoLote
        If loteTemp Is Nothing Then
            nl = New NuevoLote(Me)
        Else
            nl = New NuevoLote(Me, loteTemp)
        End If
        nl.ShowDialog()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles vermasLote.LinkClicked
        Marco.getInstancia.cargarPanel(New PanelInfoLote(loteActual.Nombre))
    End Sub

    Private Sub SigienteInforme_Click(sender As Object, e As EventArgs) Handles sigienteInforme.Click
        If actualInfore + 1 < informesElementos.Count Then
            actualInfore += 1
            actualRegistro = 0
            actualImagen = 0
            If actualInfore + 1 = informesElementos.Count Then
                sigienteInforme.Enabled = False
            End If
            anteriorInforme.Enabled = True
        End If
        cargarInformes()
    End Sub

    Private Sub AnteriorInforme_Click(sender As Object, e As EventArgs) Handles anteriorInforme.Click
        If actualInfore > 0 Then
            actualInfore -= 1
            actualRegistro = 0
            actualImagen = 0
            If actualInfore = 0 Then
                anteriorInforme.Enabled = False
            End If
            sigienteInforme.Enabled = True
        End If
        cargarInformes()
    End Sub

    Private Sub AnteriorRegistro_Click(sender As Object, e As EventArgs) Handles anteriorRegistro.Click
        If actualRegistro > 0 Then
            actualRegistro -= 1
            actualImagen = 0
            If actualRegistro = 0 Then
                anteriorRegistro.Enabled = False
            End If
            SigienteRegistro.Enabled = True
        End If
        Cargaregistros()
    End Sub

    Private Sub SigienteRegistro_Click(sender As Object, e As EventArgs) Handles SigienteRegistro.Click
        If actualRegistro + 1 < informesElementos(actualInfore).Registros.Count Then
            actualRegistro += 1
            actualImagen = 0
            If actualRegistro + 1 = informesElementos(actualInfore).Registros.Count Then
                SigienteRegistro.Enabled = False
            End If
            anteriorRegistro.Enabled = True
        End If
        Cargaregistros()
    End Sub

    Private Sub SigienteImagen_Click(sender As Object, e As EventArgs) Handles SigienteImagen.Click
        If actualImagen + 1 < informesElementos(actualInfore).Registros(actualRegistro).Imagenes.Count Then
            actualImagen += 1
            If actualImagen + 1 = informesElementos(actualInfore).Registros(actualRegistro).Imagenes.Count Then
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
        If Fachada.getInstancia.DevolverUsuarioActual.ID_usuario = informesElementos(actualInfore).Creador.ID_usuario Then
            'COMPROBAR QUE NO HAYA PASADO MAS DE 2 DIAS 
            If informesElementos.Count - 1 = actualInfore Then
                Marco.getInstancia.cargarPanel(Of crearInformaDeDaños)(New crearInformaDeDaños(informesElementos(actualInfore), False, Me) With {.ListaDeTodosLosInformes = informesElementos})
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

    Private Sub CambiarGuardarLote_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles cambiarGuardarLote.LinkClicked
        'If cambiarGuardarLote.Text.Equals("Cambiar lote ") Then
        '    cargarLotes()
        '    cambiarGuardarLote.Text = "Guardar"
        '    nuevoLote.Visible = True
        '    EliminarLoteSelecion.Visible = True
        '    Cancelar.Visible = True
        '    EliminarLoteSelecion.Enabled = False
        '    LoteCombo.Enabled = True
        '    vermasLote.Enabled = False

        'Else
        '    cambiarGuardarLote.Text = "Cambiar lote "
        '    nuevoLote.Visible = False
        '    EliminarLoteSelecion.Visible = False
        '    Cancelar.Visible = False
        '    vermasLote.Enabled = True
        '    LoteCombo.Enabled = False

        '    If loteTemp IsNot Nothing Then
        '        Dim idlote As Integer = Fachada.getInstancia.nuevoLote(loteTemp)
        '        loteTemp.IDLote = idlote
        '        Fachada.getInstancia.insertIntegra(loteTemp, vehiculo, Fachada.getInstancia.TrabajaEnAcutual.Usuario, True)
        '    Else
        '        Fachada.getInstancia.insertIntegra(todosLosLotesDisponibles(LoteCombo.SelectedIndex), vehiculo, Fachada.getInstancia.TrabajaEnAcutual.Usuario, True)
        '    End If
        '    Fachada.getInstancia.eliminarLoteSiNoTieneVehiculos(loteActual)

        '    cargarMiLote()
        '    loteTemp = Nothing
        'End If
    End Sub

    Private Sub Cancelar_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Cancelar.LinkClicked
        cambiarGuardarLote.Text = "Cambiar lote "
        nuevoLote.Visible = False
        EliminarLoteSelecion.Visible = False
        Cancelar.Visible = False
        LoteCombo.Enabled = False
        vermasLote.Enabled = True
        cargarMiLote()
        loteTemp = Nothing
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sfd As New SaveFileDialog With {
            .Filter = "Imagen PNG|*.png",
            .AddExtension = True
        }
        If sfd.ShowDialog = DialogResult.OK Then
            Dim fs = sfd.OpenFile
            Me.qrcode.Save(fs, Imaging.ImageFormat.Png)
        End If
    End Sub
End Class