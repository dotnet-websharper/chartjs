#load "tools/includes.fsx"
open IntelliFactory.Build

let buildTool =
    BuildTool().PackageId("WebSharper.ChartJs", "3.0-alpha")
    |> fun buildTool ->
        buildTool.WithFramework(buildTool.Framework.Net40)

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
