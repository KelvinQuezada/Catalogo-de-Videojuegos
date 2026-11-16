// Generador de datos de prueba para el catálogo de videojuegos.
// Produce:
//   sql/01_datos_iniciales.sql  -> catálogos + 100 videojuegos (esquema inicial)
//   sql/datos_plataformas.json  -> plataformas por videojuego (para el script N:N)
//
// Uso: node tools/generar_datos.js

const fs = require('fs');
const path = require('path');

const root = path.join(__dirname, '..');

const generos = [
  [1, 'Acción', 'Combate en tiempo real, reflejos y habilidad motriz.', true],
  [2, 'Aventura', 'Exploración, narrativa y resolución de acertijos.', true],
  [3, 'Rol (RPG)', 'Progresión de personajes, estadísticas e historia.', true],
  [4, 'Shooter', 'Combate con armas de fuego en primera o tercera persona.', true],
  [5, 'Estrategia', 'Planificación de recursos, unidades o cartas.', false],
  [6, 'Deportes', 'Simulación de disciplinas deportivas reales.', true],
  [7, 'Carreras', 'Competición de velocidad con vehículos.', true],
  [8, 'Simulación', 'Gestión de entornos, vidas o sistemas.', false],
  [9, 'Plataformas', 'Saltos y desplazamiento por escenarios.', true],
  [10, 'Terror', 'Suspenso, supervivencia y atmósfera inquietante.', false],
  [11, 'Puzzle', 'Resolución de problemas lógicos.', false],
  [12, 'Lucha', 'Combate cuerpo a cuerpo uno contra uno.', false],
];

const desarrolladoras = [
  [1, 'Nintendo EPD', 'Japón', '2015-09-16', 'https://www.nintendo.com', 6000, true],
  [2, 'Rockstar Games', 'Estados Unidos', '1998-12-01', 'https://www.rockstargames.com', 2000, true],
  [3, 'CD Projekt Red', 'Polonia', '2002-05-01', 'https://www.cdprojektred.com', 1200, true],
  [4, 'FromSoftware', 'Japón', '1986-11-01', 'https://www.fromsoftware.jp', 400, true],
  [5, 'Naughty Dog', 'Estados Unidos', '1984-09-09', 'https://www.naughtydog.com', 400, true],
  [6, 'Santa Monica Studio', 'Estados Unidos', '1999-01-01', 'https://sms.playstation.com', 300, true],
  [7, 'Ubisoft Montreal', 'Canadá', '1997-12-01', 'https://www.ubisoft.com', 4000, true],
  [8, 'Valve', 'Estados Unidos', '1996-08-24', 'https://www.valvesoftware.com', 360, true],
  [9, 'Bethesda Game Studios', 'Estados Unidos', '2001-01-01', 'https://bethesda.net', 450, true],
  [10, 'Capcom', 'Japón', '1979-05-30', 'https://www.capcom.com', 3000, true],
  [11, 'Square Enix', 'Japón', '2003-04-01', 'https://www.square-enix.com', 5000, true],
  [12, 'Guerrilla Games', 'Países Bajos', '2000-01-01', 'https://www.guerrilla-games.com', 400, true],
  [13, 'Insomniac Games', 'Estados Unidos', '1994-02-28', 'https://insomniac.games', 500, true],
  [14, 'Larian Studios', 'Bélgica', '1996-01-01', 'https://larian.com', 500, true],
  [15, 'Mojang Studios', 'Suecia', '2009-05-17', 'https://www.minecraft.net', 600, true],
  [16, 'Electronic Arts', 'Estados Unidos', '1982-05-28', 'https://www.ea.com', 13000, true],
  [17, 'Playground Games', 'Reino Unido', '2010-01-01', 'https://playgroundgames.com', 400, true],
  [18, 'Remedy Entertainment', 'Finlandia', '1995-08-18', 'https://www.remedygames.com', 350, true],
  [19, 'Team Cherry', 'Australia', '2014-01-01', null, 3, true],
  [20, 'Supergiant Games', 'Estados Unidos', '2009-01-01', 'https://www.supergiantgames.com', 30, true],
  [21, 'Sega', 'Japón', '1960-06-03', 'https://www.sega.com', 3500, true],
  [22, 'Atlus', 'Japón', '1986-04-07', 'https://atlus.com', 300, true],
  [23, 'Techland', 'Polonia', '1991-01-01', 'https://techland.net', 500, true],
  [24, 'Epic Games', 'Estados Unidos', '1991-01-01', 'https://www.epicgames.com', 4000, true],
  [25, 'ConcernedApe', 'Estados Unidos', '2011-01-01', 'https://www.stardewvalley.net', 1, true],
  [26, 'Crystal Dynamics', 'Estados Unidos', '1992-01-01', 'https://www.crystald.com', 300, true],
  [27, 'Hazelight Studios', 'Suecia', '2014-01-01', 'https://www.hazelight.se', 80, true],
  [28, 'Psyonix', 'Estados Unidos', '2001-01-01', 'https://www.psyonix.com', 120, true],
];

