using DashboardDemo.AttachedProperties;
using DashboardDemo.Enums;
using DashboardDemo.ViewModels;
using Microcharts;

namespace DashboardDemo.Views;

public partial class DashboardView : ContentPage
{
    DashboardViewModel _viewModel;
    public DashboardView(DashboardViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        chartView.Chart = new BarChart
        {
            Entries = _viewModel.Entries,
            LabelTextSize = 30,
            ValueLabelTextSize = 35,
            ValueLabelOption = ValueLabelOption.TopOfElement
        };

        var role = UserRole.User;

        foreach (var child in MainLayout.Children)
        {
            var view = (View)child;
            var viewRole =
                RoleManager.GetVisibility(view);

            switch (role)
            {
                case UserRole.User:
                    view.IsVisible = viewRole == UserRole.User;
                    break;
                case UserRole.Admin:
                    view.IsVisible = true;
                    break;
            }
        }

    }
}