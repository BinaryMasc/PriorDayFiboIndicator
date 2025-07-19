// Copyright QUANTOWER LLC. © 2017-2023. All rights reserved.

using System;
using System.Drawing;
using TradingPlatform.BusinessLayer;
using TradingPlatform.BusinessLayer.Chart;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
using Font = System.Drawing.Font;
using System.Collections.Generic;

namespace Indicator1
{

	public class Indicator1 : Indicator
    {
        private bool showLowHighDay = true;
        private bool showPreviousLowHigh = true;
        private bool showtext = true;
        private bool showPrevIntradayFibos = false;
        private bool showIntradayFibos = false;

        private Color fibosColor = Color.Green;
        private Color intradayFibosColor = Color.Olive;
        private Brush textColor = Brushes.DarkCyan;
        private int lineWidth = 300;


        public override IList<SettingItem> Settings
        {
            get
            {
                IList<SettingItem> settings = base.Settings;

                settings.Add(new SettingItemBoolean("showtext", showtext)
                {
                    Text = "Show Text Levels",
                    SortIndex = 0,
                });

                settings.Add(new SettingItemBoolean("showLowHighDay", showLowHighDay)
                {
                    Text = "Show Today High and Low",
                    SortIndex = 1,
                });

                settings.Add(new SettingItemBoolean("showPreviousLowHigh", showPreviousLowHigh)
                {
                    Text = "Show Previous Day High and Low",
                    SortIndex = 2,
                });

                settings.Add(new SettingItemColor("fibosColor", fibosColor)
                {
                    Text = "Fibo Levels Color",
                    SortIndex = 3,
                });

                settings.Add(new SettingItemBoolean("showPrevIntradayFibos", showPrevIntradayFibos)
                {
                    Text = "Show Previous Day Fibos",
                    SortIndex = 4,
                });

                settings.Add(new SettingItemBoolean("showIntradayFibos", showIntradayFibos)
                {
                    Text = "Show Intraday (today) Fibos",
                    SortIndex = 5,
                });

                settings.Add(new SettingItemColor("intradayFibosColor", intradayFibosColor)
                {
                    Text = "Fibo Previous Day Levels Color",
                    SortIndex = 6,
                });

                settings.Add(new SettingItemInteger("lineWidth", lineWidth)
                {
                    Text = "Line Width",
                    SortIndex = 10,
                });




                return settings;
            }
            set
            {
                if (value.TryGetValue<bool>("showLowHighDay", out var value1))
                {
                    showLowHighDay = value1;
                }

                if (value.TryGetValue<bool>("showPreviousLowHigh", out var value2))
                {
                    showPreviousLowHigh = value2;
                }

                if (value.TryGetValue<Color>("fibosColor", out var value3))
                {
                    fibosColor = value3;
                }

                if (value.TryGetValue<bool>("showPrevIntradayFibos", out var value4))
                {
                    showPrevIntradayFibos = value4;
                }

                if (value.TryGetValue<Color>("intradayFibosColor", out var value5))
                {
                    intradayFibosColor = value5;
                }

                if (value.TryGetValue<bool>("showtext", out var value6))
                {
                    showtext = value6;
                }

                if (value.TryGetValue<bool>("showIntradayFibos", out var value7))
                {
                    showIntradayFibos = value7;
                }

                if (value.TryGetValue<int>("lineWidth", out var value8))
                {
                    lineWidth = value8;
                }


                OnSettingsUpdated();
            }
        }


            public Indicator1()
            : base()
            {
                Name = "PriorDays";
                Description = "PriorDays";

                //// Defines line on demand with particular parameters.
                //AddLineSeries("day low", Color.CadetBlue, 1, LineStyle.Solid);
                //AddLineSeries("day high", Color.CadetBlue, 1, LineStyle.Solid);
                //AddLineSeries("prev low", Color.DarkRed, 1, LineStyle.Solid);
                //AddLineSeries("prev high", Color.DarkRed, 1, LineStyle.Solid);


                //AddLineSeries("Fibo 138%", Color.Green, 1, LineStyle.Solid);
                //AddLineSeries("Fibo 161%", Color.Green, 1, LineStyle.Solid);
                //AddLineSeries("Fibo 150%", Color.Green, 1, LineStyle.Solid);
                //AddLineSeries("Fibo 200%", Color.Green, 1, LineStyle.Solid);
                //AddLineSeries("Fibo", Color.Green, 1, LineStyle.Solid);



                // By default indicator will be applied on main window of the chart
                SeparateWindow = false;
            }

