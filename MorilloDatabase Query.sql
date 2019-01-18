/*CREATE DATABASE HospitalesDB;*/

/*
/* 1 */
CREATE TABLE Direcciones(
	ID_Direccion int IDENTITY(1,1) PRIMARY KEY,
	Ciudad varchar(255),
	Sector varchar(255),
	Codigo_Postal varchar(255),
	Calle varchar(255),
	Residencial varchar(255),
	Direccion varchar(255)
);*/

/*
	Ciudad varchar(255),
	Sector varchar(255),
	Calle varchar(255),
	#_Residencia varchar(255)
	Residencial varchar(255)
*/

/* 2 */
CREATE TABLE Hospitales(
	ID_Hospital int IDENTITY(1,1) PRIMARY KEY,
	Nombre varchar(255),
	Ciudad varchar(255),
	Sector varchar(255),
	Calle varchar(255),
	#_Residencia int,
	Telefono varchar(255)
);

/* 3 */
CREATE TABLE Especialidades(
	ID_Especialidad int IDENTITY(1,1) PRIMARY KEY,
	Nombre varchar(255),
	Descripcion varchar(255)
);

/* 4 */
CREATE TABLE Medicos(
	ID_Medico int IDENTITY(1,1) PRIMARY KEY,
	Nombre varchar(255) NOT NULL,
	Apellido varchar(255) NOT NULL,
	Cedula varchar(255) NOT NULL,
	Ciudad varchar(255) NOT NULL,
	Sector varchar(255) NOT NULL,
	Calle varchar(255) NOT NULL,
	#_Residencia int NOT NULL,
	Telefono varchar(255) NOT NULL
);

/* 5 */
CREATE TABLE Medico_Especialidad(
	ID_MedicoEspecialidad int IDENTITY(1,1) PRIMARY KEY,
	ID_Medico int,
	ID_Especialidad int, 
	CONSTRAINT ID_Medico FOREIGN KEY (ID_Medico) REFERENCES Medicos(ID_Medico),
	CONSTRAINT ID_Especialidad FOREIGN KEY (ID_Especialidad) REFERENCES Especialidades(ID_Especialidad)	
);
/* 6 */
CREATE TABLE Enfermeras(
	ID_Enfermera int IDENTITY(1,1) PRIMARY KEY,
	Nombre varchar(255),
	Apellido varchar(255),
	Cedula varchar(255),
	Ciudad varchar(255),
	Sector varchar(255),
	Calle varchar(255),
	#_Residencia int,
	Telefono varchar(255)
);

/* 7 */
CREATE TABLE Pacientes(
	ID_Paciente int IDENTITY(1,1) PRIMARY KEY,
	Nombre varchar(255) NOT NULL,
	Cedula varchar(255) NOT NULL,
	Apellido varchar(255) NOT NULL,
	Telefono varchar(255) NOT NULL,
	Genero varchar(255) NOT NULL,
	Edad int NOT NULL,
	Ciudad varchar(255),
	Sector varchar(255),
	Calle varchar(255),
	#_Residencia int,
	Dia_Nacimiento int NOT NULL,
	Mes_Nacimiento int NOT NULL,
	Ano_Nacimiento int NOT NULL,
	Email varchar(255),
	NSS varchar(255) NOT NULL,
	Tipo_Sangre varchar(255) NOT NULL
);

/* 8 */
CREATE TABLE Citas(
	ID_Cita int IDENTITY(1,1) PRIMARY KEY,
	ID_Paciente int FOREIGN KEY REFERENCES Pacientes(ID_Paciente),
	ID_Medico int FOREIGN KEY REFERENCES Medicos(ID_Medico),
	ID_Hospital int FOREIGN KEY REFERENCES Hospitales(ID_Hospital),
	Fecha_Agendada varchar(255),
	Mes int,
	Dia int, 
	Año int,
	Descripcion varchar(255)
);

