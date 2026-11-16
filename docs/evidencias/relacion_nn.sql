\echo '=== ESTRUCTURA DE LA TABLA INTERMEDIA GENERADA POR EF CORE ==='
\d "PlataformaVideojuego"

\echo ''
\echo '=== HISTORIAL DE MIGRACIONES (3 migraciones aplicadas) ==='
SELECT "MigrationId", "ProductVersion" FROM "__EFMigrationsHistory" ORDER BY "MigrationId";

\echo ''
\echo '=== TOTAL DE ASOCIACIONES EN LA TABLA INTERMEDIA ==='
SELECT COUNT(*) AS asociaciones,
       COUNT(DISTINCT "VideojuegosId") AS videojuegos_con_plataformas,
       COUNT(DISTINCT "PlataformasId") AS plataformas_con_videojuegos
FROM "PlataformaVideojuego";

\echo ''
\echo '=== SENTIDO 1: UN VIDEOJUEGO EN VARIAS PLATAFORMAS (Id 16) ==='
SELECT v."Titulo", p."Id" AS plataforma_id, p."Nombre" AS plataforma
FROM "Videojuegos" v
JOIN "PlataformaVideojuego" pv ON pv."VideojuegosId" = v."Id"
JOIN "Plataformas" p ON p."Id" = pv."PlataformasId"
WHERE v."Id" = 16
ORDER BY p."Id";

\echo ''
\echo '=== SENTIDO INVERSO: UNA PLATAFORMA CON VARIOS VIDEOJUEGOS (Id 6) ==='
SELECT p."Nombre" AS plataforma, v."Id" AS videojuego_id, v."Titulo"
FROM "Plataformas" p
JOIN "PlataformaVideojuego" pv ON pv."PlataformasId" = p."Id"
JOIN "Videojuegos" v ON v."Id" = pv."VideojuegosId"
WHERE p."Id" = 6
ORDER BY v."Id";

\echo ''
\echo '=== RESUMEN: PLATAFORMAS POR VIDEOJUEGO (TOP 5) ==='
SELECT v."Id", v."Titulo", COUNT(*) AS plataformas
FROM "Videojuegos" v
JOIN "PlataformaVideojuego" pv ON pv."VideojuegosId" = v."Id"
GROUP BY v."Id", v."Titulo"
ORDER BY plataformas DESC, v."Id" LIMIT 5;
