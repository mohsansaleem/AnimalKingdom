using PG.Core.installer;
using Zenject;

namespace PG.Core.Commands
{
    public class UnloadSceneCommand : BaseCommand
    {
        [Inject] private readonly ISceneLoader _sceneLoader;

        public void Execute(UnloadSceneSignal loadParams)
        {
            _sceneLoader.UnloadScene (loadParams.Scene).Done (
                () =>
                {
                    if (loadParams.OnComplete != null)
                    {
                        loadParams.OnComplete.Resolve();
                    }
                },
                exception =>
                {
                    if (loadParams.OnComplete != null)
                    {
                        loadParams.OnComplete.Reject(exception);
                    }
                }
            );
        }
    }
}
