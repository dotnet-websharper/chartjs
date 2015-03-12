namespace WebSharper.ChartJs

open WebSharper
open WebSharper.InterfaceGenerator

module Definition =
    
    let GlobalChartConfiguration =
        Pattern.Config "GlobalChartConfiguration" {
            Required = []
            Optional =
                [
                    "animation"             , T<bool>
                    "animationSteps"        , T<int>
                    "animationEasing"       , T<string>
                    "showScale"             , T<bool>
                    "scaleOverride"         , T<bool>
                    "scaleSteps"            , T<int>
                    "scaleStepWidth"        , T<float>
                    "scaleStartValue"       , T<float>
                    "scaleLineColor"        , T<string>
                    "scaleLineWidth"        , T<int>
                    "scaleShowLabels"       , T<bool>
                    "scaleLabel"            , T<string>
                    "scaleIntegersOnly"     , T<bool>
                    "scaleBeginAtZero"      , T<bool>
                    "scaleFontFamily"       , T<string>
                    "scaleFontSize"         , T<int>
                    "scaleFontStyle"        , T<string>
                    "scaleFontColor"        , T<string>
                    "responsive"            , T<bool>
                    "maintainAspectRatio"   , T<bool>
                    "showTooltips"          , T<bool>
                    "customTooltips"        , T<bool>
                    "tooltipEvents"         , T<string []>
                    "tooltipFillColor"      , T<string>
                    "tooltipFontFamily"     , T<string>
                    "tooltipFontSize"       , T<int>
                    "tooltipFontStyle"      , T<string>
                    "tooltipFontColor"      , T<string>
                    "tooltipTitleFontFamily", T<string>
                    "tooltipTitleFontSize"  , T<int>
                    "tooltipTitleFontStyle" , T<string>
                    "tooltipTitleFontColor" , T<string>
                    "tooltipYPadding"       , T<int>
                    "tooltipXPadding"       , T<int>
                    "tooltipCaretSize"      , T<int>
                    "tooltipCornerRadius"   , T<int>
                    "tooltipXOffset"        , T<int>
                    "tooltipTemplate"       , T<string>
                    "multiTooltipTemplate"  , T<string>
                    "onAnimationProgress"   , T<unit -> unit>
                    "onAnimationComplete"   , T<unit -> unit>
                ]
        }

    let LineChartDataset =
        Pattern.Config "LineChartDataset" {
            Required = []
            Optional =
                [
                    "label"               , T<string>
                    "fillColor"           , T<string>
                    "strokeColor"         , T<string>
                    "pointColor"          , T<string>
                    "pointStrokeColor"    , T<string>
                    "pointHighlightFill"  , T<string>
                    "pointHighlightStroke", T<string>
                    "data"                , T<float []>
                ]
        }

    let LineChartData =
        Pattern.Config "LineChartData" {
            Required = []
            Optional =
                [
                    "labels"  , T<string []>
                    "datasets", Type.ArrayOf LineChartDataset
                ]
        }

    let LineChartConfiguration =
        Pattern.Config "LineChartConfiguration" {
            Required = []
            Optional =
                [
                    "scaleShowGridLines"      , T<bool>
                    "scaleGridLineColor"      , T<string>
                    "scaleGridLineWidth"      , T<int>
                    "scaleShowHorizontalLines", T<bool>
                    "scaleShowVerticalLines"  , T<bool>
                    "bezierCurve"             , T<bool>
                    "bezierCurveTension"      , T<float>
                    "pointDot"                , T<bool>
                    "pointDotRadius"          , T<int>
                    "pointDotStrokeWidth"     , T<int>
                    "pointHitDetectionRadius" , T<int>
                    "datasetStroke"           , T<bool>
                    "datasetStrokeWidth"      , T<int>
                    "datasetFill"             , T<bool>
                    "legendTemplate"          , T<string>
                ]
        }
        |=> Inherits GlobalChartConfiguration

    let BarChartDataset =
        Pattern.Config "BarChartDataset" {
            Required = []
            Optional =
                [
                    "label"          , T<string>
                    "fillColor"      , T<string>
                    "strokeColor"    , T<string>
                    "highlightFill"  , T<string>
                    "highlightStroke", T<string>
                    "data"           , T<float []>
                ]
        }

    let BarChartData =
        Pattern.Config "BarChartData" {
            Required = []
            Optional =
                [
                    "labels"  , T<string []>
                    "datasets", Type.ArrayOf BarChartDataset 
                ]
        }

    let BarChartConfiguration =
        Pattern.Config "BarChartConfiguration" {
            Required = []
            Optional =
                [
                    "scaleBeginAtZero"        , T<bool>
                    "scaleShowGridLines"      , T<bool>
                    "scaleGridLineColor"      , T<string>
                    "scaleGridLineWidth"      , T<int>
                    "scaleShowHorizontalLines", T<bool>
                    "scaleShowVerticalLines"  , T<bool>
                    "barShowStroke"           , T<bool>
                    "barStrokeWidth"          , T<bool>
                    "barValueSpacing"         , T<bool>
                    "barDatasetSpacing"       , T<bool>
                    "legendTemplate"          , T<string>
                ]
        }
        |=> Inherits GlobalChartConfiguration

    let RadarChartDataset =
        Class "RadarChartDataset"
        |=> Inherits LineChartDataset

    let RadarChartData =
        Pattern.Config "RadarChartData" {
            Required = []
            Optional =
                [
                    "labels"  , T<string []>
                    "datasets", Type.ArrayOf RadarChartDataset
                ]
        }
    
    let RadarChartConfiguration =
        Pattern.Config "RadarChartConfiguration" {
            Required = []
            Optional =
                [
                    "scaleShowLine"          , T<bool>
                    "scaleShowLineOut"       , T<bool>
                    "scaleShowLabels"        , T<bool>
                    "scaleBeginAtZero"       , T<bool>
                    "angleLineColor"         , T<string>
                    "angleLineWidth"         , T<int>
                    "pointLabelFontFamily"   , T<string>
                    "pointLabelFontStyle"    , T<string>
                    "pointLabelFontSize"     , T<int>
                    "pointLabelFontColor"    , T<string>
                    "pointDot"               , T<bool>
                    "pointDotRadius"         , T<int>
                    "pointDotStrokeWidth"    , T<int>
                    "pointHitDetectionRadius", T<int>
                    "datasetStroke"          , T<bool>
                    "datasetStrokeWidth"     , T<int>
                    "datasetFill"            , T<bool>
                    "legendTemplate"         , T<string>
                ]
        }

    let PolarAreaChartDataset =
        Pattern.Config "PolarAreaChartDataset" {
            Required = []
            Optional =
                [
                    "value"    , T<float>
                    "color"    , T<string>
                    "highlight", T<string>
                    "label"    , T<string>
                ]
        }

    let PolarAreaChartConfiguration =
        Pattern.Config "PolarAreaChartConfiguration" {
            Required = []
            Optional =
                [
                    "scaleShowLabelBackdrop", T<bool>
                    "scaleBackdropColor"    , T<string>
                    "scaleBeginAtZero"      , T<bool>
                    "scaleBackdropPaddingY" , T<int>
                    "scaleBackdropPaddingX" , T<int>
                    "scaleShowLine"         , T<bool>
                    "segmentShowStroke"     , T<bool>
                    "segmentStrokeColor"    , T<string>
                    "segmentStrokeWidth"    , T<int>
                    "animationSteps"        , T<int>
                    "animationEasing"       , T<string>
                    "animateRotate"         , T<bool>
                    "animateScale"          , T<bool>
                    "legendTemplate"        , T<string>
                ]
        }

    let PieChartDataset =
        Class "PieChartDataset"
        |=> Inherits PolarAreaChartDataset

    let PieChartConfiguration =
        Pattern.Config "PieChartConfiguration" {
            Required = []
            Optional =
                [
                    "segmentShowStroke"    , T<bool>
                    "segmentStrokeColor"   , T<string>
                    "segmentStrokeWidth"   , T<int>
                    "percentageInnerCutout", T<int>
                    "animationSteps"       , T<int>
                    "animationEasing"      , T<string>
                    "animateRotate"        , T<bool>
                    "animateScale"         , T<bool>
                    "legendTemplate"       , T<string>
                ]
        }

    let DoughnutChartDataset =
        Class "DoughnutChartDataset"
        |=> Inherits PieChartDataset

    let DoughnutChartConfiguration =
        Class "DoughnutChartConfiguration"
        |=> Inherits PieChartConfiguration

    let Chart =
        
        let Chart =
            let Chart = Type.New ()
            
            Interface "Chart"
            |=> Chart
            |+> [
                "clear"          => T<unit> ^-> Chart
                "stop"           => T<unit> ^-> Chart
                "resize"         => T<unit> ^-> Chart
                "destroy"        => T<unit -> unit>
                "toBase64Image"  => T<unit -> string>
                "generateLegend" => T<unit -> string>
            ]
        
        let LineChart =
            Class "LineChart"
            |=> Implements [ Chart ]
            |+> Instance [
                "getPointsAtEvent" => (T<JavaScript.Dom.Event> + T<JQuery.Event>)?event ^-> T<obj []> // !!!
                "update"           => T<unit -> unit>
                "addData"          => T<float []>?values * T<string>?label ^-> T<unit>
                "removeData"       => T<unit -> unit>
            ]
        
        let BarChart =
            Class "BarChart"
            |=> Implements [ Chart ]
            |+> Instance [
                "getBarsAtEvent" => (T<JavaScript.Dom.Event> + T<JQuery.Event>)?event ^-> T<obj []> // !!!
                "update"         => T<unit -> unit>
                "addData"        => T<float []>?values * T<string>?label ^-> T<unit>
                "removeData"     => T<unit -> unit>
            ]

        let RadarChart =
            Class "RadarChart"
            |=> Implements [ Chart ]
            |=> Inherits LineChart

        let PolarAreaChart =
            Class "PolarAreaChart"
            |=> Implements [ Chart ]
            |+> Instance [
                "getSegmentsAtEvent" => (T<JavaScript.Dom.Event> + T<JQuery.Event>)?event ^-> T<obj []> // !!!
                "update"             => T<unit -> unit>
                "addData"            => PolarAreaChartDataset?segmentData * T<int>?index ^-> T<unit>
                "removeData"         => T<int>?index ^-> T<unit>
            ]

        let PieChart =
            Class "PieChart"
            |=> Implements [ Chart ]
            |=> Inherits PolarAreaChart

        let DoughnutChart =
            Class "DoughnutChart"
            |=> Implements [ Chart ]
            |=> Inherits PieChart

        Class "Chart"
        |+> Static [
            Constructor T<JavaScript.CanvasRenderingContext2D>?context

            "defaults" =? GlobalChartConfiguration
        ]
        |+> Instance [
            "Line"      => LineChartData?data * !? LineChartConfiguration?options ^-> LineChart
            "Bar"       => BarChartData?data * !? BarChartConfiguration?options ^-> BarChart
            "Radar"     => RadarChartData?data * !? RadarChartConfiguration?options ^-> RadarChart
            "PolarArea" => (Type.ArrayOf PolarAreaChartDataset)?data * !? PolarAreaChartConfiguration?options ^-> PolarAreaChart
            "Pie"       => (Type.ArrayOf PieChartDataset)?data * !? PieChartConfiguration?options ^-> PieChart
            "Doughnut"  => (Type.ArrayOf DoughnutChartDataset)?data * !? DoughnutChartConfiguration?options ^-> DoughnutChart
        ]
        |=> Nested [
            LineChart
            BarChart
            RadarChart
            PolarAreaChart
            PieChart
            DoughnutChart
        ]

    let Assembly =
        Assembly [
            Namespace "WebSharper.ChartJs" [
                 GlobalChartConfiguration
                 LineChartDataset
                 LineChartData
                 LineChartConfiguration
                 BarChartDataset
                 BarChartData
                 BarChartConfiguration
                 RadarChartDataset
                 RadarChartData
                 RadarChartConfiguration
                 PolarAreaChartDataset
                 PolarAreaChartConfiguration
                 PieChartDataset
                 PieChartConfiguration
                 DoughnutChartDataset
                 DoughnutChartConfiguration
                 Chart
            ]
            Namespace "WebSharper.ChartJs.Resources" [
                Resource "Chart.js" "Chart.min.js"
                |> fun resource ->
                    resource.AssemblyWide()
            ]
        ]

[<Sealed>]
type Extension () =
    interface IExtension with
        member x.Assembly =
            Definition.Assembly

[<assembly: Extension(typeof<Extension>)>]
do ()
