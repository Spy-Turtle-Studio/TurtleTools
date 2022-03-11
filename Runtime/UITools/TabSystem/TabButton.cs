using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UITools
{
    [RequireComponent(typeof(Image))]
    public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
    {
        private TabGroup _tabGroup;
        public Image Background { get; private set; }

        private void Start()
        {
            Background = GetComponent<Image>();
            _tabGroup = transform.GetComponentInParent<TabGroup>().Subscribe(this);
        }

        public void OnPointerEnter(PointerEventData eventData) => _tabGroup.OnTabEnter(this);

        public void OnPointerClick(PointerEventData eventData) => _tabGroup.OnTabSelected(this);

        public void OnPointerExit(PointerEventData eventData) => _tabGroup.OnTabExit(this);
    }
}
