using Barbital.Models;
using Barbital.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Barbital.ViewModels
{
    internal class PlayerViewModel : BaseViewModel
    {
        private bool _isLoading = true;
        private int _schedulePosition = 0;

        private readonly INewsfeedService _newsfeedManager;
        private readonly ISettingsService _settingsService;

        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        public int SchedulePosition
        {
            get => _schedulePosition;
            set => SetProperty(ref _schedulePosition, value);
        }

        public ObservableCollection<ScheduleModel> Schedule { get; private set; }
        //public DelegateCommand PlayCommand { get; private set; }

        public PlayerViewModel(INewsfeedService newsfeedService, ISettingsService settingsService)
        {
            _newsfeedManager = newsfeedService;
            _settingsService = settingsService;

            Schedule = new ObservableCollection<ScheduleModel>();

            PageTitle = _settingsService[Setting.RadioName].ToString();

            LoadFeed(settingsService);
        }

        public async void LoadFeed(ISettingsService settingsService)
        {
            foreach (ScheduleModel schedule in await _newsfeedManager.LoadScheduleAsync(new Uri(settingsService[Setting.ScheduleUri].ToString())))
            {
                SchedulePosition = schedule.IsNow ? schedule.ID : 0;
                Schedule.Add(schedule);
            }
            await Task.Delay(50);
            IsLoading = false;
        }
    }
}