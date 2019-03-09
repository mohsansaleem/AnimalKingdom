using game.animalKingdom.installer;
using RSG;

namespace pg.core.assets
{
    public class AnimalPool : KeyedAsyncGenericMonoMemoryPool<AnimalPrefab, FactoryObjectParams, FactoryObject>
    {
        protected override void Reinitialize<T>(FactoryObjectParams assetParams, FactoryObject item, Promise<T> assetReadyPromise)
        {
            item.Reinitialize(assetParams, assetReadyPromise);
        }

        protected override void OnCreated(AnimalPrefab key, FactoryObject item)
        {
            base.OnCreated(key, item);

            item.OnCreated();
        }

        protected override void OnSpawned(AnimalPrefab key, FactoryObject item)
        {
            base.OnSpawned(key, item);
            item.OnSpawned();
        }

        protected override void OnDespawned(AnimalPrefab key, FactoryObject item)
        {
            base.OnDespawned(key, item);

            item.OnDespawned();
        }
    }
}
