create database videotienda
use videotienda

create table personas (

NRO_DOC numeric (11) primary key,
TIPO_DOC varchar (3) not null,
NOMBRES varchar (50) not null,
CELULAR numeric (11) not null,
CORREO varchar (100) not null,
DIRECCION varchar (100) not null,
TIPO_PERSONA varchar(3) not null,
CONTRASENA varchar(10) 

)

create table dominios (

TIPO_DOMINIO varchar (30),
ID_DOMINIO varchar (10),
VLR_DOMINIO varchar (50) not null

primary key (TIPO_DOMINIO, ID_DOMINIO)

)

create table categorias (

ID_CATEGORIA numeric (11) primary key,
NOM_CATEGORIA varchar(50) not null

)

create table productores (

ID_PROD numeric (11) primary key,
NOM_PROD varchar (50) not null

)

create table videojuegos (

NRO_REFERENCIA numeric (11) primary key,
NOM_VIDEOJUEGO varchar(50) not null,
IMG_VIDEOJUEGO varchar (100),
ID_PROD numeric(11)

foreign key (ID_PROD) references productores

)

create table cat_videojuegos (

ID_CAT_VIDEOJUEGOS numeric(11) primary key,
ID_CATEGORIA numeric (11),
NRO_REFERENCIA numeric (11)

foreign key (ID_CATEGORIA) references categorias,
foreign key (NRO_REFERENCIA) references videojuegos

)

create table alquiler (

ID_ALQUILER numeric (11) primary key,
FEC_ALQUILER datetime not null,
FEC_DEVOLUCION datetime not null,
VLR_ALQUILER decimal (5,0) not null,
VLR_MULTAS decimal (5,0),
NRO_DOC numeric (11)

foreign key (NRO_DOC) references personas


)

create table alq_videojuegos (

ID_ALQ_VIDEOJUEGOS numeric (11) primary key,
ID_ALQUILER numeric (11),
NRO_REFERENCIA numeric(11)

foreign key(ID_ALQUILER) references alquiler,
foreign key(NRO_REFERENCIA) references videojuegos

)
