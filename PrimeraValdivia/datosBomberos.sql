INSERT INTO Voluntario(idVoluntario,nombre,fechaNacimiento,ciudadNacimiento,grupoSanguineo,profesion,servicioMilitar,insignia,cargo,nRegistroInterno,nRegistroExterno,codigoRadial,rut)
VALUES(0,"Sergio Perez","16-07-1968 0:00:00","iquique","rh+","profesor",1,10,"Voluntario",1,100,"02","12767237k");
INSERT INTO Voluntario(idVoluntario,nombre,fechaNacimiento,ciudadNacimiento,grupoSanguineo,profesion,servicioMilitar,insignia,cargo,nRegistroInterno,nRegistroExterno,codigoRadial,rut)
VALUES(1,"Gonzalo Lavin","02-11-1940 0:00:00","Puerto Montt","rh-","jubilado",1,10,"Voluntario",2,101,"02","4212925k");
INSERT INTO Voluntario(idVoluntario,nombre,fechaNacimiento,ciudadNacimiento,grupoSanguineo,profesion,servicioMilitar,insignia,cargo,nRegistroInterno,nRegistroExterno,codigoRadial,rut)
VALUES(2,"Manuel Lavin","12-05-1993 0:00:00","Puerto Montt","rh+","Estudiante",1,10,"Voluntario",3,102,"02","184721910");
INSERT INTO Voluntario(idVoluntario,nombre,fechaNacimiento,ciudadNacimiento,grupoSanguineo,profesion,servicioMilitar,insignia,cargo,nRegistroInterno,nRegistroExterno,codigoRadial,rut)
VALUES(3,"Felipe Lavin","08-04-1997 0:00:00","Puerto Montt","rh+","Estudiante",1,10,"Voluntario",4,103,"02","19673824k");
INSERT INTO Voluntario(idVoluntario,nombre,fechaNacimiento,ciudadNacimiento,grupoSanguineo,profesion,servicioMilitar,insignia,cargo,nRegistroInterno,nRegistroExterno,codigoRadial,rut)
VALUES(4,"Camila Lavin","16-12-1999 0:00:00","Villarrica","rh+","Estudiante",1,10,"Voluntario",5,104,"02","190124769");
INSERT INTO Voluntario(idVoluntario,nombre,fechaNacimiento,ciudadNacimiento,grupoSanguineo,profesion,servicioMilitar,insignia,cargo,nRegistroInterno,nRegistroExterno,codigoRadial,rut)
VALUES(5,"Juan Contreras","23-08-1991 0:00:00","La Union","rh+","Estudiante",1,10,"Voluntario",6,105,"02","174371298");
INSERT INTO Voluntario(idVoluntario,nombre,fechaNacimiento,ciudadNacimiento,grupoSanguineo,profesion,servicioMilitar,insignia,cargo,nRegistroInterno,nRegistroExterno,codigoRadial,rut)
VALUES(6,"Maricela Diaz","04-09-1994 0:00:00","Puerto Natales","rh+","Estudiante",1,10,"Tesorera",7,106,"02","188123457");
INSERT INTO Voluntario(idVoluntario,nombre,fechaNacimiento,ciudadNacimiento,grupoSanguineo,profesion,servicioMilitar,insignia,cargo,nRegistroInterno,nRegistroExterno,codigoRadial,rut)
VALUES(7,"Daniel Molina","17-11-1993 0:00:00","Osorno","rh+","Estudiante",1,10,"Voluntario",8,107,"02","185780708");
INSERT INTO Voluntario(idVoluntario,nombre,fechaNacimiento,ciudadNacimiento,grupoSanguineo,profesion,servicioMilitar,insignia,cargo,nRegistroInterno,nRegistroExterno,codigoRadial,rut)
VALUES(8,"Felipe Prambs","22-02-1993 0:00:00","Osorno","rh+","Estudiante",1,10,"Voluntario",9,108,"02","184274760");
INSERT INTO Voluntario(idVoluntario,nombre,fechaNacimiento,ciudadNacimiento,grupoSanguineo,profesion,servicioMilitar,insignia,cargo,nRegistroInterno,nRegistroExterno,codigoRadial,rut)
VALUES(9,"Marcelo Torres","09-08-1993 0:00:00","Valdivia","rh+","Estudiante",1,10,"Voluntario",10,109,"02","185895866");

