using PluginLoader;

var _pluginsPath = @"C:\temp\spacebattle_plugins";

var loader = new PluginLoader.PluginLoader(_pluginsPath);

Console.WriteLine("== Начало загрузки плагинов ==");
loader.Load();
Console.WriteLine("== Окончание загрузки плагинов ==");

