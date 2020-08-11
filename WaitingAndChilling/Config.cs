using Exiled.API.Interfaces;

namespace WaitingAndChilling
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
    }
}
