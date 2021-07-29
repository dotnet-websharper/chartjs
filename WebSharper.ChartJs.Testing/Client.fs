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

//Common data

    let bgColor = [|
            "rgba(255, 99, 132, 0.2)";
            "rgba(54, 162, 235, 0.2)";
            "rgba(255, 206, 86, 0.2)";
            "rgba(75, 192, 192, 0.2)";
            "rgba(153, 102, 255, 0.2)";
            "rgba(255, 159, 64, 0.2)"
        |]
    
    let bdColor = [|
            "rgba(255, 99, 132, 1)";
            "rgba(54, 162, 235, 1)";
            "rgba(255, 206, 86, 1)";
            "rgba(75, 192, 192, 1)";
            "rgba(153, 102, 255, 1)";
            "rgba(255, 159, 64, 1)"
        |]  

//Line Data

    let lineDataSet = LineChartDataSet()
    lineDataSet.Label <- "# of Votes"
    lineDataSet.Data <- [|12;19;3;5;2;3|]
    lineDataSet.BorderColor <- Union2Of2 bdColor  
    lineDataSet.BorderWidth <- 6

    let lineData = ChartData()
    lineData.Datasets <- [|lineDataSet|]
    lineData.Labels <- [|"red";"blue";"yellow";"green";"purple";"orange"|]

//Bar Data

    let barDataSet = BarChartDataSet()
    barDataSet.Label <- "# of Votes"
    barDataSet.Data <- [|12;19;3;5;2;3|]
    barDataSet.BackgroundColor <- Union2Of2 bgColor
    barDataSet.BorderColor <- Union2Of2 bdColor  
    barDataSet.BorderWidth <- 6

    let barData = ChartData()
    barData.Datasets <- [|barDataSet|]
    barData.Labels <- [|"red";"blue";"yellow";"green";"purple";"orange"|]

//Pie Data

    let pieDataSet = PieChartDataSet()
    pieDataSet.Label <- "# of Votes"
    pieDataSet.Data <- [|12;19;3;5;2;3|]
    pieDataSet.BackgroundColor <- Union2Of2 bgColor
    pieDataSet.BorderColor <- Union2Of2 bdColor  
    pieDataSet.BorderWidth <- 3

    let pieData = ChartData()
    pieData.Datasets <- [|pieDataSet|]
    pieData.Labels <- [|"red";"blue";"yellow";"green";"purple";"orange"|]

//Doughnut Data

    let doughnutDataSet = DoughnutChartDataSet()
    doughnutDataSet.Label <- "# of Votes"
    doughnutDataSet.Data <- [|12;19;3;5;2;3|]
    doughnutDataSet.BackgroundColor <- Union2Of2 bgColor
    doughnutDataSet.BorderColor <- Union2Of2 bdColor  
    doughnutDataSet.BorderWidth <- 3

    let doughnutData = ChartData()
    doughnutData.Datasets <- [|doughnutDataSet|]
    doughnutData.Labels <- [|"red";"blue";"yellow";"green";"purple";"orange"|]

//Radar Data

    let radarDataSet1 = RadarChartDataSet()
    radarDataSet1.Label <- "First Dataset"
    radarDataSet1.Data <- [|65;59;90;81;56;55;40|]
    radarDataSet1.Fill <- Union1Of2 true
    radarDataSet1.BackgroundColor <- Union1Of2 "rgba(255, 99, 132, 0.2)"
    radarDataSet1.BorderColor <- Union1Of2 "rgba(255, 99, 132, 1)"
    radarDataSet1.PointBackgroundColor <- Union1Of2 "rgb(255, 99, 132)"
    radarDataSet1.PointBorderColor <- Union1Of2 "#fff"
    radarDataSet1.PointHoverBackgroundColor <- Union1Of2 "#fff"
    radarDataSet1.PointHoverBorderColor <- Union1Of2 "rgb(255, 99, 132)"
    
    let radarDataSet2 = RadarChartDataSet()
    radarDataSet2.Label <- "First Dataset"
    radarDataSet2.Data <- [|28;48;40;19;96;27;100|]
    radarDataSet2.Fill <- Union1Of2 true
    radarDataSet2.BackgroundColor <- Union1Of2 "rgba(54, 162, 235, 0.2)"
    radarDataSet2.BorderColor <- Union1Of2 "rgba(54, 162, 235, 1)"
    radarDataSet2.PointBackgroundColor <- Union1Of2 "rgb(54, 162, 235)"
    radarDataSet2.PointBorderColor <- Union1Of2 "#fff"
    radarDataSet2.PointHoverBackgroundColor <- Union1Of2 "#fff"
    radarDataSet2.PointHoverBorderColor <- Union1Of2 "rgb(54, 162, 235)"

    let radarData = ChartData()
    radarData.Datasets <- [|radarDataSet1;radarDataSet2|]
    radarData.Labels <- [|"Eating";"Drinking";"Sleeping";"Designing";"Coding";"Cooking";"Training"|]

//Bubble Data

    let bubbleDataSet = BubbleChartDataSet()
    bubbleDataSet.Label <- "First dataset"
    bubbleDataSet.Data <- [|BubbleDataObject(20.0,30.0,15); BubbleDataObject(40.0,10.0,10)|]
    bubbleDataSet.BackgroundColor <- Union1Of2 "rgb(255,99,132)"

    let bubbleData = ChartData()
    bubbleData.Datasets <- [|bubbleDataSet|]

