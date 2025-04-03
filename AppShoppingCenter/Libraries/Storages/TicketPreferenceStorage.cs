using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AppShoppingCenter.Models;

namespace AppShoppingCenter.Libraries.Storages
{
    public class TicketPreferenceStorage
    {
        private readonly string key = "tickets";
        public void Save(Ticket ticket)
        {
            List<Ticket> tickets;
            if (Preferences.Default.ContainsKey(key))
            {
                var ticketsSrt = Preferences.Default.Get<string>(key, default);
                tickets = JsonSerializer.Deserialize<List<Ticket>>(ticketsSrt);
            }
            else
            {
                tickets = [];
            }

            tickets.Add(ticket);
            Preferences.Clear();
            Preferences.Default.Set(key, JsonSerializer.Serialize(tickets));
        }

        public List<Ticket> Load()
        {
            if (Preferences.Default.ContainsKey(key))
            {
                var ticketsSrt = Preferences.Default.Get<string>(key, default);
                var tickets = JsonSerializer.Deserialize<List<Ticket>>(ticketsSrt);
                return tickets;
            }
            else
            {
                return [];
            }
        }
    }
}
