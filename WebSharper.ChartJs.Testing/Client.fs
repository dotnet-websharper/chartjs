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
    linearOptions.Transitions <- Transition(
        Active = Anim(
            Animation = Animation(
                Duration = 0
            )
        )
    )
    linearOptions.Plugins <- Plugin(
        Title = TitleConfig(
            Display = true,
            Text = Union1Of2 "Custom Title",
            Font = Font(
                Size = 30,
                Family = "'Helvetica Neue', 'Helvetica', 'Arial', sans-serif",
                Style = FontStyle.Italic
            )
        ),
        Subtitle = TitleConfig(
            Display = true,
            Text = Union1Of2 "Custom chart subtitle",
            Font = Font(
                Size = 18,
                Family = "'Lucida Console', 'Courier New', 'monospace'"
            )
        )
    )

    let ds1 = LineChartDataSet()
    ds1.Type <- ChartType.Line
    ds1.Label <- "Line Dataset"
    ds1.BackgroundColor <- 
        Union2Of2[|
            "rgba(255, 99, 132, 0.2)";
            "rgba(54, 162, 235, 0.2)";
            "rgba(255, 206, 86, 0.2)";
            "rgba(75, 192, 192, 0.2)"
        |]
    ds1.BorderColor <- 
        Union2Of2[|
            "rgba(255, 99, 132, 1)";
            "rgba(54, 162, 235, 1)";
            "rgba(255, 206, 86, 1)";
            "rgba(75, 192, 192, 1)"
        |]   
    ds1.BorderWidth <- 3
    ds1.Data <- [|10;20;30;40|]
    let ds2 = BarChartDataSet()
    ds1.Type <- ChartType.Bar
    ds2.Label <- "Bar Dataset"
    ds2.Data <- [|40;30;20;10|]

    let mixedData = ChartData()
    mixedData.Datasets <- [|ds1;ds2|]
    mixedData.Labels <- [|"January";"February";"March";"April"|]

    let linearChart = ChartCreate(ChartType.Line, linearData, linearOptions)
    let barChart = ChartCreate(ChartType.Bar, linearData, linearOptions)
    let pieChart = ChartCreate(ChartType.Pie, linearData, linearOptions)
    let doughnutChart = ChartCreate(ChartType.Doughnut, linearData, linearOptions)
    let bubbleChart = ChartCreate(ChartType.Bubble, linearData, linearOptions)
    let scatterChart = ChartCreate(ChartType.Scatter, linearData, linearOptions)
    let radarChart = ChartCreate(ChartType.Radar, linearData, linearOptions)
    let mixedChart = ChartCreate(ChartType.Line, mixedData, linearOptions)

    let linear () = Chart("linear", linearChart)
    let bar () = Chart("bar", barChart)
    let pie () = Chart("pie", pieChart)
    let doughnut () = Chart("doughnut", doughnutChart)
    let bubble () = Chart("bubble", bubbleChart)
    let scatter () = Chart("scatter", scatterChart)
    let radar () = Chart("radar", radarChart)
    let mixed () = Chart("mixed", mixedChart)

    [<SPAEntryPoint>]
    let Main () =

        Doc.Concat [
            h1 [] [text "ChartJs sample site"]
            h2 [] [text "Linear chart"]
            canvas [attr.``id`` "linear";on.afterRender (fun _ -> linear () |> ignore)] []
            h2 [] [text "Bar chart"]
            canvas [attr.``id`` "bar";on.afterRender (fun _ -> bar () |> ignore)] []
            h2 [] [text "Pie chart"]
            canvas [attr.``id`` "pie";on.afterRender (fun _ -> pie () |> ignore)] []
            h2 [] [text "Doughnut chart"]
            canvas [attr.``id`` "doughnut";on.afterRender (fun _ -> doughnut () |> ignore)] []
            h2 [] [text "Bubble chart"]
            canvas [attr.``id`` "bubble";on.afterRender (fun _ -> bubble () |> ignore)] []
            h2 [] [text "Scatter chart"]
            canvas [attr.``id`` "scatter";on.afterRender (fun _ -> scatter () |> ignore)] []
            h2 [] [text "Radar chart"]
            canvas [attr.``id`` "radar";on.afterRender (fun _ -> radar () |> ignore)] []
            h2 [] [text "Mixed chart"]
            canvas [attr.``id`` "mixed";on.afterRender (fun _ -> mixed () |> ignore)] []
        ]
        |> Doc.RunById "main"
