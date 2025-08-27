using System.Configuration;
using System.Reflection;
using static T.SQL.Mapper.SqlDataReaderExtensions;
using static T.SQL.Mapper.Old.SqlDataReaderExtensions;
using System.Data;

namespace T.SQL.Test;

public class SQLTest
{
    static SQLTest()
    {
        CopyConfig();
    }

    private static void CopyConfig()
    {
        try
        {
            var targetPath = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).FilePath;
            var sourcePath = Path.Combine(Path.GetDirectoryName(targetPath)!, $"{Path.GetFileName(Assembly.GetExecutingAssembly().Location)}.config");
            File.Copy(sourcePath, targetPath, true);
        }
        catch
        {
            // ignore, should already be copied
        }
    }

    public string GetConnectionString() => ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;

    [Fact]
    public async Task ConnectNew()
    {
        using var conn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
        await conn.OpenAsync();
    }

    [Fact]
    public async Task ConnectOld()
    {
        using var conn = new System.Data.SqlClient.SqlConnection(GetConnectionString());
        await conn.OpenAsync();
    }

    [Fact]
    public async Task ReadBinaryNew()
    {
        using var conn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
        await conn.OpenAsync();
        var cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT * FROM [Test].[dbo].[TableBinaryStorage]";
        var reader = await cmd.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            var data = reader.GetBytes("Bin");
        }
    }

    [Fact]
    public async Task ReadBinaryOld()
    {
        using var conn = new System.Data.SqlClient.SqlConnection(GetConnectionString());
        await conn.OpenAsync();
        var cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT * FROM [Test].[dbo].[TableBinaryStorage]";
        var reader = await cmd.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            var data = reader.GetBytes("Bin");
        }
    }

    public async Task<string> CreateTable(string? name = default)
    {
        name ??= $"TestTable_{Guid.NewGuid():N}";

        await DeleteTable(name);

        using var conn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
        await conn.OpenAsync();
        using var cmd = conn.CreateCommand();
        cmd.CommandText = $"""
            CREATE TABLE {name} (
                Id INT PRIMARY KEY IDENTITY,
                Name NVARCHAR(100) NOT NULL
            );
            """;
        _ = await cmd.ExecuteNonQueryAsync();

        return name;
    }

    protected internal async Task DeleteTable(string? name)
    {
        using var conn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
        await conn.OpenAsync();
        using var cmd = conn.CreateCommand();
        cmd.CommandText = $"""
            IF OBJECT_ID(N'{name}', N'U') IS NOT NULL
                DROP TABLE {name};
            """;
        _ = await cmd.ExecuteNonQueryAsync();
    }
}