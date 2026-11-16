\echo '=== TABLAS GENERADAS POR EF CORE (Code First) ==='
\dt

\echo ''
\echo '=== ESTRUCTURA DE "Videojuegos" (INCLUYE PK Y FK) ==='
\d "Videojuegos"

\echo ''
\echo '=== ESTRUCTURA DE "Generos" ==='
\d "Generos"

\echo ''
\echo '=== ESTRUCTURA DE "Desarrolladoras" ==='
\d "Desarrolladoras"

\echo ''
\echo '=== ESTRUCTURA DE "Plataformas" ==='
\d "Plataformas"

\echo ''
\echo '=== HISTORIAL DE MIGRACIONES ==='
SELECT "MigrationId", "ProductVersion" FROM "__EFMigrationsHistory" ORDER BY "MigrationId";
