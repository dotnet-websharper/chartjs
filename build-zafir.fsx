#load "tools/includes.fsx"
open IntelliFactory.Build

let buildTool =
    BuildTool().PackageId("Zafir.ChartJs")
        .VersionFrom("Zafir")
        .WithFSharpVersion(FSharpVersion.FSharp30)
        .WithFramework(fun f -> f.Net40)

let main =
    buildTool.Zafir.Extension("WebSharper.ChartJs")
        .SourcesFromProject()
        .Embed(["Chart.min.js"])

buildTool.Solution [
    main
    buildTool.NuGet.CreatePackage()
        .Configure(fun configuration ->
            { configuration with
                Title = Some "Zafir.ChartJs"
                LicenseUrl = Some "http://websharper.com/licensing"
                ProjectUrl = Some "https://bitbucket.org/IntelliFactory/websharper.chartjs"
                Description = "WebSharper Extension for Chart.js"
                Authors = ["IntelliFactory"]
                RequiresLicenseAcceptance = true })
        .Add(main)
]
|> buildTool.Dispatch
