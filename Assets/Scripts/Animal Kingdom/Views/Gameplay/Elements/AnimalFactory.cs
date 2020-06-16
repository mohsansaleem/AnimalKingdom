using PG.animalKingdom.installer;
using PG.AnimalKingdom.Installer;
using UnityEngine;
using Zenject;
using RSG;

namespace pg.core.assets
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
