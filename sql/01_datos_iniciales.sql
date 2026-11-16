-- =====================================================================
-- Catálogo de videojuegos — carga de datos iniciales (etapa 1)
-- Ejecutar DESPUÉS de: dotnet ef database update
-- Esquema: migración InitialCreate (sin evolución ni relación N:N).
-- =====================================================================

BEGIN;

-- 1. Limpieza ordenada (permite volver a ejecutar el script).
TRUNCATE TABLE "Videojuegos", "Plataformas", "Desarrolladoras", "Generos" RESTART IDENTITY CASCADE;

-- 2. Géneros (12 catálogos: suficiente variedad para clasificar 100 videojuegos).
INSERT INTO "Generos" ("Id", "Nombre", "Descripcion", "Popular") VALUES
  (1, 'Acción', 'Combate en tiempo real, reflejos y habilidad motriz.', true),
  (2, 'Aventura', 'Exploración, narrativa y resolución de acertijos.', true),
  (3, 'Rol (RPG)', 'Progresión de personajes, estadísticas e historia.', true),
  (4, 'Shooter', 'Combate con armas de fuego en primera o tercera persona.', true),
  (5, 'Estrategia', 'Planificación de recursos, unidades o cartas.', false),
  (6, 'Deportes', 'Simulación de disciplinas deportivas reales.', true),
  (7, 'Carreras', 'Competición de velocidad con vehículos.', true),
  (8, 'Simulación', 'Gestión de entornos, vidas o sistemas.', false),
  (9, 'Plataformas', 'Saltos y desplazamiento por escenarios.', true),
  (10, 'Terror', 'Suspenso, supervivencia y atmósfera inquietante.', false),
  (11, 'Puzzle', 'Resolución de problemas lógicos.', false),
  (12, 'Lucha', 'Combate cuerpo a cuerpo uno contra uno.', false);

-- 3. Desarrolladoras (28 estudios reales que producen los títulos cargados).
INSERT INTO "Desarrolladoras" ("Id", "Nombre", "Pais", "Fundacion", "SitioWeb", "Empleados", "Activa") VALUES
  (1, 'Nintendo EPD', 'Japón', '2015-09-16', 'https://www.nintendo.com', 6000, true),
  (2, 'Rockstar Games', 'Estados Unidos', '1998-12-01', 'https://www.rockstargames.com', 2000, true),
  (3, 'CD Projekt Red', 'Polonia', '2002-05-01', 'https://www.cdprojektred.com', 1200, true),
  (4, 'FromSoftware', 'Japón', '1986-11-01', 'https://www.fromsoftware.jp', 400, true),
  (5, 'Naughty Dog', 'Estados Unidos', '1984-09-09', 'https://www.naughtydog.com', 400, true),
  (6, 'Santa Monica Studio', 'Estados Unidos', '1999-01-01', 'https://sms.playstation.com', 300, true),
  (7, 'Ubisoft Montreal', 'Canadá', '1997-12-01', 'https://www.ubisoft.com', 4000, true),
  (8, 'Valve', 'Estados Unidos', '1996-08-24', 'https://www.valvesoftware.com', 360, true),
  (9, 'Bethesda Game Studios', 'Estados Unidos', '2001-01-01', 'https://bethesda.net', 450, true),
  (10, 'Capcom', 'Japón', '1979-05-30', 'https://www.capcom.com', 3000, true),
  (11, 'Square Enix', 'Japón', '2003-04-01', 'https://www.square-enix.com', 5000, true),
  (12, 'Guerrilla Games', 'Países Bajos', '2000-01-01', 'https://www.guerrilla-games.com', 400, true),
  (13, 'Insomniac Games', 'Estados Unidos', '1994-02-28', 'https://insomniac.games', 500, true),
  (14, 'Larian Studios', 'Bélgica', '1996-01-01', 'https://larian.com', 500, true),
  (15, 'Mojang Studios', 'Suecia', '2009-05-17', 'https://www.minecraft.net', 600, true),
  (16, 'Electronic Arts', 'Estados Unidos', '1982-05-28', 'https://www.ea.com', 13000, true),
  (17, 'Playground Games', 'Reino Unido', '2010-01-01', 'https://playgroundgames.com', 400, true),
  (18, 'Remedy Entertainment', 'Finlandia', '1995-08-18', 'https://www.remedygames.com', 350, true),
  (19, 'Team Cherry', 'Australia', '2014-01-01', NULL, 3, true),
  (20, 'Supergiant Games', 'Estados Unidos', '2009-01-01', 'https://www.supergiantgames.com', 30, true),
  (21, 'Sega', 'Japón', '1960-06-03', 'https://www.sega.com', 3500, true),
  (22, 'Atlus', 'Japón', '1986-04-07', 'https://atlus.com', 300, true),
  (23, 'Techland', 'Polonia', '1991-01-01', 'https://techland.net', 500, true),
  (24, 'Epic Games', 'Estados Unidos', '1991-01-01', 'https://www.epicgames.com', 4000, true),
  (25, 'ConcernedApe', 'Estados Unidos', '2011-01-01', 'https://www.stardewvalley.net', 1, true),
  (26, 'Crystal Dynamics', 'Estados Unidos', '1992-01-01', 'https://www.crystald.com', 300, true),
  (27, 'Hazelight Studios', 'Suecia', '2014-01-01', 'https://www.hazelight.se', 80, true),
  (28, 'Psyonix', 'Estados Unidos', '2001-01-01', 'https://www.psyonix.com', 120, true);

