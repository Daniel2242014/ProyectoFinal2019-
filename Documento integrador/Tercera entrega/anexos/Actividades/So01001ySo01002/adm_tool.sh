#!/bin/bash
#VERCION 2.0 - 4/8 SEGUNDA ENTREGA desarrolado por Bit (3°BD 2019)

Menussh()
{
 namaes=("Cambiar_clave_ssh" "Crear_Llave_Ssh" "Listar_Usuarios_SSH" "Habilitar_Usuario_SSH" "Deshabilitar_Usuario_SSH" "Usuarios_con_Certificado")
 fnctns=("cambiarLlave" "crearLlaveSsh" "usuariosConectados" "habilitarSsh" "deshabilitarSsh" "listarUsuariosConPssh")
 menu "namaes[@]" "fnctns[@]"
}

MenuProsesos()
{
 namaes=("Lista_Procesos" "Matar_Proceso")
 fnctns=("listaProcesos" "killProc")
 menu "namaes[@]" "fnctns[@]"
}

listarSLTA()
{
 cat /var/SLTAUserLog
 read i
}

MenuLog()
{
 namaes=("Log_Exitoso" "Log_Fallido" "Logs_Usuarios")
 fnctns=('listarWtmp' 'listarBtmp' 'listarSLTA')
 menu "namaes[@]" "fnctns[@]"
}

menuBackUp()
{
 namaes=('Calendario_Backups' 'Listar_Backups' 'Enviar_Backups' 'Crear_total' 'Crear_incremental' 'Restaurar' 'Lista_De_BBDD_A_Respaldar')
 fnctns=('calendarioBackups' 'listarBackups' 'send_backups' 'totalManual2' 'incrementalManual2' 'restaurar2' 'editarBBDDPermitidas')
 menu "namaes[@]" "fnctns[@]"
}

menuServicios()
{
 namaes=('Lista_serivicos' 'Buscar_Servicio')
 fnctns=('estadoServicios' 'buscarServicio')
 menu "namaes[@]" "fnctns[@]"
}


