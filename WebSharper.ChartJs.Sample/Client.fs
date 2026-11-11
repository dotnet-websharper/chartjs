namespace WebSharper.ChartJs.Sample

open WebSharper
open WebSharper.JavaScript
open WebSharper.UI
open WebSharper.UI.Client
open WebSharper.UI.Templating
open WebSharper.ChartJs

[<JavaScript>]
module Client =

    // The template is the whole document, loaded from the DOM, so editing
    // index.html and refreshing the browser is enough.
    type IndexTemplate = Template<"index.html", ClientLoad.FromDocument>

    // ------------------------------------------------------------------
    // Theme (light by default, choice persisted in localStorage)
    // ------------------------------------------------------------------

    // Keep in sync with the bootstrap script in index.html.
    let themeStorageKey = "websharper-chartjs-theme"

    let theme = Var.Create "light"
    let themeLabel = Var.Create "🌙 Dark mode"

    let applyTheme () =
        JS.Document.DocumentElement.SetAttribute("data-theme", theme.Value)
        themeLabel.Value <-
            if theme.Value = "dark" then "☀️ Light mode" else "🌙 Dark mode"

    let toggleTheme () =
        theme.Value <- (if theme.Value = "dark" then "light" else "dark")
        try JS.Window.LocalStorage.SetItem(themeStorageKey, theme.Value) with _ -> ()
        applyTheme ()

    // ------------------------------------------------------------------
    // Readouts
    // ------------------------------------------------------------------

    let status = Var.Create "Interact with a chart: hover it, or click inside it."
    let version = Var.Create "-"
    let hovered = Var.Create "-"
    let inspection = Var.Create "Click a chart to inspect the elements under the pointer."
    let snapshot = Var.Create ""

    // ------------------------------------------------------------------
    // Palette and data helpers
    // ------------------------------------------------------------------

    let bgColor = [|
        "rgba(255, 99, 132, 0.2)"
        "rgba(54, 162, 235, 0.2)"
        "rgba(255, 206, 86, 0.2)"
        "rgba(75, 192, 192, 0.2)"
        "rgba(153, 102, 255, 0.2)"
        "rgba(255, 159, 64, 0.2)"
    |]

    let bdColor = [|
        "rgba(255, 99, 132, 1)"
        "rgba(54, 162, 235, 1)"
        "rgba(255, 206, 86, 1)"
        "rgba(75, 192, 192, 1)"
        "rgba(153, 102, 255, 1)"
        "rgba(255, 159, 64, 1)"
    |]

    let labels = [| "Red"; "Blue"; "Yellow"; "Green"; "Purple"; "Orange" |]

    let rnd = System.Random()

    let roll () = [| for _ in labels -> rnd.Next(1, 20) |]

    let byId (id: string) =
        let el = JS.Document.GetElementById id
        if isNull el then None else Some el

    // A shared base for the option objects, so every chart shows a title and
    // subtitle (the `plugins.title` / `plugins.subtitle` surface).
    let baseOptions (title: string) (subtitle: string) =
        let o = Options()
        o.MaintainAspectRatio <- false
        o.Plugins <-
            Plugin(
                Title = TitleConfig(
                    Display = true,
                    Text = Union1Of2 title,
                    Font = Font(
                        Size = 18,
                        Family = "'Helvetica Neue', 'Helvetica', 'Arial', sans-serif",
                        Style = FontStyle.Italic
                    )
                ),
                Subtitle = TitleConfig(
                    Display = true,
                    Text = Union1Of2 subtitle,
                    Font = Font(Size = 12, Family = "'Lucida Console', 'Courier New', monospace")
                ),
                Legend = LegendConfig(Display = true, Position = PositionString.Top)
            )
        o

    // ------------------------------------------------------------------
    // Data sets (kept in mutable fields so the toolbar can randomize them)
    // ------------------------------------------------------------------

    let lineDs = LineChartDataSet()
    lineDs.Label <- "# of Votes"
    lineDs.Data <- [| 12; 19; 3; 5; 2; 3 |]
    lineDs.Fill <- Union1Of2 true
    lineDs.Tension <- 0.35
    lineDs.BackgroundColor <- Union2Of2 bgColor
    lineDs.BorderColor <- Union2Of2 bdColor
    lineDs.BorderWidth <- 3

    let mutable lineFilled = true

    let lineData =
        let d = ChartData()
        d.Datasets <- [| lineDs |]
        d.Labels <- labels
        d

    let barDs = BarChartDataSet()
    barDs.Label <- "# of Votes"
    barDs.Data <- [| 12; 19; 3; 5; 2; 3 |]
    barDs.BackgroundColor <- Union2Of2 bgColor
    barDs.BorderColor <- Union2Of2 bdColor
    barDs.BorderWidth <- 2
    barDs.BorderRadius <- 6

    let barData =
        let d = ChartData()
        d.Datasets <- [| barDs |]
        d.Labels <- labels
        d

    let pieDs = PieChartDataSet()
    pieDs.Label <- "# of Votes"
    pieDs.Data <- [| 12; 19; 3; 5; 2; 3 |]
    pieDs.BackgroundColor <- Union2Of2 bgColor
    pieDs.BorderColor <- Union2Of2 bdColor
    pieDs.BorderWidth <- 2

    let pieData =
        let d = ChartData()
        d.Datasets <- [| pieDs |]
        d.Labels <- labels
        d

    let doughnutDs = DoughnutChartDataSet()
    doughnutDs.Label <- "# of Votes"
    doughnutDs.Data <- [| 12; 19; 3; 5; 2; 3 |]
    doughnutDs.BackgroundColor <- Union2Of2 bgColor
    doughnutDs.BorderColor <- Union2Of2 bdColor
    doughnutDs.BorderWidth <- 2

    let doughnutData =
        let d = ChartData()
        d.Datasets <- [| doughnutDs |]
        d.Labels <- labels
        d

    let polarDs = PolarAreaChartDataSet()
    polarDs.Label <- "Polar area dataset"
    polarDs.Data <- [| 11; 16; 7; 3; 14; 9 |]
    polarDs.BackgroundColor <- Union2Of2 bgColor
    polarDs.BorderColor <- Union2Of2 bdColor
    polarDs.BorderWidth <- 2

    let polarData =
        let d = ChartData()
        d.Datasets <- [| polarDs |]
        d.Labels <- labels
        d

    let radarDs1 = RadarChartDataSet()
    radarDs1.Label <- "First dataset"
    radarDs1.Data <- [| 65; 59; 90; 81; 56; 55 |]
    radarDs1.Fill <- Union1Of2 true
    radarDs1.BackgroundColor <- Union1Of2 "rgba(255, 99, 132, 0.2)"
    radarDs1.BorderColor <- Union1Of2 "rgba(255, 99, 132, 1)"
    radarDs1.PointBackgroundColor <- Union1Of2 "rgb(255, 99, 132)"
    radarDs1.PointBorderColor <- Union1Of2 "#fff"

    let radarDs2 = RadarChartDataSet()
    radarDs2.Label <- "Second dataset"
    radarDs2.Data <- [| 28; 48; 40; 19; 96; 27 |]
    radarDs2.Fill <- Union1Of2 true
    radarDs2.BackgroundColor <- Union1Of2 "rgba(54, 162, 235, 0.2)"
    radarDs2.BorderColor <- Union1Of2 "rgba(54, 162, 235, 1)"
    radarDs2.PointBackgroundColor <- Union1Of2 "rgb(54, 162, 235)"
    radarDs2.PointBorderColor <- Union1Of2 "#fff"

    let radarData =
        let d = ChartData()
        d.Datasets <- [| radarDs1; radarDs2 |]
        d.Labels <- [| "Eating"; "Drinking"; "Sleeping"; "Designing"; "Coding"; "Cooking" |]
        d

    let bubbleDs = BubbleChartDataSet()
    bubbleDs.Label <- "First dataset"
    bubbleDs.Data <- [| BubbleDataObject(20.0, 30.0, 15); BubbleDataObject(40.0, 10.0, 10) |]
    bubbleDs.BackgroundColor <- Union1Of2 "rgba(255, 99, 132, 0.5)"
    bubbleDs.BorderColor <- Union1Of2 "rgb(255, 99, 132)"

    let bubbleData =
        let d = ChartData()
        d.Datasets <- [| bubbleDs |]
        d

    let scatterDs = ScatterChartDataSet()
    scatterDs.Label <- "Scatter dataset"
    scatterDs.Data <-
        [| ScatterDataObject(-10, 0); ScatterDataObject(0, 10)
           ScatterDataObject(10, 5); ScatterDataObject(0.5, 5.5) |]
    scatterDs.BackgroundColor <- Union1Of2 "rgba(127, 99, 255, 0.6)"

    let scatterData =
        let d = ChartData()
        d.Datasets <- [| scatterDs |]
        d

    let mixedLineDs = LineChartDataSet()
    mixedLineDs.Label <- "Line dataset"
    mixedLineDs.Data <- [| 10; 20; 30; 40; 50; 60 |]
    mixedLineDs.BorderColor <- Union1Of2 "rgba(132, 99, 255, 1)"
    mixedLineDs.BackgroundColor <- Union1Of2 "rgba(132, 99, 255, 0.2)"
    mixedLineDs.BorderWidth <- 3
    mixedLineDs.Order <- 2

    let mixedBarDs = BarChartDataSet()
    mixedBarDs.Label <- "Bar dataset"
    mixedBarDs.Data <- [| 60; 50; 40; 30; 20; 10 |]
    mixedBarDs.BackgroundColor <- Union1Of2 "rgba(255, 99, 132, 0.6)"
    mixedBarDs.BorderColor <- Union1Of2 "rgba(255, 99, 132, 1)"
    mixedBarDs.BorderWidth <- 2
    mixedBarDs.Order <- 1

    let mixedData =
        let d = ChartData()
        d.Datasets <- [| mixedLineDs; mixedBarDs |]
        d.Labels <- labels
        d

    // ------------------------------------------------------------------
    // Options
    // ------------------------------------------------------------------

    let lineOptions =
        let o = baseOptions "Line chart" "fill, tension and a tooltip callback"
        o.Plugins.Tooltip <-
            TooltipConfig(
                Mode = TooltipModes.Index,
                Intersect = false,
                Callbacks =
                    TooltipCallbacks(
                        Label = System.Func<TooltipItem, obj, string array>(fun item _ -> [| sprintf "%s: %s votes" item.Label item.FormattedValue |])
                    )
            )
        o.Scales <- New [ ("y", box (LinearAxis(BeginAtZero = true))) ]
        o

    let barOptions =
        let o = baseOptions "Bar chart" "rounded bars and a y-axis starting at zero"
        o.Scales <- New [ ("y", box (LinearAxis(BeginAtZero = true))) ]
        o

    let pieOptions = baseOptions "Pie chart" "the same data as a pie"
    let doughnutOptions = baseOptions "Doughnut chart" "the same data as a doughnut"
    let polarOptions = baseOptions "Polar area chart" "the same data as a polar area"
    let bubbleOptions = baseOptions "Bubble chart" "x, y and radius data points"
    let scatterOptions = baseOptions "Scatter chart" "x/y points on a linear scale"

    let radarOptions =
        let o = baseOptions "Radar chart" "two datasets sharing a radial scale"
        o.Elements <- Union1Of2 (ElementConfig(Line = LineConfig(BorderWidth = 3)))
        o

    let mixedOptions = baseOptions "Mixed chart" "a line and bar dataset in one chart"

    // ------------------------------------------------------------------
    // Chart lifetime
    // ------------------------------------------------------------------

    let mutable charts : (string * Chart) list = []

    let get (name: string) =
        charts |> List.tryFind (fun (n, _) -> n = name) |> Option.map snd

    let destroyAll () =
        for _, c in charts do c.Destroy()
        charts <- []

    // Hover/click wiring shared by every chart.
    let attachInteraction (o: Options) (name: string) =
        o.OnHover <-
            System.Action<Dom.Event, ActiveElement array>(fun _ els ->
                if els.Length > 0 then
                    hovered.Value <- sprintf "%s: element index %d in dataset %d" name els.[0].Index els.[0].DatasetIndex
                else
                    hovered.Value <- "-")
        o.OnClick <-
            System.Action<Dom.Event, ActiveElement array>(fun _ els ->
                if els.Length > 0 then
                    status.Value <- sprintf "Clicked %s: element index %d in dataset %d." name els.[0].Index els.[0].DatasetIndex
                else
                    status.Value <- sprintf "Clicked %s, but no data element was under the pointer." name)

    let create (name: string) (data: ChartData) (options: Options) =
        match byId name with
        | None -> ()
        | Some el ->
            attachInteraction options name
            let c = Chart(el, ChartCreate(data, options))
            // Exercise the event-inspection API on click.
            el.AddEventListener("click", (fun (ev: Dom.Event) ->
                let hits =
                    c.GetElementsAtEventForMode(ev, InteractionMode.Index, Interaction(Intersect = false), false)
                inspection.Value <-
                    sprintf "%s: getElementsAtEventForMode 'index' -> %d element(s)." name hits.Length))
            charts <- (name, c) :: charts

    let createAll () =
        // Read/override the global defaults through the static surface.
        Chart.Defaults.MaintainAspectRatio <- false
        create "line" lineData lineOptions
        create "bar" barData barOptions
        create "pie" pieData pieOptions
        create "doughnut" doughnutData doughnutOptions
        create "polarArea" polarData polarOptions
        create "bubble" bubbleData bubbleOptions
        create "scatter" scatterData scatterOptions
        create "radar" radarData radarOptions
        create "mixed" mixedData mixedOptions
        status.Value <- sprintf "Created %d charts with Chart.js %s." charts.Length Chart.Version
        hovered.Value <- "-"

    let recreateAll () =
        destroyAll ()
        createAll ()

    // ------------------------------------------------------------------
    // Toolbar actions
    // ------------------------------------------------------------------

    let update (name: string) =
        match get name with
        | Some c -> c.Update(); status.Value <- sprintf "Updated the %s chart." name
        | None -> status.Value <- sprintf "The %s chart is not created yet." name

    let randomizeLine () =
        lineDs.Data <- roll ()
        update "line"

    let toggleLineFill () =
        lineFilled <- not lineFilled
        lineDs.Fill <- Union1Of2 lineFilled
        status.Value <- sprintf "Line fill: %b." lineFilled
        update "line"

    let randomizeBar () =
        barDs.Data <- roll ()
        update "bar"

    let randomizePie () =
        pieDs.Data <- roll ()
        update "pie"

    let randomizeDoughnut () =
        doughnutDs.Data <- roll ()
        update "doughnut"

    let randomizePolar () =
        polarDs.Data <- roll ()
        update "polarArea"

    let randomizeBubble () =
        bubbleDs.Data <-
            [| BubbleDataObject(rnd.NextDouble() * 40., rnd.NextDouble() * 40., rnd.Next(5, 20))
               BubbleDataObject(rnd.NextDouble() * 40., rnd.NextDouble() * 40., rnd.Next(5, 20))
               BubbleDataObject(rnd.NextDouble() * 40., rnd.NextDouble() * 40., rnd.Next(5, 20)) |]
        update "bubble"

    let randomizeScatter () =
        scatterDs.Data <-
            [| ScatterDataObject(rnd.Next(-10, 10), rnd.Next(-10, 10))
               ScatterDataObject(rnd.Next(-10, 10), rnd.Next(-10, 10))
               ScatterDataObject(rnd.Next(-10, 10), rnd.Next(-10, 10)) |]
        update "scatter"

    let randomizeRadar () =
        radarDs1.Data <- [| for _ in 0 .. 5 -> rnd.Next(10, 100) |]
        radarDs2.Data <- [| for _ in 0 .. 5 -> rnd.Next(10, 100) |]
        update "radar"

    let randomizeMixed () =
        mixedLineDs.Data <- roll ()
        mixedBarDs.Data <- roll ()
        update "mixed"

    let randomizeAll () =
        lineDs.Data <- roll ()
        barDs.Data <- roll ()
        pieDs.Data <- roll ()
        doughnutDs.Data <- roll ()
        polarDs.Data <- roll ()
        radarDs1.Data <- [| for _ in 0 .. 5 -> rnd.Next(10, 100) |]
        radarDs2.Data <- [| for _ in 0 .. 5 -> rnd.Next(10, 100) |]
        mixedLineDs.Data <- roll ()
        mixedBarDs.Data <- roll ()
        for _, c in charts do c.Update()
        status.Value <- "Randomized every dataset."

    let resetAll () =
        for _, c in charts do c.Reset()
        status.Value <- "Reset every chart's animation state."

    let takeSnapshot () =
        match get "line" with
        | Some c ->
            snapshot.Value <- c.ToBase64Image()
            status.Value <- "Captured the line chart with toBase64Image()."
        | None -> status.Value <- "The line chart is not created yet."

    let reportMeta () =
        match get "line" with
        | Some c ->
            let meta = c.GetDatasetMeta(0)
            status.Value <- sprintf "getDatasetMeta(0) label: %s." meta.Label
        | None -> status.Value <- "The line chart is not created yet."

    // ------------------------------------------------------------------
    // Entry point
    // ------------------------------------------------------------------

    [<SPAEntryPoint>]
    let Main () =
        // Restore a previously chosen theme (light is the default).
        let savedTheme = try JS.Window.LocalStorage.GetItem(themeStorageKey) with _ -> null
        if savedTheme = "dark" || savedTheme = "light" then
            theme.Value <- savedTheme
        applyTheme ()

        version.Value <- Chart.Version

        // `.Bind()` renders the whole document body, so the canvases below are
        // in the DOM only after this call.
        IndexTemplate()
            .status(status.V)
            .version(version.V)
            .hovered(hovered.V)
            .inspection(inspection.V)
            .snapshotUrl(snapshot.V)
            .themeLabel(themeLabel.V)
            .ToggleTheme(fun _ -> toggleTheme ())
            .RandomizeAll(fun _ -> randomizeAll ())
            .ResetAll(fun _ -> resetAll ())
            .DestroyAll(fun _ -> (destroyAll (); status.Value <- "Destroyed every chart."))
            .RecreateAll(fun _ -> recreateAll ())
            .RandomizeLine(fun _ -> randomizeLine ())
            .ToggleLineFill(fun _ -> toggleLineFill ())
            .CaptureSnapshot(fun _ -> takeSnapshot ())
            .ReportMeta(fun _ -> reportMeta ())
            .RandomizeBar(fun _ -> randomizeBar ())
            .RandomizePie(fun _ -> randomizePie ())
            .RandomizeDoughnut(fun _ -> randomizeDoughnut ())
            .RandomizePolar(fun _ -> randomizePolar ())
            .RandomizeBubble(fun _ -> randomizeBubble ())
            .RandomizeScatter(fun _ -> randomizeScatter ())
            .RandomizeRadar(fun _ -> randomizeRadar ())
            .RandomizeMixed(fun _ -> randomizeMixed ())
            .Bind()

        // The DOM is ready now.
        createAll ()
