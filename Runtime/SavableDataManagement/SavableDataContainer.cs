using System.Linq;
using UnityEngine;

namespace SavableDataManagement
{
    [CreateAssetMenu(fileName = "SavableData", menuName = "GameData/SavableContainer", order = 30)]
    public class SavableDataContainer : SavableData
    {
        [SerializeField] private SavableData[] objectsToSave;
        
        public override void SaveToPlayerPrefs()
        {
            objectsToSave.ToList().ForEach(x => x.SaveToPlayerPrefs());
            base.SaveToPlayerPrefs();
        }
        
        public override void LoadFromPlayerPrefs()
        {
            objectsToSave.ToList().ForEach(x => x.LoadFromPlayerPrefs());
            base.LoadFromPlayerPrefs();
        }

        public override void ResetPlayerPrefs()
        {
            objectsToSave.ToList().ForEach(x => x.ResetPlayerPrefs());
            base.ResetPlayerPrefs();
        }
    }
}