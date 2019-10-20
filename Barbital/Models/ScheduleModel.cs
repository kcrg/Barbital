namespace Barbital.Models
{
    internal class ScheduleModel
    {
        public int ID { get; set; }
        public bool IsNow { get; set; }
        public string Title { get; set; }
        public string Time { get; set; }
    }
}