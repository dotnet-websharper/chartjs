// $begin{copyright}
//
// This file is part of WebSharper
//
// Copyright (c) 2008-2018 IntelliFactory
//
// Licensed under the Apache License, Version 2.0 (the "License"); you
// may not use this file except in compliance with the License.  You may
// obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or
// implied.  See the License for the specific language governing
// permissions and limitations under the License.
//
// $end{copyright}
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
            "bottom"
            "right"
            "chartArea"
        ]

    let AlignString =
        Pattern.EnumStrings "AlignString" [
            "start"
            "center"
            "end"
        ]

    let ADataSet = Class "ADataSet"

    let Font =
        Pattern.Config "Font" {
            Required = []
            Optional = [
                "family", T<string>
                "size", T<int>
                "style", T<string>
                "weight", T<string>
                "lineHeight", T<float> + T<string>
            ]
        }
    
    let PointStyle =
        Pattern.EnumStrings "PointStyle" [
            "circle"
            "cross"
            "crossRot"
            "dash"
            "line"
            "rect"
            "rectRounded"
            "rectRot"
            "star"
            "triangle"
        ]

    let PaddingDirections =
        Pattern.Config "PaddingDirections" {
            Required = []
            Optional = [
                "top", T<int>
                "left", T<int>
                "bottom", T<int>
                "right", T<int>
            ]
        }

    let PaddingXY =
        Pattern.Config "PaddingXY" {
            Required = []
            Optional = [
                "x", T<int>
                "y", T<int>
            ]
        }

    let ChartData =
        Pattern.Config "ChartData" {
            Required = 
                [
                    "datasets", !| ADataSet.Type
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
                    "backdropColor", T<string>
                    "backdropPadding", T<int> + PaddingDirections.Type + PaddingXY.Type
                    "callback", T<float> * T<float> * T<float []> ^-> T<obj>
                    "display", T<bool>
                    "color", T<string>
                    "font", Font.Type
                    "major", T<obj>
                    "padding", T<int>
                    "showLabelBackdrop", T<bool>
                    "textStrokeColor", T<string>
                    "textStrokeWidth", T<int>
                    "z", T<int>
                ]
        }

    let Scale =
        Pattern.Config "Scale" {
            Required = []
            Optional =
                [
                    "type", ScaleType.Type
                    "alignToPixels", T<bool>
                    "backgroundColor", T<string>
                    "display", T<bool>
                    "grid", T<obj>
                    "min", T<int>
                    "max", T<int>
                    "reverse", T<bool>
                    "stacked", T<bool> + T<string>
                    "suggestedMax", T<int>
                    "suggestedMin", T<int>
                    "ticks", TickConfig.Type
                    "weight", T<int>
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
                    "align", AlignString.Type
                    "color", T<string>
                    "display", T<bool>
                    "fullSize", T<bool>
                    "position", PositionString.Type
                    "font", Font.Type
                    "padding", T<float>
                    "text", T<string>
                ]
        }

    let LegendTitleConfig =
        Pattern.Config "LegendTitleConfig" {
            Required = []
            Optional =
                [
                    "color", T<string>
                    "display", T<bool>
                    "font", Font.Type
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
                    "boxHeight", T<int>
                    "color", T<int>
                    "font", Font.Type
                    "padding", T<float>
                    "generateLabels", ChartClass ^-> Type.ArrayOf LegendItem
                    "filter", LegendItem * T<obj> ^-> T<unit>
                    "sort", (LegendItem.Type * LegendItem.Type * T<obj> ^-> T<unit>)
                    "pointStyle", T<string> // + Image
                    "textAlign", AlignString.Type
                    "usePointStyle", T<bool>
                ]
        }

    let LegendConfig =
        Pattern.Config "LegendConfig" {
            Required = []
            Optional =
                [
                    "display", T<bool>
                    "position", PositionString.Type
                    "align", AlignString.Type
                    "maxHeight", T<int>
                    "maxWidth", T<int>
                    "fullSize", T<bool>
                    "onClick", (T<Dom.Event> * LegendItem ^-> T<unit>)
                    "onHover", (T<Dom.Event> * LegendItem ^-> T<unit>)
                    "onLeave", (T<Dom.Event> * LegendItem ^-> T<unit>)
                    "reverse", T<bool>
                    "labels", T<obj>
                    "rtl", T<bool>
                    "textDirection", T<string>
                    "title", T<obj>
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
                    "beforeLabel", TooltipItem * T<obj> ^-> T<string []>
                    "label", TooltipItem * T<obj> ^-> T<string []>
                    "labelColor", TooltipItem * ChartClass ^-> LabelColor
                    "labelTextColor", TooltipItem * T<obj> ^-> T<string []>
                    "labelPointStyle", TooltipItem * T<obj> ^-> T<string []>
                    "afterLabel", TooltipItem * T<obj> ^-> T<string []>
                    "afterBody", Type.ArrayOf TooltipItem * T<obj> ^-> T<string []>
                    "beforeFooter", Type.ArrayOf TooltipItem * T<obj> ^-> T<string []>
                    "footer", Type.ArrayOf TooltipItem * T<obj> ^-> T<string []>
                    "afterFooter", Type.ArrayOf TooltipItem * T<obj> ^-> T<string []>
                ]
        }

    let TooltipPosition =
        Pattern.EnumStrings "TooltipPosition" [
            "average"
            "nearest"
        ]


    let TooltipXAlign =
        Pattern.EnumStrings "TooltipXAlign" [
            "left"
            "center"
            "right"
        ]

    let TooltipYAlign =
        Pattern.EnumStrings "TooltipYAlign" [
            "top"
            "center"
            "bottom"
        ]     
        
    let TooltipTextAlign =
        Pattern.EnumStrings "TooltipTextAlign" [
            "left"
            "right"
            "center"
        ]

    let TooltipConfig =
        Pattern.Config "TooltipConfig" {
            Required = []
            Optional =
                [
                    "enabled", T<bool>
                    "mode", T<string>
                    "intersect", T<bool>
                    "position", PositionString.Type
                    "callbacks", T<obj>
                    "itemSort", T<obj> * T<obj> * !?T<obj> ^-> T<int>
                    "filter", T<obj> * !?T<obj> ^-> T<bool>
                    "backgroundColor", T<string>
                    "titleColor", T<string>
                    "titleFont", Font.Type
                    "titleAlign", TooltipTextAlign.Type
                    "titleSpacing", T<float>
                    "titleMarginBottom", T<float>
                    "bodyColor", T<string>
                    "bodyFont", Font.Type
                    "bodyAlign", TooltipTextAlign.Type
                    "bodySpacing", T<float>
                    "footerColor", T<string>
                    "footerFont", Font.Type
                    "footerAlign", TooltipTextAlign.Type
                    "footerSpacing", T<float>
                    "footerMarginTop", T<float>
                    "padding", T<int> + PaddingDirections.Type + PaddingXY.Type
                    "caretPadding", T<int>
                    "caretSize", T<int>
                    "cornerRadius", T<float>
                    "multiKeyBackground", T<string>
                    "displayColors", T<bool>
                    "boxWidth", T<int>
                    "boxHeight", T<int>
                    "usePointStyle", T<bool>
                    "borderColor", T<string>
                    "borderWidth", T<int>
                    "rtl", T<bool>
                    "textDirection", T<string>
                    "xAlign", TooltipXAlign.Type
                    "yAlign", TooltipYAlign.Type
                ]
        }

    let HoverConfig =
        Pattern.Config "HoverConfig" {
            Required = []
            Optional =
                [
                    "mode", InteractionMode.Type
                    "intersect", T<bool>
                    "axis", T<string>
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
                    "animation", T<obj>
                    "animations", T<obj>
                    "transitions", T<obj>
                    "duration", T<int>
                    "easing", Easing.Type
                    "delay", T<int>
                    "loop", T<bool>
                    "properties", T<string []>
                    "type", T<string>
                    "from", T<int> + T<string> + T<bool>
                    "to", T<int> + T<string> + T<bool>
                    "fn", T<int> + T<string> + T<bool>
                    "numbers", T<string []>
                    "colors", T<string []>
                    "onProgress", AnimationCallbackObj ^-> T<unit>
                    "onComplete", AnimationCallbackObj ^-> T<unit>
                ]
        }

    let ArcConfig =
        Pattern.Config "ArcConfig" {
            Required = []
            Optional =
                [
                    "angle", T<int>
                    "backgroundColor", T<string>
                    "borderAlign", AlignString.Type
                    "borderColor", T<string>
                    "borderWidth", T<float> 
                ]
        }

    let BarConfig =
        Pattern.Config "BarConfig" {
            Required = []
            Optional = [
                "backgroundColor", T<string>
                "borderWidth", T<int>
                "borderColor", T<string>
                "borderSkipped", T<string>
                "borderRadius", T<int> + T<obj>
                "pointStyle", PointStyle.Type // + Image
            ]
        }

    let LineConfig =
        Pattern.Config "LineConfig" {
            Required = []
            Optional =
                [
                    "tension", T<float>
                    "backgroundColor", T<string>
                    "borderWidth", T<int>
                    "borderColor", T<string>
                    "borderCapStyle", T<string>
                    "borderDash", T<float []>
                    "borderDashOffset", T<float>
                    "borderJoinStyle", T<string>
                    "capBezierPoints", T<bool>
                    "cubicInterpolationMode", T<string>
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
                    "pointStyle", PointStyle.Type
                    "rotation", T<int>
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
                    "aspectRatio", T<int>
                    "maintainAspectRatio", T<bool>
                    "events", T<string []>
                    "onHover", (T<Dom.Event> * T<Dom.Element []> ^-> T<unit>)
                    "onClick", (T<Dom.Event> * T<Dom.Element []> ^-> T<unit>)
                    "legendCallback", (ChartClass ^-> T<string>)
                    "onResize", (ChartClass * T<int> ^-> T<unit>)
                    "resizeDelay", T<int>
                    "layout", LayoutConfig.Type
                    "padding", PaddingConfig.Type
                    "title", TitleConfig.Type
                    "legend", LegendConfig.Type
                    "tooltip", TooltipConfig.Type
                    "hover", HoverConfig.Type
                    "animation", AnimationConfig.Type
                    "elements", ElementConfig.Type
                    "scale", Scales.Type
                    "devicePixelRatio", T<int>
                    "locale", T<string>
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
                    "backgroundColor", T<string>
                    "borderCapStyle", T<string>
                    "borderColor", T<string>
                    "borderDash", T<float []>
                    "borderDashOffset", T<float>
                    "borderJoinStyle", T<string>
                    "borderWidth", T<int>
                    "clip", T<int> + T<obj>
                    "cubicInterpolationMode", T<string>
                    "data", T<obj>
                    "fill", T<bool>
                    "hoverBackgroundColor", T<string> + T<string []>
                    "hoverBorderCapStyle", T<string>
                    "hoverBorderColor", T<string> + T<string []>
                    "hoverBorderDash", T<int []>
                    "hoverBorderDashOffset", T<int>
                    "hoverBorderJoinStyle", T<string>
                    "hoverBorderWidth", T<int>
                    "indexAxis", T<string>
                    "label", T<string>
                    "order", T<int>
                    "pointBackgroundColor", T<string> + T<string []>
                    "pointBorderColor", T<string> + T<string []>
                    "pointBorderWidth", T<int>
                    "pointHitRadius", T<int>
                    "pointHoverBackgroundColor", T<string> + T<string []>
                    "pointHoverBorderColor", T<string> + T<string []>
                    "pointHoverBorderWidth", T<int>
                    "pointHoverRadius", T<int>
                    "pointRadius", T<int>
                    "pointRotation", T<int>
                    "pointStyle", T<string> // + Image
                    "segment", T<obj>
                    "showLine", T<bool>
                    "spanGaps", T<bool>
                    "stack", T<string>
                    "stepped", T<bool> + T<string>
                    "tension", T<int>
                    "xAxisID", T<string>
                    "yAxisID", T<string>
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
                    "backgroundColor", T<string>
                    "base", T<int>
                    "barPercentage", T<int>
                    "barThickness", T<int> + T<string>
                    "borderColor", T<string>
                    "borderSkipped", T<string>
                    "borderWidth", T<int> + T<obj>
                    "borderRadius", T<int> + T<obj>
                    "categoryPercentage", T<int>
                    "clip", T<int> + T<obj>
                    "data", T<obj> + T<obj []> + T<int []> + T<float []> + T<string []>
                    "grouped", T<bool>
                    "hoverBackgroundColor", T<string>
                    "hoverBorderColor", T<string>
                    "hoverBorderWidth", T<int>
                    "hoverBorderRadius", T<int>
                    "indexAxis", T<string>
                    "maxBarThickness", T<int>
                    "minBarLength", T<int>
                    "label", T<string>
                    "order", T<int>
                    "pointStyle", T<string> // + Image
                    "skippNull", T<bool>
                    "stack", T<string>
                    "XAxisID", T<string>
                    "YAxisID", T<string>
                ]
        }
        |=> Inherits ADataSet

    let RadarChartDataSet =
        Pattern.Config "RadarChartDataSet" {
            Required = []
            Optional =
                [
                    "backgroundColor", T<string>
                    "borderCapStyle", T<string>
                    "borderColor", T<string>
                    "borderDash", T<float []>
                    "borderDashOffset", T<float>
                    "borderJoinStyle", T<string>
                    "borderWidth", T<int>
                    "hoverBackgroundColor", T<string>
                    "hoverBorderCapStyle", T<string>
                    "hoverBorderColor", T<string>
                    "hoverBorderDash", T<int []>
                    "hoverBorderDashOffset", T<int>
                    "hoverBorderJoinStyle", T<string>
                    "hoverBorderWidth", T<int>
                    "clip", T<int> + T<obj>
                    "data", T<float []>
                    "fill", T<bool>
                    "label", T<string>
                    "order", T<int>
                    "tension", T<int>
                    "pointBackgroundColor", T<string> + T<string []>
                    "pointBorderColor", T<string> + T<string []>
                    "pointBorderWidth", T<int> + T<int []>
                    "pointHitRadius", T<int> + T<int []>
                    "pointHoverBackgroundColor", T<string> + T<string []>
                    "pointHoverBorderColor", T<string> + T<string []>
                    "pointHoverBorderWidth", T<int> + T<int []>
                    "pointHoverRadius", T<int>
                    "pointRadius", T<int> + T<int []>
                    "pointRotation", T<int>
                    "pointStyle", T<string> // + Image
                    "spanGaps", T<bool>
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

    let PolarAreaChartDataSet =
        Pattern.Config "PolarAreaChartDataSet" {
            Required = []
            Optional =
                [
                    "backgroundColor", T<string>
                    "borderAlign", T<string>
                    "borderColor", T<string>
                    "borderWidth", T<int []>
                    "clip", T<int> + T<obj>
                    "data", T<float []>
                    "hoverBackgroundColor", T<string>
                    "hoverBorderColor", T<string>
                    "hoverBorderWidth", T<int>
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

    let PolarAreaChartOptions =
        Pattern.Config "PolarAreaChartOptions" {
            Required = []
            Optional =
                [
                    "startAngle", T<int>
                    
                ]
        }
        |=> Inherits CommonChartConfig

    let PieDoughnutDataset =
        Pattern.Config "PieDoughnutDataset" {
            Required = []
            Optional = [
                "data", T<int []> + T<float []>
            ]
        }

    let PieDoughnutData =
        Pattern.Config "PieDoughnutData" {
            Required = []
            Optional = [
                "datasets", PieDoughnutDataset.Type
                "labels", T<string>
            ]
        }

    let PieChartDataSet =
        Pattern.Config "PieChartDataSet" {
            Required = []
            Optional =
                [
                    "backgroundColor", T<string []>
                    "borderAlign", T<string>
                    "borderColor", T<string []>
                    "borderRadius", T<int> + T<obj>
                    "borderWidth", T<int []>
                    "circumference", T<int>
                    "clip", T<int> + T<obj>
                    "data", T<float []>
                    "hoverBackgroundColor", T<string []>
                    "hoverBorderColor", T<string []>
                    "hoverBorderWidth", T<int []>
                    "hoverOffset", T<int>
                    "offset", T<int>
                    "rotation", T<int>
                    "spacing", T<int>
                    "weight", T<int>
                ]
        }
        |=> Inherits ADataSet

    let DoughnutChartDataSet =
        Pattern.Config "DoughnutChartDataSet" {
            Required = []
            Optional =
                [
                    "backgroundColor", T<string []>
                    "borderAlign", T<string>
                    "borderColor", T<string []>
                    "borderRadius", T<int> + T<obj>
                    "borderWidth", T<int []>
                    "circumference", T<int>
                    "clip", T<int> + T<obj>
                    "data", T<float []>
                    "hoverBackgroundColor", T<string []>
                    "hoverBorderColor", T<string []>
                    "hoverBorderWidth", T<int []>
                    "hoverOffset", T<int>
                    "offset", T<int>
                    "rotation", T<int>
                    "spacing", T<int>
                    "weight", T<int>
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
                    "r", T<int>
                ]
            Optional = []
        }

    let BubbleChartDataSet =
        Pattern.Config "BubbleChartDataSet" {
            Required = []
            Optional =
                [
                    "backgroundColor", T<string>
                    "borderColor", T<string>
                    "borderWidth", T<int> + T<int []>
                    "clip", T<int> + T<obj>
                    "data", !| BubbleDataObject.Type
                    "hoverBackgroundColor", T<string>
                    "hoverBorderColor", T<string>
                    "hoverBorderWidth", T<int> + T<int []>
                    "hoverRadius", T<int>
                    "hitRadius",T<int>
                    "label", T<string>
                    "order", T<int>
                    "pointStyle", T<string> // + Image
                    "rotation", T<int>
                    "radius", T<int>
                ]
        }
        |=> Inherits ADataSet

    let ScatterChartDataSet =
        Pattern.Config "ScatterChartDataSet" {
            Required = []
            Optional =
                [
                    "backgroundColor", T<string>
                    "borderCapStyle", T<string>
                    "borderColor", T<string>
                    "borderDash", T<float []>
                    "borderDashOffset", T<float>
                    "borderJoinStyle", T<string>
                    "borderWidth", T<int>
                    "clip", T<int> + T<obj>
                    "cubicInterpolationMode", T<string>
                    "data", T<obj>
                    "fill", T<bool>
                    "hoverBackgroundColor", T<string>
                    "hoverBorderCapStyle", T<string>
                    "hoverBorderColor", T<string>
                    "hoverBorderDash", T<int []>
                    "hoverBorderDashOffset", T<int>
                    "hoverBorderJoinStyle", T<string>
                    "hoverBorderWidth", T<int>
                    "indexAxis", T<string>
                    "label", T<string>
                    "order", T<int>
                    "pointBackgroundColor", T<string>
                    "pointBorderColor", T<string>
                    "pointBorderWidth", T<int>
                    "pointHitRadius", T<int>
                    "pointHoverBackgroundColor", T<string>
                    "pointHoverBorderColor", T<string>
                    "pointHoverBorderWidth", T<int>
                    "pointHoverRadius", T<int>
                    "pointRadius", T<int>
                    "pointRotation", T<int>
                    "pointStyle", T<string> // + Image
                    "segment", T<obj>
                    "showLine", T<bool>
                    "spanGaps", T<bool>
                    "stack", T<string>
                    "stepped", T<bool> + T<string>
                    "tension", T<int>
                    "xAxisID", T<string>
                    "yAxisID", T<string>
                ]
        }
        |=> Inherits ADataSet

    let Fill =
        Pattern.Config "Fill" {
            Required = []
            Optional = [
                "target", T<int> + T<float> + T<string> + T<bool> + T<obj>
            ]
        }

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
                Font
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
                PolarAreaChartDataSet
                BubbleDataObject
                BubbleChartDataSet
                ChartCreate
                Chart
                BarChartXAxes
                BarChartYAxes
                RadarChartOptions
                PolarAreaChartOptions
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
                Fill
                ScatterChartDataSet
                PointStyle
                AlignString
                TooltipYAlign
                TooltipXAlign
                TooltipTextAlign
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
