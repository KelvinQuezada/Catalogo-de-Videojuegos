\echo '=== ESTADO DESPUÉS DE LA MIGRACIÓN ActualizarVideojuego ==='
SELECT "MigrationId", "ProductVersion" FROM "__EFMigrationsHistory" ORDER BY "MigrationId";

\echo ''
\echo '=== NUEVAS COLUMNAS EN "Videojuegos" ==='
SELECT column_name, data_type, is_nullable, column_default
FROM information_schema.columns
WHERE table_name = 'Videojuegos' AND column_name IN ('Multijugador', 'Observacion');

\echo ''
\echo '=== CONSERVACIÓN DE LOS DATOS EXISTENTES ==='
SELECT COUNT(*) AS total,
       MD5(string_agg("Id" || '|' || "Titulo" || '|' || "Precio" || '|' || "FechaLanzamiento", ',' ORDER BY "Id")) AS huella
FROM "Videojuegos";

\echo ''
\echo '=== LOS 100 REGISTROS SIGUEN DISPONIBLES (muestra) ==='
SELECT "Id", "Titulo", "Precio", "Multijugador", COALESCE("Observacion", '(sin observación)') AS observacion
FROM "Videojuegos" ORDER BY "Id" LIMIT 5;
