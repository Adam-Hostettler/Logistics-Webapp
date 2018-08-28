using System;

namespace OrderProcess.Data
{
    /// <summary>
    /// Holds the properies needed for charting number of tickets completed by date.
    /// </summary>
    public class TicketChartData
    {
        public string Date { get; set; }
        public int TicketsCompleted { get; set; }
    }
}