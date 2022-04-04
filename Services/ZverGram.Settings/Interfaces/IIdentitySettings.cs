using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZverGram.Settings
{
    public interface IIdentitySettings
    {
        string Url { get; }
        string ClientId { get; }
        string ClientSecret { get; }
        bool RequireHttps { get; }
    }
}
