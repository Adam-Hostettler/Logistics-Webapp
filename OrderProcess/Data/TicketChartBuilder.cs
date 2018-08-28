using System;
using System.Collections.Generic;
using System.Linq;
using OrderProcess.Domain;

namespace OrderProcess.Data
{
    /// <summary>
    /// Creates nested Lists of the tickets. Based on the tickets completeTime and the count of the tickets with that date.
    /// </summary>
    /// <param name="tickets">Comes from the Ticket table.</param>
    /// <returns></returns>
    public class TicketChartBuilder
    {
        public List<TicketChartData> BuildCompletedTicketsByDate(IEnumerable<TicketDTO> tickets)
        {
            List<TicketChartData> results = new List<TicketChartData>();
            var uniqueDates = tickets.Select(dates => dates.CompleteTime.Value.Date).Distinct();
            foreach (var date in uniqueDates)
            {
                var result = new TicketChartData();

                result.Date = date.ToShortDateString();
                foreach (var ticket in tickets)
                {
                    if (ticket.CompleteTime.Value.Date == date)
                    {
                        result.TicketsCompleted++;
                    }    
                }
                results.Add(result);
            }
            return results;
        }

        public List<TicketDurationChartData> BuildTicketDurationByDate(IEnumerable<TicketDTO> tickets)
        {
            List<TicketDurationChartData> results = new List<TicketDurationChartData>();
            var uniqueDates = tickets.Select(dates => dates.CompleteTime.Value.Date).Distinct();
            foreach (var date in uniqueDates)
            {
                var result = new TicketDurationChartData();
                List<double> durations = new List<double>();

                result.Date = date.ToShortDateString();
                foreach (var ticket in tickets)
                {
                    if (ticket.CompleteTime.Value.Date == date)
                    {
                        var durationinsec = ticket.CompleteTime - ticket.StartTime;
                        durations.Add(durationinsec.Value.TotalSeconds);
                    }
                }
                result.Duration = durations.Average();
                results.Add(result);
            }
            return results;
        }

        public List<TicketStatusChart> BuildTicketTodaybyStatus(IEnumerable<TicketDTO> tickets)
        {
            List<TicketStatusChart> results = new List<TicketStatusChart>();
            var uniqueStatus = tickets.Select(status => status.Status).Distinct();
            foreach (var status in uniqueStatus)
            {
                var result = new TicketStatusChart();
                result.TicketStatus = ((TicketStatus) status).ToString();

                foreach (var ticket in tickets)
                {
                    if (ticket.StartTime >= DateTime.Today)
                    {
                        if (ticket.Status == status)
                        {
                            result.NumberOfTickets++;
                        }
                    }
                }
                results.Add(result);
            }
            return results;
        }
    }

    public class TicketStatusChart
    {
        public int NumberOfTickets { get; set; }
        public string TicketStatus { get; set; }
    }

}