INSERT INTO "Categoria" VALUES(0,"Cargos","Todos los cargos disponibles");
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("Director Honorario",0);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("Director",0);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("Secretario",0);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("Tesorero",0);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("Medico",0);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("Abogado",0);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("Capitan",0);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("Teniente 1°",0);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("Teniente 2°",0);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("Teniente 3°",0);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("Teniente 4°",0);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("Odontologo",0);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("Intendente",0);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("Ingeniero Compañia",0);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("Teniente de Maquinas",0);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("Ayudante 1°",0);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("Ayudante 2°",0);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("Voluntario",0);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("Aspirante",0);

INSERT INTO "Categoria" VALUES(1,"Años Calificacion","Todos las calificaciones disponibles");
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("5 Años",1);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("10 Años",1);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("15 Años",1);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("20 Años",1);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("25 Años",1);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("30 Años",1);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("35 Años",1);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("40 Años",1);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("45 Años",1);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("50 Años",1);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("55 Años",1);

INSERT INTO "Categoria" VALUES(2,"Tipo Incendio","Datos del incendio");
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("Compartimentalizado",2);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("Estructural",2);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("Multicompartimental",2);

INSERT INTO "Categoria" VALUES(3,"Fase Incendio","Datos del incendio");
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("Ignición",3);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("Incremento de temperatura",3);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("Libre combustión",3);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("Decaimiento de combustión",3);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("Latente de combustión",3);

INSERT INTO "Categoria" VALUES(4,"Tipo Lugar","Datos del lugar");
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("Vivienda",4);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("Negocio",4);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("Industria",4);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("Colegio",4);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("Vehículo",4);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("Sitio eriazo",4);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("Via pública",4);

INSERT INTO "Categoria" VALUES(5,"Tipo Construccion","Datos del lugar");
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("Adobe",5);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("Bloques de cemento",5);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("Estructura metálica",5);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("Hormigon armado",5);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("Ladrillo",5);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("Madera",5);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("Mixta ladrillo y adobe",5);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("Mixta ladrillo y estructura metálica",5);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("Mixta ladrillo y madera",5);
INSERT INTO "Item"("nombre","fk_idCategoria") VALUES("Mixta madera y estructura metálica",5);

INSERT INTO Carro(idCarro,nombre,tipo,descripcion,kilometraje,horas_motor,horas_bomba)
VALUES(0,"B1","Incendio","Carro para Incendio",0,0,0);
INSERT INTO Carro(idCarro,nombre,tipo,descripcion,kilometraje,horas_motor,horas_bomba)
VALUES(1,"R1","Rescate","Carro para Rescate",0,0,0);
INSERT INTO Carro(idCarro,nombre,tipo,descripcion,kilometraje,horas_motor,horas_bomba)
VALUES(2,"B2","Incendio","Carro para Incendio",0,0,0);

INSERT INTO Material(idMaterial,nombre,descripcion,fk_idCarro)
VALUES(0,"Manguera","manguera para lanzar agua",0);
INSERT INTO Material(idMaterial,nombre,descripcion,fk_idCarro)
VALUES(1,"Escalera","para subir a lugares altos",0);

INSERT INTO Material(idMaterial,nombre,descripcion,fk_idCarro)
VALUES(2,"Manguera","manguera para lanzar agua",2);
INSERT INTO Material(idMaterial,nombre,descripcion,fk_idCarro)
VALUES(3,"Escalera","para subir a lugares altos",2);

