namespace PluginBase
{
    public interface IPlugin
    {
        string Name { get; }
        void Run(IHost host);
    }
}
