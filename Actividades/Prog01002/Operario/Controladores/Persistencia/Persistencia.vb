﻿Imports System.Data.Odbc
Imports Controladores.Extenciones.Extensiones

Public Class Persistencia
    Private Sub New()
        _UsuarioIngresado = New Usuario
        _trabajaEnActual = Nothing
        _conexcionActualHora = Nothing
    End Sub

    Private Shared initi As Persistencia

    Private _con As OdbcConnection
    Public ReadOnly Property Conexcion() As OdbcConnection
        Get
            Return _con
        End Get
    End Property

    Private _UsuarioIngresado As Usuario

    Public Function Consultar(p As String, ParamArray values As Object()) As DataTable
        Dim cmd As New OdbcDataAdapter(p, _con)
        values.ForEach(Sub(x) cmd.SelectCommand.CrearParametro(x))
        Dim ds As New DataSet
        cmd.Fill(ds)
        Return ds.Tables.Item(0)
    End Function

    Public Property UsuarioActual() As Usuario
        Get
            Return _UsuarioIngresado
        End Get
        Set(ByVal value As Usuario)
            _UsuarioIngresado = value
        End Set
    End Property

    Private _trabajaEnActual As TrabajaEn
    Public Property TrabajaEn() As TrabajaEn
        Get
            Return _trabajaEnActual
        End Get
        Set(ByVal value As TrabajaEn)
            _trabajaEnActual = value
        End Set
    End Property

    Private _conexcionActualHora As DateTime
    Public Property HoraDeLaConexcionActual() As DateTime
        Get
            Return _conexcionActualHora
        End Get
        Set(ByVal value As DateTime)
            _conexcionActualHora = value
        End Set
    End Property

    Public Shared Function getInstancia() As Persistencia
        If initi Is Nothing Then
            initi = New Persistencia
        End If
        Return initi
    End Function

    Public Function RealizarConexcion(ip As String, port As String, servername As String, uid As String, pwd As String, db As String, prueba As Boolean) As Boolean
        Try
            Dim creacion As String = "Driver=IBM INFORMIX ODBC DRIVER (64-bit);Database=" & db & ";Host=" & ip & ";Server=" & servername & ";Service=" &
            port & ";UID=" & uid & ";PWD=" & pwd & ";"
            Dim con As New OdbcConnection(creacion)
            con.Open()
            If prueba Then
                _con = con
            Else
                con.Close()
            End If
            Return True
        Catch ee As Exception
            Return False

        End Try
    End Function

    Public Function VerificarCredenciales(nombreDeUsuario, password) As Boolean
        Try
            Dim consulta = New OdbcCommand("select hash_contra from usuario where nombredeusuario=?", _con)
            consulta.CrearParametro(DbType.String, nombreDeUsuario)
            Dim hash = consulta.ExecuteScalar
            Return BCrypt.Net.BCrypt.EnhancedVerify(password, hash, BCrypt.Net.HashType.SHA256)
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function ExistenciaDeUsuario(nombreDeUsuario) As Boolean
        Try
            Dim consulta As New OdbcCommand("select count(*)=1 from usuario where nombredeusuario=?;", Conexcion)
            consulta.CrearParametro(DbType.String, nombreDeUsuario)
            Return consulta.ExecuteScalar()
        Catch ex As Exception
            Return False
        End Try

    End Function



    Public Function PreguntaSecretaUsuario(username As String) As String
        Dim cmd As New OdbcCommand("select preguntasecreta from usuario where nombredeusuario=?;", Conexcion)
        cmd.CrearParametro(DbType.String, username)
        Return cmd.ExecuteScalar
    End Function


    Public Function RespuestaSecretaUsuario(username As String) As String
        Dim cmd As New OdbcCommand("select RespuestaSecreta from usuario where nombredeusuario=?;", Conexcion)
        cmd.CrearParametro(DbType.String, username)
        Return cmd.ExecuteScalar
    End Function


    Public Function ModificarContraseñaPorDatosDeRecuperacion(username As String, newpass As String) As Boolean
        Dim cmd As New OdbcCommand("update usuario set hash_contra=? where nombredeusuario=?;", Conexcion)
        cmd.CrearParametro(DbType.StringFixedLength, Funciones_comunes.ContraseñaHash(newpass))
        cmd.CrearParametro(DbType.String, username)
        Return cmd.ExecuteNonQuery > 0
    End Function


    Public Function TrabajaEnPorusuarioDatosBasicos(username As String) As DataTable 'nos da la fecha, usuario y lugar
        Try
            Dim cmd As New OdbcDataAdapter("select lugar.nombre, trabajaen.fechainicio, trabajaen.fechafin, lugar.nombre, lugar.idlugar, lugar.GeoX , lugar.GeoY, trabajaen.id, lugar.tipo
                                    from lugar,trabajaen,usuario
                                    where lugar.idlugar = trabajaen.idlugar and trabajaen.idusuario=usuario.idusuario 
                                    and usuario.nombredeusuario=?", Conexcion)
            cmd.SelectCommand.CrearParametro(DbType.String, username)
            Dim TrabajaEn = New DataSet()
            cmd.Fill(TrabajaEn)
            Return TrabajaEn.Tables.Item(0)
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Function NombreLugarDeTrabajoPorID(id As Integer) As String
        Try
            Dim cmd As New OdbcCommand("select lugar.nombre from lugar where idlugar=?", Conexcion)
            cmd.CrearParametro(DbType.Int32, id)
            Return cmd.ExecuteScalar()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ConexcionesTrabaen(id As Integer) As DataTable
        Try
            Dim cmd As New OdbcDataAdapter("select conexion.HoraIngreso ,conexion.HoraSalida from 
                                        trabajaen,conexion where conexion.idtrabajaen = trabajaen.id and trabajaen.id=?", Conexcion)
            cmd.SelectCommand.CrearParametro(DbType.Int32, id)
            Dim ds As New DataSet
            cmd.Fill(ds)
            Return ds.Tables.Item(0)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NuevaConext(id As Integer, horaInicio As DateTime) As Boolean
        Dim com As New OdbcCommand("insert into conexion(IDTrabajaEn, HoraIngreso) values(?, ?);", Conexcion)
        com.CrearParametro(DbType.Int64, id)
        com.CrearParametro(DbType.DateTime, Date.Now)
        Try
            Return com.ExecuteNonQuery() > 0
        Catch e As Exception
            Return False
        End Try

    End Function

    Public Sub Cerrarseccion(id As Integer, horaInico As Date)
        Dim com As New OdbcCommand("update conexion set HoraSalida=? where idtrabajaen=? and HoraIngreso=?;", Conexcion)
        com.CrearParametro(DbType.DateTime, Date.Now.ToString("yyyy-MM-dd HH:mm:ss"))
        com.CrearParametro(DbType.Int32, id)
        com.CrearParametro(DbType.DateTime, horaInico.ToString("yyyy-MM-dd HH:mm:ss"))
        com.ExecuteNonQuery()
        borrarDatosLocalesPorSeccion()
    End Sub

    Private Sub borrarDatosLocalesPorSeccion()
        _UsuarioIngresado = New Usuario()
        _trabajaEnActual = Nothing
        _conexcionActualHora = Nothing
    End Sub

    Public Function DatosBaseVehiculos(ParamArray VIN() As String) As DataTable
        If VIN.Length < 1 Then
            Return Nothing
        End If
        Dim ParamList = "(" + String.Join(", ", "?".Multiply(VIN.Length)) + ")"
        Dim cmd = $"select vehiculo.vin, vehiculo.marca, vehiculo.modelo, vehiculo.anio, vehiculo.tipo, vehiculo.color, cliente.IDCliente, cliente.RUT, cliente.Nombre, cliente.fechaRegistro , vehiculo.idvehiculo from vehiculo inner join cliente on vehiculo.Cliente=Cliente.IDCliente where vehiculo.vin in {ParamList};"
        Dim com As New OdbcDataAdapter(cmd, _con)
        For Each i In VIN
            com.SelectCommand.CrearParametro(DbType.AnsiStringFixedLength, i)
        Next
        Dim ds As New DataSet
        com.Fill(ds)
        Return ds.Tables.Item(0)
    End Function

    Public Function VehiculosEnLote(IDLote As Integer) As DataTable
        Dim com As New OdbcCommand("select vin, fecha, idusuario from integra,vehiculo where Lote=? and invalidado='f' and integra.idvehiculo=vehiculo.vin;", _con)
        com.CrearParametro(DbType.Int32, IDLote)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Public Function DatosBaseLote(Optional IDLote As Integer? = Nothing, Optional Nombre As String = Nothing) As DataTable
        Dim com As OdbcCommand
        Dim commandStart = "select lote.nombre, l1.nombre, l2.nombre, lote.Origen, lote.Destino, lote.estado, lote.prioridad, lote.idlote, lote.fechacreacion from lote inner join lugar as l1 on l1.idlugar=lote.Destino inner join lugar as l2 on l2.idlugar=lote.Origen"
        Dim prefixes() = {" where lote.idlote=?;", " where lote.nombre=?;"}
        If IDLote IsNot Nothing Then
            com = New OdbcCommand(commandStart + prefixes(0), _con)
            com.CrearParametro(DbType.Int32, IDLote)
        ElseIf Nombre IsNot Nothing Then
            com = New OdbcCommand(commandStart + prefixes(1), _con)
            com.CrearParametro(DbType.String, Nombre)
        Else
            Return Nothing
        End If
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Public Function DatosBaseUsuario(nom As String) As DataTable
        Dim com As New OdbcCommand("select IDUsuario, Email, FechaNac, Telefono, PrimerNombre, PrimerNombre, PrimerApellido, PrimerApellido, PreguntaSecreta, RespuestaSecreta, Sexo, rol
                                    from Usuario Where Usuario.nombreDeUsuario=? ;", Conexcion)
        com.CrearParametro(DbType.String, nom)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Public Function NumeroLotesCreadorPorusuario_ID(id As Integer) As Integer
        Dim com As New OdbcCommand("select count(*) from lote where creadorID=? ;", Conexcion)
        com.CrearParametro(DbType.Int32, id)
        Return com.ExecuteScalar
    End Function

    Public Function NumeroVehiculosDatosDeAltaPorUsuario_ID(id As Integer) As Integer
        Dim com As New OdbcCommand("select count(*) from vehiculoIngresa where Usuario=? and TipoIngreso='Alta';", Conexcion)
        com.CrearParametro(DbType.Int32, id)
        Return com.ExecuteScalar
    End Function

    Public Function IDLotePor_IDvehiculo_y_IDLugar(idve As Integer, id As Integer) As Integer
        Try
            Dim com As New OdbcCommand("select lote.idlote from integra, lote where idvehiculo=?
                                    and invalidado ='f' and integra.lote=lote.idlote
                                    and fecha in (select max(fecha) from lote, integra where idvehiculo=? and
                                    integra.lote =lote.idlote and lote.Origen=?)", Conexcion)
            com.CrearParametro(DbType.Int32, idve)
            com.CrearParametro(DbType.Int32, idve)
            com.CrearParametro(DbType.Int32, id)
            Return com.ExecuteScalar
        Catch ex As Exception
            Return -1
        End Try

    End Function

    Public Function DatosBasicosParaListarVehiculosPorLugar(idlugar As Integer) As DataTable

        Dim com As New OdbcCommand($"select distinct vehiculo.idvehiculo, vehiculo.vin, vehiculo.marca, vehiculo.modelo, vehiculo.tipo 
                                    from vehiculo, posicionado, vehiculoIngresa
                                    where posicionado.idvehiculo=vehiculo.idvehiculo and vehiculoIngresa.idvehiculo = vehiculo.idvehiculo
                                    and posicionado.idlugar in (select unnamed_col_1 from table(subzonas_en_lugar({idlugar})))",
                                  Conexcion)
        'com.CrearParametro(DbType.Int32, idlugar)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Public Function ComprobarLoteTrasladoRealizado(id As Integer) As Boolean
        Dim com As New OdbcCommand("select count(transporte.estado) from lote
                                      inner join transporta on transporta.idlote=lote.idlote
                                      inner join transporte on transporte.transporteid=transporta.transporteid
                                    where lote.idlote=? and transporte.estado='Exitoso'", Conexcion)
        com.CrearParametro(DbType.Int32, id)
        Return com.ExecuteScalar > 0
    End Function

    Public Function AutoComplete(start As String) As List(Of String)
        If start.Contains("%") Then Return New List(Of String)
        Dim cmd = New OdbcCommand("select vin from vehiculo where vin like ?;", Conexcion)
        cmd.CrearParametro(DbType.String, start + "%")
        Dim dt As New DataTable
        dt.Load(cmd.ExecuteReader)
        Return dt.ToList.Select(Function(x) DirectCast(x(0), String)).ToList
    End Function


    Public Function DevolverInformacionBasicaDeZonasPorID_lugar(id As Integer) As DataTable
        Dim com As New OdbcCommand($"select unnamed_col_1 as idzona, unnamed_col_2 as nombrezona, unnamed_col_3 as capacidad from table(zonas_en_lugar({id}));", Conexcion)
        'com.SelectCommand.CrearParametro(DbType.Int32, id)
        Dim ds As New DataTable
        ds.Load(com.ExecuteReader)
        Return ds
    End Function

    Public Function DevolverInformacionDeSubzonaPorIdZona(id_z As Integer, id_l As Integer) As DataTable
        Dim com As New OdbcCommand($"select unnamed_col_1 as idzona, unnamed_col_2 as nombrezona, unnamed_col_3 as capacidad from table(subzonas_en_zona({id_l}, {id_z}));", Conexcion)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Public Function DevolverTodosLosLotesPor_IdLugar(id As Integer?) As DataTable
        If id Is Nothing Then
            Return Nothing
        End If
        Dim com As New OdbcCommand("select lote.idlote, lote.nombre, lote.estado, (select count(*) from integra where integra.lote=lote.idlote and integra.invalidado='f'), (select count(*) from transporta inner join transporte on transporta.transporteID=transporte.transporteID where transporta.IDLote=lote.IDLote) from lote inner join lugar on lote.origen = lugar.idlugar where lugar.idlugar = ?;", Conexcion)
        com.CrearParametro(DbType.Int32, id)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        dt.Columns.Item(0).ColumnName = "ID del Lote"
        dt.Columns.Item(1).ColumnName = "Nombre del Lote"
        dt.Columns.Item(2).ColumnName = "Estado del Lote"
        dt.Columns.Item(3).ColumnName = "Autos en Lote"
        dt.Columns.Add("Transportado", GetType(Boolean))
        For Each i As DataRow In dt.Rows
            i.Item(5) = CType(i.Item(4), Integer) > 0
        Next
        dt.Columns.RemoveAt(4)
        Return dt
    End Function

    Public Function DevolverDatosBasicosDelVehiculoPrecargadoPor_VIN_vehiculo(vin As String) As DataTable
        Try
            Dim com As New OdbcCommand("select VIN,Marca,Modelo,color,tipo,anio,cliente.nombre,cliente.rut,cliente.idcliente
                                    from vehiculo inner join cliente on cliente.idcliente=vehiculo.cliente
                                    where vin=?;", Conexcion)
            com.CrearParametro(DbType.String, vin)
            Dim dt As New DataTable
            dt.Load(com.ExecuteReader)
            Return dt
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ExistenciaDeVehiculoPRecargado(vin As String) As Boolean
        Dim com As New OdbcCommand("select count(vehiculo.idvehiculo) from vehiculoIngresa, vehiculo where vehiculo.idvehiculo=vehiculoIngresa.idvehiculo and vin=? and tipoIngreso='Precarga'", Conexcion)
        com.CrearParametro(DbType.String, vin)
        Return com.ExecuteScalar > 0
    End Function

    Public Function PoscionesOcupadasPor_ID_Subzona(id As Integer) As DataTable
        Dim com As New OdbcCommand("select posicion from posicionado where posicionado.idlugar=? and hasta is null", Conexcion)
        com.CrearParametro(DbType.Int32, id)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Public Function clienteDelSistema() As DataTable
        Dim com As New OdbcCommand("select cliente.idcliente,cliente.rut,cliente.nombre from cliente", Conexcion)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Public Function devolverIdDeTodosLosInformesyRegistros(idVehiculo As Integer) As DataTable
        Dim com As New OdbcCommand("select informedanios.ID as idinforme, registrodanios.idregistro,
                      nvl(actualiza.tipo, 'No actualiza'), actualiza.informe2, actualiza.registro2
       from informedanios inner join registrodanios on informedanios.ID=registrodanios.informedanios
       left join actualiza on actualiza.registro1=registrodanios.idregistro and actualiza.informe1=informedanios.id
                                    where informedanios.Idvehiculo=?", Conexcion)
        com.CrearParametro(DbType.Int32, idVehiculo)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Public Function vinPorId(vin As String) As Integer
        Dim com As New OdbcCommand("select IDVehiculo from vehiculo where vin=?", Conexcion)
        com.CrearParametro(DbType.String, vin)
        Return com.ExecuteScalar
    End Function

End Class