const plataformas = [
  [1, 'PC', 'Microsoft', '1981-08-12', 1, null, true],
  [2, 'PlayStation 5', 'Sony', '2020-11-12', 9, 499.99, true],
  [3, 'PlayStation 4', 'Sony', '2013-11-15', 8, 299.99, true],
  [4, 'Xbox Series X|S', 'Microsoft', '2020-11-10', 9, 499.99, true],
  [5, 'Xbox One', 'Microsoft', '2013-11-22', 8, 249.99, true],
  [6, 'Nintendo Switch', 'Nintendo', '2017-03-03', 8, 299.99, true],
  [7, 'Nintendo Switch 2', 'Nintendo', '2025-06-05', 9, 449.99, true],
  [8, 'Steam Deck', 'Valve', '2022-02-25', 9, 399.00, true],
  [9, 'Android', 'Google', '2008-09-23', null, null, true],
  [10, 'iOS', 'Apple', '2007-06-29', null, null, true],
  [11, 'Xbox 360', 'Microsoft', '2005-11-22', 7, 199.99, false],
  [12, 'PlayStation 3', 'Sony', '2006-11-11', 7, 499.99, false],
];

// [titulo, generoId, desarrolladoraId, precio, fecha, disponible, jugadores, clasificacion, descripcion]
const videojuegos = [
  ['The Legend of Zelda: Breath of the Wild', 2, 1, 59.99, '2017-03-03', true, 1, 'E10+', 'Exploración de mundo abierto en Hyrule con física y supervivencia.'],
  ['Super Mario Odyssey', 9, 1, 49.99, '2017-10-27', true, 2, 'E', 'Mario viaja por reinos tridimensionales para rescatar a la princesa.'],
  ['Mario Kart 8 Deluxe', 7, 1, 49.99, '2017-04-28', true, 8, 'E', 'Carreras de karts con objetos y circuitos de la saga Mario.'],
  ['Animal Crossing: New Horizons', 8, 1, 49.99, '2020-03-20', true, 8, 'E', 'Simulación de vida en una isla con vecinos y coleccionismo.'],
  ['Splatoon 3', 4, 1, 49.99, '2022-09-09', true, 8, 'E10+', 'Combates de tinta en equipos de cuatro contra cuatro.'],
  ['Super Smash Bros. Ultimate', 12, 1, 59.99, '2018-12-07', true, 8, 'T', 'Juego de lucha con el plantel más grande de la saga.'],
  ['The Legend of Zelda: Tears of the Kingdom', 2, 1, 69.99, '2023-05-12', true, 1, 'E10+', 'Aventura con construcción de vehículos y cielos flotantes.'],
  ['Super Mario Bros. Wonder', 9, 1, 59.99, '2023-10-20', true, 4, 'E', 'Plataformas lateral con efectos sorpresa y cooperación local.'],
  ['Pikmin 4', 5, 1, 59.99, '2023-07-21', true, 2, 'E10+', 'Estrategia de gestión de criaturas para explorar un planeta.'],
  ['Grand Theft Auto V', 1, 2, 29.99, '2013-09-17', true, 1, 'M', 'Acción de mundo abierto en la ciudad ficticia de Los Santos.'],
  ['Red Dead Redemption 2', 2, 2, 59.99, '2018-10-26', true, 1, 'M', 'Western de mundo abierto sobre una banda de forajidos.'],
  ['L.A. Noire', 2, 2, 19.99, '2011-05-17', true, 1, 'M', 'Investigación policial con interrogatorios y expresión facial.'],
  ['Bully: Scholarship Edition', 1, 2, 14.99, '2008-03-04', false, 1, 'T', 'Aventura escolar con misiones y conflictos entre pandillas.'],
  ['Grand Theft Auto IV', 1, 2, 19.99, '2008-04-29', false, 1, 'M', 'Historia criminal del inmigrante Niko Bellic en Liberty City.'],
  ['The Witcher 3: Wild Hunt', 3, 3, 39.99, '2015-05-19', true, 1, 'M', 'RPG de mundo abierto protagonizado por el brujo Geralt.'],
  ['Cyberpunk 2077', 3, 3, 59.99, '2020-12-10', true, 1, 'M', 'RPG futurista en la megaciudad de Night City.'],
  ['The Witcher 2: Assassins of Kings', 3, 3, 19.99, '2011-05-17', true, 1, 'M', 'RPG con decisiones políticas y combate técnico.'],
  ['Gwent: The Witcher Card Game', 5, 3, 0.00, '2018-10-23', true, 2, 'T', 'Juego de cartas coleccionables ambientado en el universo Witcher.'],
  ['Elden Ring', 3, 4, 59.99, '2022-02-25', true, 1, 'M', 'RPG de acción con mundo abierto creado junto a George R. R. Martin.'],
  ['Dark Souls III', 3, 4, 39.99, '2016-03-24', true, 1, 'M', 'RPG de acción con combate exigente y mundo interconectado.'],
  ['Sekiro: Shadows Die Twice', 1, 4, 59.99, '2019-03-22', true, 1, 'M', 'Acción de sigilo y katanas en el Japón feudal.'],
  ['Bloodborne', 3, 4, 19.99, '2015-03-24', true, 1, 'M', 'RPG de acción gótico con combate agresivo.'],
  ['The Last of Us Part II', 1, 5, 39.99, '2020-06-19', true, 1, 'M', 'Supervivencia y venganza en un mundo postapocalíptico.'],
  ['Uncharted 4: A Thief\'s End', 2, 5, 19.99, '2016-05-10', true, 1, 'T', 'Aventura de tesoros con escalada y tiroteos.'],
  ['The Last of Us Remastered', 2, 5, 19.99, '2014-07-29', true, 1, 'M', 'Viaje de supervivencia entre Joel y Ellie.'],
  ['Crash Bandicoot N. Sane Trilogy', 9, 5, 39.99, '2017-06-30', true, 2, 'E10+', 'Remasterización de tres clásicos de plataformas.'],
  ['God of War', 1, 6, 19.99, '2018-04-20', true, 1, 'M', 'Kratos y Atreus recorren los reinos nórdicos.'],
  ['God of War Ragnarök', 1, 6, 69.99, '2022-11-09', true, 1, 'M', 'Conclusión de la saga nórdica con combate brutal.'],
  ['God of War III Remastered', 1, 6, 19.99, '2015-07-14', true, 1, 'M', 'Kratos enfrenta a los dioses del Olimpo.'],
  ['Assassin\'s Creed Valhalla', 1, 7, 59.99, '2020-11-10', true, 1, 'M', 'Aventura vikinga de mundo abierto en Inglaterra.'],
  ['Far Cry 5', 4, 7, 29.99, '2018-03-27', true, 2, 'M', 'Shooter de mundo abierto contra una secta en Montana.'],
  ['Rainbow Six Siege', 4, 7, 19.99, '2015-12-01', true, 10, 'M', 'Shooter táctico de asedio por equipos.'],
  ['For Honor', 12, 7, 29.99, '2017-02-14', true, 8, 'M', 'Combate medieval por equipos de caballeros, vikingos y samuráis.'],
  ['Assassin\'s Creed Mirage', 1, 7, 49.99, '2023-10-05', true, 1, 'M', 'Regreso al sigilo clásico en el Bagdad del siglo IX.'],
  ['Tom Clancy\'s The Division 2', 4, 7, 29.99, '2019-03-15', true, 4, 'M', 'Shooter de rol cooperativo en Washington D. C.'],
  ['Half-Life 2', 4, 8, 9.99, '2004-11-16', true, 1, 'M', 'Shooter narrativo con física y el motor Source.'],
  ['Portal 2', 11, 8, 9.99, '2011-04-19', true, 2, 'E10+', 'Puzles con portales y humor en un laboratorio.'],
  ['Counter-Strike 2', 4, 8, 0.00, '2023-09-27', true, 10, 'M', 'Shooter competitivo de rondas entre terroristas y antiterroristas.'],
  ['Dota 2', 5, 8, 0.00, '2013-07-09', true, 10, 'T', 'MOBA de cinco contra cinco con héroes y estrategia.'],
  ['Team Fortress 2', 4, 8, 0.00, '2007-10-10', true, 12, 'M', 'Shooter por clases con estética caricaturesca.'],
  ['The Elder Scrolls V: Skyrim', 3, 9, 39.99, '2011-11-11', true, 1, 'M', 'RPG de mundo abierto en la provincia de Skyrim.'],
  ['Fallout 4', 3, 9, 29.99, '2015-11-10', true, 1, 'M', 'RPG postapocalíptico con asentamientos y exploración.'],
  ['Starfield', 3, 9, 69.99, '2023-09-06', true, 1, 'M', 'RPG espacial con exploración de planetas.'],
  ['Fallout 76', 3, 9, 19.99, '2018-11-14', true, 4, 'M', 'RPG en línea ambientado en Appalachia.'],
  ['Resident Evil 4 Remake', 10, 10, 59.99, '2023-03-24', true, 1, 'M', 'Terror y acción con Leon Kennedy rescatando a la hija del presidente.'],
  ['Monster Hunter: World', 3, 10, 29.99, '2018-01-26', true, 4, 'T', 'Cacería de monstruos gigantes con equipo cooperativo.'],
  ['Devil May Cry 5', 1, 10, 29.99, '2019-03-08', true, 1, 'M', 'Acción estilizada con combos y demonios.'],
  ['Street Fighter 6', 12, 10, 59.99, '2023-06-02', true, 2, 'T', 'Lucha con sistema de control moderno y modo aventura.'],
  ['Monster Hunter Rise', 3, 10, 39.99, '2021-03-26', true, 4, 'T', 'Cacería con desplazamiento vertical y compañeros.'],
  ['Resident Evil Village', 10, 10, 39.99, '2021-05-07', true, 1, 'M', 'Terror en primera persona con licántropos y vampiros.'],
  ['Final Fantasy VII Remake', 3, 11, 39.99, '2020-04-10', true, 1, 'T', 'Reimaginación del clásico RPG con combate en tiempo real.'],
  ['Final Fantasy XVI', 3, 11, 69.99, '2023-06-22', true, 1, 'M', 'RPG de acción con Eikons y conflicto político.'],
  ['Kingdom Hearts III', 3, 11, 39.99, '2019-01-29', true, 1, 'E10+', 'Aventura de rol con mundos Disney y Square Enix.'],
  ['NieR: Automata', 3, 11, 39.99, '2017-03-17', true, 1, 'M', 'RPG de acción sobre androides en un mundo devastado.'],
  ['Final Fantasy XIV Online', 3, 11, 19.99, '2013-08-27', true, 8, 'T', 'MMORPG con historia episódica en Eorzea.'],
  ['Dragon Quest XI S', 3, 11, 39.99, '2019-09-27', true, 1, 'T', 'RPG clásico por turnos con mundo colorido.'],
  ['Horizon Zero Dawn', 3, 12, 19.99, '2017-02-28', true, 1, 'T', 'Aventura de rol contra máquinas en un futuro postapocalíptico.'],
  ['Horizon Forbidden West', 3, 12, 59.99, '2022-02-18', true, 1, 'T', 'Aloy explora el oeste prohibido y nuevas máquinas.'],
  ['Killzone Shadow Fall', 4, 12, 9.99, '2013-11-15', false, 2, 'M', 'Shooter futurista de lanzamiento para PlayStation 4.'],
  ['Marvel\'s Spider-Man', 1, 13, 39.99, '2018-09-07', true, 1, 'T', 'Acción con balanceo urbano y villanos de Marvel.'],
  ['Marvel\'s Spider-Man 2', 1, 13, 69.99, '2023-10-20', true, 1, 'T', 'Peter Parker y Miles Morales contra Venom.'],
  ['Ratchet & Clank: Rift Apart', 9, 13, 59.99, '2021-06-11', true, 1, 'E10+', 'Plataformas y disparos con saltos entre dimensiones.'],
  ['Baldur\'s Gate 3', 3, 14, 59.99, '2023-08-03', true, 4, 'M', 'RPG por turnos basado en las reglas de Dungeons & Dragons.'],
  ['Divinity: Original Sin 2', 3, 14, 44.99, '2017-09-14', true, 2, 'M', 'RPG táctico por turnos con cooperación.'],
  ['Divinity: Original Sin', 3, 14, 39.99, '2014-06-30', true, 2, 'M', 'RPG clásico con magia y decisiones.'],
  ['Minecraft', 8, 15, 29.99, '2011-11-18', true, 8, 'E10+', 'Construcción y supervivencia en mundos de bloques.'],
  ['Minecraft Dungeons', 3, 15, 19.99, '2020-05-26', true, 4, 'E10+', 'Rol de mazmorras basado en el universo de Minecraft.'],
  ['Minecraft Legends', 5, 15, 39.99, '2023-04-18', true, 4, 'E10+', 'Estrategia de acción para defender aldeas.'],
  ['FIFA 23', 6, 16, 59.99, '2022-09-30', true, 4, 'E', 'Simulación de fútbol con licencias y modo carrera.'],
  ['EA Sports FC 25', 6, 16, 69.99, '2024-09-27', true, 4, 'E', 'Fútbol con tácticas avanzadas y modos sociales.'],
  ['Battlefield 2042', 4, 16, 59.99, '2021-11-19', true, 64, 'M', 'Shooter de guerra a gran escala con clima dinámico.'],
  ['Star Wars Jedi: Fallen Order', 2, 16, 39.99, '2019-11-15', true, 1, 'T', 'Aventura de un padawan perseguido por el Imperio.'],
  ['Apex Legends', 4, 16, 0.00, '2019-02-04', true, 3, 'T', 'Battle royale por escuadrones con personajes únicos.'],
  ['Titanfall 2', 4, 16, 19.99, '2016-10-28', true, 6, 'M', 'Shooter con titanes y campaña aclamada.'],
  ['Need for Speed Unbound', 7, 16, 39.99, '2022-12-02', true, 2, 'T', 'Carreras callejeras con estética urbana.'],
  ['The Sims 4', 8, 16, 0.00, '2014-09-02', true, 1, 'T', 'Simulación social de hogares y construcción.'],
  ['Forza Horizon 5', 7, 17, 59.99, '2021-11-09', true, 2, 'E', 'Carreras de mundo abierto en México.'],
  ['Forza Horizon 4', 7, 17, 29.99, '2018-10-02', true, 2, 'E', 'Festival de carreras con estaciones dinámicas en Reino Unido.'],
  ['Alan Wake 2', 10, 18, 49.99, '2023-10-27', true, 1, 'M', 'Terror psicológico con dos protagonistas.'],
  ['Control', 1, 18, 29.99, '2019-08-27', true, 1, 'M', 'Acción sobrenatural con poderes telequinéticos.'],
  ['Alan Wake Remastered', 10, 18, 29.99, '2021-10-05', true, 1, 'T', 'Escritor atrapado en una pesadilla en Bright Falls.'],
  ['Hollow Knight', 9, 19, 14.99, '2017-02-24', true, 1, 'E10+', 'Metroidvania de exploración en el reino de Hallownest.'],
  ['Hollow Knight: Silksong', 9, 19, 19.99, '2025-09-04', true, 1, 'E10+', 'Aventura de Hornet en un nuevo reino de insectos.'],
  ['Hades', 1, 20, 24.99, '2020-09-17', true, 1, 'T', 'Roguelite de acción con mitología griega.'],
  ['Hades II', 1, 20, 29.99, '2025-09-25', true, 1, 'T', 'Continuación con Melinoë y combate mágico.'],
  ['Yakuza: Like a Dragon', 3, 21, 59.99, '2020-11-10', true, 1, 'M', 'RPG por turnos con crimen organizado en Yokohama.'],
  ['Like a Dragon: Infinite Wealth', 3, 21, 69.99, '2024-01-26', true, 1, 'M', 'Aventura de Ichiban y Kiryu en Hawái y Japón.'],
  ['Like a Dragon: Ishin!', 1, 21, 49.99, '2023-02-21', true, 1, 'M', 'Acción samurái con el elenco de la saga Yakuza.'],
  ['Sonic Frontiers', 9, 21, 39.99, '2022-11-08', true, 1, 'E10+', 'Velocidad y exploración en islas abiertas.'],
  ['Persona 5 Royal', 3, 22, 59.99, '2020-03-31', true, 1, 'M', 'RPG escolar con mazmorras y vínculos sociales.'],
  ['Metaphor: ReFantazio', 3, 22, 69.99, '2024-10-11', true, 1, 'T', 'RPG de fantasía con ciclo de calendario y arquetipos.'],
  ['Persona 3 Reload', 3, 22, 69.99, '2024-02-02', true, 1, 'M', 'Remake del RPG nocturno con combate renovado.'],
  ['Dying Light 2: Stay Human', 10, 23, 39.99, '2022-02-04', true, 4, 'M', 'Supervivencia con parkour en una ciudad infectada.'],
  ['Dying Light', 10, 23, 19.99, '2015-01-26', true, 4, 'M', 'Zombis y parkour en primera persona.'],
  ['Fortnite', 4, 24, 0.00, '2017-07-25', true, 4, 'T', 'Battle royale con construcción y eventos colaborativos.'],
  ['Stardew Valley', 8, 25, 14.99, '2016-02-26', true, 4, 'E10+', 'Gestión de una granja y vida social en un pueblo.'],
  ['Tomb Raider', 2, 26, 19.99, '2013-03-05', true, 1, 'M', 'Origen de Lara Croft y supervivencia en una isla.'],
  ['Shadow of the Tomb Raider', 2, 26, 29.99, '2018-09-14', true, 1, 'M', 'Lara explora ruinas mayas antes de un apocalipsis.'],
  ['It Takes Two', 9, 27, 39.99, '2021-03-26', true, 2, 'T', 'Aventura cooperativa de una pareja convertida en muñecos.'],
  ['Rocket League', 6, 28, 0.00, '2015-07-07', true, 8, 'E', 'Fútbol con vehículos y acrobacias.'],
];

