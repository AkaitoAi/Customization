using UnityEngine;

namespace AkaitoAi.Customization
{
    public abstract class Customization : MonoBehaviour
    {
        [SerializeField] private CustomizationType type;
        [SerializeField] private CustomizationSO customizationData;

        public CustomizationType Type => type;
        public CustomizationSO CustomizationData => customizationData;

        protected virtual bool CanCustomize()
        {
            if (customizationData == null) return false;

            if (customizationData.type != type) return false;

            return true;
        }

        protected virtual void Customize(int itemID)
        {

        }
    }
}