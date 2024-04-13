using BasePlugin;

namespace SpacebattleMoreShipsPlugin;

public class MoreShipsPlugin : IPlugin
{
    public string PluginName => "More Ships Plugin v0.2";
    
    public void Load()
    {
        Console.WriteLine($"{PluginName} загружен.");
    }
}