\echo '=== CANTIDAD DE REGISTROS POR TABLA ==='
SELECT 'Generos' AS tabla, COUNT(*) AS registros FROM "Generos"
UNION ALL SELECT 'Desarrolladoras', COUNT(*) FROM "Desarrolladoras"
UNION ALL SELECT 'Plataformas', COUNT(*) FROM "Plataformas"
UNION ALL SELECT 'Videojuegos', COUNT(*) FROM "Videojuegos"
ORDER BY tabla;

\echo ''
\echo '=== HUELLA DE LOS DATOS (para comprobar conservación) ==='
SELECT COUNT(*) AS total,
       MD5(string_agg("Id" || '|' || "Titulo" || '|' || "Precio" || '|' || "FechaLanzamiento", ',' ORDER BY "Id")) AS huella
FROM "Videojuegos";

\echo ''
\echo '=== MUESTRA DE VIDEOJUEGOS CON SUS RELACIONES 1:N ==='
SELECT v."Id", v."Titulo", v."Precio", v."FechaLanzamiento" AS lanzamiento,
       g."Nombre" AS genero, d."Nombre" AS desarrolladora
FROM "Videojuegos" v
JOIN "Generos" g ON g."Id" = v."GeneroId"
JOIN "Desarrolladoras" d ON d."Id" = v."DesarrolladoraId"
ORDER BY v."Id"
LIMIT 10;