        private HistoricalData hdm;

        /// <summary>
        /// This function will be called after creating an indicator as well as after its input params reset or chart (symbol or timeframe) updates.
        /// </summary>
        protected override void OnInit()
        {
            

            this.hdm = this.Symbol.GetHistory(new Period(BasePeriod.Day, 1), Symbol.HistoryType, 3);

            //this.hdm.HistoryItemUpdated += this.Hdm_HistoryItemUpdated;

            //AddLineLevel(GetBar().Low, "Daily Low", Color.DarkBlue);
            //AddLineLevel(GetBar().High, "Daily High", Color.DarkBlue);

            //AddLineLevel(GetBar(1).Low, "Daily Low", Color.CadetBlue);
            //AddLineLevel(GetBar(1).High, "Daily High", Color.CadetBlue);

            //AddLineLevel((GetBar(1).High - GetBar(1).Low) * 1.618 + GetBar(1).Low, "fibo 38.2", Color.Green);
            //AddLineLevel((GetBar(1).High - GetBar(1).Low) * 1.382 + GetBar(1).Low, "fibo 61.8", Color.Green);
            //AddLineLevel((GetBar(1).High - GetBar(1).Low) * 1.5 + GetBar(1).Low, "fibo 150", Color.Green);

            


            
        }

        /// <summary>
        /// Calculation entry point. This function is called when a price data updates. 
        /// Will be runing under the HistoricalBar mode during history loading. 
        /// Under NewTick during realtime. 
        /// Under NewBar if start of the new bar is required.
        /// </summary>
        /// <param name="args">Provides data of updating reason and incoming price.</param>
        protected override void OnUpdate(UpdateArgs args)
        {

            //SetValue(GetBar().Low, 0);
            //SetValue(GetBar().High, 1);

            //SetValue(GetBar(1).Low, 2);
            //SetValue(GetBar(1).High, 3);

            // fibo 38.2
            //SetValue((GetBar(1).High - GetBar(1).Low) * 1.618 + GetBar(1).Low, 4);

            //// fibo 61.8
            //SetValue((GetBar(1).High - GetBar(1).Low) * 1.382 + GetBar(1).Low, 5);


            //// fibo 76.4
            ////SetValue((GetBar(1).High - GetBar(1).Low) * 1.236 + GetBar(1).Low, 6);

            //// fibo 23.6
            ////SetValue((GetBar(1).High - GetBar(1).Low) * 1.764 + GetBar(1).Low, 7);

            //// fibo 150
            //SetValue((GetBar(1).High - GetBar(1).Low) * 1.5 + GetBar(1).Low, 6);

            //// fibo 200
            //SetValue((GetBar(1).High - GetBar(1).Low) * 2 + GetBar(1).Low, 7);


            //var price = (GetBar(1).High - GetBar(1).Low) * 1.764 + GetBar(1).Low;
            //AddLineLevel(new LineLevel(price, "test", Color.White, LineStyle.Points));

            
        }

