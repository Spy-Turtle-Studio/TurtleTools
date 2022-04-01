using System.Linq;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ScreenDebug
{
    [RequireComponent(typeof(TMP_Text))]
    public class FPSCounter : MonoBehaviour
    {
        [SerializeField, Range(0, 10)] 
        private float updateFrequency = 0.2f;
    
        private TMP_Text _text;

        private int _lastFrameIndex;
        private float[] _frameDeltaTimes;

        private float _lastUpdateTime;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
            _frameDeltaTimes = new float[50];
            _lastFrameIndex = 0;
            _lastUpdateTime = 0;
        }

        private void Update()
        {
            _frameDeltaTimes[_lastFrameIndex] = 1f / Time.deltaTime;
            _lastFrameIndex = (_lastFrameIndex + 1) % _frameDeltaTimes.Length;

            if (!(Time.realtimeSinceStartup - _lastUpdateTime > updateFrequency)) return;
            _text.text = ((int) math.round(_frameDeltaTimes.Average())).ToString();
            _lastUpdateTime = Time.realtimeSinceStartup;
        }
    }
}
