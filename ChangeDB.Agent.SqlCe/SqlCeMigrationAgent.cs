﻿using System.Data.Common;
using ChangeDB.Migration;
using YS.Knife;

namespace ChangeDB.Agent.SqlCe
{
    [DictionaryKey("sqlce")]
    [Service]
    public class SqlCeMigrationAgent : IMigrationAgent
    {
        public IDataMigrator DataMigrator { get => SqlCeDataMigrator.Default; }
        public IMetadataMigrator MetadataMigrator { get => SqlCeMetadataMigrator.Default; }
        public IDatabaseTypeMapper DatabaseTypeMapper { get => SqlCeDatabaseTypeMapper.Default; }
        public ISqlExpressionTranslator ExpressionTranslator { get => SqlCeSqlExpressionTranslator.Default; }

        public DbConnection CreateConnection(string connectionString)
        {
            return null;
           // return new Npgsql.NpgsqlConnection(connectionString);
        }
    }
}
