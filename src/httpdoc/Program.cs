﻿using Microsoft.OpenApi.Readers;
using HttpDocLib;
using System.Reflection;

var openApiDocument = args[0];
var outFolder = args[1];

// Load OpenAPI document
var fileStream = File.OpenRead(openApiDocument);
var result = await new OpenApiStreamReader().ReadAsync(fileStream);
var document = result.OpenApiDocument;

// Create TOC File
using var tocfile = File.Create(outFolder + "/toc.yml");

var tocBuilder = new TocBuilder(document,tocfile, 
        (uri,pathItem,operationType, operation,fileName) => {
            // Generate HTML documentation for TOC entry
            var outFile = outFolder + "/" + fileName;
            using var outStream = File.Create(outFile);
            var contentWriter = new StreamWriter(outStream);
            var writer = new OpenApiDocWriter(contentWriter, document); 
            writer.CreateHttpDoc(uri, pathItem, operationType, operation);
            contentWriter.Flush();
});

tocBuilder.BuildToc();

//Assembly.GetAssembly(typeof(OpenApiDocWriter)).GetManifestResourceNames().ToList().ForEach(x => Console.WriteLine(x));  
// Get OpenApi.css embedded resource and save to out folder
using var cssStream = Assembly.GetAssembly(typeof(OpenApiDocWriter))?.GetManifestResourceStream("httpdoclib.OpenApi.css");
if (cssStream == null) {
    throw new Exception("Could not find embedded resource httphoclib.OpenApi.css");
}
using var cssFile = File.Create(outFolder + "/OpenApi.css");
cssStream.CopyTo(cssFile);
