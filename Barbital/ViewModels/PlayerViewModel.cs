using Barbital.Models;
using Barbital.Services;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Barbital.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class PlayerViewModel : BaseViewModel
    {
        private readonly INewsfeedService _newsfeedManager;
        private readonly ISettingsService _settingsService;

        public bool IsSheduleLoading { get; set; }
        public ScheduleModel IsNowItem { get; set; }

        public ObservableCollection<ScheduleModel> Schedule { get; private set; }
        //public DelegateCommand PlayCommand { get; private set; }

        public PlayerViewModel(INewsfeedService newsfeedService, ISettingsService settingsService)
        {
            _newsfeedManager = newsfeedService;
            _settingsService = settingsService;

            Schedule = new ObservableCollection<ScheduleModel>();

            PageTitle = _settingsService[Setting.RadioName].ToString();

            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await GetSheduleFeed();
            });
        }

        public async Task GetSheduleFeed()
        {
            IsSheduleLoading = true;

            IList<ScheduleModel> ScheduleList = await _newsfeedManager.LoadScheduleAsync(new Uri(_settingsService[Setting.ScheduleUri].ToString()));
            foreach (ScheduleModel schedule in ScheduleList)
            {
                Schedule.Add(schedule);
            }
            IsSheduleLoading = false;

            IsNowItem = GetIsNowItem(ScheduleList);
        }

        public ScheduleModel GetIsNowItem(IList<ScheduleModel> ScheduleList)
        {
            return ScheduleList.FirstOrDefault(x => x.IsNow);
        }
    }
}