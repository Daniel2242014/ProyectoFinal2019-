#!/bin/bash
#VERCION 2.0 - 4/8 SEGUNDA ENTREGA desarrolado por Bit (3°BD 2019)
yum install ncurses-compat-libs 
groupadd informix
useradd -g informix -s /bin/bash -m informix

echo "postgres" | passwd --stdin informix
echo "sqlturbo	1526/tcp" >> /etc/services
echo "sqlexec	9088/tcp" >> /etc/services
echo "sqlexec	9088/udp" >> /etc/services
echo "sqlexec -ssl	9089/tcp" >> /etc/services
echo "sqlexec -ssl	9089/tcp" >> /etc/services
echo "Informix" >> /etc/hostname
echo "0.0.0.0 Informix" >> /etc/hosts

echo "Descargando archivos de informix...."
git clone https://github.com/Daniel2242014/Informix2
cd Informix2
mkdir descom
echo "Descomprimiendo...."
cat informix.tar.001 informix.tar.002 informix.tar.003 informix.tar.004 informix.tar.005 informix.tar.006 informix.tar.007 informix.tar.008 | tar -xvif - -C descom
echo "Se prosedera a ingrezar dentro del instalador, por favor ingrese las opciones por defecto"
descom/ids_install 
echo "Esperando que informix termine de instaladr en 2º plano"
sleep 5
echo "eliminando archivos de instalacio de informix"
cd ..
rm -rf Informix2
echo "Realizando configuraciones"
touch /etc/profile.d/zz_configInformix.sh
cat >> /etc/profile.d/zz_configInformix.sh<<EOF
export INFORMIXDIR='/opt/IBM/Informix_Software_Bundle'
export ONCONFIG=onconfig.bit
export INFORMIXSERVER=bit
export INFORMIXSQLHOSTS='/opt/IBM/Informix_Software_Bundle/etc/sqlhosts.std'
export PATH=/opt/IBM/Informix_Software_Bundle/bin:\$PATH
export DBDATE=DMY4/
export TERM=vt100
export TERMCAP='/opt/IBM/Informix_Software_Bundle/etc/termcap'
EOF
cd /opt/IBM/Informix_Software_Bundle/
mkdir dbspaces 
chmod 770 dbspaces
chown informix:informix dbspaces 
cd dbspaces
touch rootdbs
chmod 660 rootdbs 
chown informix:informix rootdbs 
touch tempdbs
chmod 660 tempdbs
chown informix:informix tempdbs 
touch root_mirror
chmod 660 root_mirror
chown informix:informix root_mirror
touch datosdbs
chmod 660 datosdbs 
chown informix:informix datosdbs 
cd /opt/IBM/Informix_Software_Bundle/etc
cp onconfig.std onconfig.bit
sed -i "s/ROOTNAME.*/ROOTNAME rootdbs/" onconfig.bit
sed -i 's/ROOTPATH.*/ROOTPATH \/opt\/IBM\/Informix_Software_Bundle\/dbspaces\/rootdbs/' onconfig.bit
sed -i "s/ROOTSIZE.*/ROOTSIZE 1000000/" onconfig.bit
sed -i 's/MIRRORPATH.*/MIRRORPATH \/opt\/IBM\/Informix_Software_Bundle\/dbspaces\/root_mirror/' onconfig.bit
sed -i 's/DBSPACETEMP.*/DBSPACETEMP \/opt\/IBM\/Informix_Software_Bundle\/dbspaces\/tempdbs/' onconfig.bit
sed -i "s/SERVERNUM.*/SERVERNUM 0/" onconfig.bit
sed -i "s/DBSERVERNAME.*/DBSERVERNAME bit/" onconfig.bit
sed -i "s/TAPEDEV.*/TAPEDEV \/dev\/null/" onconfig.bit
sed -i "s/LTAPEDEV.*/LTAPEDEV \/dev\/null/" onconfig.bit
cat >>/opt/IBM/Informix_Software_Bundle/etc/sqlhosts.std <<EOF
bit onsoctcp 192.168.1.100 9088
EOF
touch /var/DataConfiguracionABMusuariosSO/I_Inxo
chmod 770 /opt/IBM
chown informix:informix /opt/IBM
clear
echo "Como uno de los ultimos pasos, se debe reiniciar el pc, aunque para finalizar la instalacion por favor ejecute source setup.sh" 
echo "Toque cualquier boton para continuar"
read fff
echo "Reiniciando en 3"
sleep 1
echo "2"
sleep 1
echo "1"
sleep 1
shutdown -r now


