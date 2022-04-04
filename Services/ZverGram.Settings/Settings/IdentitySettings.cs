using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZverGram.Settings
{
    public class IdentitySettings : IIdentitySettings
    {
        private readonly ISettingsSource source;
        public IdentitySettings(ISettingsSource source) => this.source = source;

        public string Url => source.GetAsString("IdentityServer:Url");
        public string ClientId => source.GetAsString("IdentityServer:ClientId");
        public string ClientSecret => source.GetAsString("IdentityServer:ClientSecret");
        public bool RequireHttps => Url.ToLower().StartsWith("https://");
    }
}