INSERT INTO Material(idMaterial,nombre,descripcion,fk_idCarro)
VALUES(4,"Motosierra","para cortar arboles",1);
INSERT INTO Material(idMaterial,nombre,descripcion,fk_idCarro)
VALUES(5,"Oxicorte","para cortar metal",1);

INSERT INTO Evento(idEvento,correlativoLlamado,correlativoCBV,claveServicio,fecha,motivo,calle,numeroCalle,calleProxima,sector,poblacion,ruta,kilometroRuta,bomberoCargo,bomberoInforme,codigoCargo,codigoInforme,numeroDepartamento,numeroBlock,resumen,codigoServicio,asistenciaObligatoria)
VALUES(0,0,0,"10","11-07-2015 16:02:06","Incendio","Santa Maria",999,"Pedro Montt","Regional","","",0,"Sergio Perez","Gonzalo Lavin","02","02","","","inflamacion de chimenea","10",1);
INSERT INTO Evento(idEvento,correlativoLlamado,correlativoCBV,claveServicio,fecha,motivo,calle,numeroCalle,calleProxima,sector,poblacion,ruta,kilometroRuta,bomberoCargo,bomberoInforme,codigoCargo,codigoInforme,numeroDepartamento,numeroBlock,resumen,codigoServicio,asistenciaObligatoria)
VALUES(1,0,0,"10","12-08-2015 11:15:30","Incendio","Pedro Montt",1201,"Ramon Picarte","Centro","","",0,"Sergio Perez","Gonzalo Lavin","02","02","","","inflamacion de galon de gas","10",0);
INSERT INTO Evento(idEvento,correlativoLlamado,correlativoCBV,claveServicio,fecha,motivo,calle,numeroCalle,calleProxima,sector,poblacion,ruta,kilometroRuta,bomberoCargo,bomberoInforme,codigoCargo,codigoInforme,numeroDepartamento,numeroBlock,resumen,codigoServicio,asistenciaObligatoria)
VALUES(2,0,0,"10","13-09-2015 18:46:43","Rescate","",0,"","Alamos","","S-45",8,"Sergio Perez","Gonzalo Lavin","02","02","","","volcamiento de vehiculo","10",1);

INSERT INTO Asistencia(idAsistencia,fk_idVoluntario,fk_idEvento,codigoAsistencia,asistenciaObligatoria)
VALUES(0,0,0,"L",1);
INSERT INTO Asistencia(idAsistencia,fk_idVoluntario,fk_idEvento,codigoAsistencia,asistenciaObligatoria)
VALUES(1,1,0,"L",1);
INSERT INTO Asistencia(idAsistencia,fk_idVoluntario,fk_idEvento,codigoAsistencia,asistenciaObligatoria)
VALUES(2,2,0,"L",1);
INSERT INTO Asistencia(idAsistencia,fk_idVoluntario,fk_idEvento,codigoAsistencia,asistenciaObligatoria)
VALUES(3,3,0,"L",1);
INSERT INTO Asistencia(idAsistencia,fk_idVoluntario,fk_idEvento,codigoAsistencia,asistenciaObligatoria)
VALUES(4,4,0,"L",1);
INSERT INTO Asistencia(idAsistencia,fk_idVoluntario,fk_idEvento,codigoAsistencia,asistenciaObligatoria)
VALUES(5,5,0,"L",1);
INSERT INTO Asistencia(idAsistencia,fk_idVoluntario,fk_idEvento,codigoAsistencia,asistenciaObligatoria)
VALUES(6,6,0,"L",1);
INSERT INTO Asistencia(idAsistencia,fk_idVoluntario,fk_idEvento,codigoAsistencia,asistenciaObligatoria)
VALUES(7,7,0,"L",1);
INSERT INTO Asistencia(idAsistencia,fk_idVoluntario,fk_idEvento,codigoAsistencia,asistenciaObligatoria)
VALUES(8,8,0,"L",1);
INSERT INTO Asistencia(idAsistencia,fk_idVoluntario,fk_idEvento,codigoAsistencia,asistenciaObligatoria)
VALUES(9,9,0,"L",1);

