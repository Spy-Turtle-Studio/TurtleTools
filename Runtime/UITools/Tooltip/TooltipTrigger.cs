using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UITools.Tooltip
{
    public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField]
        private string header;
        [SerializeField] [Multiline]
        private string content;

        private Coroutine _showing;
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            _showing = StartCoroutine(Show());
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (_showing != null) StopCoroutine(_showing);
            TooltipSystem.Hide();
        }

        private void OnMouseEnter()
        {
            _showing = StartCoroutine(Show());
        }

        private void OnMouseExit()
        {
            if (_showing != null) StopCoroutine(_showing);
            TooltipSystem.Hide();
        }

        private IEnumerator Show()
        {
            yield return new WaitForSeconds(.5f);
            TooltipSystem.Show(content, header);
        }
    }
}