using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.OpenApi.MicrosoftExtensions;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Services;

namespace HttpDocLib;

public static class Constants
{
    public const string DefaultOpenApiLabel = "default";
    public const string TempDirectoryName = "kiota";
}


public static partial class OpenApiUrlTreeNodeExtensions
{
    private static string GetDotIfBothNotNullOfEmpty(string x, string y) => string.IsNullOrEmpty(x) || string.IsNullOrEmpty(y) ? string.Empty : ".";
    private static readonly Func<string, string> replaceSingleParameterSegmentByItem =
    static x => x.IsPathSegmentWithSingleSimpleParameter() ? "item" : x;
    private static readonly char[] namespaceNameSplitCharacters = ['.', '-', '$']; //$ref from OData
    private const string EscapedSuffix = "Escaped";
    internal static string GetNamespaceFromPath(this string currentPath, string prefix) =>
        prefix +
                ((currentPath?.Contains(PathNameSeparator, StringComparison.OrdinalIgnoreCase) ?? false) ?
                    (string.IsNullOrEmpty(prefix) ? string.Empty : ".")
                            + currentPath
                            .Split(PathNameSeparator, StringSplitOptions.RemoveEmptyEntries)
                            .Select(replaceSingleParameterSegmentByItem)
                            .Select(static x => string.Join(string.Empty, x
                                                    .Split(namespaceNameSplitCharacters, StringSplitOptions.RemoveEmptyEntries)
                                                    .Select(CleanupParametersFromPath)
                                                    .Select(static (y, idx) => idx == 0 ? y : y.ToFirstCharacterUpperCase())))
                            .Select(static x => SegmentsToSkipForClassNames.Contains(x) ? $"{x}{EscapedSuffix}" : x)
                            .Select(static x => x.CleanupSymbolName())
                            .Select(static x => "models".Equals(x, StringComparison.OrdinalIgnoreCase) ? $"{x}Requests" : x) //avoids projecting requests builders to models namespace
                            .Aggregate(string.Empty,
                                static (x, y) => $"{x}{GetDotIfBothNotNullOfEmpty(x, y)}{y}") :
                    string.Empty)
                .ReplaceValueIdentifier();
    public static string GetNodeNamespaceFromPath(this OpenApiUrlTreeNode currentNode, string prefix)
    {
        ArgumentNullException.ThrowIfNull(currentNode);
        return currentNode.Path.GetNamespaceFromPath(prefix);
    }
    //{id}, name(idParam={id}), name(idParam='{id}'), name(idParam='{id}',idParam2='{id2}')
    [GeneratedRegex(@"(?:\w+)?=?'?\{(?<paramName>\w+)\}'?,?", RegexOptions.Singleline, 500)]
    private static partial Regex PathParametersRegex();
    // microsoft.graph.getRoleScopeTagsByIds(ids=@ids)
    [GeneratedRegex(@"=@(\w+)", RegexOptions.Singleline, 500)]
    private static partial Regex AtSignPathParameterRegex();
    private const char RequestParametersChar = '{';
    private const char RequestParametersEndChar = '}';
    private const string RequestParametersSectionChar = "(";
    private const string RequestParametersSectionEndChar = ")";
    private const string WithKeyword = "With";
    private static readonly MatchEvaluator requestParametersMatchEvaluator = match =>
        WithKeyword + match.Groups["paramName"].Value.ToFirstCharacterUpperCase();
    private static string CleanupParametersFromPath(string pathSegment)
    {
        if (string.IsNullOrEmpty(pathSegment))
            return pathSegment;
        return PathParametersRegex().Replace(
                                        AtSignPathParameterRegex().Replace(pathSegment, "={$1}"),
                                        requestParametersMatchEvaluator)
                                    .Replace(RequestParametersSectionEndChar, string.Empty, StringComparison.OrdinalIgnoreCase)
                                    .Replace(RequestParametersSectionChar, string.Empty, StringComparison.OrdinalIgnoreCase);
    }
    private static IEnumerable<OpenApiParameter> GetParametersForPathItem(OpenApiPathItem pathItem, string nodeSegment)
    {
        return pathItem.Parameters
                    .Union(pathItem.Operations.SelectMany(static x => x.Value.Parameters))
                    .Where(static x => x.In == ParameterLocation.Path)
                    .Where(x => nodeSegment.Contains($"{{{x.Name}}}", StringComparison.OrdinalIgnoreCase));
    }
    public static IEnumerable<OpenApiParameter> GetPathParametersForCurrentSegment(this OpenApiUrlTreeNode node)
    {
        if (node != null &&
            node.IsComplexPathMultipleParameters())
            if (node.PathItems.TryGetValue(Constants.DefaultOpenApiLabel, out var pathItem))
                return GetParametersForPathItem(pathItem, node.DeduplicatedSegment());
            else if (node.Children.Any())
                return node.Children
                            .Where(static x => x.Value.PathItems.ContainsKey(Constants.DefaultOpenApiLabel))
                            .SelectMany(x => GetParametersForPathItem(x.Value.PathItems[Constants.DefaultOpenApiLabel], node.DeduplicatedSegment()))
                            .Distinct();
        return Enumerable.Empty<OpenApiParameter>();
    }
    private const char PathNameSeparator = '\\';
    [GeneratedRegex(@"-?id\d?}?$", RegexOptions.Singleline | RegexOptions.IgnoreCase, 500)]
    private static partial Regex idClassNameCleanup();
    private static readonly HashSet<string> httpVerbs = new(8, StringComparer.OrdinalIgnoreCase) { "get", "post", "put", "patch", "delete", "head", "options", "trace" };
    private static readonly HashSet<string> SegmentsToSkipForClassNames = new(6, StringComparer.OrdinalIgnoreCase) {
        "json",
        "xml",
        "csv",
        "yaml",
        "yml",
        "txt",
    };
    [GeneratedRegex(@"[\r\n\t]", RegexOptions.Singleline, 500)]
    private static partial Regex descriptionCleanupRegex();
    public static string CleanupDescription(this string? description) => string.IsNullOrEmpty(description) ? string.Empty : descriptionCleanupRegex().Replace(description, string.Empty);
    public static string GetPathItemDescription(this OpenApiUrlTreeNode currentNode, string label, string? defaultValue = default)
    {
        if (currentNode != null && !string.IsNullOrEmpty(label) && currentNode.PathItems.TryGetValue(label, out var pathItem))
            return ((string.IsNullOrEmpty(pathItem.Description), string.IsNullOrEmpty(pathItem.Summary)) switch
            {
                (false, _) => pathItem.Description,
                (_, false) => pathItem.Summary,
                (_, _) => defaultValue,
            }).CleanupDescription();
        return string.IsNullOrEmpty(defaultValue) ? string.Empty : defaultValue;
    }
    public static bool DoesNodeBelongToItemSubnamespace(this OpenApiUrlTreeNode currentNode) => currentNode.IsPathSegmentWithSingleSimpleParameter();
    public static bool IsPathSegmentWithSingleSimpleParameter(this OpenApiUrlTreeNode currentNode) =>
        currentNode?.DeduplicatedSegment().IsPathSegmentWithSingleSimpleParameter() ?? false;
    private static bool IsPathSegmentWithSingleSimpleParameter(this string currentSegment)
    {
        if (string.IsNullOrEmpty(currentSegment)) return false;
        var segmentWithoutExtension = stripExtensionForIndexersRegex().Replace(currentSegment, string.Empty);

        return segmentWithoutExtension.StartsWith(RequestParametersChar) &&
                segmentWithoutExtension.EndsWith(RequestParametersEndChar) &&
                segmentWithoutExtension.IsPathSegmentWithNumberOfParameters(static x => x.Count() == 1);
    }
    private static bool IsPathSegmentWithNumberOfParameters(this string currentSegment, Func<IEnumerable<char>, bool> eval)
    {
        if (string.IsNullOrEmpty(currentSegment)) return false;

        return eval(currentSegment.Where(static x => x == RequestParametersChar));
    }
    [GeneratedRegex(@"\.(?:json|yaml|yml|csv|txt)$", RegexOptions.Singleline, 500)]
    private static partial Regex stripExtensionForIndexersRegex(); // so {param-name}.json is considered as indexer
    [GeneratedRegex(@"\{\w+\}\.(?:json|yaml|yml|csv|txt)$", RegexOptions.Singleline, 500)]
    private static partial Regex stripExtensionForIndexersTestRegex(); // so {param-name}.json is considered as indexer
    public static bool IsComplexPathMultipleParameters(this OpenApiUrlTreeNode currentNode) =>
        (currentNode?.DeduplicatedSegment()?.IsPathSegmentWithNumberOfParameters(static x => x.Any()) ?? false) && !currentNode.IsPathSegmentWithSingleSimpleParameter();
    public static string GetUrlTemplate(this OpenApiUrlTreeNode currentNode)
    {
        ArgumentNullException.ThrowIfNull(currentNode);
        var queryStringParameters = string.Empty;
        if (currentNode.HasOperations(Constants.DefaultOpenApiLabel))
        {
            var pathItem = currentNode.PathItems[Constants.DefaultOpenApiLabel];
            var parameters = pathItem.Parameters
                                    .Where(static x => x.In == ParameterLocation.Query)
                                    .Union(
                                        pathItem.Operations
                                                .SelectMany(static x => x.Value.Parameters)
                                                .Where(static x => x.In == ParameterLocation.Query))
                                    .DistinctBy(static x => x.Name)
                                    .ToArray();
            if (parameters.Length != 0)
                queryStringParameters = "{?" +
                                        parameters.Select(static x =>
                                                            x.Name.SanitizeParameterNameForUrlTemplate() +
                                                            (x.Explode ?
                                                                "*" : string.Empty))
                                                .Aggregate(static (x, y) => $"{x},{y}") +
                                        '}';
        }
        var pathReservedPathParametersIds = currentNode.PathItems.TryGetValue(Constants.DefaultOpenApiLabel, out var pItem) ?
                                                pItem.Parameters
                                                        .Union(pItem.Operations.SelectMany(static x => x.Value.Parameters))
                                                        .Where(static x => x.In == ParameterLocation.Path && x.Extensions.TryGetValue(OpenApiReservedParameterExtension.Name, out var ext) && ext is OpenApiReservedParameterExtension reserved && reserved.IsReserved.HasValue && reserved.IsReserved.Value)
                                                        .Select(static x => x.Name)
                                                        .ToHashSet(StringComparer.OrdinalIgnoreCase) :
                                                new HashSet<string>();
        return "{+baseurl}" +
                SanitizePathParameterNamesForUrlTemplate(currentNode.Path.Replace('\\', '/'), pathReservedPathParametersIds) +
                queryStringParameters;
    }
    [GeneratedRegex(@"{(?<paramname>[^}]+)}", RegexOptions.Singleline, 500)]
    private static partial Regex pathParamMatcher();
    private static string SanitizePathParameterNamesForUrlTemplate(string original, HashSet<string> reservedParameterNames)
    {
        if (string.IsNullOrEmpty(original) || !original.Contains('{', StringComparison.OrdinalIgnoreCase)) return original;
        var parameters = pathParamMatcher().Matches(original);
        foreach (var value in parameters.Select(x => x.Groups["paramname"].Value))
            original = original.Replace(value, (reservedParameterNames.Contains(value) ? "+" : string.Empty) + value.SanitizeParameterNameForUrlTemplate(), StringComparison.Ordinal);
        return original;
    }
    public static string SanitizeParameterNameForUrlTemplate(this string original)
    {
        if (string.IsNullOrEmpty(original)) return original;
        return Uri.EscapeDataString(stripExtensionForIndexersRegex()
                                        .Replace(original, string.Empty) // {param-name}.json becomes {param-name}
                                .TrimStart('{')
                                .TrimEnd('}'))
                    .Replace("-", "%2D", StringComparison.OrdinalIgnoreCase)
                    .Replace(".", "%2E", StringComparison.OrdinalIgnoreCase)
                    .Replace("~", "%7E", StringComparison.OrdinalIgnoreCase);// - . ~ are invalid uri template character but don't get encoded by Uri.EscapeDataString
    }
    [GeneratedRegex(@"%[0-9A-F]{2}", RegexOptions.Singleline, 500)]
    private static partial Regex removePctEncodedCharacters();
    public static string SanitizeParameterNameForCodeSymbols(this string original, string replaceEncodedCharactersWith = "")
    {
        if (string.IsNullOrEmpty(original)) return original;
        return removePctEncodedCharacters().Replace(original.ToCamelCase('-', '.', '~').SanitizeParameterNameForUrlTemplate(), replaceEncodedCharactersWith);
    }
    private const string DeduplicatedSegmentKey = "x-ms-kiota-deduplicatedSegment";
    public static string DeduplicatedSegment(this OpenApiUrlTreeNode currentNode)
    {
        if (currentNode is null) return string.Empty;
        if (currentNode.AdditionalData.TryGetValue(DeduplicatedSegmentKey, out var deduplicatedSegment) && deduplicatedSegment.FirstOrDefault() is string deduplicatedSegmentString)
            return deduplicatedSegmentString;
        return currentNode.Segment;
    }
    public static void AddDeduplicatedSegment(this OpenApiUrlTreeNode openApiUrlTreeNode, string newName)
    {
        ArgumentNullException.ThrowIfNull(openApiUrlTreeNode);
        ArgumentException.ThrowIfNullOrEmpty(newName);
        openApiUrlTreeNode.AdditionalData.Add(DeduplicatedSegmentKey, [newName]);
    }
}
