using UnityEditor;
using UnityEngine;

namespace Code
{
    [CustomEditor(typeof(ProductHelper))]
    public sealed class ProductHelperEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            var lessonHelper = (ProductHelper) target;
            
            if (GUILayout.Button("BuyProduct"))
            {
                lessonHelper.BuyProduct();
            }
            
            if (GUILayout.Button("ShowPopup"))
            {
                lessonHelper.ShowPopup();
            }
            
            if (GUILayout.Button("ShowShopPopup"))
            {
                lessonHelper.ShowShopPopup();
            }
        }
    }
}
