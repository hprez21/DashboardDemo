using CommunityToolkit.Mvvm.ComponentModel;
using DashboardDemo.Models;
using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashboardDemo.ViewModels
{
    public partial class DashboardViewModel : ObservableObject
    {
        [ObservableProperty]
        List<ChartEntry> entries =
            new List<ChartEntry>();

        List<DailySales> sales;

        public DashboardViewModel()
        {
            LoadData();
            CreateChartData();
        }

        private void CreateChartData()
        {
            foreach(var sale in sales)
            {
                var total =
                    (float)sale.Total;

                Entries.Add(new ChartEntry(total)
                {
                    Label = sale.Date.ToString("dd MMM"),
                    ValueLabel = FormatValueLabel(total),
                    Color = SKColor.Parse(CalculateColor(sales, total))
                });
            }
        }

        private string FormatValueLabel(float value)
        {
            if(value >= 100)
            {
                return $"${value / 1000:F1}k";
            }
            return $"${value:F0}";
        }

        private string CalculateColor(List<DailySales> sales, float total)
        {
            float minTotal =
                (float)sales.Min(s => s.Total);
            float maxTotal =
                (float)sales.Max(s => s.Total);

            if(minTotal == maxTotal)
            {
                return "#90EE90";
            }

            float normalizedValue =
                (total - minTotal) / (maxTotal - minTotal);

            var lightGreen = (R: 144, G: 238, B: 144);
            var darkGreen = (R: 0, G: 100, B: 0);

            var currentGreen = (
                 R: (byte)(lightGreen.R + (darkGreen.R - lightGreen.R) * normalizedValue),
                 G: (byte)(lightGreen.G + (darkGreen.G - lightGreen.G) * normalizedValue),
                 B: (byte)(lightGreen.B + (darkGreen.B - lightGreen.B) * normalizedValue)
                );

            string colorHex =
                $"#{currentGreen.R:X2}{currentGreen.G:X2}{currentGreen.B:X2}";
            return colorHex;
        }

        private void LoadData()
        {
            sales = new List<DailySales>
            {
                new DailySales { Date = new DateTime(2030, 6, 10), Total = 1048 },
                new DailySales { Date = new DateTime(2030, 6, 11), Total = 982 },
                new DailySales { Date = new DateTime(2030, 6, 12), Total = 1348 },
                new DailySales { Date = new DateTime(2030, 6, 13), Total = 570 },
                new DailySales { Date = new DateTime(2030, 6, 14), Total = 792 },
                new DailySales { Date = new DateTime(2030, 6, 15), Total = 821 },
                new DailySales { Date = new DateTime(2030, 6, 16), Total = 1365 },
                new DailySales { Date = new DateTime(2030, 6, 17), Total = 168 },
                new DailySales { Date = new DateTime(2030, 6, 18), Total = 654 },
                new DailySales { Date = new DateTime(2030, 6, 19), Total = 2504 },
            };

        }
    }
}