INSERT INTO Asistencia(idAsistencia,fk_idVoluntario,fk_idEvento,codigoAsistencia,asistenciaObligatoria)
VALUES(10,0,1,"a",0);
INSERT INTO Asistencia(idAsistencia,fk_idVoluntario,fk_idEvento,codigoAsistencia,asistenciaObligatoria)
VALUES(11,1,1,"a",0);
INSERT INTO Asistencia(idAsistencia,fk_idVoluntario,fk_idEvento,codigoAsistencia,asistenciaObligatoria)
VALUES(12,2,1,"a",0);
INSERT INTO Asistencia(idAsistencia,fk_idVoluntario,fk_idEvento,codigoAsistencia,asistenciaObligatoria)
VALUES(13,3,1,"a",0);
INSERT INTO Asistencia(idAsistencia,fk_idVoluntario,fk_idEvento,codigoAsistencia,asistenciaObligatoria)
VALUES(14,4,1,"a",0);
INSERT INTO Asistencia(idAsistencia,fk_idVoluntario,fk_idEvento,codigoAsistencia,asistenciaObligatoria)
VALUES(15,5,1,"a",0);
INSERT INTO Asistencia(idAsistencia,fk_idVoluntario,fk_idEvento,codigoAsistencia,asistenciaObligatoria)
VALUES(16,6,1,"a",0);
INSERT INTO Asistencia(idAsistencia,fk_idVoluntario,fk_idEvento,codigoAsistencia,asistenciaObligatoria)
VALUES(17,7,1,"a",0);
INSERT INTO Asistencia(idAsistencia,fk_idVoluntario,fk_idEvento,codigoAsistencia,asistenciaObligatoria)
VALUES(18,8,1,"a",0);
INSERT INTO Asistencia(idAsistencia,fk_idVoluntario,fk_idEvento,codigoAsistencia,asistenciaObligatoria)
VALUES(19,9,1,"a",0);

INSERT INTO Asistencia(idAsistencia,fk_idVoluntario,fk_idEvento,codigoAsistencia,asistenciaObligatoria)
VALUES(20,0,2,"A",1);
INSERT INTO Asistencia(idAsistencia,fk_idVoluntario,fk_idEvento,codigoAsistencia,asistenciaObligatoria)
VALUES(21,1,2,"A",1);
INSERT INTO Asistencia(idAsistencia,fk_idVoluntario,fk_idEvento,codigoAsistencia,asistenciaObligatoria)
VALUES(22,2,2,"A",1);
INSERT INTO Asistencia(idAsistencia,fk_idVoluntario,fk_idEvento,codigoAsistencia,asistenciaObligatoria)
VALUES(23,3,2,"A",1);
INSERT INTO Asistencia(idAsistencia,fk_idVoluntario,fk_idEvento,codigoAsistencia,asistenciaObligatoria)
VALUES(24,4,2,"A",1);
INSERT INTO Asistencia(idAsistencia,fk_idVoluntario,fk_idEvento,codigoAsistencia,asistenciaObligatoria)
VALUES(25,5,2,"A",1);
INSERT INTO Asistencia(idAsistencia,fk_idVoluntario,fk_idEvento,codigoAsistencia,asistenciaObligatoria)
VALUES(26,6,2,"A",1);
INSERT INTO Asistencia(idAsistencia,fk_idVoluntario,fk_idEvento,codigoAsistencia,asistenciaObligatoria)
VALUES(27,7,2,"A",1);
INSERT INTO Asistencia(idAsistencia,fk_idVoluntario,fk_idEvento,codigoAsistencia,asistenciaObligatoria)
VALUES(28,8,2,"A",1);
INSERT INTO Asistencia(idAsistencia,fk_idVoluntario,fk_idEvento,codigoAsistencia,asistenciaObligatoria)
VALUES(29,9,2,"A",1);
