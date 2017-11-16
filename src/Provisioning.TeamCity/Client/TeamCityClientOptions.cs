using System;

namespace Provisioning.TeamCity.Client
{
    public class TeamCityClientOptions
    {
        public Uri ServerUri { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string DefaultAcceptHeaderValue { get; set; }

        public TeamCityClientOptions()
        {
            DefaultAcceptHeaderValue = "application/json";
        }
    }
}
