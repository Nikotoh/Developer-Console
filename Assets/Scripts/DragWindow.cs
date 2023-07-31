using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Nikotoh.DeveloperConsole
{
    
    // Provided by CodeMonkey https://www.youtube.com/watch?v=Mb2oua3FjZg&ab_channel=CodeMonkey 
    public class DragWindow : MonoBehaviour, IDragHandler
    {
        [SerializeField] private RectTransform dragRectTransform;
        [SerializeField] private Canvas canvas;

        private void Awake()
        {
            // If dragRectTransform is not set in Unity Editor, this will automatically get it.
            if(dragRectTransform == null)
            {
                dragRectTransform = transform.parent.GetComponent<RectTransform>();
            }

            // If canvas is not set in Unity Editor, this will automatically get it.
            if (canvas == null)
            {
                Transform testCanvasTransform = transform.parent;
                while(testCanvasTransform != null)
                {
                    canvas = testCanvasTransform.GetComponent<Canvas>();
                    if(canvas != null)
                    {
                        break;
                    }
                    testCanvasTransform = testCanvasTransform.parent;
                }
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            dragRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }
}
