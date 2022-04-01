using System.Linq;
using UnityEngine;

namespace SavableDataManagement
{
    public class SavableDataHandler : MonoBehaviour
    {
        [SerializeField] 
        private SavableData[] objectsToSave;

        [SerializeField] 
        private SavableData[] objectsToLoad;

        [SerializeField] 
        private SavableData[] objectsToDelete;
        
        public void AddObjectToDelete(SavableData savableData)
        {
            objectsToDelete ??= new SavableData[0];
            objectsToDelete.ToList().Add(savableData);
        }

        protected void ManageData()
        {
            objectsToSave?.ToList().ForEach(x => x.SaveToPlayerPrefs());
            objectsToLoad?.ToList().ForEach(x => x.LoadFromPlayerPrefs());
            objectsToDelete?.ToList().ForEach(x => x.ResetPlayerPrefs());
        }
    }
}