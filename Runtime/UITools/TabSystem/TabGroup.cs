using System;
using System.Collections.Generic;
using System.Linq;
using spyturtlestudio.tools.Editor.CustomInspector;
using UnityEngine;

namespace UITools
{
    public class TabGroup : MonoBehaviour
    {
        [SerializeField] private PanelGroup panelsToSwap;
        
        [Space]
        [SerializeField] 
        private bool changeColor;
        [SerializeField] 
        [ConditionalHide("changeColor")] 
        private Color hoverColor;
        [SerializeField] 
        [ConditionalHide("changeColor")] 
        private Color selectedColor;
        [SerializeField] 
        [ConditionalHide("changeColor")] 
        private Color idleColor;
        
        [Space]
        [SerializeField] 
        private bool changeSprite;
        [SerializeField] 
        [ConditionalHide("changeSprite")] 
        private Sprite hoverSprite;
        [SerializeField] 
        [ConditionalHide("changeSprite")] 
        private Sprite selectedSprite;
        [SerializeField] 
        [ConditionalHide("changeSprite")] 
        private Sprite idleSprite;
    
        private List<TabButton> _tabButtons;
        private TabButton _selectedTab;

        public TabGroup Subscribe(TabButton button)
        {
            _tabButtons ??= new List<TabButton>();
            _tabButtons.Add(button);
            return this;
        }

        public void OnTabEnter(TabButton button)
        {
            ResetTabs();
            if (_selectedTab != null && button == _selectedTab) return;
            if (changeColor) button.Background.color = hoverColor;
            if (changeSprite) button.Background.sprite = hoverSprite;
        }
    
        public void OnTabExit(TabButton button)
        {
            ResetTabs();
        }
    
        public void OnTabSelected(TabButton button)
        {
            _selectedTab = button;
            ResetTabs();
            if (changeColor) button.Background.color = selectedColor;
            if (changeSprite) button.Background.sprite = selectedSprite;
            
            panelsToSwap.ActivatePanel(button.transform.GetSiblingIndex());
        }

        private void Start()
        {
            _tabButtons
                .Where(button => button.transform.GetSiblingIndex() == 0)
                .ToList()
                .ForEach(OnTabSelected);
        }

        private void ResetTabs()
        {
            _tabButtons
                .Where(button => changeColor)
                .Where(button => _selectedTab == null || button != _selectedTab)
                .ToList()
                .ForEach(x => x.Background.color = idleColor);
            _tabButtons
                .Where(button => changeSprite)
                .Where(button => _selectedTab == null || button != _selectedTab)
                .ToList()
                .ForEach(x => x.Background.sprite = idleSprite);
        }
    }
}
