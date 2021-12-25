﻿using System.Data.Common;
using System.Data.SqlServerCe;
using ChangeDB.Agent.SqlServer;
using ChangeDB.Migration;

namespace ChangeDB.Agent.SqlCe
{
    public class SqlCeMigrationAgent : IMigrationAgent
    {
        public IDataMigrator DataMigrator { get => SqlCeDataMigrator.Default; }
        public IMetadataMigrator MetadataMigrator { get => SqlCeMetadataMigrator.Default; }
        public IDataTypeMapper DataTypeMapper { get => SqlCeDataTypeMapper.Default; }
        public ISqlExpressionTranslator ExpressionTranslator { get => SqlServerSqlExpressionTranslator.Default; }
        public IDatabaseManager DatabaseManger { get => SqlCeDatabaseManager.Default; }
        public AgentSetting AgentSetting { get => new AgentSetting { DefaultSchema = null, ObjectNameMaxLength = 128, IdentityName = SqlCeUtils.IdentityName }; }
        public IRepr Repr { get => SqlServerRepr.Default; }

        public DbConnection CreateConnection(string connectionString) => new SqlCeConnection(connectionString);

    }
}
