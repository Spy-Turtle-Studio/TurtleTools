using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Unity.Linq;

namespace UITools
{
    public class PanelGroup : MonoBehaviour
    {
        private List<GameObject> _panels;

        private GameObject _activePanel;

        public void ActivatePanel(int index)
        {
            if (_activePanel != null) _activePanel.SetActive(false);
            _activePanel = _panels[index];
            _activePanel.SetActive(true);
        }
        
        private void Awake()
        {
            _panels = transform.gameObject.Children().ToList();
            _panels.ForEach(panel => panel.SetActive(false));
        }
    }
}