// Plataformas por videojuego según año, estudio y tipo de lanzamiento.
// Cada regla devuelve ids de la tabla Plataformas.
function plataformasDe(v) {
  const [titulo, genero, dev, , fecha] = v;
  const year = Number(fecha.slice(0, 4));
  const set = new Set();

  const movil = /Android|iOS/.test(titulo);
  if (movil) return [9, 10];

  if (dev === 1) {
    // Estudio interno de Nintendo: consolas Nintendo.
    set.add(6);
    if (year >= 2025) set.add(7);
    return [...set];
  }

  if (year <= 2012) {
    set.add(1);
    set.add(11);
    set.add(12);
  } else if (year <= 2015) {
    set.add(1);
    set.add(3);
    set.add(5);
    if (year <= 2014) set.add(11);
  } else if (year <= 2019) {
    set.add(1);
    set.add(3);
    set.add(5);
    if (dev === 8 || dev >= 19) set.add(6);
  } else if (year <= 2021) {
    set.add(1);
    set.add(2);
    set.add(3);
    set.add(4);
    set.add(5);
  } else {
    set.add(1);
    set.add(2);
    set.add(4);
    if (dev >= 18) set.add(6);
    if (dev >= 19) set.add(8);
  }

  // Los juegos de PC/indie llegan a Steam Deck.
  if (dev >= 19 && year >= 2022) set.add(8);

  // Lanzamientos simultáneos en la consola de nueva generación de Nintendo.
  if (dev >= 19 && year >= 2025) set.add(7);

  // Títulos con versión móvil oficial.
  if (['Minecraft', 'Stardew Valley', 'Fortnite'].includes(titulo)) {
    set.add(9);
    set.add(10);
  }

  return [...set].sort((a, b) => a - b);
}

