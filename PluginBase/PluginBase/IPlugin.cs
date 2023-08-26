namespace PluginBase
{
    public interface IPlugin
    {
        string ShowName { get; }
        void Run(IHost host);
    }
}
