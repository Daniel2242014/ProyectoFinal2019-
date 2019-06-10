Mgrupo=''
ModificarGrupo() {
	
	verif5=0
	while test $verif5 -eq 0
	do
		echo "Ingrese el nombre del grupo a modificar, si lodeja vacio se cancelara la operacion"
		read dato	
		if test -z $dato
		then
			verif5=2
			echo "Proseso cancelado, toque enter para continuar "
			read ff
		else
			if test $(cut -d: -f1,3 /etc/group | grep -e "^$dato:[1-9][0-9]\{3\}$"|wc -l) -eq 1
			then
				Mgrupo=$dato
				verif5=1
	
			else
				echo "Entrada invalida"
			fi	
		fi
	done

	if test $verif5 -eq 1
	then
		eu1=('Cambiar_nombre' 'Cambiar_GID')
		eu2=('MGNombre' 'MGGID')	
	
		menu 'eu1[@]' 'eu2[@]'	

		ary1=(${nombres[@]})
		ary2=(${direcionesSetUp[@]})

	fi
}	
	


MGNombre() 
{
	verif=0
	while test $verif -eq 0 #Bucle que se repite hasta que se ingrese un nombre de usuario valido 
	do	
		echo "Ingrese el nuevo nombre del grupo (Dejelo vacio para cancelar la operacion)"	
		read dato	
		if ! test -z $dato
		then 
			if test $(echo "$dato" | grep -e '[a-zA-Z][a-zA-Z0-9]\+$'| wc -l ) -eq 1 #Comprueba que el nombre comienze con una letra, luego podra tener el numero de letras o numeros que dese
			then
				if ! test -z $dato && test $(cat '/etc/group'| cut -d: -f1| grep -x "$dato"| wc -l) -eq 0 #Comprueba que el grupo no exista en el sistema  
				then			
					groupmod -n $dato $Mgrupo 2> /dev/null
					Mgrupo=$dato #Carga el valor en la variable Mgrupo 					
					verif=1 #Rompe bucle 
				else	
					error "Usuario ya ingrezado" #Utiliza el metodo 'error' el cual pinta en rojo el error, de esta forma es mas facil diferenciarlo  
				fi
			else 
				error "Formato no valido " 
			fi	
		else
			echo "Operacion cancelada, toque cualquier boton para continuar"
			read ff
			verif=2
		fi
	done
}

MGGID()
{
	verif=0
	verGIDGrupo $Mgrupo
	echo "Su actual GID es: $respuesta"
		while test $verif -eq 0 
		do
			echo "Ingrese el GID (se cancelara si no se ingreza) (de 4 cifras)" 
			read dato #Ingreo de informacion 	
			if ! test -z $dato 
			then
				if test $(cat '/etc/group'| cut -d: -f3| grep "$dato"| wc -l) -eq 0 #Verifica que ña UID no exista 
				then
					if test $(echo $dato| grep -e "^[1-9][0-9]\{3\}$"|wc -l) -eq 1 #El numero tiene que ser de 4 cifras numericas 
					then	 			
						groupmod -g $dato $Mgrupo 2> /dev/null
						verif=1 #rompe el bucle 
						echo "Operacion realizada, toque enter para continuar"
						read f
					else
						error "Formato del numero invalido (debe ser de 4 cifras)"
					fi
				else
					error "Ese GID ya existe, toque enter para continuar" 
				fi
			else 			
				echo "Se cancela el proseso, toque cualquier boton para continuar"
				verif=1 #rompe el bucle 									
				read ff			
			fi

		done


}

verGIDGrupo()
{
	respuesta=$(cut -d: -f1,3 /etc/group | grep -e "^$1:"|cut -d: -f2)

}


