# UptimeKumaAPI
Class: KumaAPIHub

# Initialization:
First you need to connect the library in the "Links". After you have attached it to the project. Initialize with
(where all libraries are connected)
`using UptimeKumaAPI;`

Next, we initialize the library as an object:
`KumaAPIHub hub = new KumaAPIHub("url");`

Example:
`var hub = new KumaAPIHub("https://uptime.unkov.cf/");`

# Functions in the library:
`string GetStatusPageConfig(string statusPage = "default")` - get status page config
`string GetStatusPageIncident(string statusPage = "default")` - get status page incident
`string GetStatusPagePublicGroupList(string statusPage = "default")` - get status page public group list
string GetMonitorsHearbeatList(string statusPage = "default") - get monitors hearbeat list
`string GetMonitorsUptimeList(string statusPage = "default")` - get monitors uptime list
`bool Push(string code, string status = "up", string msg = "OK", string ping = "")` - push the service
`string GetEntryPage()` - get entry page of the Uptime Kuma
`string GetStatusBadge(int monitor)` - get status badge of service
`string GetUptimeBadge(int monitor, int hours)` - get uptime badge of service
`string GetPingBadge(int monitor, int hours)` - get ping badge of service
