CREATE database sorteoEstacionamientos;

use sorteoEstacionamientos;

/*--------------------------------TABLAS--------------------------------*/
/*Creamos la tabla de los participantes*/
create table tbParticipantes
(`IdParticipante` int(11) not null auto_increment, 
 `partIdTipoParticipante` int(11) not null, 
 `partCURP` varchar(20) not null, 
 `partBoleta` varchar(15) not null, 
 `partNombre` varchar(50) not null, 
 `partPrimerAp` varchar(50) not null, 
 `partSegundoAp` varchar(50) not null, 
 `partIdCarrera` int(11) not null,
 `partIdSemestre` int(11) not null, 
 `partEmail` varchar(50) not null, 
 `partNoTelefono` varchar(20) not null, 
 `partIdEstado` int(11) not null, 
 `partIdTipoPlaca` int(11) not null, 
 `partPlaca` varchar(50) not null, 
 `partMarca` varchar(50) default null, 
 `partModelo` varchar(50) default null,
 `partIdColor` int(11) not null, 
 `partVersion` varchar(50) default null, 
 `partAnio` int(4) not null, 
 /*-----------ARCHIVOS---------------*/
 `partCredencialIPN` varchar(50) not null,
 `partTarjetaCirculacion` varchar(50) not null, 
 `partLicencia` varchar(50) not null, 
 `partComprobante` varchar(50) not null,
 /*-----------ARCHIVOS---------------*/
 `partStatus` bit(1) not null,
 `partTipoVehiculo` varchar(45) default null,
  primary key (`IdParticipante`),
  FOREIGN KEY (`partIdTipoParticipante`) REFERENCES cattipoparticipante(IdTipoParticipante),
  FOREIGN KEY (`partIdCarrera`) REFERENCES catcarrera(IdCarrera),
  FOREIGN KEY (`partIdSemestre`) REFERENCES catsemestre(IdSemestre),
  FOREIGN KEY (`partIdEstado`) REFERENCES catestados(IdEstado),
  FOREIGN KEY (`partIdTipoPlaca`) REFERENCES cattipoplaca(IdTipoPlaca),
  FOREIGN KEY (`partIdColor`) REFERENCES catcolores(IdColor)
  ) engine=InnoDB default charset=latin1;
  


/*Creamos la tabla de los ganadores*/
CREATE TABLE `tbganadores` (
  `IdGanador` int(11) NOT NULL AUTO_INCREMENT,
  `ganIdParticipante` int(11) NOT NULL,
  `ganSorteoAM` varchar(1) NOT NULL,
  PRIMARY KEY (`IdGanador`),
  FOREIGN KEY (`ganIdParticipante`) REFERENCES tbParticipantes(IdParticipante)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Creamos la tabla de los usuarios
CREATE TABLE `tbusuarios` (
  `IdUsuario` int(11) NOT NULL AUTO_INCREMENT,
  `usuCURP` varchar(20) NOT NULL,
  `usuEmail` varchar(80) NOT NULL,
  `usuUsuario` varchar(20) NOT NULL,
  `usuPassword` varchar(255) NOT NULL,
  `usuFechaAlta` datetime NOT NULL,
  `usuIdPrivilegio` int(11) NOT NULL,
  `usuStatus` bit(1) NOT NULL,
  PRIMARY KEY (`IdUsuario`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;*/

/*Creamos la tabla de las convocatorias
CREATE TABLE `tbconvocatorias` (
  `IdConv` int(11) NOT NULL AUTO_INCREMENT,
  `LinkConv`
	PRIMARY KEY (`IdConv`)
  );*/
/*--------------------------------TABLAS--------------------------------*/
                             
/*--------------------------------CATALOGOS--------------------------------*/
/*Creamos el catalogo del TipoParticipante*/
create table `catTipoParticipante` (`IdTipoParticipante` int(11) not null auto_increment,
									`TipoParticipante` varchar(50) not null,
									primary key (`IdTipoParticipante`)
) engine=InnoDB default charset=latin1;

/*Creamos el catalogo de colores*/
create table `catColores` (`IdColor` int(11) not null auto_increment,
						   `colorNombre` varchar(50) not null,
						   primary key (`IdColor`)
) engine=InnoDB default charset=latin1;
						
/*Creamos el catalogo de los estados*/
create table `catEstados` (`IdEstado` int(11) not null auto_increment,
						   `edoNombre` varchar(20) not null,
						   primary key (`IdEstado`)
) engine=InnoDB default charset=latin1; 
                           
                           
/*Creamos catalogo de Carreras*/
create table `catCarrera` (`IdCarrera` int(11) not null auto_increment,
						   `Carrera` varchar(50) not null,
						   primary key (`IdCarrera`)
) engine=InnoDB default charset=latin1; 


/*Creamos catalogo de Semestres*/
create table `catSemestre` (`IdSemestre` int(11) not null auto_increment,
						   `Semestre` int(2) not null,
						   primary key (`IdSemestre`)
) engine=InnoDB default charset=latin1; 


/*Creamos el catalogo del tipo de placa*/
CREATE TABLE `catTipoPlaca` (`IdTipoPlaca` int(11) NOT NULL AUTO_INCREMENT,
							`tipoPlaca` varchar(30) NOT NULL,
							PRIMARY KEY (`IdTipoPlaca`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;





/*--------------------------------CATALOGOS--------------------------------*/

