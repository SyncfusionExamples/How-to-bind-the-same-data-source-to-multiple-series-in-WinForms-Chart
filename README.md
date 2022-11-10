# How to bind the same data source to multiple series in WinForms Chart

This article explains how to bind a same data source to multiple series in [WinForms Charts](https://help.syncfusion.com/windowsforms/chart/getting-started) with the following tabulated data, populated as a common data source to below candle and line charts.

**Data points**

| Date  | High | Low  | Open | Close  | EMA | SMA |
| ------------- | ------------- | ------------- | ------------- | ------------- | ------------- | ------------- | 
| Dec 30  | 470  | 200  | 270  | 400  | 544  | 444  |
| Dec 31  | 520  | 234  | 321  | 458  | 511  | 411  |
| Jan 1  | 482  | 193  | 352  | 302  | 467  | 367  |
| Jan 2  | 457  | 230  | 300  | 410  | 432  | 332  |
| Jan 3  | 421  | 150  | 357  | 200  | 411  | 311  |
| Jan 4  | 475  | 200  | 300  | 355  | 386  | 365  |
| Jan 5  | 470  | 200  | 270  | 400  | 354  | 427  |
| Jan 6  | 520  | 234  | 321  | 458  | 316  | 444  |
| Jan 7  | 482  | 193  | 352  | 302  | 298  | 456  |
| Jan 8  | 457  | 230  | 300  | 410  | 286  | 473  |

You can bind the same data source to multiple series by using the [CategoryAxisDataBindModel](https://help.syncfusion.com/cr/windowsforms/Syncfusion.Windows.Forms.Chart.CategoryAxisDataBindModel.html) class as shown in the following steps:

**Step 1:** Create a model with the required properties for the data points.
```
public class ChartModel
{
        public DateTime Date { get; set; }
 
        public double High { get; set; }
 
        public double Low { get; set; }
 
        public double Open { get; set; }
 
        public double Close { get; set; }
 
        public double EMA { get; set; }
 
        public double SMA { get; set; }
 
        public ChartModel(DateTime date, double high, double low, double open, double close, double yValue1, double yValue2 )
        {
            Date = date;
            High = high;
            Low = low;
            Open = open;
            Close = close;
            EMA = yValue1;
            SMA = yValue2;
        }
}
```

**Step 2:** Create a BindingList for chart data source using the defined model.
```
DateTime start = new DateTime (2020, 12, 30);
BindingList<ChartModel> dataSource = new BindingList<ChartModel>();
dataSource.Add(new ChartModel (start.AddDays(0), 470, 200, 270, 400, 544, 444));
dataSource.Add(new ChartModel (start.AddDays(1), 520, 234, 321, 458, 511, 411));
dataSource.Add(new ChartModel (start.AddDays(2), 482, 193, 352, 302, 467, 367));
dataSource.Add(new ChartModel (start.AddDays(3), 457, 230, 300, 410, 432, 332));
dataSource.Add(new ChartModel (start.AddDays(4), 421, 150, 357, 200, 411, 311));
dataSource.Add(new ChartModel (start.AddDays(5), 475, 200, 300, 385, 386, 365));
dataSource.Add(new ChartModel (start.AddDays(6), 470, 200, 270, 400, 354, 427));
dataSource.Add(new ChartModel (start.AddDays(7), 520, 234, 321, 458, 316, 444));
dataSource.Add(new ChartModel (start.AddDays(8), 482, 193, 352, 302, 298, 456));
dataSource.Add(new ChartModel (start.AddDays(9), 457, 230, 300, 410, 286, 473));
```

**Step 3:** Create an instance of [CategoryAxisDataBindModel](https://help.syncfusion.com/cr/windowsforms/Syncfusion.Windows.Forms.Chart.CategoryAxisDataBindModel.html) class with an already defined data source for each series and set the binding property name value for [CategoryName](https://help.syncfusion.com/cr/windowsforms/Syncfusion.Windows.Forms.Chart.CategoryAxisDataBindModel.html#Syncfusion_Windows_Forms_Chart_CategoryAxisDataBindModel_CategoryName) and [YNames](https://help.syncfusion.com/cr/windowsforms/Syncfusion.Windows.Forms.Chart.CategoryAxisDataBindModel.html#Syncfusion_Windows_Forms_Chart_CategoryAxisDataBindModel_YNames) properties for each series. Then, bind the instance of [CategoryAxisDataBindModel](https://help.syncfusion.com/cr/windowsforms/Syncfusion.Windows.Forms.Chart.CategoryAxisDataBindModel.html) to [CategoryModel](https://help.syncfusion.com/cr/windowsforms/Syncfusion.Windows.Forms.Chart.ChartSeries.html#Syncfusion_Windows_Forms_Chart_ChartSeries_CategoryModel) property of chart series respectively as shown in the following code example.

```
Panel panel = new Panel();
this.chartControl1 = new Syncfusion.Windows.Forms.Chart.ChartControl();
 
this.chartControl1.PrimaryXAxis.TitleColor = System.Drawing.SystemColors.ControlText;
this.chartControl1.Indexed = true;
this.chartControl1.PrimaryXAxis.EdgeLabelsDrawingMode = ChartAxisEdgeLabelsDrawingMode.Shift;
this.chartControl1.PrimaryYAxis.Title = "Price $";
this.chartControl1.PrimaryYAxis.Format = "#$";
this.chartControl1.PrimaryXAxis.RangeType = ChartAxisRangeType.Set;
this.chartControl1.PrimaryXAxis.ValueType = ChartValueType.DateTime;
this.chartControl1.PrimaryXAxis.DateTimeRange = new ChartDateTimeRange(start.AddDays(-1), start.AddDays(11), 1, ChartDateTimeIntervalType.Days);
this.chartControl1.PrimaryYAxis.TitleFont = new System.Drawing.Font("Candara", 11F, System.Drawing.FontStyle.Bold);
this.chartControl1.PrimaryXAxis.TitleFont = new System.Drawing.Font("Candara", 11F, System.Drawing.FontStyle.Bold);
this.chartControl1.PrimaryXAxis.DateTimeFormat = "MMM dd";
this.chartControl1.PrimaryXAxis.Title = "Week Day";            
 
CategoryAxisDataBindModel dataSeriesModel1 = new CategoryAxisDataBindModel(dataSource);
dataSeriesModel1.CategoryName = "Date";
dataSeriesModel1.YNames = new string[] { "High", "Low", "Open", "Close" };
ChartSeries chartSeries1 = new ChartSeries("Series 1");
chartSeries1.CategoryModel = dataSeriesModel1;
chartSeries1.Type = ChartSeriesType.Candle;
 
CategoryAxisDataBindModel dataSeriesModel2 = new CategoryAxisDataBindModel(dataSource);
dataSeriesModel2.CategoryName = "Date";
dataSeriesModel2.YNames = new string[] { "EMA" };
ChartSeries chartSeries2 = new ChartSeries("Series 2");
chartSeries2.CategoryModel = dataSeriesModel2; 
chartSeries2.Type = ChartSeriesType.Line;
chartSeries2.Style.Interior = new Syncfusion.Drawing.BrushInfo(Color.Blue);
 
CategoryAxisDataBindModel dataSeriesModel3 = new CategoryAxisDataBindModel(dataSource);
dataSeriesModel3.CategoryName = "Date";
dataSeriesModel3.YNames = new string[] { "SMA" };
ChartSeries chartSeries3 = new ChartSeries("Series 3");
chartSeries3.CategoryModel = dataSeriesModel3;
chartSeries3.Type = ChartSeriesType.Line;
chartSeries3.Style.Interior = new Syncfusion.Drawing.BrushInfo(Color.Red);
 
this.chartControl1.Series.Add(chartSeries1);
this.chartControl1.Series.Add(chartSeries2);
this.chartControl1.Series.Add(chartSeries3);
 
panel.Controls.Add(chartControl1);
```

## Output

![](https://user-images.githubusercontent.com/53489303/200549891-75903ed0-20c8-45d7-b838-c1cd2f5ee5b1.png)

KB article - [How to bind the same data source to multiple series in WinForms Chart](https://www.syncfusion.com/kb/12555/how-to-bind-the-same-data-source-to-multiple-series-in-winforms-chart)

## See also 

[How to bind the data source via chart wizard](https://www.syncfusion.com/kb/7680/how-to-bind-the-data-source-via-chart-wizard)

[How to bind a dataset with date values in Chart](https://www.syncfusion.com/kb/37/how-to-bind-a-dataset-with-date-values-in-chart)

[How to customize data points for the chart series](https://www.syncfusion.com/kb/74/how-to-customize-data-points-for-the-chart-series)

[How to create parallel coordinate plot in WinForms Chart](https://www.syncfusion.com/kb/12234/how-to-create-parallel-coordinate-plot-in-winforms-chart)

