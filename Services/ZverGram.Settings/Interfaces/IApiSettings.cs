namespace ZverGram.Settings
{
    public interface IApiSettings
    {
        IGeneralSettings GeneralSettings { get; }
        IIdentitySettings IdentityServer{ get; }
        IDbSettings DbSettings { get; }
    }
}
