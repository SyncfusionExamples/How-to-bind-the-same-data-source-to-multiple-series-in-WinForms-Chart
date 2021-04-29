using Syncfusion.Drawing;
using Syncfusion.Windows.Forms.Chart;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GettingStarted_Chart
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Panel panel = new Panel();

            this.chartControl1 = new Syncfusion.Windows.Forms.Chart.ChartControl();
            this.SuspendLayout();
            panel.SuspendLayout();
            // 
            // chartControl1
            // 
            this.chartControl1.ChartArea.BackInterior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.Transparent);
            this.chartControl1.ChartArea.CursorLocation = new System.Drawing.Point(0, 0);
            this.chartControl1.ChartArea.CursorReDraw = false;
            this.chartControl1.IsWindowLess = false;            
            this.chartControl1.TabIndex = 0;            
            this.chartControl1.Skins = Skins.Metro;
            ChartTitle title = new Syncfusion.Windows.Forms.Chart.ChartTitle();
            title.Text = "Foregin Exchange Rate Analysis";
            this.chartControl1.Titles.Add(title);
            this.chartControl1.Title.Font = new System.Drawing.Font("Candara", 9F, System.Drawing.FontStyle.Bold);
            this.chartControl1.BackInterior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.LightBlue);
            this.chartControl1.ChartInterior = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Horizontal, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.LightBlue);

            DateTime start = new DateTime(2020, 12, 30);
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

            //
            // PrimaryXAxis
            //
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
            ChartSeries chartSeries = new ChartSeries("Series 1");
            chartSeries.CategoryModel = dataSeriesModel1;
            chartSeries.Type = ChartSeriesType.Candle;

            CategoryAxisDataBindModel dataSeriesModel2 = new CategoryAxisDataBindModel(dataSource);
            dataSeriesModel2.CategoryName = "Date";
            dataSeriesModel2.YNames = new string[] { "EMA" };
            ChartSeries chartSeries1 = new ChartSeries("Series 2");
            chartSeries1.CategoryModel = dataSeriesModel2;
            chartSeries1.Type = ChartSeriesType.Line;
            chartSeries1.Style.Interior = new Syncfusion.Drawing.BrushInfo(Color.Blue);

            CategoryAxisDataBindModel dataSeriesModel3 = new CategoryAxisDataBindModel(dataSource);
            dataSeriesModel3.CategoryName = "Date";
            dataSeriesModel3.YNames = new string[] { "SMA" };
            ChartSeries chartSeries2 = new ChartSeries("Series 3");
            chartSeries2.CategoryModel = dataSeriesModel3;
            chartSeries2.Type = ChartSeriesType.Line;
            chartSeries2.Style.Interior = new Syncfusion.Drawing.BrushInfo(Color.Red);

            this.chartControl1.Series.Add(chartSeries);
            this.chartControl1.Series.Add(chartSeries1);
            this.chartControl1.Series.Add(chartSeries2);

            this.chartControl1.ShowToolTips = true;
            this.chartControl1.ShowLegend = false;
            this.chartControl1.Tooltip.BackgroundColor = new BrushInfo(Color.White);
            this.chartControl1.Tooltip.BorderStyle = BorderStyle.FixedSingle;
            this.chartControl1.Tooltip.Font = new Font("Segoe UI", 10);
            chartSeries.PointsToolTipFormat = "{2}";

            this.chartControl1.Size = new System.Drawing.Size(1700, 650);
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 577);

            panel.AutoSize = true;
            panel.Controls.Add(chartControl1);

            this.Controls.Add(panel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
        }

        #endregion

        private Syncfusion.Windows.Forms.Chart.ChartControl chartControl1;
    }
}

