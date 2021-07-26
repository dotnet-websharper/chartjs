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

//Options

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
            Text = Union1Of2 "Linear Chart",
            Font = Font(
                Size = 30,
                Family = "'Helvetica Neue', 'Helvetica', 'Arial', sans-serif",
                Style = FontStyle.Italic
            )
        ),
        Subtitle = TitleConfig(
            Display = true,
            Text = Union1Of2 "subtitle for line chart",
            Font = Font(
                Size = 18,
                Family = "'Lucida Console', 'Courier New', 'monospace'"
            )
        )
    )

    let barOptions = Options()
    barOptions.Transitions <- Transition(
        Active = Anim(
            Animation = Animation(
                Duration = 0
            )
        )
    )
    barOptions.Plugins <- Plugin(
        Title = TitleConfig(
            Display = true,
            Text = Union1Of2 "Bar Chart",
            Font = Font(
                Size = 30,
                Family = "'Helvetica Neue', 'Helvetica', 'Arial', sans-serif",
                Style = FontStyle.Italic
            )
        ),
        Subtitle = TitleConfig(
            Display = true,
            Text = Union1Of2 "subtitle for bar chart",
            Font = Font(
                Size = 18,
                Family = "'Lucida Console', 'Courier New', 'monospace'"
            )
        )
    )
    
    let pieOptions = Options()
    pieOptions.Transitions <- Transition(
        Active = Anim(
            Animation = Animation(
                Duration = 0
            )
        )
    )
    pieOptions.Plugins <- Plugin(
        Title = TitleConfig(
            Display = true,
            Text = Union1Of2 "Pie Chart",
            Font = Font(
                Size = 30,
                Family = "'Helvetica Neue', 'Helvetica', 'Arial', sans-serif",
                Style = FontStyle.Italic
            )
        ),
        Subtitle = TitleConfig(
            Display = true,
            Text = Union1Of2 "subtitle for pie chart",
            Font = Font(
                Size = 18,
                Family = "'Lucida Console', 'Courier New', 'monospace'"
            )
        )
    )

    let doughnutOptions = Options()
    doughnutOptions.Transitions <- Transition(
        Active = Anim(
            Animation = Animation(
                Duration = 0
            )
        )
    )
    doughnutOptions.Plugins <- Plugin(
        Title = TitleConfig(
            Display = true,
            Text = Union1Of2 "Doughnut Chart",
            Font = Font(
                Size = 30,
                Family = "'Helvetica Neue', 'Helvetica', 'Arial', sans-serif",
                Style = FontStyle.Italic
            )
        ),
        Subtitle = TitleConfig(
            Display = true,
            Text = Union1Of2 "subtitle for doughnut chart",
            Font = Font(
                Size = 18,
                Family = "'Lucida Console', 'Courier New', 'monospace'"
            )
        )
    )
    
    let bubbleOptions = Options()
    bubbleOptions.Transitions <- Transition(
        Active = Anim(
            Animation = Animation(
                Duration = 0
            )
        )
    )
    bubbleOptions.Plugins <- Plugin(
        Title = TitleConfig(
            Display = true,
            Text = Union1Of2 "Bubble Chart",
            Font = Font(
                Size = 30,
                Family = "'Helvetica Neue', 'Helvetica', 'Arial', sans-serif",
                Style = FontStyle.Italic
            )
        ),
        Subtitle = TitleConfig(
            Display = true,
            Text = Union1Of2 "subtitle for bubble chart",
            Font = Font(
                Size = 18,
                Family = "'Lucida Console', 'Courier New', 'monospace'"
            )
        )
    )

    let scatterOptions = Options()
    scatterOptions.Transitions <- Transition(
        Active = Anim(
            Animation = Animation(
                Duration = 0
            )
        )
    )
    scatterOptions.Plugins <- Plugin(
        Title = TitleConfig(
            Display = true,
            Text = Union1Of2 "Scatter Chart",
            Font = Font(
                Size = 30,
                Family = "'Helvetica Neue', 'Helvetica', 'Arial', sans-serif",
                Style = FontStyle.Italic
            )
        ),
        Subtitle = TitleConfig(
            Display = true,
            Text = Union1Of2 "subtitle for scatter chart",
            Font = Font(
                Size = 18,
                Family = "'Lucida Console', 'Courier New', 'monospace'"
            )
        )
    )

    let radarOptions = Options()
    radarOptions.Transitions <- Transition(
        Active = Anim(
            Animation = Animation(
                Duration = 0
            )
        )
    )
    radarOptions.Plugins <- Plugin(
        Title = TitleConfig(
            Display = true,
            Text = Union1Of2 "Radar Chart",
            Font = Font(
                Size = 30,
                Family = "'Helvetica Neue', 'Helvetica', 'Arial', sans-serif",
                Style = FontStyle.Italic
            )
        ),
        Subtitle = TitleConfig(
            Display = true,
            Text = Union1Of2 "subtitle for radar chart",
            Font = Font(
                Size = 18,
                Family = "'Lucida Console', 'Courier New', 'monospace'"
            )
        )
    )

    let mixedOptions = Options()
    mixedOptions.Transitions <- Transition(
        Active = Anim(
            Animation = Animation(
                Duration = 0
            )
        )
    )
    mixedOptions.Plugins <- Plugin(
        Title = TitleConfig(
            Display = true,
            Text = Union1Of2 "Mixed Chart",
            Font = Font(
                Size = 30,
                Family = "'Helvetica Neue', 'Helvetica', 'Arial', sans-serif",
                Style = FontStyle.Italic
            )
        ),
        Subtitle = TitleConfig(
            Display = true,
            Text = Union1Of2 "subtitle for mixed chart",
            Font = Font(
                Size = 18,
                Family = "'Lucida Console', 'Courier New', 'monospace'"
            )
        )
    )

