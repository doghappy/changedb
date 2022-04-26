﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ChangeDB.Migration
{
    public interface IDataMigrator
    {
        Task BeforeWriteTargetTable(TableDescriptor tableDescriptor, AgentContext agentContext);

        Task AfterWriteTargetTable(TableDescriptor tableDescriptor, AgentContext agentContext);

        Task<DataTable> ReadSourceTable(TableDescriptor table, PageInfo pageInfo, AgentContext agentContext);

        Task<long> CountSourceTable(TableDescriptor table, AgentContext agentContext);

        Task WriteTargetTable(IAsyncEnumerable<DataTable> datas, TableDescriptor table, AgentContext agentContext, InsertionKind insertionKind);

    }
    public static class DataMigratorExtensions
    {

        public static async IAsyncEnumerable<DataTable> ReadSourceTable(this IDataMigrator dataMigrator, TableDescriptor sourceTable, AgentContext agentContext, MigrationSetting setting)
        {


            var (loadedCount, maxRowSize, fetchCount) = (0, 1, 1);

            while (true)
            {
                var pageInfo = new PageInfo { Offset = loadedCount, Limit = Math.Max(1, fetchCount) };
                var dataTable = await dataMigrator.ReadSourceTable(sourceTable, pageInfo, agentContext);

                yield return dataTable;

                loadedCount += dataTable.Rows.Count;
                maxRowSize = Math.Max(maxRowSize, dataTable.MaxRowSize());
                fetchCount = Math.Min(fetchCount * setting.GrowthSpeed, Math.Max(1, setting.FetchDataMaxSize / maxRowSize));

                if (dataTable.Rows.Count < pageInfo.Limit)
                {
                    break;
                }
            }
        }

        public static async IAsyncEnumerable<DataRow> ReadSourceRows(this IDataMigrator dataMigrator, TableDescriptor sourceTable, AgentContext agentContext, MigrationSetting setting)
        {
            await foreach (DataTable table in dataMigrator.ReadSourceTable(sourceTable, agentContext, setting))
            {
                foreach (DataRow row in table.Rows)
                {
                    yield return row;
                }
            }
        }
    }

}
