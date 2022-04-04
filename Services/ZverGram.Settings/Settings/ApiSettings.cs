using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZverGram.Settings
{
    public class ApiSettings : IApiSettings
    {
        private readonly ISettingsSource source;
        private readonly IGeneralSettings generalSettings;
        private readonly IIdentitySettings identitySettings;
        private readonly IDbSettings dbSettings;

        public ApiSettings(ISettingsSource source)
        {
            this.source = source;
        }

        public ApiSettings(ISettingsSource source, IIdentitySettings identitySettings, IGeneralSettings generalSettings, IDbSettings dbSettings)
        {
            this.source = source;
            this.generalSettings = generalSettings;
            this.dbSettings = dbSettings;
            this.identitySettings = identitySettings;
        }

        public IGeneralSettings GeneralSettings => generalSettings ?? new GeneralSettings(source);
        public IIdentitySettings IdentityServer => identitySettings ?? new IdentitySettings(source);
        public IDbSettings DbSettings => dbSettings ?? new DbSettings(source);
    }
}
