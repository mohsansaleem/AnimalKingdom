using Zenject;

namespace PG.Core.Commands
{
    public abstract class BaseCommand
    {
        [Inject]
        protected SignalBus SignalBus;
    }
}