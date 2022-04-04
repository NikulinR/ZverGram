
namespace ZverGram.Settings
{
    public interface ISettingsSource
    {
        string GetConnectionString(string source = null);
        string GetAsString(string source, string defaultValue = null);
        int GetAsInt(string source, int defaultValue = 0);
        bool GetAsBool(string source, bool defaultValue = false);
    }
}
