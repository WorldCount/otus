using System.Collections.Concurrent;
using System.Reflection;
using BasePlugin;

namespace PluginLoader;

public class PluginLoader
{
    private readonly string _pluginExtension = "dll";
    private readonly string _pluginDirectory;
    
    public PluginLoader(string pluginDirectory)
    {
        if (string.IsNullOrWhiteSpace(pluginDirectory))
            throw new ArgumentNullException(nameof(pluginDirectory), "Укажите директорию плагина");

        if (!Directory.Exists(_pluginDirectory))
            Directory.CreateDirectory(pluginDirectory);

        _pluginDirectory = pluginDirectory;
    }

    public void Load()
    {
        var initQueue = InitPlugins();
        var loadPluginThead = new Thread(() => LoadPlugins(initQueue));
        
        loadPluginThead.Start();
        loadPluginThead.Join();
    }

    private string[] FindPlugins()
    {
        return Directory.GetFiles(_pluginDirectory, $"*.{_pluginExtension}", SearchOption.AllDirectories);
    }

    private ConcurrentQueue<IPlugin> InitPlugins()
    {
        var initQueue = new ConcurrentQueue<IPlugin>();
        var pluginPaths = FindPlugins();

        if (pluginPaths.Length == 0)
            Console.WriteLine($"Не обнаружены плагины в папке: '{_pluginDirectory}'");

        foreach (var pluginPath in pluginPaths)
        {
            try
            {
                var assembly = Assembly.LoadFrom(pluginPath);
                var type = assembly.GetTypes().FirstOrDefault(t => typeof(IPlugin).IsAssignableFrom(t));
                
                if(type == null)
                    continue;

                if (Activator.CreateInstance(type) is IPlugin pluginInstance)
                {
                    initQueue.Enqueue(pluginInstance);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка при загрузке {pluginPath}: {e.Message}");
                continue;
            }
        }
        
        return initQueue;
    }

    private void LoadPlugins(ConcurrentQueue<IPlugin> initQueue)
    {
        var reloadQueue = new ConcurrentQueue<IPlugin>();

        while (initQueue.Count > 0)
        {
            var count = initQueue.Count;
            
            while (initQueue.TryDequeue(out var plugin))
            {
                try
                {
                    plugin.Load();
                }
                catch
                {
                    Console.WriteLine($"[-] Ошибка при загрузке плагина: {plugin.PluginName}");
                    reloadQueue.Enqueue(plugin);
                }
            }

            if (count == reloadQueue.Count)
                return;

            if (reloadQueue.Any())
            {
                initQueue = reloadQueue;
                reloadQueue = new ConcurrentQueue<IPlugin>();
            }
        }
    }
}