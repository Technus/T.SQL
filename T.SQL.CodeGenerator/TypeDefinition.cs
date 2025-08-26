using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;

namespace T.SQL.CodeGenerator;
internal class TypeDefinition
{
    public TypeDefinition(
      TypeDeclarationSyntax typeDeclarationSyntax,
      string name,
      string namespaceName,
      List<string> typeList,
      List<ISymbol> tableMemberDeclarations,
      List<ITypeSymbol> implementingTypes)
    {
        TypeDeclarationSyntax = typeDeclarationSyntax;
        Name = name;
        Namespace = namespaceName;
        TypeList = typeList;
        TableMemberDeclarations = tableMemberDeclarations;
        Commands = [];
        ImplementingTypes = implementingTypes;
    }

    public TypeDeclarationSyntax TypeDeclarationSyntax { get; }

    /// <summary>
    /// The output file name
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// The namespace
    /// </summary>
    public string Namespace { get; }

    /// <summary>
    /// In case of types rooted in other types
    /// </summary>
    public List<string> TypeList { get; }

    /// <summary>
    /// Members in the type to write
    /// </summary>
    public List<ISymbol> TableMemberDeclarations { get; }

    public Dictionary<string, (ISymbol method, IMethodSymbol invoke)> Commands { get; }

    public List<ITypeSymbol> ImplementingTypes { get; }
}