if test $(git --help 2>/dev/null | wc -l ) -ne 0
then
    if test $USER = "root" # Debe ser el usuario root quien utilice el shell 
    then
	if test $(echo $PATH | grep "/var/DataConfiguracionABMusuariosSO/"|wc -l) -eq 1 && ! test -f /etc/profile.d/z_ABMConfiguration.sh
	then
	    echo "El sistema ha sido eliminado utilizando setup llamado con el comando sh"
	    echo "Use el comando 'exit' para volver a ingresar al sistema y luego ejecute este software nuevamente"
	else
	    if ! test $(echo $PATH | grep "/var/DataConfiguracionABMusuariosSO/"|wc -l) -eq 1 &&  test -f /etc/profile.d/z_ABMConfiguration.sh
	    then
		echo "ha instalado el sistema sin usar source, salga y vuelva a ingresar al sistema"
	    else
		if test $(echo $PATH | grep "/var/DataConfiguracionABMusuariosSO/"|wc -l) -eq 1  #revisa que este la ubicacion de la instalacion 
		then
		    clear
		    #Se importan un conjunto de archivos llenos de metodos a utilizar en la ABM
		    source /var/DataConfiguracionABMusuariosSO/lib/lib_menu.sh
                    source /var/DataConfiguracionABMusuariosSO/lib/fireMod.sh
		    source /var/DataConfiguracionABMusuariosSO/lib/DT.sh
		    source /var/DataConfiguracionABMusuariosSO/lib/expiracionUsuario.sh
		    source /var/DataConfiguracionABMusuariosSO/lib/FuncionesBBDD.sh
		    source /var/DataConfiguracionABMusuariosSO/lib/GP.sh
		    source /var/DataConfiguracionABMusuariosSO/lib/GS.sh
		    source /var/DataConfiguracionABMusuariosSO/lib/NDiasHasta.sh
		    source /var/DataConfiguracionABMusuariosSO/lib/pass.sh
		    source /var/DataConfiguracionABMusuariosSO/lib/shell.sh
		    source /var/DataConfiguracionABMusuariosSO/lib/UDI.sh
		    source /var/DataConfiguracionABMusuariosSO/lib/userE.sh
		    source /var/DataConfiguracionABMusuariosSO/lib/fechacal.sh
		    source /var/DataConfiguracionABMusuariosSO/lib/sudoUser.sh
		    source /var/DataConfiguracionABMusuariosSO/lib/backup_functions.sh
		    source /var/DataConfiguracionABMusuariosSO/lib/allowed.sh
	            source /var/DataConfiguracionABMusuariosSO/lib/re_sysmaster.sh
		    source /var/DataConfiguracionABMusuariosSO/sub_shell/agregarUsuario.sh 
		    source /var/DataConfiguracionABMusuariosSO/sub_shell/restaurarBackup.sh
		    source /var/DataConfiguracionABMusuariosSO/sub_shell/ModificarUsuario.sh 
		    source /var/DataConfiguracionABMusuariosSO/sub_shell/eliminarUsuario.sh
		    source /var/DataConfiguracionABMusuariosSO/sub_shell/listarUsuarios.sh 
		    source /var/DataConfiguracionABMusuariosSO/sub_shell/agregarGrupo.sh 
		    source /var/DataConfiguracionABMusuariosSO/sub_shell/ModificarGrupo.sh 
		    source /var/DataConfiguracionABMusuariosSO/sub_shell/EliminarGrupo.sh 
		    source /var/DataConfiguracionABMusuariosSO/sub_shell/listarGrupos.sh 
		    source /var/DataConfiguracionABMusuariosSO/sub_shell/Preferencias.sh
		    source /var/DataConfiguracionABMusuariosSO/sub_shell/uninstall.sh
		    source /var/DataConfiguracionABMusuariosSO/sub_shell/cambiarLlaveSsh.sh
		    source /var/DataConfiguracionABMusuariosSO/sub_shell/estadoRedes.sh
		    source /var/DataConfiguracionABMusuariosSO/sub_shell/estadoSockets.sh
		    source /var/DataConfiguracionABMusuariosSO/sub_shell/listaProcesos.sh
		    source /var/DataConfiguracionABMusuariosSO/sub_shell/matarProceso.sh
		    source /var/DataConfiguracionABMusuariosSO/sub_shell/configurarRed.sh
		    source /var/DataConfiguracionABMusuariosSO/sub_shell/crearLlaveSsh.sh
		    source /var/DataConfiguracionABMusuariosSO/sub_shell/listarLogs.sh
		    source /var/DataConfiguracionABMusuariosSO/sub_shell/calendarioBackups.sh
		    source /var/DataConfiguracionABMusuariosSO/sub_shell/listarBackups.sh
		    source /var/DataConfiguracionABMusuariosSO/sub_shell/usuariosViaSsh.sh
		    source /var/DataConfiguracionABMusuariosSO/sub_shell/habilitarSsh.sh
		    source /var/DataConfiguracionABMusuariosSO/sub_shell/deshabilitarSsh.sh
		    source /var/DataConfiguracionABMusuariosSO/sub_shell/estadoServicios.sh
		    source /var/DataConfiguracionABMusuariosSO/sub_shell/send_backups.sh
		    source /var/DataConfiguracionABMusuariosSO/sub_shell/smRedes.sh
		    source /var/DataConfiguracionABMusuariosSO/sub_shell/menuinformix.sh
		    source /var/DataConfiguracionABMusuariosSO/sub_shell/menuFirewall.sh
		    source /var/DataConfiguracionABMusuariosSO/sub_shell/usuariosConClavePublica.sh	            
		

		    carpetaBase='/var/DataConfiguracionABMusuariosSO'

		    respuesta="" #El dato pasado por los return solo puede ser numerico, entonces utilizamos una variable externa donde se cargen las salidas, como si fuera un $? pero con mayor capasidad

		    echo "   _____________________________________________  "
		    echo "   |                                           | "
		    echo "   |                                           | "
		    echo "   |    Centro de computos y Abm usuarios      | "
		    echo "   |                  por Bit                  | "
		    echo "   |                Vercion 3.0                | "
		    echo "   |___________________________________________| "
		    echo "" 
		    # se carga un array con los nombre de las opciones del menu

		    nombres=('Agregar_usuario' 'Modificar_usuarios' 'Eliminar_usuarios' 'Listar_usuarios' 'Agregar_grupo' 'editar_grupo' 'eliminar_grupo' 'Listar_grupo' 'Editar_preferencias' 'Reinstalar' 'Desinstalar' 'SSH' 'Estado_Sockets' 'Prosesos' 'Logs_login' 'Backups' 'Servicios' 'Redes' 'Informix' 'Firewall')
		    # se carga el nombre de los metodos que llaman dichas opciones
		    direcionesSetUp=('agregarUsuario' 'ModificarUsuario' 'eliminarUsuarios' 'listarUsuarios' 'agregarGrupo' 'ModificarGrupo' 'eliminarGrupo' 'MenuListarGrupos' 'Preferencias' 'ConfiguracionDelAmbienteDeTrabajo' 'desinstalar' 'Menussh' 'socketList' 'MenuProsesos' 'MenuLog' 'menuBackUp' 'menuServicios' 'smRedes' 'menuInformix' 'menuFirewall')
		    menu 'nombres[@]' 'direcionesSetUp[@]' #se llama al metodo menu
		fi	
	    fi
	fi
    else
	echo "Debe ser root para ejecutar este software"
    fi
else
    echo "Debe tener instalado Git para utilizar este shell "
fi

