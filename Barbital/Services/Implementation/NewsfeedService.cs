using Barbital.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace Barbital.Services.Implementation
{
    internal class NewsfeedService : INewsfeedService
    {
        #region Schedule
        public async Task<IList<ScheduleModel>> LoadScheduleAsync(Uri URL)
        {
            HtmlDocument document = await new HtmlWeb().LoadFromWebAsync(URL.ToString());
            HtmlNodeCollection nodes = document?.DocumentNode.SelectNodes("//section[@class='av_textblock_section ']/div/table/tbody/tr");
            List<ScheduleModel> shedule = new List<ScheduleModel>();
            foreach (HtmlNode node in nodes)
            {
                shedule.Add(new ScheduleModel()
                {
                    Title = HttpUtility.HtmlDecode(node.SelectSingleNode("./td[@class='a3 tytul']").InnerText),
                    Time = DateTime.ParseExact(node.SelectSingleNode("./td[@class='a2 godzina']").InnerText, "HH:mm", null)
                });
            }

            return shedule;
        }
        #endregion
    }
}