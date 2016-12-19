-- Creator:       MySQL Workbench 6.3.7/ExportSQLite Plugin 0.1.0
-- Author:        Manuel
-- Caption:       New Model
-- Project:       Name of the project
-- Changed:       2016-07-11 01:04
-- Created:       2016-07-05 17:43
-- Schema: bomberos
CREATE TABLE IF NOT EXISTS "Evento"(
  "idEvento" INTEGER PRIMARY KEY NOT NULL,
  "correlativoLlamado" INTEGER,
  "correlativoCBV" INTEGER,
  "claveServicio" VARCHAR(45),
  "fecha" VARCHAR(45),
  "motivo" VARCHAR(45),
  "calle" VARCHAR(45),
  "numeroCalle" INTEGER,
  "calleProxima" VARCHAR(45),
  "sector" VARCHAR(45),
  "poblacion" VARCHAR(45),
  "ruta" VARCHAR(45),
  "kilometroRuta" INTEGER,
  "bomberoCargo" VARCHAR(45),
  "bomberoInforme" VARCHAR(45),
  "codigoCargo" VARCHAR(45),
  "codigoInforme" VARCHAR(45),
  "numeroDepartamento" VARCHAR(45),
  "numeroBlock" VARCHAR(45),
  "resumen" VARCHAR(45),
  "codigoServicio" VARCHAR(10),
  "asistenciaObligatoria" BOOLEAN,
  CONSTRAINT "idEvento_UNIQUE"
    UNIQUE("idEvento")
);
CREATE TABLE IF NOT EXISTS "Motosierra"(
  "idMotosierra" INTEGER PRIMARY KEY NOT NULL,
  "numeroMotosierra" INTEGER,
  "limpeza" VARCHAR(45),
  "estado" VARCHAR(45),
  "fk_idEventoMotosierra" INTEGER,
  CONSTRAINT "idMotosierra_UNIQUE"
    UNIQUE("idMotosierra"),
  CONSTRAINT "fk_idEventoMotosierra"
    FOREIGN KEY("fk_idEventoMotosierra")
    REFERENCES "Evento"("idEvento")
);
CREATE TABLE IF NOT EXISTS "Calificacion"(
  "idCalificacion" INTEGER PRIMARY KEY NOT NULL,
  "numero" INTEGER,
  "premio" VARCHAR(45),
  "anos" VARCHAR(45),
  "fk_idVoluntario" INTEGER,
  "fecha" VARCHAR(45),
  CONSTRAINT "idCalificacion_UNIQUE"
    UNIQUE("idCalificacion"),
  CONSTRAINT "fk_idVoluntario"
    FOREIGN KEY("fk_idVoluntario")
    REFERENCES "Voluntario"("rut")
);
CREATE TABLE IF NOT EXISTS "MaterialHospital"(
  "idMaterialHospital" INTEGER PRIMARY KEY NOT NULL,
  "tipoMaterial" VARCHAR(45),
  "cantidadMaterial" INTEGER,
  "fk_idEventoHospital" INTEGER,
  CONSTRAINT "idMaterialHospital_UNIQUE"
    UNIQUE("idMaterialHospital"),
  CONSTRAINT "fk_idEventoHospital"
    FOREIGN KEY("fk_idEventoHospital")
    REFERENCES "Evento"("idEvento")
);
CREATE TABLE IF NOT EXISTS "Categoria"(
  "idCategoria" INTEGER PRIMARY KEY NOT NULL,
  "nombre" VARCHAR(45),
  "descripcion" VARCHAR(45),
  CONSTRAINT "idCategoria_UNIQUE"
    UNIQUE("idCategoria")
);
CREATE TABLE IF NOT EXISTS "Incendio"(
  "idIncendio" INTEGER PRIMARY KEY NOT NULL,
  "tipoIncendio" VARCHAR(45),
  "faseIncendio" VARCHAR(45),
  "det" BOOLEAN,
  "bomberoDet" VARCHAR(45),
  "origen" VARCHAR(45),
  "causa" VARCHAR(45),
  "fuenteCalor" VARCHAR(45),
  "tipoLugar" VARCHAR(45),
  "tipoConstruccion" VARCHAR(45),
  "fk_idEventoInc" INTEGER,
  CONSTRAINT "idIncendio_UNIQUE"
    UNIQUE("idIncendio"),
  CONSTRAINT "fk_idEventoInc"
    FOREIGN KEY("fk_idEventoInc")
    REFERENCES "Evento"("idEvento")
);
CREATE TABLE IF NOT EXISTS "Compania"(
  "idCompania" INTEGER PRIMARY KEY NOT NULL,
  "nombre" VARCHAR(45) NOT NULL,
  "clave" VARCHAR(45) NOT NULL,
  "calle" VARCHAR(45) NOT NULL,
  "numeroCalle" INTEGER,
  "ciudad" VARCHAR(45) NOT NULL,
  "registroCompania" INTEGER,
  CONSTRAINT "idCompania_UNIQUE"
    UNIQUE("idCompania")
);
CREATE TABLE IF NOT EXISTS "MaterialPeligroso"(
  "idMaterialPeligroso" INTEGER PRIMARY KEY NOT NULL,
  "claveIncendio" VARCHAR(45),
  "tipoMaterialPeligroso" VARCHAR(45),
  "cantidadMaterialPeligroso" INTEGER,
  "empresa" VARCHAR(45),
  "fk_idIncendio" INTEGER,
  CONSTRAINT "idMaterialPeligroso_UNIQUE"
    UNIQUE("idMaterialPeligroso"),
  CONSTRAINT "fk_idIncendio"
    FOREIGN KEY("fk_idIncendio")
    REFERENCES "Incendio"("idIncendio")
);
CREATE TABLE IF NOT EXISTS "Afectado_Rescate"(
  "idRescate" INTEGER PRIMARY KEY NOT NULL,
  "nombre" VARCHAR(45),
  "rut" VARCHAR(45),
  "tipoAfectado" VARCHAR(45),
  "estado" VARCHAR(45),
  "fk_idEventoRescate" INTEGER,
  CONSTRAINT "idRescate_UNIQUE"
    UNIQUE("idRescate"),
  CONSTRAINT "fk_idEventoRescate"
    FOREIGN KEY("fk_idEventoRescate")
    REFERENCES "Evento"("idEvento")
);
CREATE TABLE IF NOT EXISTS "Carro"(
  "idCarro" INTEGER PRIMARY KEY NOT NULL,
  "nombre" VARCHAR(45),
  "tipo" VARCHAR(45),
  "descripcion" VARCHAR(45),
  "kilometraje" FLOAT,
  "horas_motor" FLOAT,
  "horas_bomba" FLOAT,
  CONSTRAINT "idCarro_UNIQUE"
    UNIQUE("idCarro")
);
CREATE TABLE IF NOT EXISTS "Apoyo"(
  "idApoyo" INTEGER PRIMARY KEY NOT NULL,
  "tipo" VARCHAR(45),
  "procedencia" VARCHAR(45),
  "personaCargo" VARCHAR(45),
  "rango" VARCHAR(45),
  "patente" VARCHAR(45),
  "compañia" VARCHAR(45),
  "municipalidad" VARCHAR(45),
  "fk_idEventoApoyo" INTEGER,
  CONSTRAINT "idVehiculo_UNIQUE"
    UNIQUE("idApoyo"),
  CONSTRAINT "fk_idEventoApoyo"
    FOREIGN KEY("fk_idEventoApoyo")
    REFERENCES "Evento"("idEvento")
);
CREATE TABLE IF NOT EXISTS "Era"(
  "idEra" INTEGER PRIMARY KEY NOT NULL,
  "numeroArne" INTEGER,
  "numeroMascara" INTEGER,
  "estado" VARCHAR(45),
  "fk_idEventoEra" INTEGER,
  CONSTRAINT "idEra_UNIQUE"
    UNIQUE("idEra"),
  CONSTRAINT "fk_idEventoEra"
    FOREIGN KEY("fk_idEventoEra")
    REFERENCES "Evento"("idEvento")
);
CREATE TABLE IF NOT EXISTS "Item"(
  "idItem" INTEGER PRIMARY KEY NOT NULL,
  "nombre" VARCHAR(45),
  "fk_idCategoria" INTEGER,
  "descripcion" VARCHAR(45),
  CONSTRAINT "idItem_UNIQUE"
    UNIQUE("idItem"),
  CONSTRAINT "fk_idCategoria"
    FOREIGN KEY("fk_idCategoria")
    REFERENCES "Categoria"("idCategoria")
);
CREATE TABLE IF NOT EXISTS "Afectado_Incendio"(
  "idAfectado" INTEGER PRIMARY KEY NOT NULL,
  "nombre" VARCHAR(45),
  "rut" VARCHAR(45),
  "tipoAfectado" VARCHAR(45),
  "numeroAdulto" INTEGER,
  "numeroNiños" INTEGER,
  "dañoVivienda" INTEGER,
  "dañoEnseres" INTEGER,
  "superficie" INTEGER,
  "prioridad" VARCHAR(45),
  "fk_idIncendioAfectado" INTEGER,
  CONSTRAINT "idAfectado_UNIQUE"
    UNIQUE("idAfectado"),
  CONSTRAINT "fk_idIncendioAfectado"
    FOREIGN KEY("fk_idIncendioAfectado")
    REFERENCES "Incendio"("idIncendio")
);
CREATE TABLE IF NOT EXISTS "Vehiculo"(
  "idVehiculo" INTEGER PRIMARY KEY NOT NULL,
  "tipo" VARCHAR(45),
  "marca" VARCHAR(45),
  "modelo" VARCHAR(45),
  "patente" VARCHAR(45),
  "daño" VARCHAR(45),
  "numeroAdultos" INTEGER,
  "numeroNiños" INTEGER,
  "fk_idRescate" INTEGER,
  CONSTRAINT "idVehiculo_UNIQUE"
    UNIQUE("idVehiculo"),
  CONSTRAINT "fk_idRescate"
    FOREIGN KEY("fk_idRescate")
    REFERENCES "Afectado_Rescate"("idRescate")
);
CREATE TABLE IF NOT EXISTS "Material"(
  "idMaterial" INTEGER PRIMARY KEY NOT NULL,
  "nombre" VARCHAR(45),
  "descripcion" VARCHAR(45),
  "fk_idCarro" INTEGER,
  CONSTRAINT "idMaterial_UNIQUE"
    UNIQUE("idMaterial"),
  CONSTRAINT "fk_idCarro"
    FOREIGN KEY("fk_idCarro")
    REFERENCES "Carro"("idCarro")
);
CREATE TABLE IF NOT EXISTS "Gas"(
  "idGas" INTEGER PRIMARY KEY NOT NULL,
  "tipoContenedor" VARCHAR(45),
  "tipoGas" VARCHAR(45),
  "capacidad" INTEGER,
  "empresa" VARCHAR(45),
  "fk_idIncendioGas" INTEGER,
  CONSTRAINT "idGas_UNIQUE"
    UNIQUE("idGas"),
  CONSTRAINT "fk_idIncendioGas"
    FOREIGN KEY("fk_idIncendioGas")
    REFERENCES "Incendio"("idIncendio")
);
CREATE TABLE IF NOT EXISTS "Voluntario"(
  "idVoluntario" INTEGER PRIMARY KEY NOT NULL,
  "nombre" VARCHAR(45) NOT NULL,
  "fechaNacimiento" VARCHAR(45) NOT NULL,
  "ciudadNacimiento" VARCHAR(45) NOT NULL,
  "grupoSanguineo" VARCHAR(45) NOT NULL,
  "profesion" VARCHAR(45),
  "servicioMilitar" BOOLEAN,
  "insignia" INTEGER,
  "cargo" VARCHAR(45),
  "nRegistroInterno" INTEGER,
  "nRegistroExterno" INTEGER,
  "codigoRadial" VARCHAR(45),
  "rut" VARCHAR(45) NOT NULL,
  CONSTRAINT "idVoluntario_UNIQUE"
    UNIQUE("rut")
);
CREATE TABLE IF NOT EXISTS "CompaniaVoluntario"(
  "idCompaniaVoluntario" INTEGER PRIMARY KEY NOT NULL,
  "fechaIngreso" VARCHAR(45),
  "fechaSalida" VARCHAR(45),
  "fk_compania" INTEGER,
  "fk_voluntario" VARCHAR(45),
  CONSTRAINT "idCompaniaVoluntario_UNIQUE"
    UNIQUE("idCompaniaVoluntario"),
  CONSTRAINT "fk_compania"
    FOREIGN KEY("fk_compania")
    REFERENCES "Compania"("idCompania"),
  CONSTRAINT "fk_voluntario"
    FOREIGN KEY("fk_voluntario")
    REFERENCES "Voluntario"("rut")
);
CREATE TABLE IF NOT EXISTS "Aseguradora_Vehiculo"(
  "idAseguradora_vehiculo" INTEGER PRIMARY KEY NOT NULL,
  "poliza" VARCHAR(45),
  "compañia" VARCHAR(45),
  "especie" VARCHAR(45),
  "fk_idAseguradoraVehiculo" INTEGER,
  CONSTRAINT "idAseguradora_vehiculo_UNIQUE"
    UNIQUE("idAseguradora_vehiculo"),
  CONSTRAINT "fk_idAseguradoraVehiculo"
    FOREIGN KEY("fk_idAseguradoraVehiculo")
    REFERENCES "Vehiculo"("idVehiculo")
);
CREATE TABLE IF NOT EXISTS "Material_evento"(
  "idMaterialEvento" INTEGER PRIMARY KEY NOT NULL,
  "nombre" VARCHAR(45),
  "descripcion" VARCHAR(45),
  "fk_idMaterial" INTEGER,
  "fk_idEventoMaterial" INTEGER,
  CONSTRAINT "idMaterialEvento_UNIQUE"
    UNIQUE("idMaterialEvento"),
  CONSTRAINT "fk_idMaterial"
    FOREIGN KEY("fk_idMaterial")
    REFERENCES "Material"("idMaterial"),
  CONSTRAINT "fk_idEventoMaterial"
    FOREIGN KEY("fk_idEventoMaterial")
    REFERENCES "Evento"("idEvento")
);
CREATE TABLE IF NOT EXISTS "MaterialMayor"(
  "idCarroEvento" INTEGER PRIMARY KEY NOT NULL,
  "conductor" VARCHAR(45),
  "oficialCargo" VARCHAR(45),
  "horaSalidaCuartel" VARCHAR(45),
  "horaLlegadaEvento" VARCHAR(45),
  "horaSalidaEvento" VARCHAR(45),
  "horaLlegadaCuartel" VARCHAR(45),
  "fk_idCarroMaterial" INTEGER,
  "fk_idEventoMaterial" INTEGER,
  "kilometrajeSalida" FLOAT,
  "kilometrajeLlegada" FLOAT,
  CONSTRAINT "idCarroEvento_UNIQUE"
    UNIQUE("idCarroEvento"),
  CONSTRAINT "fk_idEventoMaterial"
    FOREIGN KEY("fk_idEventoMaterial")
    REFERENCES "Evento"("idEvento"),
  CONSTRAINT "fk_idCarroMaterial"
    FOREIGN KEY("fk_idCarroMaterial")
    REFERENCES "Carro"("idCarro")
);
CREATE TABLE IF NOT EXISTS "Acompañante"(
  "idAcompañante" INTEGER PRIMARY KEY NOT NULL,
  "nombre" VARCHAR(45),
  "rut" VARCHAR(45),
  "estado" VARCHAR(45),
  "fk_idVehiculo" INTEGER,
  CONSTRAINT "idAcompañante_UNIQUE"
    UNIQUE("idAcompañante"),
  CONSTRAINT "fk_idVehiculo"
    FOREIGN KEY("fk_idVehiculo")
    REFERENCES "Vehiculo"("idVehiculo")
);
CREATE TABLE IF NOT EXISTS "Asistencia"(
  "idAsistencia" INTEGER PRIMARY KEY AUTOINCREMENT,
  "fk_rut" VARCHAR(45),
  "fk_idEvento" INTEGER,
  "codigoAsistencia" VARCHAR(45),
  "asistenciaObligatoria" BOOLEAN,
  CONSTRAINT "idAsistencia_UNIQUE"
    UNIQUE("idAsistencia"),
  CONSTRAINT "fk_rut"
    FOREIGN KEY("fk_rut")
    REFERENCES "Voluntario"("rut"),
  CONSTRAINT "fk_idEvento"
    FOREIGN KEY("fk_idEvento")
    REFERENCES "Evento"("idEvento")
);
CREATE TABLE IF NOT EXISTS "Aseguradora_Vivienda_Afectado"(
  "idaseguradora_afectado" INTEGER PRIMARY KEY NOT NULL,
  "poliza" VARCHAR(45),
  "compañia" VARCHAR(45),
  "especie" VARCHAR(45),
  "fk_idAfectado" INTEGER,
  CONSTRAINT "idaseguradora_afectado_UNIQUE"
    UNIQUE("idaseguradora_afectado"),
  CONSTRAINT "fk_idAfectado"
    FOREIGN KEY("fk_idAfectado")
    REFERENCES "Afectado_Incendio"("idAfectado")
);

