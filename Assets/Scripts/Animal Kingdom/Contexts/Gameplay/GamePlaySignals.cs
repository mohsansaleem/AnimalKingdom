using PG.animalKingdom.model.remote;
using RSG;
using Zenject;

namespace PG.animalKingdom.installer
{
    public class ResetGameSignal { }
    public class GameTickSignal { }
    public class UnloadGroupSignal { }
    public class SpawnIfSpaceSignal { }
    
    public class AddAnimalToGroupSignal
    {
        public AnimalRemoteDataModel AnimalModel;
        public Promise OnAnimalAdded;

        public static Promise AddAnimal(SignalBus signalBus, AnimalRemoteDataModel animalModel)
        {
            AddAnimalToGroupSignal signal = new AddAnimalToGroupSignal
            {
                AnimalModel = animalModel, OnAnimalAdded = new Promise()
            };

            signalBus.Fire(signal);

            return signal.OnAnimalAdded;
        }
    }
}