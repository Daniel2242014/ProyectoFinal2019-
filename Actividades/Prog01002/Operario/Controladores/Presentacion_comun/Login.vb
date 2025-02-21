﻿Imports ConexionLib
Imports ConexionLib.FachadaRegistro
Imports Controladores.Extenciones

Public Class Login
    Implements ConfigurarRed.INotifyCallback
    Private contraseñaVisible As Boolean = False
    Private Shared defaultLambda As LambdaDelegate = Nothing
    Private Shared defaultRole As String = Nothing

    Public Sub New()
        Me.New(defaultLambda, defaultRole)
    End Sub

    Public Sub New(loginLambda As LambdaDelegate, rol As String)
        Me.Redirect = loginLambda
        Me.ForRole = rol
        defaultLambda = loginLambda
        defaultRole = rol
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Button1.Visible = True
        Button3.Visible = True
        Button1.Enabled = True
        Button3.Enabled = True
        NotificarDeConexion(False)
        LanguageSwap()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Tiempo.Tick 'se ejecuta un reloj cada 0.5 segundos
        Dim Tiempo As Date = Date.Now
        fecha.Text = Tiempo.ToString("dd MMMM yyyy") ' dd -> día en formato 01, 02, ..., 31. MMMM -> nombre completo del mes (enero, febrero, ..., diciembre). yyyy -> año en formato 1900, 1901, ..., 2019.
        hora.Text = Tiempo.ToString("HH:mm:ss") ' HH -> hora en formato 24hs. mm -> minutos del 00 al 59. ss -> segundos del 00 al 59
    End Sub

    Private Sub LanguageSwap()
        user.Text = Funciones_comunes.I18N("Nombre de usuario", Marco.Language)
        pass.Text = Funciones_comunes.I18N("Contraseña", Marco.Language)
        Button1.Text = Funciones_comunes.I18N("Ingresar", Marco.Language)
        Button3.Text = Funciones_comunes.I18N("Restaurar", Marco.Language)
        Button4.Text = Funciones_comunes.I18N("Configurar red", Marco.Language)
        Label1.Text = Funciones_comunes.I18N("Estado:", Marco.Language)
        Label3.Text = Funciones_comunes.I18N("Diseñado por", Marco.Language)
        Select Case ForRole
            Case Usuario.TIPO_ROL_ADMINISTRADOR
                aplicacionModo.Text = Funciones_comunes.I18N("Aplicacion del Administrador", Marco.Language)
            Case Usuario.TIPO_ROL_OPERARIO
                aplicacionModo.Text = Funciones_comunes.I18N("Aplicacion del Operario", Marco.Language)
            Case Usuario.TIPO_ROL_TRANSPORTISTA
                aplicacionModo.Text = Funciones_comunes.I18N("Aplicacion del Transportista", Marco.Language)
        End Select
        Label2.Text = Funciones_comunes.I18N("Elija su lenguaje", Marco.Language)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Tiempo.Start()
        Me.LanguageBox.Items.Clear()
        Me.LanguageBox.Items.AddRange(Funciones_comunes.Languages)
        Me.AcceptButton = Button1 ' al asignar Button1 a la propiedad AcceptButton, el evento Click de Button1 será ejecutado al presionar enter

    End Sub

    Private Sub user_Enter(sender As Object, e As EventArgs) Handles user.Enter
        If user.Text = Funciones_comunes.I18N("Nombre de usuario", Marco.Language) Then
            user.Text = ""
            user.ForeColor = Color.FromArgb(28, 28, 28)
        End If
        e1.BackColor = Color.FromArgb(18, 115, 201)
    End Sub

    Private Sub user_Leave(sender As Object, e As EventArgs) Handles user.Leave
        If String.IsNullOrEmpty(user.Text.TrimStart()) Then
            user.Text = Funciones_comunes.I18N("Nombre de usuario", Marco.Language)
            user.ForeColor = Color.FromArgb(100, 100, 100)
        End If
        e1.BackColor = Color.FromArgb(23, 23, 23)
    End Sub


    Private Sub pass_Leave(sender As Object, e As EventArgs) Handles pass.Leave
        If 0 = pass.Text.Length Then
            pass.Text = Funciones_comunes.I18N("Contraseña", Marco.Language)
            pass.PasswordChar = ""
            ver.Enabled = False
            pass.ForeColor = Color.FromArgb(100, 100, 100)
        End If
        e2.BackColor = Color.FromArgb(23, 23, 23)
    End Sub

    Private Sub pass_Enter(sender As Object, e As EventArgs) Handles pass.Enter
        If pass.Text = Funciones_comunes.I18N("Contraseña", Marco.Language) Then
            pass.Text = ""
            If contraseñaVisible Then ' asignar diseño de acuerdo al estado de contraseñaVisible
                ver.Image = Global.Controladores.My.Resources.ojo_no
                pass.PasswordChar = ""
            Else
                ver.Image = Global.Controladores.My.Resources.ojo
                pass.PasswordChar = "*"
            End If
            ver.Enabled = True
            pass.ForeColor = Color.FromArgb(28, 28, 28)
        End If
        e2.BackColor = Color.FromArgb(18, 115, 201)
    End Sub

    Private Sub ver_Click(sender As Object, e As EventArgs) Handles ver.Click
        If Not contraseñaVisible Then
            contraseñaVisible = True
            pass.PasswordChar = ""
            ver.Image = Global.Controladores.My.Resources.ojo_no
        Else
            contraseñaVisible = False
            pass.PasswordChar = "*"
            ver.Image = Global.Controladores.My.Resources.ojo
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        login()
    End Sub

    Public Redirect As LambdaDelegate = Nothing
    Public ForRole As String = Nothing

    Private Sub login()
        If Redirect Is Nothing Or ForRole Is Nothing Then
            MsgBoxI18N("No se ha configurado correctamente la clase de login")
            Return
        End If
        If Not Controladores.Fachada.getInstancia.IngresoDeUsuarioConComprobacion(user.Text, pass.Text) Then 'YA CARGA EN EL METODO AL USUARIO QUE INGRESO 
            MsgBoxI18N("Credenciales incorrectas. Intente nuevamente", MsgBoxStyle.Critical)
        Else
            If Controladores.Fachada.getInstancia.rolDeUnUsuarioPorElNombreDeUsuario(user.Text) = ForRole Then
                If Controladores.Fachada.getInstancia.usuarioInvalidado(user.Text) Then
                    MsgBoxI18N("Este usuario ha sido invalidado", MsgBoxStyle.Critical)
                    Return
                End If
                Redirect()
            Else
                MsgBoxI18NFormat("Esta aplicacion es unicamente para los {0}", ForRole)
            End If

        End If
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Principal.getInstancia.cargarPanel(Of RestablecerContraseña)(New RestablecerContraseña)
    End Sub

    Public Sub NotificarDeConexion(exitoso As Boolean, Optional config As ConfiguracionEnRed = Nothing) Implements ConfigurarRed.INotifyCallback.NotificarDeConexion
        If exitoso AndAlso (config.Database Is Nothing OrElse Fachada.getInstancia.IniciarConexcion(config)) Then
            estadoConex.Text = Funciones_comunes.I18N("Conectado", Marco.Language)
            estadoConex.ForeColor = Color.FromArgb(13, 163, 51)
            Button1.Enabled = True
            Button3.Enabled = True
            user.Enabled = True
            pass.Enabled = True
        Else
            estadoConex.Text = Funciones_comunes.I18N("Desconectado", Marco.Language)
            estadoConex.ForeColor = Color.FromArgb(180, 20, 20)
            Button1.Enabled = False
            Button3.Enabled = False
            user.Enabled = False
            pass.Enabled = False
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim config As New ConfigurarRed(Me)
        config.ShowDialog()

    End Sub

    Private Sub LanguageBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LanguageBox.SelectedIndexChanged
        Marco.Language = LanguageBox.SelectedItem
        LanguageSwap()
    End Sub

    Private Sub PanelLogin_SizeChanged(sender As Object, e As EventArgs) Handles panelLogin.SizeChanged
        super.Location = New Point((Me.Width / 2) - (super.Width / 2), (Me.Height / 2) - (super.Height / 2))
    End Sub
End Class