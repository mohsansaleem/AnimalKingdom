using PG.AnimalKingdom.Installer;
using PG.Core.Generic.PoolFactory;
using RSG;
using UnityEngine;
using Zenject;

namespace PG.AnimalKingdom.Views.GamePlay
{
    public class AnimalFactory : IAsyncGenericAssetFactory<AnimalPrefab, FactoryObject>
    {
        private readonly DiContainer _container;
        
        public AnimalFactory(DiContainer container)
        {
            _container = container;
        }
        
        public IPromise<T> Create<T>(AnimalPrefab prefabData) where T : FactoryObject
        {
            Promise<T> createAssetPromise = new Promise<T>();
            GameObject instance = _container.InstantiatePrefab(prefabData.Prefab);
            T factoryObject = instance.GetComponent<T>() ?? _container.InstantiateComponent<T>(instance);
            createAssetPromise.Resolve(factoryObject);
            return createAssetPromise;
        }
    }
}
