﻿Namespace Logica
    Public Enum EstadoLote
        Abierto
        Cerrado
        Transportado
    End Enum
    Public Enum PrioridadLote
        Normal
        Alto
    End Enum
    Public Class Lote
        Public ReadOnly ID As UInteger
        Public ReadOnly FechaPartida As DateTime
        Public ReadOnly Desde As Lugar
        Public ReadOnly Hacia As Lugar
        Public ReadOnly Creador As Usuario
        Public ReadOnly Integrantes As New List(Of Vehiculo)
        Public Prioridad As PrioridadLote
        Private _estado As EstadoLote
        Public ReadOnly Property Estado As EstadoLote
            Get
                Return _estado
            End Get
        End Property

        Public Sub CambiarEstado(NuevoEstado As EstadoLote)
            If NuevoEstado < _estado Then
                Throw New InvalidOperationException("No puedes bajar el estado de un lote")
            End If
            _estado = NuevoEstado
        End Sub

        Public Sub New(dr As DataRow, estado As EstadoLote)
            Me.New(dr("IDLote"), dr("FechaPartida"), LRepo.LugarPorID(dr("Desde")), LRepo.LugarPorID(dr("Hacia")), URepo.UsuarioIncompletoPorID(dr("CreadorID")), dr("Prioridad"), estado)
        End Sub

        Public Sub New(iD As UInteger, fechaPartida As Date, desde As Lugar, hacia As Lugar, creador As Usuario, prioridad As String, estado As String)
            Me.ID = iD
            Me.FechaPartida = fechaPartida
            Me.Desde = desde
            Me.Hacia = hacia
            Me.Creador = creador
            Me.Prioridad = prioridad
            _estado = estado
            desde.LotesCreados.Add(Me)
        End Sub
    End Class
End Namespace