using BasePlugin;

namespace SpacebattleMoreArmsPlugin;

public class MoreArms : IPlugin
{
    public string PluginName => "More Arms v1.0";
    
    public void Load()
    {
        Console.WriteLine($"{PluginName} загружен.");
    }
}