using Prism;

namespace Barbital.Services.Implementation
{
    public class SettingsService : ISettingsService
    {
        public SettingsService()
        {
            //if (this["Initialized"] is false)
            //{
            ResetConfig();
            //}
        }

        public void ResetConfig()
        {
            this["RadioName"] = "placeholder radio name";

            this["StreamUri"] = "http://62.133.128.18:8040/";
            this["NewsfeedUri"] = "https://www.centrumxp.pl/feed.xml";
            this["ScheduleUri"] = "https://www.radiomaryja.pl/ramowka/";
            this["AgreementsUri"] = "https://radiovia.com.pl/o-nas/radio-via";
            this["ReportEmail"] = "kacper@tryniecki.com";
            this["PhoneNumber"] = "222222222";
            this["FacebookPageId"] = "390561431473804";

            this["Initialized"] = true;

            Save();
        }

        public object this[string PropertyName]
        {
            set => PrismApplicationBase.Current.Properties[PropertyName] = value;
            get
            {
                if (PrismApplicationBase.Current.Properties.ContainsKey(PropertyName))
                {
                    return PrismApplicationBase.Current.Properties[PropertyName];
                }
                else
                {
                    return false;
                }
            }
        }

        public object this[Setting PropertyName]
        {
            get => this[PropertyName.ToString()];
            set => this[PropertyName.ToString()] = value;
        }

        public async void Save()
        {
            await PrismApplicationBase.Current.SavePropertiesAsync();
        }
    }
}