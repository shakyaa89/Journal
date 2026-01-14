using Journal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Journal.Services
{
    public interface IAnalyticsService
    {
        Dictionary<string, double> GetMoodDistribution(List<JournalEntry> entries);
    }
}
