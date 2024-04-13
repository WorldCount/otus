using BasePlugin;

namespace FirstLoadPlugin;

public class FirstLoadPlugin : IPlugin
{
    public string PluginName => "First Load Plugin";
    public void Load()
    {
        throw new NotImplementedException();
    }
}