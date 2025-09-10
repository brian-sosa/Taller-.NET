using Microsoft.AspNetCore.SignalR;


    public class LoginHub: Hub
    {
        
        public async Task Redireccionar()
        {
            await Clients.All.SendAsync("Redirect");
        }
    }

