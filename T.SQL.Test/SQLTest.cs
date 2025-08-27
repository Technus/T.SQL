using System.Configuration;
using System.Reflection;
using static T.SQL.Mapper.SqlDataReaderExtensions;
using static T.SQL.Mapper.Old.SqlDataReaderExtensions;
using System.Data;
using System.Diagnostics;
using Xunit.Abstractions;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace T.SQL.Test;

public class SQLTest
{
    private readonly ITestOutputHelper output;
    
    static SQLTest()
    {
        CopyConfig();
    }

    public SQLTest(ITestOutputHelper output)
    {
        this.output = output;
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
    public async Task ReadBinaryAsyncNew()
    {
        for (int i = 0; i < 1000; i++)
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
        var s = Stopwatch.StartNew();
        for (int i = 0; i < 1000; i++)
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
        s.Stop();
        output.WriteLine($"T:{s.Elapsed}");
    }

    [Fact]
    public async Task ReadBinaryAsyncOld()
    {
        for (int i = 0; i < 1000; i++)
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
        var s = Stopwatch.StartNew();
        for (int i = 0; i < 1000; i++)
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
        s.Stop();
        output.WriteLine($"T:{s.Elapsed}");
    }

    [Fact]
    public void ReadBinaryNew()
    {
        for (int i = 0; i < 1000; i++)
        {
            using var conn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM [Test].[dbo].[TableBinaryStorage]";
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var data = reader.GetBytes("Bin");
            }
        }
        var s = Stopwatch.StartNew();
        for (int i = 0; i < 1000; i++)
        {
            using var conn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM [Test].[dbo].[TableBinaryStorage]";
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var data = reader.GetBytes("Bin");
            }
        }
        s.Stop();
        output.WriteLine($"T:{s.Elapsed}");
    }

    [Fact]
    public void ReadBinaryOld()
    {
        for (int i = 0; i < 1000; i++)
        {
            using var conn = new System.Data.SqlClient.SqlConnection(GetConnectionString());
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM [Test].[dbo].[TableBinaryStorage]";
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var data = reader.GetBytes("Bin");
            }
        }
        var s = Stopwatch.StartNew();
        for (int i = 0; i < 1000; i++)
        {
            using var conn = new System.Data.SqlClient.SqlConnection(GetConnectionString());
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM [Test].[dbo].[TableBinaryStorage]";
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var data = reader.GetBytes("Bin");
            }
        }
        s.Stop();
        output.WriteLine($"T:{s.Elapsed}");
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