-- 4. Plataformas (12: consolas, PC, portátiles y móviles).
INSERT INTO "Plataformas" ("Id", "Nombre", "Fabricante", "FechaLanzamiento", "Generacion", "PrecioBase", "Activa") VALUES
  (1, 'PC', 'Microsoft', '1981-08-12', 1, NULL, true),
  (2, 'PlayStation 5', 'Sony', '2020-11-12', 9, 499.99, true),
  (3, 'PlayStation 4', 'Sony', '2013-11-15', 8, 299.99, true),
  (4, 'Xbox Series X|S', 'Microsoft', '2020-11-10', 9, 499.99, true),
  (5, 'Xbox One', 'Microsoft', '2013-11-22', 8, 249.99, true),
  (6, 'Nintendo Switch', 'Nintendo', '2017-03-03', 8, 299.99, true),
  (7, 'Nintendo Switch 2', 'Nintendo', '2025-06-05', 9, 449.99, true),
  (8, 'Steam Deck', 'Valve', '2022-02-25', 9, 399, true),
  (9, 'Android', 'Google', '2008-09-23', NULL, NULL, true),
  (10, 'iOS', 'Apple', '2007-06-29', NULL, NULL, true),
  (11, 'Xbox 360', 'Microsoft', '2005-11-22', 7, 199.99, false),
  (12, 'PlayStation 3', 'Sony', '2006-11-11', 7, 499.99, false);

