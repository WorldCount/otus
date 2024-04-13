namespace BasePlugin;

public interface IPlugin
{
    string PluginName { get; }
    
    void Load();
}