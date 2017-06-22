namespace WebSharper.ChartJs

open WebSharper
open WebSharper.JavaScript
open WebSharper.InterfaceGenerator
open WebSharper.JQuery

module Definition =

    let ChartClass =
        Class "Chart"

    let PositionString =
        Pattern.EnumStrings "PositionString" [
            "top"
            "left"
            "right"
            "bottom"
        ]

    let ADataSet = Class "ADataSet"
    
    let ChartData =
        Pattern.Config "ChartData" {
            Required = 
                [
                    "datasets", Type.ArrayOf ADataSet
                ]
            Optional =
                [
                    "labels", T<string []>
                    "xLabels", T<string []>
                    "yLabels", T<string []>
                ]
        }

    
    let DataObject =
        Pattern.Config "DataObject" {
            Required =
                [
                    "x", T<float>
                    "y", T<float>
                ]
            Optional = []
        }

    let ScaleType =
        Pattern.EnumStrings "ScaleType" [
            "category"
            "linear"
            "logarithmic"
            "time"
            "radialLinear"
        ]

    let GridLineConfig =
        Pattern.Config "GridLineConfig" {
            Required = []
            Optional =
                [
                    "display", T<bool>
                    "color", T<string> + T<string []>
                    "borderDash", T<float []>
                    "borderDashOffset", T<float>
                    "lineWidth", T<float> + T<float []>
                    "drawBorder", T<bool>
                    "drawOnChartArea", T<bool>
                    "drawTicks", T<bool>
                    "tickMarkLength", T<int>
                    "zeroLineWidth", T<int>
                    "zeroLineColor", T<string>
                    "offsetGridLines", T<bool>
                ]
        }

    let ScaleTitleConfig =
        Pattern.Config "ScaleTitleConfig" {
            Required = []
            Optional =
                [
                    "display", T<bool>
                    "labelString", T<string>
                    "fontColor", T<string>
                    "fontFamily", T<string>
                    "fontSize", T<int>
                    "fontStyle", T<string>
                ]
        }

    let TickConfig =
        Pattern.Config "TickConfig" {
            Required = []
            Optional =
                [
                    "autoSkip", T<bool>
                    "autoSkipPadding", T<int>
                    "callback", T<float> * T<float> * T<float []> ^-> T<obj>
                    "display", T<bool>
                    "fontColor", T<string>
                    "fontFamily", T<string>
                    "fontSize", T<int>
                    "labelOffset", T<int>
                    "maxRotation", T<int>
                    "minRotation", T<int>
                    "mirror", T<bool>
                    "padding", T<int>
                    "reverse", T<bool>
                ]
        }

    let Scale =
        Pattern.Config "Scale" {
            Required = []
            Optional =
                [
                    "type", ScaleType.Type
                    "display", T<bool>
                    "position", PositionString.Type
                    "id", T<string>
                    "beforeUpdate", TSelf ^-> T<unit>
                    "beforeSetDimensions", TSelf ^-> T<unit>
                    "afterSetDimensions", TSelf ^-> T<unit>
                    "beforeDataLimits", TSelf ^-> T<unit>
                    "afterDataLimits", TSelf ^-> T<unit>
                    "beforeBuildTicks", TSelf ^-> T<unit>
                    "afterBuildTicks", TSelf ^-> T<unit>
                    "beforeTickToLabelConversion", TSelf ^-> T<unit>
                    "afterTickToLabelConversion", TSelf ^-> T<unit>
                    "beforeCalculateTickRotation", TSelf ^-> T<unit>
                    "afterCalculateTickRotation", TSelf ^-> T<unit>
                    "beforeFit", TSelf ^-> T<unit>
                    "afterFit", TSelf ^-> T<unit>
                    "afterUpdate", TSelf ^-> T<unit>
                    "gridLines", GridLineConfig.Type
                    "scaleLabel", ScaleTitleConfig.Type
                    "ticks", TickConfig.Type
                ]
        }

    let Scales =
        Pattern.Config "Scales" {
            Required = []
            Optional =
                [
                    "xAxes", Scale.Type
                    "yAxes", Scale.Type
                ]
        }

    let PaddingConfig =
        Pattern.Config "PaddingConfig" {
            Required = []
            Optional = 
                [
                    "left", T<string>
                    "top", T<string>
                    "right", T<string>
                    "bottom", T<string>
                ]
        }

    let LayoutConfig =
        Pattern.Config "LayoutConfig" {
            Required =
                [
                    "padding", T<int> + PaddingConfig.Type
                ]
            Optional = []
        }

    let TitleConfig =
        Pattern.Config "TitleConfig" {
            Required = []
            Optional =
                [
                    "display", T<bool>
                    "position", PositionString.Type
                    "fullWidth", T<bool>
                    "fontSize", T<int>
                    "fontFamily", T<string>
                    "fontColor", T<string>
                    "fontStyle", T<string>
                    "padding", T<float>
                    "text", T<string>
                ]
        }

    let LegendItem =
        Class "LegendItem"
        |+> Instance [
            "text" =@ T<string>
            "fillStyle" =@ T<string>
            "hidden" =@ T<bool>
            "lineCap" =@ T<string>
            "lineDash" =@ T<float []>
            "lineDashOffset" =@ T<float>
            "lineJoin" =@ T<string>
            "lineWidth" =@ T<int>
            "strokeStyle" =@ T<string>
            "pointStyle" =@ T<string>
        ]

    let LegendLabelConfig =
        Pattern.Config "LabelConfig" {
            Required = []
            Optional =
                [
                    "boxWidth", T<int>
                    "fontSize", T<int>
                    "fontStyle", T<string>
                    "fontColor", T<string>
                    "fontFamily", T<string>
                    "padding", T<float>
                    "usePointStyle", T<bool>
                    "generateLabels", ChartClass ^-> Type.ArrayOf LegendItem
                    "filter", LegendItem * T<obj> ^-> T<unit>
                ]
        }

    let LegendConfig =
        Pattern.Config "LegendConfig" {
            Required = []
            Optional =
                [
                    "display", T<bool>
                    "position", PositionString.Type
                    "fullWidth", T<bool>
                    "onClick", (T<Dom.Event> * LegendItem ^-> T<unit>)
                    "onHover", (T<Dom.Event> * LegendItem ^-> T<unit>)
                    "labels", T<obj>
                    "reverse", T<bool>
                ]
        }

    let InteractionMode =
        Pattern.EnumStrings "InteractionMode" [
            "point"
            "nearest"
            "single"
            "label"
            "index"
            "x-axis"
            "dataset"
            "x"
            "y"
        ]

    let TooltipItem = 
        Pattern.Config "TooltipItem" {
            Required = []
            Optional =
                [
                    "xLabel", T<string>
                    "yLabel", T<string>
                    "dataSetIndex", T<int>
                    "index", T<int>
                    "x", T<float>
                    "y", T<float>
                ]
        }

    let LabelColor =
        Pattern.Config "LabelColor" {
            Required =
                [
                    "borderColor", T<string>
                    "backgroundColor", T<string>
                ]
            Optional = []
        }
            

    let TooltipCallbacks =
        Pattern.Config "TooltipCallbacks" {
            Required = []
            Optional =
                [
                    "beforeTitle", Type.ArrayOf TooltipItem * T<obj> ^-> T<string []>
                    "title", Type.ArrayOf TooltipItem * T<obj> ^-> T<string []>
                    "afterTitle", Type.ArrayOf TooltipItem * T<obj> ^-> T<string []>
                    "beforeBody", Type.ArrayOf TooltipItem * T<obj> ^-> T<string []>
                    "afterBody", Type.ArrayOf TooltipItem * T<obj> ^-> T<string []>
                    "beforeFooter", Type.ArrayOf TooltipItem * T<obj> ^-> T<string []>
                    "footer", Type.ArrayOf TooltipItem * T<obj> ^-> T<string []>
                    "afterFooter", Type.ArrayOf TooltipItem * T<obj> ^-> T<string []>
                    "beforeLabel", TooltipItem * T<obj> ^-> T<string []>
                    "label", TooltipItem * T<obj> ^-> T<string []>
                    "afterLabel", TooltipItem * T<obj> ^-> T<string []>
                    "labelColor", TooltipItem * ChartClass ^-> LabelColor
                    "dataPoints", Type.ArrayOf TooltipItem ^-> T<obj []>
                ]
        }

    let TooltipConfig =
        Pattern.Config "TooltipConfig" {
            Required = []
            Optional =
                [
                    "enabled", T<bool>
                    "custom", TSelf ^-> T<unit>
                    "mode", InteractionMode.Type
                    "intersect", T<bool>
                    "position", T<string>
                    "itemSort", T<obj> * T<obj> * !?T<obj> ^-> T<int>
                    "filter", T<obj> * !?T<obj> ^-> T<bool>
                    "backgroundColor", T<string>
                    "titleFontFamily", T<string>
                    "titleFontSize", T<float>
                    "titleFontStyle", T<string>
                    "titleFontColor", T<string>
                    "titleSpacing", T<float>
                    "titleMarginBottom", T<float>
                    "bodyFontFamily", T<string>
                    "bodyFontSize", T<float>
                    "bodyFontStyle", T<string>
                    "bodyFontColor", T<string>
                    "bodySpacing", T<float>
                    "footerFontFamily", T<string>
                    "footerFontSize", T<float>
                    "footerFontStyle", T<string>
                    "footerFontColor", T<string>
                    "footerSpacing", T<float>
                    "footerMarginBottom", T<float>
                    "xPadding", T<float>
                    "yPadding", T<float>
                    "caretSize", T<float>
                    "cornerRadius", T<float>
                    "multiKeyBackground", T<string>
                    "displayColors", T<bool>
                    "callbacks", T<obj>
                ]
        }

    let HoverConfig =
        Pattern.Config "HoverConfig" {
            Required = []
            Optional =
                [
                    "mode", InteractionMode.Type
                    "intersect", T<bool>
                    "animationDuration", T<int>
                    "onHover", T<Dom.Event> * T<obj []> ^-> T<unit>
                ]
        }

    let Easing =
        Pattern.EnumStrings "Easing" [
            "linear"
            "easeInQuad"
            "easeOutQuad"
            "easeInOutQuad"
            "easeInCubic"
            "easeOutCubic"
            "easeInOutCubic"
            "easeInQuart"
            "easeOutQuart"
            "easeInOutQuart"
            "easeInQuint"
            "easeOutQuint"
            "easeInOutQuint"
            "easeInSine"
            "easeOutSine"
            "easeInOutSine"
            "easeInExpo"
            "easeOutExpo"
            "easeInOutExpo"
            "easeInCirc"
            "easeOutCirc"
            "easeInOutCirc"
            "easeInElastic"
            "easeOutElastic"
            "easeInOutElastic"
            "easeInBack"
            "easeOutBack"
            "easeInOutBack"
            "easeInBounce"
            "easeOutBounce"
            "easeInOutBounce"
        ]

    let AnimationObject =
        Class "Chart.Animation"
        |+> Instance [
            "currentStep" =? T<int>
            "numSteps" =? T<int>
            "easing" =? Easing.Type
            "render" =? T<obj>
            "onAnimationProgress" =? T<obj>
            "onAnimationCallback" =? T<obj>
        ]

    let AnimationCallbackObj =
        Class "AnimationCallbackObj"
        |+> Instance [
            "chartInstance" =? ChartClass
            "animationObject" =? T<obj>
        ]

    let AnimationConfig =
        Pattern.Config "AnimationConfig" {
            Required = []
            Optional =
                [
                    "duration", T<int>
                    "easing", Easing.Type
                    "onProgress", AnimationCallbackObj ^-> T<unit>
                    "onComplete", AnimationCallbackObj ^-> T<unit>
                ]
        }

    let ArcConfig =
        Pattern.Config "ArcConfig" {
            Required = []
            Optional =
                [
                    "backgroundColor", T<string>
                    "borderColor", T<string>
                    "borderWidth", T<float> 
                ]
        }

    let LineConfig =
        Pattern.Config "LineConfig" {
            Required = []
            Optional =
                [
                    "tension", T<float>
                    "backgroundColor", T<string>
                    "borderWidth", T<float>
                    "borderColor", T<string>
                    "borderCapStyle", T<string>
                    "borderDash", T<float []>
                    "borderDashOffset", T<float>
                    "borderJoinStyle", T<string>
                    "capBezierPoints", T<bool>
                    "fill", T<bool> + T<string>
                    "stepped", T<bool>
                ]
        }

    let PointConfig =
        Pattern.Config "PointConfig" {
            Required = []
            Optional =
                [
                    "radius", T<float>
                    "pointStyle", T<string>
                    "backgroundColor", T<string>
                    "borderWidth", T<int>
                    "borderColor", T<string>
                    "hitRadius", T<int>
                    "hoverRadius", T<int>
                    "hoverBorderWidth", T<int>
                ]
        }

    let RectangleConfig =
        Pattern.Config "RectangleConfig" {
            Required = []
            Optional =
                [
                    "backgroundColor", T<string>
                    "borderWidth", T<int>
                    "borderColor", T<string>
                    "borderSkipped", T<string>
                ]
        }

    let ElementConfig =
        Pattern.Config "ElementConfig" {
            Required = []
            Optional = 
                [
                    "arc", ArcConfig.Type
                    "line", LineConfig.Type
                    "point", PointConfig.Type
                    "rectangle", RectangleConfig.Type
                ]
        }

    let CommonChartConfig =
        Pattern.Config "CommonChartConfig" {
            Required = []
            Optional =
                [
                    "responsive", T<bool>
                    "responsiveAnimationDuration", T<int>
                    "maintainAspectRation", T<bool>
                    "events", T<string []>
                    "onClick", (T<Dom.Event> * T<Dom.Element []> ^-> T<unit>)
                    "legendCallback", (ChartClass ^-> T<string>)
                    "onResize", (ChartClass * T<int> ^-> T<unit>)
                    "layout", LayoutConfig.Type
                    "padding", PaddingConfig.Type
                    "title", TitleConfig.Type
                    "legend", LegendConfig.Type
                    "tooltip", TooltipConfig.Type
                    "hover", HoverConfig.Type
                    "animation", AnimationConfig.Type
                    "elements", ElementConfig.Type
                    "scale", Scales.Type
                ]
        }

    let ChartCreate =
        Pattern.Config "ChartCreate" {
            Required =
                [
                    "type", T<string>
                    "data", ChartData.Type
                    "options", CommonChartConfig.Type
                ]
            Optional = []
        }

    let LineChartDataSet =
        Pattern.Config "LineChartDataSet" {
            Required = []
            Optional =
                [
                    "label", T<string>
                    "xAxisID", T<string>
                    "yAxisID", T<string>
                    "fill", T<bool>
                    "cubicInterpolationMode", T<string>
                    "lineTension", T<float>
                    "backgroundColor", T<string>
                    "borderWidth", T<int>
                    "borderColor", T<string>
                    "borderDash", T<float []>
                    "borderDashOffset", T<float>
                    "borderJoinStyle", T<string>
                    "pointBorderColor", T<string> + T<string []>
                    "pointBorderWidth", T<int> + T<int []>
                    "pointBackgroundColor", T<string> + T<string []>
                    "pointRadius", T<int> + T<int []>
                    "pointHitRadius", T<int> + T<int []>
                    "pointHoverBackgroundColor", T<string> + T<string []>
                    "pointHoverBorderColor", T<string> + T<string []>
                    "pointHoverBorderWidth", T<int> + T<int []>
                    "pointStyle", T<string> + T<string []> // + Image + Image []
                    "showLine", T<bool>
                    "spanGaps", T<bool>
                    "steppedLine", T<bool>
                    "data", T<obj>
                ]
        }
        |=> Inherits ADataSet

    let BarChartXAxes =
        Pattern.Config "BarChartXAxes" {
            Required = []
            Optional =
                [
                    "stacked", T<bool>
                    "barThickness", T<int>
                    "categoryPercentage", T<float>
                    "barPercentage", T<float>
                ]
        }
        |=> Inherits Scale

    let BarChartYAxes =
        Pattern.Config "BarChartYAxes" {
            Required = []
            Optional =
                [
                    "stacked", T<bool>
                    "barThickness", T<int>
                ]
        }
        |=> Inherits Scale

    let BarChartDataSet =
        Pattern.Config "BarChartDataSet" {
            Required = []
            Optional =
                [
                    "label", T<string>
                    "xAxisID", T<string>
                    "yAxisID", T<string>
                    "backgroundColor", T<string>
                    "borderWidth", T<int>
                    "borderColor", T<string>
                    "borderSkipped", T<string> + T<string []>
                    "hoverBackgroundColor", T<string>
                    "hoverBorderWidth", T<int>
                    "hoverBorderColor", T<string>
                    "stack", T<string>
                    "data", T<float []>
                ]
        }
        |=> Inherits ADataSet

    let RadarChartDataSet =
        Pattern.Config "RadarChartDataSet" {
            Required = []
            Optional =
                [
                    "label", T<string>
                    "fill", T<bool>
                    "lineTension", T<float>
                    "backgroundColor", T<string>
                    "borderWidth", T<int>
                    "borderColor", T<string>
                    "borderCapStyle", T<string>
                    "borderDash", T<float []>
                    "borderDashOffset", T<float>
                    "borderJoinStyle", T<string>
                    "pointBorderColor", T<string> + T<string []>
                    "pointBorderWidth", T<int> + T<int []>
                    "pointBackgroundColor", T<string> + T<string []>
                    "pointRadius", T<int> + T<int []>
                    "pointHitRadius", T<int> + T<int []>
                    "pointHoverBackgroundColor", T<string> + T<string []>
                    "pointHoverBorderColor", T<string> + T<string []>
                    "pointHoverBorderWidth", T<int> + T<int []>
                    "pointStyle", T<string> + T<string []> // + Image + Image []
                    "data", T<float []>
                ]
        }
        |=> Inherits ADataSet

    let RadarChartOptions =
        Pattern.Config "RadarChartOptions" {
            Required = []
            Optional =
                [
                    "startAngle", T<int>
                ]
        }
        |=> Inherits CommonChartConfig

    let PolarChartDataSet =
        Pattern.Config "PolarChartDataSet" {
            Required = []
            Optional =
                [
                    "label", T<string>
                    "backgroundColor", T<string []>
                    "borderWidth", T<int []>
                    "borderColor", T<string []>
                    "hoverBackgroundColor", T<string []>
                    "hoverBorderWidth", T<int []>
                    "hoverBorderColor", T<string []>
                    "data", T<float []>
                ]
        }
        |=> Inherits ADataSet

    let EnhancedAnimation =
        Pattern.Config "EnhancedAnimation" {
            Required = []
            Optional =
                [
                    "animateRotate", T<bool>
                    "animateScale", T<bool>
                ]
        }
        |=> Inherits AnimationConfig

    let PolarChartOptions =
        Pattern.Config "PolarChartOptions" {
            Required = []
            Optional =
                [
                    "startAngle", T<int>
                    
                ]
        }
        |=> Inherits CommonChartConfig

    let PieChartDataSet =
        Pattern.Config "PieChartDataSet" {
            Required = []
            Optional =
                [
                    "label", T<string>
                    "backgroundColor", T<string []>
                    "borderWidth", T<int []>
                    "borderColor", T<string []>
                    "hoverBackgroundColor", T<string []>
                    "hoverBorderWidth", T<int []>
                    "hoverBorderColor", T<string []>
                    "data", T<float []>
                ]
        }
        |=> Inherits ADataSet

    let DoughnutChartDataSet =
        Pattern.Config "DoughnutChartDataSet" {
            Required = []
            Optional =
                [
                    "label", T<string>
                    "backgroundColor", T<string []>
                    "borderWidth", T<int []>
                    "borderColor", T<string []>
                    "hoverBackgroundColor", T<string []>
                    "hoverBorderWidth", T<int []>
                    "hoverBorderColor", T<string []>
                    "data", T<float []>
                ]
        }
        |=> Inherits ADataSet

    let PieDoughnutChartOptions =
        Pattern.Config "PieDoughnutChartOptions" {
            Required = []
            Optional =
                [
                    "cutoutPercentage", T<int>
                    "rotation", T<float>
                    "circumference", T<float>
                ]
        }
        |=> Inherits CommonChartConfig

    let BubbleDataObject =
        Pattern.Config "BubbleDataObject" {
            Required =
                [
                    "x", T<float>
                    "y", T<float>
                    "r", T<float>
                ]
            Optional = []
        }

    let BubbleChartDataSet =
        Pattern.Config "BubbleChartDataSet" {
            Required = []
            Optional =
                [
                    "label", T<string>
                    "backgroundColor", T<string> + T<string []>
                    "borderWidth", T<int> + T<int []>
                    "borderColor", T<string> + T<string []>
                    "hoverBackgroundColor", T<string> + T<string []>
                    "hoverBorderWidth", T<int> + T<int []>
                    "hoverBorderColor", T<string> + T<string []>
                    "hoverRadius", T<float> + T<float []>
                    "data", Type.ArrayOf BubbleDataObject
                ]
        }
        |=> Inherits ADataSet

    let Global =
        Pattern.Config "Global" {
            Required =
                [
                    "global", CommonChartConfig.Type
                ]
            Optional = []
        }

    let Chart =
        let Context = (T<Dom.Element> + T<JQuery.JQuery> + T<string>)?elementId // + T<JavaScript.CanvasElement>
        ChartClass
        |+> Static [
            Constructor (Context * ChartCreate)
            "Line" => Context * ChartCreate ^-> TSelf
            "default" =? CommonChartConfig
        ]
        |+> Instance [
            "destroy" => T<unit> ^-> T<unit>
            "update" => T<unit> ^-> T<unit>
            "update" => T<int> ^-> T<unit>
            "update" => T<int> * T<bool> ^-> T<unit>
            "reset" => T<unit> ^-> T<unit>
            "render" => T<unit> ^-> T<unit>
            "render" => T<int> ^-> T<unit>
            "render" => T<int> * T<bool> ^-> T<unit>
            "stop" => T<unit> ^-> TSelf
            "clear" => T<unit> ^-> TSelf
            "resize" => T<unit> ^-> TSelf
            "toBase64Image" => T<unit> ^-> T<string>
            "generateLegend" => T<unit> ^-> T<string>
            "getElementAtEvent" => T<Dom.Event> + T<JQuery.Event> ^-> T<Dom.Element>
            "getsElementAtEvent" => T<Dom.Event> + T<JQuery.Event> ^-> T<Dom.Element []>
            "getDatasetAtEvent" => T<Dom.Event> + T<JQuery.Event> ^-> T<Dom.Element>
            "getDatasetMeta" => T<int> ^-> ADataSet

        ]

    let Assembly =
        Assembly [
            Namespace "WebSharper.ChartJs" [
                PositionString
                ChartData
                PaddingConfig
                LayoutConfig
                TitleConfig
                LegendItem
                LegendLabelConfig
                LegendConfig
                Easing
                InteractionMode
                TooltipItem
                TooltipCallbacks
                TooltipConfig
                HoverConfig
                AnimationObject
                AnimationCallbackObj
                AnimationConfig
                ArcConfig
                RectangleConfig
                PointConfig
                LineConfig
                ElementConfig
                CommonChartConfig
                LineChartDataSet
                BarChartDataSet
                PieChartDataSet
                DoughnutChartDataSet
                RadarChartDataSet
                PolarChartDataSet
                BubbleDataObject
                BubbleChartDataSet
                ChartCreate
                Chart
                BarChartXAxes
                BarChartYAxes
                RadarChartOptions
                PolarChartOptions
                PieDoughnutChartOptions
                EnhancedAnimation
                Scale
                Scales
                TickConfig
                ScaleTitleConfig
                GridLineConfig
                ScaleType
                ADataSet
                LabelColor
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
