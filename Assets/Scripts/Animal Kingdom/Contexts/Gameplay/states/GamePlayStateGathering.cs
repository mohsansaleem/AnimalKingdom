using PG.animalKingdom.model.scene;
using UniRx;
using UnityEngine;

namespace PG.animalKingdom.view
{
    public partial class GamePlayMediator
    {
        public class GamePlayStateGathering : GamePlayState
        {
            public GamePlayStateGathering(GamePlayMediator mediator) : base(mediator)
            {
            }

            public override void OnStateEnter()
            {
                base.OnStateEnter();

                View.OnMouseDownEvent += OnMouseDown;
                View.OnScroll += OnScroll;

                Mediator._hero.OnAnimalEnter += OnAnimalEnter;
                Mediator._hero.OnAnimalExit += OnAnimalExit;

                Mediator._hero.OnPenEnter += OnPenEnter;

                RemoteDataModel.HeroModel.SpeedBoost.Subscribe((s) =>
                    {
                        if (s > 0)
                        {
                            Mediator.CalculateSpeedAndMove();
                        }
                    })
                    .AddTo(Disposables);
            }

            private void OnPenEnter()
            {
                GamePlayModel.GamePlayState.Value = model.scene.GamePlayModel.EGamePlayState.Unloading;
            }

            private void OnAnimalExit(AnimalView obj)
            {
                // TODO: MS: Handle the case of Scatering when there is hurdle in the path.
            }

            private void OnAnimalEnter(AnimalView obj)
            {
                Mediator.AddAnimalToGroup(obj);
            }

            private void OnMouseDown(Vector3 position)
            {
                Ray ray = Mediator._camera.ScreenPointToRay(position);

                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Mediator._destination = hit.point;

                    Mediator.CalculateSpeedAndMove();
                }
            }


            private void OnScroll(float f)
            {
                Mediator._camera.transform.LookAt(GameObject.Find("Hero").transform);

                Mediator._camera.transform.position =
                    Mediator._camera.transform.position + Mediator._camera.transform.forward * f;

                Debug.LogError("Scroll: " + f);
            }
        }
    }
}