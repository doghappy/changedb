﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChangeDB.Agent.SqlCe;
using ChangeDB.Migration;


namespace ChangeDB.Agent.SqlCe
{
    public class SqlCeMetadataMigrator : IMetadataMigrator
    {
        public static readonly IMetadataMigrator Default = new SqlCeMetadataMigrator();
      

        public Task<DatabaseDescriptor> GetDatabaseDescriptor(DbConnection dbConnection, MigrationSetting migrationSetting)
        {
            var databaseDescriptor = SqlCeUtils.GetDataBaseDescriptorByEFCore(dbConnection);
            return Task.FromResult(databaseDescriptor);
        }
        public Task PreMigrate(DatabaseDescriptor databaseDescriptor, DbConnection dbConnection, MigrationSetting migrationSetting)
        {
            throw new NotImplementedException();
        }
        public Task PostMigrate(DatabaseDescriptor databaseDescriptor, DbConnection dbConnection, MigrationSetting migrationSetting)
        {
            throw new NotImplementedException();
        }

    }
}
