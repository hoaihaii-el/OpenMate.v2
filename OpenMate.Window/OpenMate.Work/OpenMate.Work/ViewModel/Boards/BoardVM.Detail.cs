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

        public async void LoadStoryPointStatistics(Sprint spr)
        {
            try
            {
                var stats = await projectService.GetSprintStats(spr.Id);
                SprintLabels = new ObservableCollection<string>();
                StoryPointSeries = new SeriesCollection();
                DefectSeries = new SeriesCollection();

                for (int i = 1; i <= spr.Order; i++)
                {
                    SprintLabels.Add($"Sprint {i}");
                }

                StoryPointSeries.Add(new ColumnSeries
                {
                    Title = "Story Points",
                    Values = new ChartValues<int>(stats.StoryPoints)
                });

                foreach (var val in stats.Defects)
                {
                    DefectSeries.Add(new PieSeries()
                    {
                        Title = val.Item1,
                        Values = new ChartValues<ObservableValue> { new ObservableValue(val.Item2) },
                        DataLabels = true
                    });
                }
            }
            catch
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
                        Title = "Hoài Hải",
                        Values = new ChartValues<ObservableValue> { new ObservableValue(2) },
                        DataLabels = true
                    },
                    new PieSeries()
                    {
                        Title = "Hoài Nhân",
                        Values = new ChartValues<ObservableValue> { new ObservableValue(4) },
                        DataLabels = true
                    },
                    new PieSeries()
                    {
                        Title = "Minh Ngọc",
                        Values = new ChartValues<ObservableValue> { new ObservableValue(4) },
                        DataLabels = true
                    },
                };
            }
        }
    }
}
