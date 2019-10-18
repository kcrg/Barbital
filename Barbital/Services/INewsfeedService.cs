using Barbital.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Barbital.Services
{
    internal interface INewsfeedService
    {
        Task<IList<ScheduleModel>> LoadScheduleAsync(Uri URL);
    }
}