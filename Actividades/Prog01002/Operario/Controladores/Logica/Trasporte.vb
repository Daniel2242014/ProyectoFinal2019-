﻿Imports Controladores

Public Class Trasporte
    Public Shared ReadOnly TIPO_ESTADO_PROSESO As String = "Proceso"
    Public Shared ReadOnly TIPO_ESTADO_FALLO As String = "Fallo"
    Public Shared ReadOnly TIPO_ESTADO_EXISTOSO As String = "Exitoso"
    Public Shared ReadOnly TIPO_ESTADO_CANCELADO As String = "Cancelado"

    Public Shared ReadOnly Property TIPOS_ESTADOS() As String()
        Get
            Return {TIPO_ESTADO_PROSESO, TIPO_ESTADO_FALLO, TIPO_ESTADO_EXISTOSO, TIPO_ESTADO_CANCELADO}
        End Get
    End Property

    Public Sub New(iD As Integer, fechaLLegadaEstimada As Date, fechaLLegadaReal As Date, estado As String, trass As Usuario)
        Me.ID = iD
        Me.FechaLLegadaEstimada = fechaLLegadaEstimada
        Me.FechaLLegadaReal = fechaLLegadaReal
        Me.Estado = estado
        Me.Lotes = New List(Of Lote)
        Me.Trasportista = trass
    End Sub

    Public Sub New()
        Me.Lotes = New List(Of Lote)
    End Sub

    Private _medi As MedioDeTransporte
    Public Property MedioDeTrasporte() As MedioDeTransporte
        Get
            Return _medi
        End Get
        Set(ByVal value As MedioDeTransporte)
            _medi = value
        End Set
    End Property

    Private _id As Integer
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)

            If value >= 0 Then
                _id = value
            Else
                Throw New Exception("El id no puede ser negativo")
            End If
        End Set
    End Property

    Private _fechaLlegadaE As DateTime
    Public Property FechaLLegadaEstimada() As DateTime
        Get
            Return _fechaLlegadaE
        End Get
        Set(ByVal value As DateTime)
            _fechaLlegadaE = value
        End Set
    End Property

    Private _fechaLlegadaR As DateTime
    Public Property FechaLLegadaReal() As DateTime
        Get
            Return _fechaLlegadaR
        End Get
        Set(ByVal value As DateTime)
            _fechaLlegadaR = value
        End Set
    End Property

    Private _fechaCreacion As DateTime
    Public Property FechaCreacion() As DateTime
        Get
            Return _fechaCreacion
        End Get
        Set(ByVal value As DateTime)
            _fechaCreacion = value
        End Set
    End Property

    Private _fechaSalida As DateTime
    Public Property FechaSalida() As DateTime
        Get
            Return _fechaSalida
        End Get
        Set(ByVal value As DateTime)
            _fechaSalida = value
        End Set
    End Property

    Private _estado As String
    Public Property Estado() As String
        Get
            Return _estado
        End Get
        Set(ByVal value As String)

            _estado = value


        End Set
    End Property

    Private _lotes As List(Of Lote)
    Public Property Lotes() As List(Of Lote)
        Get
            Return _lotes
        End Get
        Set(ByVal value As List(Of Lote))
            _lotes = value
        End Set
    End Property

    Private _trasportista As Usuario
    Public Property Trasportista() As Usuario
        Get
            Return _trasportista
        End Get
        Set(ByVal value As Usuario)
            _trasportista = value
        End Set
    End Property
End Class
