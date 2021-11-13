﻿using System.Data.Common;
using System.Threading.Tasks;

namespace ChangeDB.Migration
{
    public interface IMetadataMigrator
    {
        Task<DatabaseDescriptor> GetDatabaseDescriptor(DbConnection connection, MigrationSetting migrationSetting);

        Task PreMigrate(DatabaseDescriptor databaseDescriptor, DbConnection connection, MigrationSetting migrationSetting);

        Task PostMigrate(DatabaseDescriptor databaseDescriptor, DbConnection connection, MigrationSetting migrationSetting);

        Task DropDatabaseIfExists(DbConnection connection, MigrationSetting migrationSetting);

        Task CreateDatabase(DbConnection connection, MigrationSetting migrationSetting);

        public async Task MigrateAllMetaData(DatabaseDescriptor databaseDescriptor, DbConnection connection, MigrationSetting migrationSetting)
        {
            await PreMigrate(databaseDescriptor, connection, migrationSetting);
            await PostMigrate(databaseDescriptor, connection, migrationSetting);
        }

        public async Task ReCreateDatabase(DbConnection connection, MigrationSetting migrationSetting)
        {
            await DropDatabaseIfExists(connection, migrationSetting);
            await CreateDatabase(connection, migrationSetting);
        }
    }
}