//Scatter Data

    let scatterDataSet = ScatterChartDataSet()
    scatterDataSet.Label <- "Scatter Dataset"
    scatterDataSet.Data <- [|ScatterDataObject(-10,0);ScatterDataObject(0,10);ScatterDataObject(10,5);ScatterDataObject(0.5,5.5)|]
    scatterDataSet.BackgroundColor <- Union1Of2 "rgb(127,99,127)"

    let scatterData = ChartData()
    scatterData.Datasets <- [|scatterDataSet|]

//PolarArea Data

    let polarAreaDataSet = PolarAreaChartDataSet()
    polarAreaDataSet.Label <- "Polar area dataset"
    polarAreaDataSet.Data <- [|11;16;7;3;14|]
    polarAreaDataSet.BackgroundColor <- Union2Of2[|
        "rgb(255, 99, 132)";
        "rgb(75, 192, 192)";
        "rgb(255, 205, 86)";
        "rgb(201, 203, 207)";
        "rgb(54, 162, 235)"
    |]

    let polarAreaData = ChartData()
    polarAreaData.Datasets <- [|polarAreaDataSet|]
    polarAreaData.Labels <- [|"Red";"Green";"Yellow";"Grey";"Blue"|]

//Mixed Data

    let ds1 = LineChartDataSet()
    ds1.Label <- "Line Dataset"
    ds1.Data <- [|10;20;30;40|]
    ds1.BorderColor <- Union1Of2 "rgba(132, 99, 255, 1)"
    ds1.BorderWidth <- 3
    ds1.Order <- 2
    let ds2 = BarChartDataSet()
    ds2.Label <- "Bar Dataset"
    ds2.Data <- [|40;30;20;10|]
    ds2.BackgroundColor <- Union1Of2 "rgba(255, 99, 132, 1)"            
    ds2.BorderColor <- Union1Of2 "rgba(255, 99, 132, 1)"
    ds2.BorderWidth <- 3
    ds2.Order <- 1

    let mixedData = ChartData()
    mixedData.Datasets <- [|ds1;ds2|]
    mixedData.Labels <- [|"January";"February";"March";"April"|]
//Scale

    let scale = LinearAxis(BeginAtZero = true)


//Options

    let linearOptions = Options()
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
    barOptions.Scales <-
        New ["y",scale :> obj]
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
    
    let polarAreaOptions = Options()
    polarAreaOptions.Plugins <- Plugin(
        Title = TitleConfig(
            Display = true,
            Text = Union1Of2 "PolarArea Chart",
            Font = Font(
                Size = 30,
                Family = "'Helvetica Neue', 'Helvetica', 'Arial', sans-serif",
                Style = FontStyle.Italic
            )
        ),
        Subtitle = TitleConfig(
            Display = true,
            Text = Union1Of2 "subtitle for polararea chart",
            Font = Font(
                Size = 18,
                Family = "'Lucida Console', 'Courier New', 'monospace'"
            )
        )
    )

    let bubbleOptions = Options()
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
    radarOptions.Elements <- Union1Of2 (ElementConfig(Line = LineConfig(BorderWidth = 6)))

    let mixedOptions = Options()
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

//Charts

    let linearChart = ChartCreate(lineData, linearOptions)
    let barChart = ChartCreate(barData, barOptions)
    let pieChart = ChartCreate(pieData, pieOptions)
    let doughnutChart = ChartCreate(doughnutData, doughnutOptions)
    let bubbleChart = ChartCreate(bubbleData, bubbleOptions)
    let polarAreaChart = ChartCreate(polarAreaData, polarAreaOptions)
    let scatterChart = ChartCreate(scatterData, scatterOptions)
    let radarChart = ChartCreate(radarData, radarOptions)
    let mixedChart = ChartCreate(mixedData, mixedOptions)

    let linear () = Chart("linear", linearChart)
    let bar () = Chart("bar", barChart)
    let pie () = Chart("pie", pieChart)
    let doughnut () = Chart("doughnut", doughnutChart)
    let polarArea () = Chart("polarArea", polarAreaChart)
    let bubble () = Chart("bubble", bubbleChart)
    let scatter () = Chart("scatter", scatterChart)
    let radar () = Chart("radar", radarChart)
    let mixed () = Chart("mixed", mixedChart)

    [<SPAEntryPoint>]
    let Main () =
        let wrapCanvas x =
            div [] [x]
        Doc.Concat [
            h1 [] [text "ChartJs sample site"]
            canvas [attr.``id`` "linear";on.afterRender (fun _ -> linear () |> ignore)] [] |> wrapCanvas
            canvas [attr.``id`` "bar";on.afterRender (fun _ -> bar () |> ignore)] [] |> wrapCanvas
            canvas [attr.``id`` "pie";on.afterRender (fun _ -> pie () |> ignore)] [] |> wrapCanvas
            canvas [attr.``id`` "doughnut";on.afterRender (fun _ -> doughnut () |> ignore)] [] |> wrapCanvas
            canvas [attr.``id`` "polarArea";on.afterRender (fun _ -> polarArea () |> ignore)] [] |> wrapCanvas
            canvas [attr.``id`` "bubble";on.afterRender (fun _ -> bubble () |> ignore)] [] |> wrapCanvas
            canvas [attr.``id`` "scatter";on.afterRender (fun _ -> scatter () |> ignore)] [] |> wrapCanvas
            canvas [attr.``id`` "radar";on.afterRender (fun _ -> radar () |> ignore)] [] |> wrapCanvas
            canvas [attr.``id`` "mixed";on.afterRender (fun _ -> mixed () |> ignore)] [] |> wrapCanvas
        ]
        |> Doc.RunById "main"
