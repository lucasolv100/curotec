using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace CuroTec.API.Hubs
{
    public class DashboardHub: Hub
{
    public async Task BroadcastUpdate(string data)
    {
        await Clients.All.SendAsync("ReceiveUpdate", data);
    }
}
}