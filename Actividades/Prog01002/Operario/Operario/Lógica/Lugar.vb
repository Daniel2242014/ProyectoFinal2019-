﻿Namespace Logica
    ' Funcionamiento a desarrollar:
    ' Clases "repositorio" desde donde se cargan y donde se guardan las entidades
    ' los "repositorios" tendrán métodos de actualización que guardarán los cambios
    Public Enum TipoLugar
        Puerto
        Patio
    End Enum
    Public Class Lugar
        Public ReadOnly ID As Integer
        Public ReadOnly Nombre As String
        Public ReadOnly Capacidad As UInteger
        Public ReadOnly Posicion As PointF
        Public ReadOnly Creador As Usuario
        Public ReadOnly Tipo As TipoLugar
        Private _zonas As List(Of Zona)
        Public ReadOnly Property Zonas As List(Of Zona)
            Get
                Return _zonas
            End Get
        End Property
        Public ReadOnly LotesCreados As List(Of Lote)

        Public Sub New(ID As Integer, nombre As String, capacidad As UInteger, posicion As PointF, creador As Usuario, tipo As TipoLugar, zonas As List(Of Zona), lotesCreados As List(Of Lote))
            Me.ID = ID
            Me.Nombre = nombre
            Me.Capacidad = capacidad
            Me.Posicion = posicion
            Me.Creador = creador
            Me.Tipo = tipo
            _zonas = zonas
            Me.LotesCreados = lotesCreados
        End Sub

        Public Sub New(dr As DataRow)
            Me.New(dr("IDLugar"), dr("Nombre"), dr("Capacidad"), New PointF(dr("GeoX"), dr("GeoY")), URepo.UsuarioIncompletoPorID(dr("UsuarioCreador")), TipoFromString(dr("Tipo")), New List(Of Zona), New List(Of Lote))
        End Sub

        Public ReadOnly Property LotesPorPartir As List(Of Lote)
            Get
                Return LotesCreados.Where(Function(x) [Enum].GetName(GetType(EstadoLote), x.Estado).Contains("Cerrado") And Not [Enum].GetName(GetType(EstadoLote), x.Estado).Contains("Transportado"))
            End Get
        End Property

        Public ReadOnly Property Subzonas As List(Of Subzona)
            Get
                Return Zonas.Select(Of List(Of Subzona))(Function(x) x.Subzonas).UnionListas
            End Get
        End Property

    End Class
End Namespace