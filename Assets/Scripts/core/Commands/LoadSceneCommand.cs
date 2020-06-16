﻿using PG.Core.Generic;
using PG.Core.installer;
using Zenject;

namespace PG.Core.Commands
{
    public class LoadSceneCommand : BaseCommand
    {
        [Inject] private readonly ISceneLoader _sceneLoader;

        public void Execute(LoadSceneSignal loadParams)
        {
            _sceneLoader.LoadScene (loadParams.Scene).Done(
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
