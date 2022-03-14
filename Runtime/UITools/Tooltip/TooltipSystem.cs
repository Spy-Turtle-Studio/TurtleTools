using System;
using System.Linq;
using System.Security.Cryptography;
using Unity.Linq;
using UnityEngine;

namespace UITools.Tooltip
{
    public class TooltipSystem : MonoBehaviour
    {
        private static TooltipSystem _current;
        private Tooltip _tooltip;
        
        public void Awake()
        {
            if (_current == null)
            {
                _tooltip = gameObject.Children().First().GetComponent<Tooltip>();
                _current = this;
            }
            else
                Destroy(gameObject);
        }

        public static void Show(string content, string header = "")
        {
            if (_current == null) return;
            _current._tooltip.SetText(content, header);
            _current._tooltip.gameObject.SetActive(true);
        }

        public static void Hide()
        {
            if (_current == null) return;
            _current._tooltip.gameObject.SetActive(false);
        }
    }
}