using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Nikotoh.DeveloperConsole
{

    public class SubmitButton : MonoBehaviour
    {
        [SerializeField] private Button button;

        // Start is called before the first frame update
        void Start()
        {
            if(TryGetComponent(out Button btn))
            {
                button = btn;
                button.onClick.AddListener(SubmitButtonClick);
            }
        }

        private  void OnDestroy()
        {
            if (button == null) return;

            button.onClick.RemoveAllListeners();
        }

        private void SubmitButtonClick()
        {
            //ConsoleEvents.InputFieldSubmit();
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}