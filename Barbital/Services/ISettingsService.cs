namespace Barbital.Services
{
    public interface ISettingsService
    {
        object this[string PropertyName] { get; set; }
        object this[Setting PropertyName] { get; set; }

        void ResetConfig();
        void Save();
    }

    public enum Setting
    {
        RadioName,
        StreamUri,
        NewsfeedUri,
        ScheduleUri,
        AgreementsUri,
        ReportEmail,
        PhoneNumber,
        FacebookPageId
    }
}