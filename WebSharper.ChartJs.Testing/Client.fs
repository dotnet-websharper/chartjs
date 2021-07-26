namespace WebSharper.ChartJs.Testing

open WebSharper
open WebSharper.JavaScript
open WebSharper.JQuery
open WebSharper.UI
open WebSharper.UI.Html
open WebSharper.UI.Client
open WebSharper.UI.Templating
open WebSharper.ChartJs

[<JavaScript>]
module Client =


    let linearDataSet = LineChartDataSet()
    linearDataSet.Label <- "# of Votes"
    linearDataSet.Data <- [|12;19;3;5;2;3|]
    linearDataSet.BackgroundColor <- 
        Union2Of2[|
            "rgba(255, 99, 132, 0.2)";
            "rgba(54, 162, 235, 0.2)";
            "rgba(255, 206, 86, 0.2)";
            "rgba(75, 192, 192, 0.2)";
            "rgba(153, 102, 255, 0.2)";
            "rgba(255, 159, 64, 0.2)"
        |]
    linearDataSet.BorderColor <- 
        Union2Of2[|
            "rgba(255, 99, 132, 1)";
            "rgba(54, 162, 235, 1)";
            "rgba(255, 206, 86, 1)";
            "rgba(75, 192, 192, 1)";
            "rgba(153, 102, 255, 1)";
            "rgba(255, 159, 64, 1)"
        |]   
    linearDataSet.BorderWidth <- 3


    let linearData = ChartData()
    linearData.Datasets <- [|linearDataSet|]
    linearData.Labels <- [|"red";"blue";"yellow";"green";"purple";"orange"|]

    let linearOptions = Options()
    linearOptions.Scales <- Scale()

    let linearChart = ChartCreate(ChartType.Line, linearData, linearOptions)
    let barChart = ChartCreate(ChartType.Bar, linearData, linearOptions)
    let pieChart = ChartCreate(ChartType.Pie, linearData, linearOptions)
    let doughnutChart = ChartCreate(ChartType.Doughnut, linearData, linearOptions)

    let linear () = Chart("linear", linearChart)
    let bar () = Chart("bar", barChart)
    let pie () = Chart("pie", pieChart)
    let doughnut () = Chart("doughnut", doughnutChart)

    [<SPAEntryPoint>]
    let Main () =

        Doc.Concat [
            h1 [] [text "ChartJs sample site"]
            h2 [] [text "Linear chart"]
            canvas [
                attr.``id`` "linear"
                on.afterRender (fun _ -> linear () |> ignore)
            ] []
            h2 [] [text "Bar chart"]
            canvas [
                attr.``id`` "bar"
                on.afterRender (fun _ -> bar () |> ignore)
            ] []
            h2 [] [text "Pie chart"]
            canvas [
                attr.``id`` "pie"
                on.afterRender (fun _ -> pie () |> ignore)
            ] []
            h2 [] [text "Doughnut chart"]
            canvas [
                attr.``id`` "doughnut"
                on.afterRender (fun _ -> doughnut () |> ignore)
            ] []
        ]
        |> Doc.RunById "main"