const q = (s) => (s === null || s === undefined ? 'NULL' : `'${String(s).replace(/'/g, "''")}'`);
const n = (v) => (v === null || v === undefined ? 'NULL' : v);

function fechaRegistro(i) {
  const dia = String((i % 28) + 1).padStart(2, '0');
  const mes = String(((i * 3) % 10) + 1).padStart(2, '0');
  const hora = String(8 + (i % 10)).padStart(2, '0');
  return `${2026}-${mes}-${dia} ${hora}:15:00-05`;
}

const lineas = [];
lineas.push('-- =====================================================================');
lineas.push('-- Catálogo de videojuegos — carga de datos iniciales (etapa 1)');
lineas.push('-- Ejecutar DESPUÉS de: dotnet ef database update');
lineas.push('-- Esquema: migración InitialCreate (sin evolución ni relación N:N).');
lineas.push('-- =====================================================================');
lineas.push('');
lineas.push('BEGIN;');
lineas.push('');
lineas.push('-- 1. Limpieza ordenada (permite volver a ejecutar el script).');
lineas.push('TRUNCATE TABLE "Videojuegos", "Plataformas", "Desarrolladoras", "Generos" RESTART IDENTITY CASCADE;');
lineas.push('');

lineas.push('-- 2. Géneros (12 catálogos: suficiente variedad para clasificar 100 videojuegos).');
lineas.push('INSERT INTO "Generos" ("Id", "Nombre", "Descripcion", "Popular") VALUES');
lineas.push(generos.map(([id, nom, desc, pop]) => `  (${id}, ${q(nom)}, ${q(desc)}, ${pop})`).join(',\n') + ';');
lineas.push('');