/*
INSERT INTO "Categoria" VALUES(0,"Cargos","Todos los cargos disponibles");
INSERT INTO "Item" VALUES(0,"Director Honorario",0,"");
INSERT INTO "Item" VALUES(1,"Director",0,"");
INSERT INTO "Item" VALUES(2,"Secretario",0,"");
INSERT INTO "Item" VALUES(3,"Tesorero",0,"");
INSERT INTO "Item" VALUES(4,"Medico",0,"");
INSERT INTO "Item" VALUES(5,"Abogado",0,"");
INSERT INTO "Item" VALUES(6,"Capitan",0,"");
INSERT INTO "Item" VALUES(7,"Teniente 1°",0,"");
INSERT INTO "Item" VALUES(8,"Teniente 2°",0,"");
INSERT INTO "Item" VALUES(9,"Teniente 3°",0,"");
INSERT INTO "Item" VALUES(10,"Teniente 4°",0,"");
INSERT INTO "Item" VALUES(11,"Odontologo",0,"");
INSERT INTO "Item" VALUES(12,"Intendente",0,"");
INSERT INTO "Item" VALUES(13,"Ingeniero Compañia",0,"");
INSERT INTO "Item" VALUES(14,"Teniente de Maquinas",0,"");
INSERT INTO "Item" VALUES(15,"Ayudante 1°",0,"");
INSERT INTO "Item" VALUES(16,"Ayudante 2°",0,"");
INSERT INTO "Item" VALUES(17,"Voluntario",0,"");
INSERT INTO "Item" VALUES(18,"Aspirante",0,"");

INSERT INTO "Categoria" VALUES(1,"Años Calificacion","Todos las calificaciones disponibles");
INSERT INTO "Item" VALUES(19,"5 Años",1,"");
INSERT INTO "Item" VALUES(20,"10 Años",1,"");
INSERT INTO "Item" VALUES(21,"15 Años",1,"");
INSERT INTO "Item" VALUES(22,"20 Años",1,"");
INSERT INTO "Item" VALUES(23,"25 Años",1,"");
INSERT INTO "Item" VALUES(24,"30 Años",1,"");
INSERT INTO "Item" VALUES(25,"35 Años",1,"");
INSERT INTO "Item" VALUES(26,"40 Años",1,"");
INSERT INTO "Item" VALUES(27,"45 Años",1,"");
INSERT INTO "Item" VALUES(28,"50 Años",1,"");
INSERT INTO "Item" VALUES(29,"55 Años",1,"");
*/