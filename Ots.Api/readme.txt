=== DOCKER ===
docker start ots-postgres ots-mssql        (bilgisayar açılınca)
docker stop ots-postgres ots-mssql         (kapatmadan önce)
docker ps                                  (çalışanları listele)
docker logs ots-mssql                      (konteynerin çıktısı)

=== EF CORE (pk-ots\Ots.Api klasöründe: Rider terminalinde önce "cd Ots.Api") ===
-- Migration üret (DB'ye dokunmaz) - HER İKİ CONTEXT İÇİN
dotnet ef migrations add <Ad> --context OtsMsSqlDbContext --output-dir Migrations/MsSql
dotnet ef migrations add <Ad> --context OtsPostgreSqlDbContext --output-dir Migrations/PostgreSql

-- DB'ye uygula
dotnet ef database update --context OtsMsSqlDbContext
dotnet ef database update --context OtsPostgreSqlDbContext

-- Belirli bir migration'a geri dön (Down çalışır)
dotnet ef database update <MigrationAdı> --context <Context>

-- Durum: hangi migration uygulandı, hangisi bekliyor (Pending)
dotnet ef migrations list --context <Context>

-- Son migration'ı sil (sadece DB'ye uygulanmamışsa)
dotnet ef migrations remove --context <Context>

=== BAĞLANTI BİLGİLERİ (sadece lokal) ===
PostgreSQL : localhost:5432  postgres / Ots12345
SQL Server : localhost:1433  sa / Ots.Sql12345