//Bubble chart

    let bubbleDataSet = BubbleChartDataSet()
    bubbleDataSet.Label <- "First dataset"
    bubbleDataSet.Data <- [|BubbleDataObject(20.0,30.0,15); BubbleDataObject(40.0,10.0,10)|]
    bubbleDataSet.BackgroundColor <- Union1Of2 "rgb(255,99,132)"

    let bubbleData = ChartData()
    bubbleData.Datasets <- [|bubbleDataSet|]

//Scatter chart

    let scatterDataSet = ScatterChartDataSet()
    scatterDataSet.Label <- "Scatter Dataset"
    scatterDataSet.Data <- [|ScatterDataObject(-10,0);ScatterDataObject(0,10);ScatterDataObject(10,5);ScatterDataObject(0.5,5.5)|]
    scatterDataSet.BackgroundColor <- Union1Of2 "rgb(127,99,127)"

    let scatterData = ChartData()
    scatterData.Datasets <- [|scatterDataSet|]

//Mixed charts

    let ds1 = LineChartDataSet()
    ds1.Type <- ChartType.Line
    ds1.Label <- "Line Dataset"
    ds1.Data <- [|10;20;30;40|]
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
    let ds2 = BarChartDataSet()
    ds2.Type <- ChartType.Bar
    ds2.Label <- "Bar Dataset"
    ds2.Data <- [|40;30;20;10|]
    ds2.BackgroundColor <- 
        Union2Of2[|
            "rgba(255, 99, 132, 0.2)";
            "rgba(54, 162, 235, 0.2)";
            "rgba(255, 206, 86, 0.2)";
            "rgba(75, 192, 192, 0.2)"
        |]
    ds2.BorderColor <- 
        Union2Of2[|
            "rgba(255, 99, 132, 1)";
            "rgba(54, 162, 235, 1)";
            "rgba(255, 206, 86, 1)";
            "rgba(75, 192, 192, 1)"
        |]   
    ds2.BorderWidth <- 3

    let mixedData = ChartData()
    mixedData.Datasets <- [|ds1;ds2|]
    mixedData.Labels <- [|"January";"February";"March";"April"|]

    let linearChart = ChartCreate(ChartType.Line, linearData, linearOptions)
    let barChart = ChartCreate(ChartType.Bar, linearData, barOptions)
    let pieChart = ChartCreate(ChartType.Pie, linearData, pieOptions)
    let doughnutChart = ChartCreate(ChartType.Doughnut, linearData, doughnutOptions)
    let bubbleChart = ChartCreate(ChartType.Bubble, bubbleData, bubbleOptions)
    let scatterChart = ChartCreate(ChartType.Scatter, scatterData, scatterOptions)
    let radarChart = ChartCreate(ChartType.Radar, linearData, radarOptions)
    let mixedChart = ChartCreate(ChartType.Line, mixedData, mixedOptions)

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
            canvas [attr.``id`` "linear";on.afterRender (fun _ -> linear () |> ignore)] []
            canvas [attr.``id`` "bar";on.afterRender (fun _ -> bar () |> ignore)] []
            canvas [attr.``id`` "pie";on.afterRender (fun _ -> pie () |> ignore)] []
            canvas [attr.``id`` "doughnut";on.afterRender (fun _ -> doughnut () |> ignore)] []
            canvas [attr.``id`` "bubble";on.afterRender (fun _ -> bubble () |> ignore)] []
            canvas [attr.``id`` "scatter";on.afterRender (fun _ -> scatter () |> ignore)] []
            canvas [attr.``id`` "radar";on.afterRender (fun _ -> radar () |> ignore)] []
            canvas [attr.``id`` "mixed";on.afterRender (fun _ -> mixed () |> ignore)] []
        ]
        |> Doc.RunById "main"