        public override void OnPaintChart(PaintChartEventArgs args)
        {
            IChartWindow chartWindow = base.CurrentChart.Windows[args.WindowIndex];
            //pointF.Y = (float)chartWindow.CoordinatesConverter.GetChartY(pivotPoint.value);

            //// Estilo de fuente y color
            //using var font = new Font("Arial", 12);
            //var brush = Brushes.Red;

            //// Texto a dibujar y coordenadas (x = pixel horizontal, y = vertical)
            


            var font = new Font("Arial", 9);
            var brush = textColor;

            var pointY = (float)chartWindow.CoordinatesConverter.GetChartY((GetBar().Low));

            if (showLowHighDay)
            {
                if (showtext) args.Graphics.DrawString($"Daily Low", font, brush, 10, pointY + 5);
                args.Graphics.DrawLine(new Pen(Color.LightGray), 0, pointY, 100, pointY);

                pointY = (float)chartWindow.CoordinatesConverter.GetChartY((GetBar().High));
                if (showtext) args.Graphics.DrawString($"Daily High", font, brush, 10, pointY + 5);
                args.Graphics.DrawLine(new Pen(Color.LightGray), 0, pointY, 100, pointY);
            }

            if (showPreviousLowHigh)
            {

                pointY = (float)chartWindow.CoordinatesConverter.GetChartY((GetBar(1).Low));
                if (showtext) args.Graphics.DrawString($"Previous Low", font, brush, 10, pointY + 5);
                args.Graphics.DrawLine(new Pen(Color.CadetBlue), 0, pointY, 100, pointY);


                pointY = (float)chartWindow.CoordinatesConverter.GetChartY((GetBar(1).High));
                if (showtext) args.Graphics.DrawString($"Previous High", font, brush, 10, pointY + 5);
                args.Graphics.DrawLine(new Pen(Color.CadetBlue), 0, pointY, 100, pointY);
            }

            var fibos_pen = new Pen(fibosColor);
            var fibos_font = new Font("Arial", 8);


            if (showPrevIntradayFibos)
            {
                var intraday_fibos_pen = new Pen(intradayFibosColor);
                var fibo61 = (GetBar(1).High - GetBar(1).Low) * 0.618 + GetBar(1).Low;
                var fibo50 = (GetBar(1).High - GetBar(1).Low) * 0.5 + GetBar(1).Low;
                var fibo38 = (GetBar(1).High - GetBar(1).Low) * 0.382 + GetBar(1).Low;
                

                pointY = (float)chartWindow.CoordinatesConverter.GetChartY(fibo61);
                if (showtext) args.Graphics.DrawString($"Fibo 61.8", fibos_font, brush, 40, pointY + 5);
                args.Graphics.DrawLine(intraday_fibos_pen, 0, pointY, lineWidth, pointY);

                pointY = (float)chartWindow.CoordinatesConverter.GetChartY(fibo50);
                if (showtext) args.Graphics.DrawString($"Fibo 50", fibos_font, brush, 40, pointY + 5);
                args.Graphics.DrawLine(intraday_fibos_pen, 0, pointY, lineWidth, pointY);

                pointY = (float)chartWindow.CoordinatesConverter.GetChartY(fibo38);
                if (showtext) args.Graphics.DrawString($"Fibo 38.2", fibos_font, brush, 40, pointY + 5);
                args.Graphics.DrawLine(intraday_fibos_pen, 0, pointY, lineWidth, pointY);

            }

            if (showIntradayFibos)
            {
                var intraday_fibos_pen = new Pen(intradayFibosColor);
                var fibo61 = (GetBar(0).High - GetBar(0).Low) * 0.618 + GetBar(0).Low;
                var fibo50 = (GetBar(0).High - GetBar(0).Low) * 0.5 + GetBar(0).Low;
                var fibo38 = (GetBar(0).High - GetBar(0).Low) * 0.382 + GetBar(0).Low;


                pointY = (float)chartWindow.CoordinatesConverter.GetChartY(fibo61);
                if (showtext) args.Graphics.DrawString($"Fibo 61.8", fibos_font, brush, 40, pointY + 5);
                args.Graphics.DrawLine(intraday_fibos_pen, 0, pointY, lineWidth, pointY);

                pointY = (float)chartWindow.CoordinatesConverter.GetChartY(fibo50);
                if (showtext) args.Graphics.DrawString($"Fibo 50", fibos_font, brush, 40, pointY + 5);
                args.Graphics.DrawLine(intraday_fibos_pen, 0, pointY, lineWidth, pointY);

                pointY = (float)chartWindow.CoordinatesConverter.GetChartY(fibo38);
                if (showtext) args.Graphics.DrawString($"Fibo 38.2", fibos_font, brush, 40, pointY + 5);
                args.Graphics.DrawLine(intraday_fibos_pen, 0, pointY, lineWidth, pointY);

            }


            var fibo161 = (GetBar(1).High - GetBar(1).Low) * 1.618 + GetBar(1).Low;
            var fibo138 = (GetBar(1).High - GetBar(1).Low) * 1.382 + GetBar(1).Low;
            var fibo150 = (GetBar(1).High - GetBar(1).Low) * 1.5 + GetBar(1).Low;
            var fibo200 = (GetBar(1).High - GetBar(1).Low) * 2 + GetBar(1).Low;

            

            pointY = (float)chartWindow.CoordinatesConverter.GetChartY(fibo138);
            if (showtext) args.Graphics.DrawString($"Fibo 38.2", fibos_font, brush, 30, pointY + 5);
            args.Graphics.DrawLine(fibos_pen, 0, pointY, lineWidth, pointY);

            pointY = (float)chartWindow.CoordinatesConverter.GetChartY(fibo161);
            if (showtext) args.Graphics.DrawString($"Fibo 61.8", fibos_font, brush, 30, pointY + 5);
            args.Graphics.DrawLine(fibos_pen, 0, pointY, lineWidth, pointY);

            pointY = (float)chartWindow.CoordinatesConverter.GetChartY(fibo150);
            if (showtext) args.Graphics.DrawString($"Fibo 50", fibos_font, brush, 30, pointY + 5);
            args.Graphics.DrawLine(fibos_pen, 0, pointY, lineWidth, pointY);

            pointY = (float)chartWindow.CoordinatesConverter.GetChartY(fibo200);
            if (showtext) args.Graphics.DrawString($"Fibo 100", fibos_font, brush, 30, pointY + 5);
            args.Graphics.DrawLine(fibos_pen, 0, pointY, lineWidth, pointY);



            //---

            var downfibo161 = ((GetBar(1).High - GetBar(1).Low) * 1.618 - GetBar(1).High) * -1;
            var downfibo138 = ((GetBar(1).High - GetBar(1).Low) * 1.382 - GetBar(1).High) * -1;
            var downfibo150 = ((GetBar(1).High - GetBar(1).Low) * 1.5 - GetBar(1).High) * -1;
            var downfibo200 = ((GetBar(1).High - GetBar(1).Low) * 2 - GetBar(1).High) * -1;


            //fibos_pen = new Pen(Color.DarkRed);

            pointY = (float)chartWindow.CoordinatesConverter.GetChartY(downfibo161);
            if (showtext) args.Graphics.DrawString($"Fibo 61.8", fibos_font, brush, 30, pointY + 5);
            args.Graphics.DrawLine(fibos_pen, 0, pointY, lineWidth, pointY);

            pointY = (float)chartWindow.CoordinatesConverter.GetChartY(downfibo138);
            if (showtext) args.Graphics.DrawString($"Fibo 38.2", fibos_font, brush, 30, pointY + 5);
            args.Graphics.DrawLine(fibos_pen, 0, pointY, lineWidth, pointY);

            pointY = (float)chartWindow.CoordinatesConverter.GetChartY(downfibo150);
            if (showtext) args.Graphics.DrawString($"Fibo 50", fibos_font, brush, 30, pointY + 5);
            args.Graphics.DrawLine(fibos_pen, 0, pointY, lineWidth, pointY);

            pointY = (float)chartWindow.CoordinatesConverter.GetChartY(downfibo200);
            if (showtext) args.Graphics.DrawString($"Fibo 100", fibos_font, brush, 30, pointY + 5);
            args.Graphics.DrawLine(fibos_pen, 0, pointY, lineWidth, pointY);


            //args.Graphics.DrawString(downfibo161.ToString(), new Font("Arial", 12), Brushes.DarkCyan, 100, 10);

            //args.Graphics.DrawIcon(new Icon("C:\\Users\\binary\\Desktop\\goku.ico"), 100, 500);

        }

        private HistoryItemBar GetBar(int index = 0) => ((HistoryItemBar)this.hdm[index]);
    }
}