lineas.push('-- 3. Desarrolladoras (28 estudios reales que producen los títulos cargados).');
lineas.push('INSERT INTO "Desarrolladoras" ("Id", "Nombre", "Pais", "Fundacion", "SitioWeb", "Empleados", "Activa") VALUES');
lineas.push(desarrolladoras.map(([id, nom, pais, fund, web, emp, act]) =>
  `  (${id}, ${q(nom)}, ${q(pais)}, ${q(fund)}, ${q(web)}, ${n(emp)}, ${act})`).join(',\n') + ';');
lineas.push('');

lineas.push('-- 4. Plataformas (12: consolas, PC, portátiles y móviles).');
lineas.push('INSERT INTO "Plataformas" ("Id", "Nombre", "Fabricante", "FechaLanzamiento", "Generacion", "PrecioBase", "Activa") VALUES');
lineas.push(plataformas.map(([id, nom, fab, fecha, gen, precio, act]) =>
  `  (${id}, ${q(nom)}, ${q(fab)}, ${q(fecha)}, ${n(gen)}, ${n(precio)}, ${act})`).join(',\n') + ';');
lineas.push('');

lineas.push(`-- 5. Videojuegos (${videojuegos.length} registros: entidad transaccional principal).`);
lineas.push('INSERT INTO "Videojuegos" ("Id", "Titulo", "Descripcion", "Precio", "FechaLanzamiento", "FechaRegistro", "Disponible", "CantidadJugadores", "ClasificacionPorEdad", "GeneroId", "DesarrolladoraId") VALUES');
lineas.push(videojuegos.map((v, i) => {
  const [titulo, gen, dev, precio, fecha, disp, jug, clasif, desc] = v;
  return `  (${i + 1}, ${q(titulo)}, ${q(desc)}, ${precio.toFixed(2)}, ${q(fecha)}, ${q(fechaRegistro(i))}, ${disp}, ${jug}, ${q(clasif)}, ${gen}, ${dev})`;
}).join(',\n') + ';');
lineas.push('');

