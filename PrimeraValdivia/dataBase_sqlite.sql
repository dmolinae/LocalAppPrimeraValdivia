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
CREATE TABLE IF NOT EXISTS "Compañia"(
  "idCompañia" INTEGER PRIMARY KEY NOT NULL,
  "rut" VARCHAR(45) NOT NULL,
  "clave" VARCHAR(45) NOT NULL,
  "calle" VARCHAR(45) NOT NULL,
  "numeroCalle" VARCHAR(45),
  "ciudad" VARCHAR(45) NOT NULL,
  "nombreCompañia" VARCHAR(45),
  CONSTRAINT "idCompañia_UNIQUE"
    UNIQUE("idCompañia")
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
CREATE TABLE IF NOT EXISTS "Tipo"(
  "idTipo" INTEGER PRIMARY KEY NOT NULL,
  "nombre" VARCHAR(45),
  "fk_idCategoria" INTEGER,
  "descripcion" VARCHAR(45),
  CONSTRAINT "idTipo_UNIQUE"
    UNIQUE("idTipo"),
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
  "rut" VARCHAR(45) PRIMARY KEY NOT NULL,
  "nombre" VARCHAR(45) NOT NULL,
  "fechaNacimiento" VARCHAR(45) NOT NULL,
  "ciudadNacimiento" VARCHAR(45) NOT NULL,
  "grupoSanguineo" VARCHAR(45) NOT NULL,
  "profesion" VARCHAR(45),
  "fechaIngreso" VARCHAR(45) NOT NULL,
  "fechaReincorporacion" VARCHAR(45),
  "servicioCompañia" VARCHAR(45),
  "servicioMilitar" BOOLEAN,
  "insignia" INTEGER,
  "registroCompañia" INTEGER,
  "cargo" VARCHAR(45),
  "calificacion" VARCHAR(45),
  "fk_idCompañia" INTEGER,
  CONSTRAINT "idVoluntario_UNIQUE"
    UNIQUE("rut"),
  CONSTRAINT "fk_idCompañia"
    FOREIGN KEY("fk_idCompañia")
    REFERENCES "Compañia"("idCompañia")
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
  "horaSalidaCuartel" TIME,
  "horaLlegadaEvento" TIME,
  "horaSalidaEvento" DATETIME,
  "horaLlegadaCuartel" DATETIME,
  "fk_idCarroMaterial" INTEGER,
  "fk_idEventoMaterial" INTEGER,
  "kilometrajeSalida" INTEGER,
  "kilometrajeLlegada" INTEGER,
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