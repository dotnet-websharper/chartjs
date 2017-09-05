#load "tools/includes.fsx"
open IntelliFactory.Build

let buildTool =
    BuildTool().PackageId("WebSharper.ChartJs")
        .VersionFrom("WebSharper", versionSpec = "(,4.0)")
        .WithFSharpVersion(FSharpVersion.FSharp30)
        .WithFramework(fun f -> f.Net40)

let main =
    buildTool.WebSharper.Extension("WebSharper.ChartJs")
        .SourcesFromProject()
        .Embed(["Chart.min.js"])

buildTool.Solution [
    main
    buildTool.NuGet.CreatePackage()
        .Configure(fun configuration ->
            { configuration with
                Title = Some "WebSharper.ChartJs"
                LicenseUrl = Some "http://websharper.com/licensing"
                ProjectUrl = Some "https://bitbucket.org/IntelliFactory/websharper.chartjs"
                Description = "WebSharper Extension for Chart.js"
                Authors = ["IntelliFactory"]
                RequiresLicenseAcceptance = true })
        .Add(main)
]
|> buildTool.Dispatch
