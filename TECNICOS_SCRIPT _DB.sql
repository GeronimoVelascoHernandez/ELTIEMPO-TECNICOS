CREATE TABLE Sucursal(
idSucursal int IDENTITY(1,1) PRIMARY KEY NOT NULL,
nombre varchar(50) NOT NULL
);

CREATE TABLE Elemento(
idElemento int IDENTITY(1,1) PRIMARY KEY NOT NULL,
nombre varchar(50) NOT NULL
);

CREATE TABLE Tecnico(
idTecnico varchar(50) PRIMARY KEY NOT NULL,
nombre varchar(50) NOT NULL,
salario int NOT NULL,
IdSucursal int not null,
foreign key(IdSucursal) references Sucursal(idSucursal) 
);

CREATE TABLE TecnicoElemento(
idTecnicoElemento int IDENTITY(1,1)  PRIMARY KEY NOT NULL,
cantidad int NOT NULL,
idTecnico varchar(50) NOT NULL,
idElemento int NOT NULL,
foreign key(idTecnico) references Tecnico(idTecnico),
foreign key (idElemento) references Elemento(idElemento) 
);

BEGIN TRANSACTION;  
BEGIN TRY  
     INSERT INTO Sucursal(nombre)
	 VALUES ('Sucursal occidente'),('Sucursal del norte'),('Sucursal sur');
	 COMMIT TRANSACTION;  
END TRY  
BEGIN CATCH  
      ROLLBACK TRANSACTION;  
END CATCH;

BEGIN TRANSACTION;  
BEGIN TRY  
     INSERT INTO Elemento(nombre)
	 VALUES ('Martillo'),('Pico'),('Botas');
	 COMMIT TRANSACTION;  
END TRY  
BEGIN CATCH  
      ROLLBACK TRANSACTION;  
END CATCH;