-- 5. Videojuegos (100 registros: entidad transaccional principal).
INSERT INTO "Videojuegos" ("Id", "Titulo", "Descripcion", "Precio", "FechaLanzamiento", "FechaRegistro", "Disponible", "CantidadJugadores", "ClasificacionPorEdad", "GeneroId", "DesarrolladoraId") VALUES
  (1, 'The Legend of Zelda: Breath of the Wild', 'Exploración de mundo abierto en Hyrule con física y supervivencia.', 59.99, '2017-03-03', '2026-01-01 08:15:00-05', true, 1, 'E10+', 2, 1),
  (2, 'Super Mario Odyssey', 'Mario viaja por reinos tridimensionales para rescatar a la princesa.', 49.99, '2017-10-27', '2026-04-02 09:15:00-05', true, 2, 'E', 9, 1),
  (3, 'Mario Kart 8 Deluxe', 'Carreras de karts con objetos y circuitos de la saga Mario.', 49.99, '2017-04-28', '2026-07-03 10:15:00-05', true, 8, 'E', 7, 1),
  (4, 'Animal Crossing: New Horizons', 'Simulación de vida en una isla con vecinos y coleccionismo.', 49.99, '2020-03-20', '2026-10-04 11:15:00-05', true, 8, 'E', 8, 1),
  (5, 'Splatoon 3', 'Combates de tinta en equipos de cuatro contra cuatro.', 49.99, '2022-09-09', '2026-03-05 12:15:00-05', true, 8, 'E10+', 4, 1),
  (6, 'Super Smash Bros. Ultimate', 'Juego de lucha con el plantel más grande de la saga.', 59.99, '2018-12-07', '2026-06-06 13:15:00-05', true, 8, 'T', 12, 1),
  (7, 'The Legend of Zelda: Tears of the Kingdom', 'Aventura con construcción de vehículos y cielos flotantes.', 69.99, '2023-05-12', '2026-09-07 14:15:00-05', true, 1, 'E10+', 2, 1),
  (8, 'Super Mario Bros. Wonder', 'Plataformas lateral con efectos sorpresa y cooperación local.', 59.99, '2023-10-20', '2026-02-08 15:15:00-05', true, 4, 'E', 9, 1),
  (9, 'Pikmin 4', 'Estrategia de gestión de criaturas para explorar un planeta.', 59.99, '2023-07-21', '2026-05-09 16:15:00-05', true, 2, 'E10+', 5, 1),
  (10, 'Grand Theft Auto V', 'Acción de mundo abierto en la ciudad ficticia de Los Santos.', 29.99, '2013-09-17', '2026-08-10 17:15:00-05', true, 1, 'M', 1, 2),
  (11, 'Red Dead Redemption 2', 'Western de mundo abierto sobre una banda de forajidos.', 59.99, '2018-10-26', '2026-01-11 08:15:00-05', true, 1, 'M', 2, 2),
  (12, 'L.A. Noire', 'Investigación policial con interrogatorios y expresión facial.', 19.99, '2011-05-17', '2026-04-12 09:15:00-05', true, 1, 'M', 2, 2),
  (13, 'Bully: Scholarship Edition', 'Aventura escolar con misiones y conflictos entre pandillas.', 14.99, '2008-03-04', '2026-07-13 10:15:00-05', false, 1, 'T', 1, 2),
  (14, 'Grand Theft Auto IV', 'Historia criminal del inmigrante Niko Bellic en Liberty City.', 19.99, '2008-04-29', '2026-10-14 11:15:00-05', false, 1, 'M', 1, 2),
  (15, 'The Witcher 3: Wild Hunt', 'RPG de mundo abierto protagonizado por el brujo Geralt.', 39.99, '2015-05-19', '2026-03-15 12:15:00-05', true, 1, 'M', 3, 3),
  (16, 'Cyberpunk 2077', 'RPG futurista en la megaciudad de Night City.', 59.99, '2020-12-10', '2026-06-16 13:15:00-05', true, 1, 'M', 3, 3),
  (17, 'The Witcher 2: Assassins of Kings', 'RPG con decisiones políticas y combate técnico.', 19.99, '2011-05-17', '2026-09-17 14:15:00-05', true, 1, 'M', 3, 3),
  (18, 'Gwent: The Witcher Card Game', 'Juego de cartas coleccionables ambientado en el universo Witcher.', 0.00, '2018-10-23', '2026-02-18 15:15:00-05', true, 2, 'T', 5, 3),
  (19, 'Elden Ring', 'RPG de acción con mundo abierto creado junto a George R. R. Martin.', 59.99, '2022-02-25', '2026-05-19 16:15:00-05', true, 1, 'M', 3, 4),
  (20, 'Dark Souls III', 'RPG de acción con combate exigente y mundo interconectado.', 39.99, '2016-03-24', '2026-08-20 17:15:00-05', true, 1, 'M', 3, 4),
  (21, 'Sekiro: Shadows Die Twice', 'Acción de sigilo y katanas en el Japón feudal.', 59.99, '2019-03-22', '2026-01-21 08:15:00-05', true, 1, 'M', 1, 4),
  (22, 'Bloodborne', 'RPG de acción gótico con combate agresivo.', 19.99, '2015-03-24', '2026-04-22 09:15:00-05', true, 1, 'M', 3, 4),
  (23, 'The Last of Us Part II', 'Supervivencia y venganza en un mundo postapocalíptico.', 39.99, '2020-06-19', '2026-07-23 10:15:00-05', true, 1, 'M', 1, 5),
  (24, 'Uncharted 4: A Thief''s End', 'Aventura de tesoros con escalada y tiroteos.', 19.99, '2016-05-10', '2026-10-24 11:15:00-05', true, 1, 'T', 2, 5),
  (25, 'The Last of Us Remastered', 'Viaje de supervivencia entre Joel y Ellie.', 19.99, '2014-07-29', '2026-03-25 12:15:00-05', true, 1, 'M', 2, 5),
  (26, 'Crash Bandicoot N. Sane Trilogy', 'Remasterización de tres clásicos de plataformas.', 39.99, '2017-06-30', '2026-06-26 13:15:00-05', true, 2, 'E10+', 9, 5),
  (27, 'God of War', 'Kratos y Atreus recorren los reinos nórdicos.', 19.99, '2018-04-20', '2026-09-27 14:15:00-05', true, 1, 'M', 1, 6),
  (28, 'God of War Ragnarök', 'Conclusión de la saga nórdica con combate brutal.', 69.99, '2022-11-09', '2026-02-28 15:15:00-05', true, 1, 'M', 1, 6),
  (29, 'God of War III Remastered', 'Kratos enfrenta a los dioses del Olimpo.', 19.99, '2015-07-14', '2026-05-01 16:15:00-05', true, 1, 'M', 1, 6),
  (30, 'Assassin''s Creed Valhalla', 'Aventura vikinga de mundo abierto en Inglaterra.', 59.99, '2020-11-10', '2026-08-02 17:15:00-05', true, 1, 'M', 1, 7),
  (31, 'Far Cry 5', 'Shooter de mundo abierto contra una secta en Montana.', 29.99, '2018-03-27', '2026-01-03 08:15:00-05', true, 2, 'M', 4, 7),
  (32, 'Rainbow Six Siege', 'Shooter táctico de asedio por equipos.', 19.99, '2015-12-01', '2026-04-04 09:15:00-05', true, 10, 'M', 4, 7),
  (33, 'For Honor', 'Combate medieval por equipos de caballeros, vikingos y samuráis.', 29.99, '2017-02-14', '2026-07-05 10:15:00-05', true, 8, 'M', 12, 7),
  (34, 'Assassin''s Creed Mirage', 'Regreso al sigilo clásico en el Bagdad del siglo IX.', 49.99, '2023-10-05', '2026-10-06 11:15:00-05', true, 1, 'M', 1, 7),
  (35, 'Tom Clancy''s The Division 2', 'Shooter de rol cooperativo en Washington D. C.', 29.99, '2019-03-15', '2026-03-07 12:15:00-05', true, 4, 'M', 4, 7),
  (36, 'Half-Life 2', 'Shooter narrativo con física y el motor Source.', 9.99, '2004-11-16', '2026-06-08 13:15:00-05', true, 1, 'M', 4, 8),
  (37, 'Portal 2', 'Puzles con portales y humor en un laboratorio.', 9.99, '2011-04-19', '2026-09-09 14:15:00-05', true, 2, 'E10+', 11, 8),
  (38, 'Counter-Strike 2', 'Shooter competitivo de rondas entre terroristas y antiterroristas.', 0.00, '2023-09-27', '2026-02-10 15:15:00-05', true, 10, 'M', 4, 8),
  (39, 'Dota 2', 'MOBA de cinco contra cinco con héroes y estrategia.', 0.00, '2013-07-09', '2026-05-11 16:15:00-05', true, 10, 'T', 5, 8),
  (40, 'Team Fortress 2', 'Shooter por clases con estética caricaturesca.', 0.00, '2007-10-10', '2026-08-12 17:15:00-05', true, 12, 'M', 4, 8),
  (41, 'The Elder Scrolls V: Skyrim', 'RPG de mundo abierto en la provincia de Skyrim.', 39.99, '2011-11-11', '2026-01-13 08:15:00-05', true, 1, 'M', 3, 9),
  (42, 'Fallout 4', 'RPG postapocalíptico con asentamientos y exploración.', 29.99, '2015-11-10', '2026-04-14 09:15:00-05', true, 1, 'M', 3, 9),
  (43, 'Starfield', 'RPG espacial con exploración de planetas.', 69.99, '2023-09-06', '2026-07-15 10:15:00-05', true, 1, 'M', 3, 9),
  (44, 'Fallout 76', 'RPG en línea ambientado en Appalachia.', 19.99, '2018-11-14', '2026-10-16 11:15:00-05', true, 4, 'M', 3, 9),
  (45, 'Resident Evil 4 Remake', 'Terror y acción con Leon Kennedy rescatando a la hija del presidente.', 59.99, '2023-03-24', '2026-03-17 12:15:00-05', true, 1, 'M', 10, 10),
  (46, 'Monster Hunter: World', 'Cacería de monstruos gigantes con equipo cooperativo.', 29.99, '2018-01-26', '2026-06-18 13:15:00-05', true, 4, 'T', 3, 10),
  (47, 'Devil May Cry 5', 'Acción estilizada con combos y demonios.', 29.99, '2019-03-08', '2026-09-19 14:15:00-05', true, 1, 'M', 1, 10),
  (48, 'Street Fighter 6', 'Lucha con sistema de control moderno y modo aventura.', 59.99, '2023-06-02', '2026-02-20 15:15:00-05', true, 2, 'T', 12, 10),
  (49, 'Monster Hunter Rise', 'Cacería con desplazamiento vertical y compañeros.', 39.99, '2021-03-26', '2026-05-21 16:15:00-05', true, 4, 'T', 3, 10),
  (50, 'Resident Evil Village', 'Terror en primera persona con licántropos y vampiros.', 39.99, '2021-05-07', '2026-08-22 17:15:00-05', true, 1, 'M', 10, 10),
  (51, 'Final Fantasy VII Remake', 'Reimaginación del clásico RPG con combate en tiempo real.', 39.99, '2020-04-10', '2026-01-23 08:15:00-05', true, 1, 'T', 3, 11),
  (52, 'Final Fantasy XVI', 'RPG de acción con Eikons y conflicto político.', 69.99, '2023-06-22', '2026-04-24 09:15:00-05', true, 1, 'M', 3, 11),
  (53, 'Kingdom Hearts III', 'Aventura de rol con mundos Disney y Square Enix.', 39.99, '2019-01-29', '2026-07-25 10:15:00-05', true, 1, 'E10+', 3, 11),
  (54, 'NieR: Automata', 'RPG de acción sobre androides en un mundo devastado.', 39.99, '2017-03-17', '2026-10-26 11:15:00-05', true, 1, 'M', 3, 11),
  (55, 'Final Fantasy XIV Online', 'MMORPG con historia episódica en Eorzea.', 19.99, '2013-08-27', '2026-03-27 12:15:00-05', true, 8, 'T', 3, 11),
  (56, 'Dragon Quest XI S', 'RPG clásico por turnos con mundo colorido.', 39.99, '2019-09-27', '2026-06-28 13:15:00-05', true, 1, 'T', 3, 11),
  (57, 'Horizon Zero Dawn', 'Aventura de rol contra máquinas en un futuro postapocalíptico.', 19.99, '2017-02-28', '2026-09-01 14:15:00-05', true, 1, 'T', 3, 12),
  (58, 'Horizon Forbidden West', 'Aloy explora el oeste prohibido y nuevas máquinas.', 59.99, '2022-02-18', '2026-02-02 15:15:00-05', true, 1, 'T', 3, 12),
  (59, 'Killzone Shadow Fall', 'Shooter futurista de lanzamiento para PlayStation 4.', 9.99, '2013-11-15', '2026-05-03 16:15:00-05', false, 2, 'M', 4, 12),
  (60, 'Marvel''s Spider-Man', 'Acción con balanceo urbano y villanos de Marvel.', 39.99, '2018-09-07', '2026-08-04 17:15:00-05', true, 1, 'T', 1, 13),
  (61, 'Marvel''s Spider-Man 2', 'Peter Parker y Miles Morales contra Venom.', 69.99, '2023-10-20', '2026-01-05 08:15:00-05', true, 1, 'T', 1, 13),
  (62, 'Ratchet & Clank: Rift Apart', 'Plataformas y disparos con saltos entre dimensiones.', 59.99, '2021-06-11', '2026-04-06 09:15:00-05', true, 1, 'E10+', 9, 13),
  (63, 'Baldur''s Gate 3', 'RPG por turnos basado en las reglas de Dungeons & Dragons.', 59.99, '2023-08-03', '2026-07-07 10:15:00-05', true, 4, 'M', 3, 14),
  (64, 'Divinity: Original Sin 2', 'RPG táctico por turnos con cooperación.', 44.99, '2017-09-14', '2026-10-08 11:15:00-05', true, 2, 'M', 3, 14),
  (65, 'Divinity: Original Sin', 'RPG clásico con magia y decisiones.', 39.99, '2014-06-30', '2026-03-09 12:15:00-05', true, 2, 'M', 3, 14),
  (66, 'Minecraft', 'Construcción y supervivencia en mundos de bloques.', 29.99, '2011-11-18', '2026-06-10 13:15:00-05', true, 8, 'E10+', 8, 15),
  (67, 'Minecraft Dungeons', 'Rol de mazmorras basado en el universo de Minecraft.', 19.99, '2020-05-26', '2026-09-11 14:15:00-05', true, 4, 'E10+', 3, 15),
  (68, 'Minecraft Legends', 'Estrategia de acción para defender aldeas.', 39.99, '2023-04-18', '2026-02-12 15:15:00-05', true, 4, 'E10+', 5, 15),
  (69, 'FIFA 23', 'Simulación de fútbol con licencias y modo carrera.', 59.99, '2022-09-30', '2026-05-13 16:15:00-05', true, 4, 'E', 6, 16),
  (70, 'EA Sports FC 25', 'Fútbol con tácticas avanzadas y modos sociales.', 69.99, '2024-09-27', '2026-08-14 17:15:00-05', true, 4, 'E', 6, 16),
  (71, 'Battlefield 2042', 'Shooter de guerra a gran escala con clima dinámico.', 59.99, '2021-11-19', '2026-01-15 08:15:00-05', true, 64, 'M', 4, 16),
  (72, 'Star Wars Jedi: Fallen Order', 'Aventura de un padawan perseguido por el Imperio.', 39.99, '2019-11-15', '2026-04-16 09:15:00-05', true, 1, 'T', 2, 16),
  (73, 'Apex Legends', 'Battle royale por escuadrones con personajes únicos.', 0.00, '2019-02-04', '2026-07-17 10:15:00-05', true, 3, 'T', 4, 16),
  (74, 'Titanfall 2', 'Shooter con titanes y campaña aclamada.', 19.99, '2016-10-28', '2026-10-18 11:15:00-05', true, 6, 'M', 4, 16),
  (75, 'Need for Speed Unbound', 'Carreras callejeras con estética urbana.', 39.99, '2022-12-02', '2026-03-19 12:15:00-05', true, 2, 'T', 7, 16),
  (76, 'The Sims 4', 'Simulación social de hogares y construcción.', 0.00, '2014-09-02', '2026-06-20 13:15:00-05', true, 1, 'T', 8, 16),
  (77, 'Forza Horizon 5', 'Carreras de mundo abierto en México.', 59.99, '2021-11-09', '2026-09-21 14:15:00-05', true, 2, 'E', 7, 17),
  (78, 'Forza Horizon 4', 'Festival de carreras con estaciones dinámicas en Reino Unido.', 29.99, '2018-10-02', '2026-02-22 15:15:00-05', true, 2, 'E', 7, 17),
  (79, 'Alan Wake 2', 'Terror psicológico con dos protagonistas.', 49.99, '2023-10-27', '2026-05-23 16:15:00-05', true, 1, 'M', 10, 18),
  (80, 'Control', 'Acción sobrenatural con poderes telequinéticos.', 29.99, '2019-08-27', '2026-08-24 17:15:00-05', true, 1, 'M', 1, 18),
  (81, 'Alan Wake Remastered', 'Escritor atrapado en una pesadilla en Bright Falls.', 29.99, '2021-10-05', '2026-01-25 08:15:00-05', true, 1, 'T', 10, 18),
  (82, 'Hollow Knight', 'Metroidvania de exploración en el reino de Hallownest.', 14.99, '2017-02-24', '2026-04-26 09:15:00-05', true, 1, 'E10+', 9, 19),
  (83, 'Hollow Knight: Silksong', 'Aventura de Hornet en un nuevo reino de insectos.', 19.99, '2025-09-04', '2026-07-27 10:15:00-05', true, 1, 'E10+', 9, 19),
  (84, 'Hades', 'Roguelite de acción con mitología griega.', 24.99, '2020-09-17', '2026-10-28 11:15:00-05', true, 1, 'T', 1, 20),
  (85, 'Hades II', 'Continuación con Melinoë y combate mágico.', 29.99, '2025-09-25', '2026-03-01 12:15:00-05', true, 1, 'T', 1, 20),
  (86, 'Yakuza: Like a Dragon', 'RPG por turnos con crimen organizado en Yokohama.', 59.99, '2020-11-10', '2026-06-02 13:15:00-05', true, 1, 'M', 3, 21),
  (87, 'Like a Dragon: Infinite Wealth', 'Aventura de Ichiban y Kiryu en Hawái y Japón.', 69.99, '2024-01-26', '2026-09-03 14:15:00-05', true, 1, 'M', 3, 21),
  (88, 'Like a Dragon: Ishin!', 'Acción samurái con el elenco de la saga Yakuza.', 49.99, '2023-02-21', '2026-02-04 15:15:00-05', true, 1, 'M', 1, 21),
  (89, 'Sonic Frontiers', 'Velocidad y exploración en islas abiertas.', 39.99, '2022-11-08', '2026-05-05 16:15:00-05', true, 1, 'E10+', 9, 21),
  (90, 'Persona 5 Royal', 'RPG escolar con mazmorras y vínculos sociales.', 59.99, '2020-03-31', '2026-08-06 17:15:00-05', true, 1, 'M', 3, 22),
  (91, 'Metaphor: ReFantazio', 'RPG de fantasía con ciclo de calendario y arquetipos.', 69.99, '2024-10-11', '2026-01-07 08:15:00-05', true, 1, 'T', 3, 22),
  (92, 'Persona 3 Reload', 'Remake del RPG nocturno con combate renovado.', 69.99, '2024-02-02', '2026-04-08 09:15:00-05', true, 1, 'M', 3, 22),
  (93, 'Dying Light 2: Stay Human', 'Supervivencia con parkour en una ciudad infectada.', 39.99, '2022-02-04', '2026-07-09 10:15:00-05', true, 4, 'M', 10, 23),
  (94, 'Dying Light', 'Zombis y parkour en primera persona.', 19.99, '2015-01-26', '2026-10-10 11:15:00-05', true, 4, 'M', 10, 23),
  (95, 'Fortnite', 'Battle royale con construcción y eventos colaborativos.', 0.00, '2017-07-25', '2026-03-11 12:15:00-05', true, 4, 'T', 4, 24),
  (96, 'Stardew Valley', 'Gestión de una granja y vida social en un pueblo.', 14.99, '2016-02-26', '2026-06-12 13:15:00-05', true, 4, 'E10+', 8, 25),
  (97, 'Tomb Raider', 'Origen de Lara Croft y supervivencia en una isla.', 19.99, '2013-03-05', '2026-09-13 14:15:00-05', true, 1, 'M', 2, 26),
  (98, 'Shadow of the Tomb Raider', 'Lara explora ruinas mayas antes de un apocalipsis.', 29.99, '2018-09-14', '2026-02-14 15:15:00-05', true, 1, 'M', 2, 26),
  (99, 'It Takes Two', 'Aventura cooperativa de una pareja convertida en muñecos.', 39.99, '2021-03-26', '2026-05-15 16:15:00-05', true, 2, 'T', 9, 27),
  (100, 'Rocket League', 'Fútbol con vehículos y acrobacias.', 0.00, '2015-07-07', '2026-08-16 17:15:00-05', true, 8, 'E', 6, 28);

-- 6. Sincronizar las secuencias de identidad con los Id insertados.
SELECT setval(pg_get_serial_sequence('"Generos"', 'Id'), (SELECT MAX("Id") FROM "Generos"));
SELECT setval(pg_get_serial_sequence('"Desarrolladoras"', 'Id'), (SELECT MAX("Id") FROM "Desarrolladoras"));
SELECT setval(pg_get_serial_sequence('"Plataformas"', 'Id'), (SELECT MAX("Id") FROM "Plataformas"));
SELECT setval(pg_get_serial_sequence('"Videojuegos"', 'Id'), (SELECT MAX("Id") FROM "Videojuegos"));

COMMIT;

-- Verificación rápida
SELECT (SELECT COUNT(*) FROM "Generos") AS generos,
       (SELECT COUNT(*) FROM "Desarrolladoras") AS desarrolladoras,
       (SELECT COUNT(*) FROM "Plataformas") AS plataformas,
       (SELECT COUNT(*) FROM "Videojuegos") AS videojuegos;
