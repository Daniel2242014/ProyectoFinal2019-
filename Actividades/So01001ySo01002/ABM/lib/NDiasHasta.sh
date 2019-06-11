#!bin/bash

# VERCION 1.0 - 25/6 PRIMERA ENTREGA desarrolado por Bit (3°BD 2019)

verifNumDias() #Verifica que un numero el cual sera utilizado como numero de dias hasta un evento sea realmente un numero de no mas de 4 cifras 
{
verif=0
while test $verif -eq 0
do 
	case $1	in #puede tener multiples propositos, por eso mismo se pasa dicho proposito por parametros
	1)
		echo "Ingrese el numero de dias que el sistema avisa antes que la contraseña caduque(No mas de 4 digitos)" 
		echo "No ingrese ninguna para que use la predeterminada" 
	;;

	2)
		echo "Ingrese el tiempo por el cual las contraseñas seran validas (Sino ingresa ninguna quedara por defecto (no mas de 4 dijitos)"
	;;

	3)
		echo "Numero de dias antes del bloqueo de la cuenta (Sino ingresa quedara por defecto) (No mas de 4 dijitos)  "
	;;
	
	esac

	read dato #Ingreo de datos
	if ! test -z $dato 
	then 
		if test $(echo "$dato" | grep -e "^[1-9][0-9]\{0,3\}$\|^[0-9]$" | wc -l ) -eq 1 #verifica que se trate de un numero del 0-9999
		then
			respuesta="$dato" #Salida de datos
			verif=1 #Se rompe el bucle 
		else
			echo "Entrada invalida, debe ser solo numerica, y no mayor a 4 cifras" 
		fi

	 else 		
		respuesta="POR DEFECTO" #Salida por defecto
		verif=1	#Se rompe el bucle 		
	 fi 	

done
}

mostrarNumD() #Nos devuelve el numero de dias que pueden ser de advertencia, de actividad luego que caduque la passwd y de valides de la password (no en orden como se cito aqui) 
{
case $1 in
	2)
		respuesta=$(grep -e "^$2:" /etc/shadow|cut -d: -f5)
	;;

	1)
		respuesta=$(grep -e "^$2:" /etc/shadow|cut -d: -f6)
	;;

	3)
		respuesta=$(grep -e "^$2:" /etc/shadow|cut -d: -f7)
	;;
esac
}



