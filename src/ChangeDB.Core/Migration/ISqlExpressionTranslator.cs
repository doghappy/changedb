﻿using System;
using System.Data;
using System.Data.Common;
using ChangeDB.Descriptors;

namespace ChangeDB.Migration
{
    public interface ISqlExpressionTranslator
    {
        [Obsolete("use another one")]
        SqlExpressionDescriptor ToCommonSqlExpression(string sqlExpression, SqlExpressionTranslatorContext context);

        SqlExpressionDescriptor ToCommonSqlExpression(string sqlExpression, string storeType, IDbConnection dbConnection);
        [Obsolete("use another one")]
        string FromCommonSqlExpression(SqlExpressionDescriptor sqlExpression, SqlExpressionTranslatorContext context);

        string FromCommonSqlExpression(SqlExpressionDescriptor sqlExpression, string storeType);
    }
    [Obsolete]
    public record SqlExpressionTranslatorContext
    {
        public SqlExpressionTranslatorContext()
        {

        }
        public string StoreType { get; set; }

        public AgentRunTimeInfo AgentInfo { get; set; }

        public DbConnection Connection { get; set; }

    }
}