lineas.push('-- 6. Sincronizar las secuencias de identidad con los Id insertados.');
for (const tabla of ['Generos', 'Desarrolladoras', 'Plataformas', 'Videojuegos']) {
  lineas.push(`SELECT setval(pg_get_serial_sequence('"${tabla}"', 'Id'), (SELECT MAX("Id") FROM "${tabla}"));`);
}
lineas.push('');
lineas.push('COMMIT;');
lineas.push('');
lineas.push('-- Verificación rápida');
lineas.push('SELECT (SELECT COUNT(*) FROM "Generos") AS generos,');
lineas.push('       (SELECT COUNT(*) FROM "Desarrolladoras") AS desarrolladoras,');
lineas.push('       (SELECT COUNT(*) FROM "Plataformas") AS plataformas,');
lineas.push('       (SELECT COUNT(*) FROM "Videojuegos") AS videojuegos;');
lineas.push('');

fs.mkdirSync(path.join(root, 'sql'), { recursive: true });
fs.writeFileSync(path.join(root, 'sql', '01_datos_iniciales.sql'), lineas.join('\n'), 'utf8');

// Datos para el script de la relación N:N
const relaciones = [];
videojuegos.forEach((v, i) => {
  for (const pid of plataformasDe(v)) relaciones.push([i + 1, pid]);
});
fs.writeFileSync(
  path.join(root, 'sql', 'datos_plataformas.json'),
  JSON.stringify({ videojuegos: videojuegos.length, relaciones }, null, 2),
  'utf8'
);

