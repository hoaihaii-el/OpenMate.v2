using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using OpenMate.Work.Model;
using OpenMate.Work.Resources.Uitilities;
using System.Collections.ObjectModel;

namespace OpenMate.Work.ViewModel.Boards
{
    public partial class BoardVM : BaseViewModel
    {
        private Sprint _SelectedSprint;
        public Sprint SelectedSprint
        {
            get => _SelectedSprint;
            set => SetProperty(ref _SelectedSprint, value);
        }

        private SeriesCollection _StoryPointSeries;
        public SeriesCollection StoryPointSeries
        {
            get => _StoryPointSeries;
            set => SetProperty(ref _StoryPointSeries, value);
        }

        private SeriesCollection _DefectSeries;
        public SeriesCollection DefectSeries
        {
            get => _DefectSeries;
            set => SetProperty(ref _DefectSeries, value);
        }

        private ObservableCollection<string> _SprintLabels;
        public ObservableCollection<string> SprintLabels
        {
            get => _SprintLabels;
            set => SetProperty(ref _SprintLabels, value);
        }

        public void LoadStoryPointStatistics()
        {
            SprintLabels = new ObservableCollection<string>()
            {
                "Sprint 1",
                "Sprint 2",
                "Sprint 3",
                "Sprint 4",
            };
            StoryPointSeries = new SeriesCollection()
            {
                new ColumnSeries
                {
                    Title = "Story Points",
                    Values = new ChartValues<int> {30, 34, 36, 37}
                }
            };

            DefectSeries = new SeriesCollection()
            {
                new PieSeries()
                {
                    Title = "Hoai Hai",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(2) },
                    DataLabels = true
                },
                new PieSeries()
                {
                    Title = "Hoai Nhan",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(4) },
                    DataLabels = true
                },
                new PieSeries()
                {
                    Title = "Minh Ngoc",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(4) },
                    DataLabels = true
                },
            };
        }
    }
}
