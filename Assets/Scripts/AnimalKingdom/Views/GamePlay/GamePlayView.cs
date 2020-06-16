using System;
using UnityEngine;
using UnityEngine.UI;

namespace PG.AnimalKingdom.Views.GamePlay
{
    public class GamePlayView : MonoBehaviour
    {
        [Header("References")] public Transform AnimalsRoot;
        public Button BackButton;

        public Action<Vector3> OnMouseDownEvent;
        public Action<float> OnScroll;
        
        private float _scroll = 0.0f;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnMouseDownEvent?.Invoke(Input.mousePosition);
            }

            if ((_scroll = Input.GetAxis("Mouse ScrollWheel")) != 0f)
            {
                OnScroll?.Invoke(_scroll);
            }
        }

        private void OnMouseDown(Vector3 pos)
        {
            Debug.Log("View Click");
            OnMouseDownEvent?.Invoke(pos);
        }


        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}