// ---------------------------------------------------------------------------
// Script para la relación muchos a muchos (se ejecuta después de la
// migración AgregarRelacionVideojuegoPlataforma).
// ---------------------------------------------------------------------------
const nn = [];
nn.push('-- =====================================================================');
nn.push('-- Catálogo de videojuegos — carga de la relación N:N (etapa 2)');
nn.push('-- Ejecutar DESPUÉS de: dotnet ef database update');
nn.push('--   (migración AgregarRelacionVideojuegoPlataforma)');
nn.push('-- Tabla intermedia generada por EF Core: "PlataformaVideojuego"');
nn.push('-- =====================================================================');
nn.push('');
nn.push('BEGIN;');
nn.push('');
nn.push('-- Permite volver a ejecutar el script sin duplicar filas.');
nn.push('TRUNCATE TABLE "PlataformaVideojuego" RESTART IDENTITY;');
nn.push('');
nn.push(`-- ${relaciones.length} asociaciones videojuego ↔ plataforma.`);
nn.push('INSERT INTO "PlataformaVideojuego" ("PlataformasId", "VideojuegosId") VALUES');
nn.push(relaciones.map(([vid, pid]) => `  (${pid}, ${vid})`).join(',\n'));
nn.push('ON CONFLICT ("PlataformasId", "VideojuegosId") DO NOTHING;');
nn.push('');
nn.push('COMMIT;');
nn.push('');
nn.push('-- Verificación: plataformas por videojuego (lado Videojuego → Plataforma)');
nn.push('SELECT v."Id", v."Titulo", COUNT(pv."PlataformasId") AS plataformas');
nn.push('FROM "Videojuegos" v');
nn.push('LEFT JOIN "PlataformaVideojuego" pv ON pv."VideojuegosId" = v."Id"');
nn.push('GROUP BY v."Id", v."Titulo" ORDER BY plataformas DESC, v."Id" LIMIT 10;');
nn.push('');
nn.push('-- Verificación: videojuegos por plataforma (lado Plataforma → Videojuego)');
nn.push('SELECT p."Id", p."Nombre", COUNT(pv."VideojuegosId") AS videojuegos');
nn.push('FROM "Plataformas" p');
nn.push('LEFT JOIN "PlataformaVideojuego" pv ON pv."PlataformasId" = p."Id"');
nn.push('GROUP BY p."Id", p."Nombre" ORDER BY videojuegos DESC, p."Id";');
nn.push('');

fs.writeFileSync(path.join(root, 'sql', '02_datos_relacion_nn.sql'), nn.join('\n'), 'utf8');

console.log('Videojuegos:', videojuegos.length);
console.log('Relaciones N:N:', relaciones.length);
console.log('Géneros usados:', new Set(videojuegos.map(v => v[1])).size);
console.log('Desarrolladoras usadas:', new Set(videojuegos.map(v => v[2])).size);
console.log('Plataformas usadas:', new Set(relaciones.map(r => r[1])).size);
