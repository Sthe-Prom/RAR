using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Linq;

namespace RAR.Extensions
{
    public static class MigrationBuilderExtensions
    {
        public static void ConfigForSqlite(this MigrationBuilder migrationBuilder)
        {
            //For each table registered in the builder, let's change the type of nvarchar to TEXT
            foreach (CreateTableOperation createTableOperation in migrationBuilder.Operations.ToArray().OfType<CreateTableOperation>())
            {
                foreach (var column in createTableOperation.Columns.Where(x => x.ColumnType.StartsWith("nvarchar", StringComparison.OrdinalIgnoreCase)))
                {
                    if (column.ColumnType.Contains('(') && !column.ColumnType.Contains("MAX", StringComparison.OrdinalIgnoreCase))
                        column.MaxLength = int.Parse(column.ColumnType.Substring("nvarchar".Length + 1).Replace(")", ""));
                    column.ColumnType = "TEXT";
                }
            }
        }
    }
}