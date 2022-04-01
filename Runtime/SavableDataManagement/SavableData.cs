using UnityEngine;
using UnityEngine.Events;

namespace SavableDataManagement
{
    public abstract class SavableData : ScriptableObject
    {
        [SerializeField]
        protected string playerPrefsKey;

        protected UnityAction SaveCallback;
        protected UnityAction LoadCallback;
        protected UnityAction ResetCallback;

        public virtual void SaveToPlayerPrefs()
        {
            var jsonString = JsonUtility.ToJson(this);
            PlayerPrefs.SetString(playerPrefsKey, jsonString);
        }
        
        public virtual void LoadFromPlayerPrefs()
        {
            if (playerPrefsKey == null || !PlayerPrefs.HasKey(playerPrefsKey)) return;
            var jsonString = PlayerPrefs.GetString(playerPrefsKey);
            JsonUtility.FromJsonOverwrite(jsonString, this);
            LoadCallback?.Invoke();
        }

        public virtual void ResetPlayerPrefs()
        {
            if (playerPrefsKey == null || !PlayerPrefs.HasKey(playerPrefsKey)) return;
            PlayerPrefs.DeleteKey(playerPrefsKey);
        }
    }
}