/* 9 */
CREATE TABLE Visitas(
	ID_Visita int IDENTITY(1,1) PRIMARY KEY,
	ID_Paciente int FOREIGN KEY REFERENCES Pacientes(ID_Paciente) NOT NULL,
	ID_Hospital int FOREIGN KEY REFERENCES Hospitales(ID_Hospital) NOT NULL,
	Tipo varchar(255),
	Camilla int,
	ID_Enfermera int FOREIGN KEY REFERENCES Enfermeras(ID_Enfermera) NOT NULL,
	ID_Cita int FOREIGN KEY REFERENCES Citas(ID_Cita) NOT NULL,
	Fecha_Llegada varchar(255) NOT NULL,
	Turno int
);

/* 10 */
CREATE TABLE Licencias(
	ID_Licencia int IDENTITY(1,1) PRIMARY KEY,
	ID_Visita int FOREIGN KEY REFERENCES Visitas(ID_Visita),
	ID_Medico int FOREIGN KEY REFERENCES Medicos(ID_Medico),
	ID_Hospital int FOREIGN KEY REFERENCES Hospitales(ID_Hospital),
	Descripcion varchar(255)
);

/* 11 */
CREATE TABLE Enfermedades (
  ID_Enfermedad int PRIMARY KEY,
  Nombre varchar(255) NOT NULL,
  Descripcion varchar(255) NOT NULL
);

/* 12 */
CREATE TABLE Admisiones(
	ID_Admision int IDENTITY(1,1) PRIMARY KEY,
	ID_Visita int FOREIGN KEY REFERENCES Visitas(ID_Visita),
	ID_Hospital int FOREIGN KEY REFERENCES Hospitales(ID_Hospital),
	Fecha_Ingreso varchar(255),
	Fecha_Salida varchar(255),
	Habitacion int
);

/* 13 */
CREATE TABLE Diagnosticos (
	ID_Diagnostico int IDENTITY(1,1) PRIMARY KEY,
	ID_Enfermedad int FOREIGN KEY REFERENCES Enfermedades(ID_Enfermedad),
	ID_Visita int FOREIGN KEY REFERENCES Visitas(ID_Visita),
	ID_Admision int FOREIGN KEY REFERENCES Admisiones(ID_Admision),
	Descripcion varchar(255)
);

/* 14 */
CREATE TABLE Recetas (
	ID_Receta int IDENTITY(1,1) PRIMARY KEY,
	ID_Visita int FOREIGN KEY REFERENCES Visitas(ID_Visita),
	ID_Diagnostico int FOREIGN KEY REFERENCES Diagnosticos(ID_Diagnostico),
	ID_Medico int FOREIGN KEY REFERENCES Medicos(ID_Medico),
	ID_Hospital int FOREIGN KEY REFERENCES Hospitales(ID_Hospital),
	Fecha varchar(255),
	ID_Paciente int FOREIGN KEY REFERENCES Pacientes(ID_Paciente),
	Descripcion varchar(255)
);

/* 15 */
CREATE TABLE Medicamentos (
	ID_Medicamento int IDENTITY(1,1) PRIMARY KEY,
	Nombre varchar(255),
	Descripcion varchar(255)
);

/* 16 */
CREATE TABLE Med_Receta (
	ID_MedReceta int IDENTITY(1,1) PRIMARY KEY,
	ID_Medicamento int 
	CONSTRAINT ID_Medicamento FOREIGN KEY (ID_Medicamento) REFERENCES Medicamentos(ID_Medicamento),
	ID_Receta int 
	CONSTRAINT ID_Receta FOREIGN KEY (ID_Receta) REFERENCES Recetas(ID_Receta)
);

/* 17 */
CREATE TABLE Farmacias (
	ID_Farmacia int IDENTITY(1,1) PRIMARY KEY,
	Nombre varchar(255),
	Ciudad varchar(255),
	Sector varchar(255),
	Calle varchar(255),
	#_Residencia int,
);

/* 18 */
CREATE TABLE Facturas_Farmacia (
	ID_FacturaFarmacia int IDENTITY(1,1) PRIMARY KEY,
	ID_Farmacia int
	CONSTRAINT ID_Farmacia FOREIGN KEY (ID_Farmacia) REFERENCES Farmacias(ID_Farmacia),
	ID_Paciente int
	CONSTRAINT ID_Paciente FOREIGN KEY (ID_Paciente) REFERENCES Pacientes(ID_Paciente),
	ID_Receta int FOREIGN KEY REFERENCES Recetas(ID_Receta),
	Total int,
	Fecha varchar(255),
	Descripcion varchar(255)
);

