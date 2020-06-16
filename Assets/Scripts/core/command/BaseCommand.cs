using Zenject;

namespace game.core.command
{
    public abstract class BaseCommand
    {
        [Inject]
        protected SignalBus SignalBus;
    }
}