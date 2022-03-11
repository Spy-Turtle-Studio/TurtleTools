using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace spyturtlestudio.tools.UITools
{
    public class TabGroup : MonoBehaviour
    {
        [SerializeField] private GameObject[] objectsToSwap;
    
        [SerializeField] private bool changeColor;
        [SerializeField] private Color hoverColor;
        [SerializeField] private Color selectedColor;
        [SerializeField] private Color idleColor;
    
        [SerializeField] private bool changeSprite;
        [SerializeField] private Sprite hoverSprite;
        [SerializeField] private Sprite selectedSprite;
        [SerializeField] private Sprite idleSprite;
    
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

            var index = button.transform.GetSiblingIndex();
            objectsToSwap
                .ToList()
                .ForEach(x => x.SetActive(x.transform.GetSiblingIndex() == index));
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