/* 19 */
CREATE TABLE Inventarios_Farmacia (
	ID_Inventario int IDENTITY(1,1) PRIMARY KEY,
	ID_Medicamento int FOREIGN KEY REFERENCES Medicamentos(ID_Medicamento) UNIQUE,
	ID_Farmacia int FOREIGN KEY REFERENCES Farmacias(ID_Farmacia) UNIQUE,
	Precio int,
	Cantidad_Disp int,
	Descripcion varchar(255)
);

/* 20 */
CREATE TABLE Detalle_FactFarm (
	ID_Detalle int IDENTITY(1,1) PRIMARY KEY,
	ID_InvFarm int
	CONSTRAINT ID_InvFarm FOREIGN KEY (ID_InvFarm) REFERENCES Inventarios_Farmacia(ID_Inventario),
	ID_FacturaFarmacia int FOREIGN KEY REFERENCES Facturas_Farmacia(ID_FacturaFarmacia),
	Cantidad_Comprada int,
	SubTotal int
);

/* 21 */
CREATE TABLE Analisis(
	ID_Analisis int IDENTITY(1,1) PRIMARY KEY,
	Nombre varchar(255),
	Descripcion varchar(255),
	Rango_Normal varchar(255)
);

/* 22 */
CREATE TABLE Laboratorios (
	ID_Laboratorio int IDENTITY(1,1) PRIMARY KEY,
	Nombre varchar(255),
	Descripcion varchar(255),
	Ciudad varchar(255),
	Sector varchar(255),
	Calle varchar(255),
	#_Residencia int,
	Telefono varchar(255)
);

/* 23 */
CREATE TABLE Analisis_Lab (
	ID_AnalLab int IDENTITY(1,1) PRIMARY KEY,
	ID_Analisis int FOREIGN KEY REFERENCES Analisis(ID_Analisis),
	ID_Laboratorio int FOREIGN KEY REFERENCES Laboratorios(ID_Laboratorio),
	Precio int,
);

/* 24 */
CREATE TABLE Facturas_Lab (
	ID_FacturaLab int IDENTITY(1,1) PRIMARY KEY,
	ID_Paciente int FOREIGN KEY REFERENCES Pacientes(ID_Paciente),
	ID_Receta int FOREIGN KEY REFERENCES Recetas(ID_Receta),
	ID_Lab int FOREIGN KEY REFERENCES Laboratorios(ID_Laboratorio),
	Total_Facturado int,
	Total_Pagado int,
	Fecha varchar(255),
	Descripcion varchar(255)
);

/* 25 */
CREATE TABLE Analisis_Realizados (
	ID_AnalRealizado int IDENTITY(1,1) PRIMARY KEY,
	ID_AnalLab int FOREIGN KEY REFERENCES Analisis_Lab(ID_AnalLab),
	Precio int,
	ID_Paciente int FOREIGN KEY REFERENCES Pacientes(ID_Paciente),
	ID_FacturaLab int FOREIGN KEY REFERENCES Facturas_Lab(ID_FacturaLab),
	Descripcion varchar(255)
);

/* 26 */
CREATE TABLE Resultado_Analisis (
	ID_Resultado int IDENTITY(1,1) PRIMARY KEY,
	ID_AnalRealizado int FOREIGN KEY REFERENCES Analisis_Realizados(ID_AnalRealizado),
	Descripcion varchar(255),
	Valor_Resultado int
);

/* 27 */
CREATE TABLE Analisis_Receta(
	ID_AnalisisReceta int IDENTITY(1,1) PRIMARY KEY,
	ID_Rec int
	CONSTRAINT ID_Rec FOREIGN KEY (ID_Rec) REFERENCES Recetas(ID_Receta),
	ID_Analisis int
	CONSTRAINT ID_Analisis FOREIGN KEY (ID_Analisis) REFERENCES Analisis(ID_Analisis)
);