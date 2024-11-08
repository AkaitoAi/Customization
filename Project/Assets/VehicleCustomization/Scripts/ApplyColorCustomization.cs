using UnityEngine;

namespace AkaitoAi.Customization
{
    public class ApplyColorCustomization : Customization
    {
        [SerializeField] private MeshRenderer[] meshRenderers;
        [SerializeField] private Color[] colors;
        
        protected override void Customize(int itemID)
        {
            if (!CanCustomize()) return;

            base.Customize(itemID);

            if(meshRenderers == null || colors == null)
            {
                Debug.Log("MeshRenderers or colors not set.");
                return;
            }

            if (itemID >= CustomizationData.Status.Length
                || itemID < 0)
            {
                Debug.Log("itemID is out of range.");

                return;
            }

            //colors = new Color[CustomizationData.status.Length];
            
            foreach(MeshRenderer meshRenderer in meshRenderers)
            {
                meshRenderer.material.color = colors[itemID];
            }
        }
        
        private void OnEnable()
        {
            CustomizationData.Actions.OnItemIDChanged += Customize;
        }

        private void OnDisable()
        {
            CustomizationData.Actions.OnItemIDChanged -= Customize;
        }
    }
}
