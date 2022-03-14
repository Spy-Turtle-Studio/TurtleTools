using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace UITools.Tooltip
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(RectTransform))]
    public class Tooltip : MonoBehaviour
    {
        [SerializeField] 
        private TextMeshProUGUI headerField;

        [SerializeField] 
        private TextMeshProUGUI contentField;

        [SerializeField] 
        private LayoutElement layoutElement;

        [SerializeField] 
        private int characterWrapLimit;

        private RectTransform _rectTransform;
        
        public void SetText(string content, string header = "")
        {
            contentField.text = content;
            headerField.text = header;
            headerField.gameObject.SetActive(!string.IsNullOrEmpty(header));
            
            var headerLength = headerField.text.Length;
            var contentLength = contentField.text.Length;

            layoutElement.enabled = headerLength > characterWrapLimit || contentLength > characterWrapLimit;
        }

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }
        
        private void Update()
        {
#if (UNITY_EDITOR)
            var headerLength = headerField.text.Length;
            var contentLength = contentField.text.Length;

            layoutElement.enabled = headerLength > characterWrapLimit || contentLength > characterWrapLimit;
#endif
            var position = Mouse.current.position.ReadValue();
            var pivotX = position.x / Screen.width;
            var pivotY = position.y / Screen.height;
            _rectTransform.pivot = new Vector2(pivotX, pivotY);
            transform.position = position;
        }
  
    }
}