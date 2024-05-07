using _Game.Scripts.Database;
using _Game.Scripts.ScriptableObjects.Items;
using Sirenix.OdinInspector.Editor;
using UnityEditor;

namespace _Game.Editors
{
    public class DataEditor : OdinMenuEditorWindow
    {
        [MenuItem("Tools/Data")]
        private static void OpenWindow()
        {
            GetWindow<DataEditor>().Show();
        }

        protected override OdinMenuTree BuildMenuTree()
        {
            var tree = new OdinMenuTree();
            tree.AddAllAssetsAtPath("Weapon Data", "Assets/_Game/SO Database/Items/Weapons", typeof(WeaponSO));
            return tree;
        }
    }
}