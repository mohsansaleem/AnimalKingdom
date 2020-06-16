using UnityEngine;
using Zenject;
using RSG;
using System;

namespace PG.Core.installer
{
    public enum SceneType
    {
        Screen = 0,
        Popup = 1,
        HUD = 2,
        Loader = 3
    }

    public class CoreSceneInstaller : MonoInstaller
    {
        [SerializeField] public SceneType SceneType = SceneType.Screen;

        private Type _lastValidOpenState = null;
        public Type LastValidOpenState { get { return _lastValidOpenState; } }

        public override void InstallBindings()
        {
            Container.Bind<CoreSceneInstaller>().FromInstance(this);
        }

        public void OnNewValidOpenState(Type openState)
        {
            _lastValidOpenState = openState;
        }

        public virtual Type GetDefaultState()
        {
            return null;
        }

        public virtual IPromise Open()
        {
            Promise promise = new Promise();
            promise.Resolve();
            return promise;
        }

        public virtual IPromise Close()
        {
            Promise promise = new Promise();
            promise.Resolve();
            return promise;
        }

        public virtual void OnSceneWake()
        {

        }

        public virtual void OnSceneSleep()
        {
            
        }
    }
}
