﻿Imports Controladores

Public Class SUB_Usuario
    Implements IAlfaInterface
    Private user As Usuario
    Private padre As Alfa
    Private tamañoDuplicado As Double
    Private propiedadesDuplicas As New List(Of Tuple(Of Size, Point))

    Public Sub New(usuario As Usuario)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        nom.Text = usuario.NombreDeUsuario
        Select Case usuario.Rol
            Case Usuario.TIPO_ROL_ADMINISTRADOR
                rol.Text = "Administrativo"
            Case Usuario.TIPO_ROL_OPERARIO
                rol.Text = "Operario"
            Case Usuario.TIPO_ROL_TRANSPORTISTA
                rol.Text = "Transportista"
        End Select
        user = usuario
        tamañoDuplicado = Me.Size.Height
        propiedadesDuplicas.Add(New Tuple(Of Size, Point)(nom.Size, nom.Location))
        propiedadesDuplicas.Add(New Tuple(Of Size, Point)(Label1.Size, Label1.Location))
        propiedadesDuplicas.Add(New Tuple(Of Size, Point)(rol.Size, rol.Location))
        propiedadesDuplicas.Add(New Tuple(Of Size, Point)(Button1.Size, Button1.Location))

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Button1.Text = Controladores.Funciones_comunes.I18N("Ver mas", Marco.getInstancia.Language)
    End Sub

    Public Sub darAncho(x As Integer) Implements IAlfaInterface.darAncho
        Me.Width = x
        propiedadesDuplicas.RemoveAt(3)
        propiedadesDuplicas.Add(New Tuple(Of Size, Point)(Button1.Size, Button1.Location))
    End Sub

    Public Sub darAlfa(alfa As Alfa) Implements IAlfaInterface.darAlfa
        darAncho(alfa.tamaño.Width)
        Me.padre = alfa
    End Sub

    Public Sub Reacomodarpropiedades() Implements IAlfaInterface.Reacomodarpropiedades
        Me.Height = tamañoDuplicado
        nom.Size = propiedadesDuplicas(0).Item1
        nom.Location = propiedadesDuplicas(0).Item2
        Label1.Size = propiedadesDuplicas(1).Item1
        Label1.Location = propiedadesDuplicas(1).Item2
        rol.Size = propiedadesDuplicas(2).Item1
        rol.Location = propiedadesDuplicas(2).Item2
        Button1.Size = propiedadesDuplicas(3).Item1
        Button1.Location = propiedadesDuplicas(3).Item2
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        padre.Devolver(user)
    End Sub


    Public Function dameForm() As Form Implements IAlfaInterface.dameForm
        Return Me
    End Function

    Public Function dameContenido() As Object Implements IAlfaInterface.dameContenido
        Return user
    End Function
End Class