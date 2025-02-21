﻿Imports Controladores

Public Class Usuario

    Public Shared ReadOnly TIPO_ROL_ADMINISTRADOR As String = "A"
    Public Shared ReadOnly TIPO_ROL_OPERARIO As String = "O"
    Public Shared ReadOnly TIPO_ROL_TRANSPORTISTA As String = "T"

    Public Overrides Function ToString() As String
        Return NombreDeUsuario & " (" & Rol & ")"
    End Function

    Public Sub New(iD_usuario As Integer, tele As String, rol As String, sexo As Char, username As String, nombre As String, email As String, fechaNacimiento As Date, preguntaSecreta As String, respuestaSecreeta As String, respuestaSecreta As String, linkRastreador As String)
        Me.ID_usuario = iD_usuario
        Me.Rol = rol
        Me.sexo = sexo
        Me.NombreDeUsuario = username
        Me.Nombre = nombre
        Me.Telefono = tele
        Me.Email = email
        Me.FechaNacimiento = fechaNacimiento
        Me.PreguntaSecreta = preguntaSecreta
        Me.RespuestaSecreta = respuestaSecreta
        Me.LinkRastreador = linkRastreador
        Me.MediosPermitidos = New List(Of MedioDeTransporte)
    End Sub

    Public Sub New()

    End Sub

    Private _fechaCreacion As DateTime
    Public Property FechaCreacion() As DateTime
        Get
            Return _fechaCreacion
        End Get
        Set(ByVal value As DateTime)
            _fechaCreacion = value
        End Set
    End Property

    Private _creador As Usuario
    Public Property Creador() As Usuario
        Get
            Return _creador
        End Get
        Set(ByVal value As Usuario)
            _creador = value
        End Set
    End Property

    Public Shared ReadOnly Property TIPOS_ROLES() As String()
        Get
            Return {TIPO_ROL_ADMINISTRADOR, TIPO_ROL_OPERARIO, TIPO_ROL_TRANSPORTISTA}
        End Get
    End Property

    Private _apellido As String
    Public Property Apellido() As String
        Get
            Return _apellido
        End Get
        Set(ByVal value As String)
            _apellido = value
        End Set
    End Property


    Private _telefono As String
    Public Property Telefono() As String
        Get
            Return _telefono
        End Get
        Set(ByVal value As String)
            _telefono = value
        End Set
    End Property

    Private _nombreUsuario As String
    Public Property NombreDeUsuario() As String
        Get
            Return _nombreUsuario
        End Get
        Set(ByVal value As String)
            _nombreUsuario = value
        End Set
    End Property

    Private _ID_usuario As Integer
    Public Property ID_usuario() As Integer
        Get
            Return _ID_usuario
        End Get
        Set(ByVal value As Integer)
            If value >= 0 Then
                _ID_usuario = value
            Else
                Throw New Exception("El id no puede ser negativo")
            End If
        End Set
    End Property

    Private _rol As String
    Public Property Rol() As String
        Get
            Return _rol
        End Get
        Set(ByVal value As String)
            Select Case value
                Case "T"
                    _rol = Me.TIPO_ROL_TRANSPORTISTA
                Case "O"
                    _rol = Me.TIPO_ROL_OPERARIO
                Case "A"
                    _rol = Me.TIPO_ROL_ADMINISTRADOR
                Case Else
                    Throw New Exception("Rol invalido")
            End Select

            If TIPOS_ROLES.Contains(value) Then
                _rol = value
            Else
                Throw New Exception("Rol invalido")
            End If

        End Set
    End Property

    Private _sexo As Char
    Public Property sexo() As Char
        Get
            Return _sexo
        End Get
        Set(ByVal value As Char)
            _sexo = value
        End Set
    End Property

    Private _nombre As String
    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Private _email As String
    Public Property Email() As String
        Get
            Return _email
        End Get
        Set(ByVal value As String)
            _email = value
        End Set
    End Property

    Private _fechaNac As DateTime
    Public Property FechaNacimiento() As DateTime
        Get
            Return _fechaNac
        End Get
        Set(ByVal value As DateTime)
            _fechaNac = value
        End Set
    End Property

    Private _preguntaSecreta As String
    Public Property PreguntaSecreta() As String
        Get
            Return _preguntaSecreta
        End Get
        Set(ByVal value As String)
            _preguntaSecreta = value
        End Set
    End Property

    Private _respuestaSecreeta As String
    Public Property RespuestaSecreta() As String
        Get
            Return _respuestaSecreeta
        End Get
        Set(ByVal value As String)
            _respuestaSecreeta = value
        End Set
    End Property

    Private _linkRastreador As String
    Public Property LinkRastreador() As String
        Get
            Return _linkRastreador
        End Get
        Set(ByVal value As String)
            _linkRastreador = value
        End Set
    End Property

    Private permitidos As List(Of MedioDeTransporte)
    Public Property MediosPermitidos() As List(Of MedioDeTransporte)
        Get
            Return permitidos
        End Get
        Set(ByVal value As List(Of MedioDeTransporte))
            permitidos = value
        End Set
    End Property

    Public Overrides Function Equals(obj As Object) As Boolean
        Dim usuario = TryCast(obj, Usuario)
        Return usuario IsNot Nothing AndAlso
               ID_usuario = usuario.ID_usuario
    End Function


End Class
