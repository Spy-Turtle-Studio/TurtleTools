using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ScreenDebug
{
    public class DebugManager : MonoBehaviour
    {
        [SerializeField] 
        private FPSCounter fpsCounter;
        
        private DebugControls _debugControls;

        private void Awake()
        {
            _debugControls = new DebugControls();
            
            if (!(fpsCounter == null))
            {
                _debugControls.Debug.FPS.performed += ToggleFPS;
                fpsCounter.gameObject.SetActive(Application.isEditor);
            }
            
            _debugControls.Debug.Enable();
            DontDestroyOnLoad(this);
        }

        private void ToggleFPS(InputAction.CallbackContext context) => 
            fpsCounter.gameObject.SetActive(!fpsCounter.gameObject.activeSelf);
    }
}