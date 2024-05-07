using System;
using _Game.Scripts.Database;
using _Game.Scripts.Enums;
using _Game.Scripts.Items;
using _Game.Scripts.ScriptableObjects.Items;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

namespace _Game.Editors
{
    public class DataEditor : OdinMenuEditorWindow
    {
        private CreateNewItem _createNewItem;

        [MenuItem("Tools/Data")]
        private static void OpenWindow()
        {
            GetWindow<DataEditor>().Show();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            if (_createNewItem != null)
            {
                DestroyImmediate(_createNewItem.ItemToCreate);
            }
        }

        protected override OdinMenuTree BuildMenuTree()
        {
            var tree = new OdinMenuTree();

            _createNewItem = new CreateNewItem();
            tree.Add("Create new Item", _createNewItem);
            tree.AddAllAssetsAtPath("Weapon Data", "Assets/_Game/SO Database/Items/Weapons", typeof(WeaponSO)).AddThumbnailIcons();
            tree.AddAllAssetsAtPath("Ingredient Data", "Assets/_Game/SO Database/Items/Ingredients",
                typeof(IngredientSO)).AddThumbnailIcons();
            return tree;
        }

        protected override void OnBeginDrawEditors()
        {
            OdinMenuTreeSelection selected = this.MenuTree.Selection;

            SirenixEditorGUI.BeginHorizontalToolbar();

            if (SirenixEditorGUI.ToolbarButton("Delete current"))
            {
                BaseItemSO item = selected.SelectedValue as BaseItemSO;
                string path = AssetDatabase.GetAssetPath(item);
                AssetDatabase.DeleteAsset(path);
                AssetDatabase.SaveAssets();
            }

            SirenixEditorGUI.EndHorizontalToolbar();
        }

        public class CreateNewItem
        {
            public CreateNewItem()
            {
                ItemToCreate = ScriptableObject.CreateInstance<BaseItemSO>();
                ItemToCreate.ItemName = "New Item";
            }

            [InlineEditor(ObjectFieldMode = InlineEditorObjectFieldModes.Hidden)]
            public BaseItemSO ItemToCreate;

            [Button("Add new item")]
            private void CreateItem()
            {
                string path = "Assets/_Game/SO Database/Items/";

                switch (ItemToCreate.ItemType)
                {
                    case ItemType.None:
                        break;
                    case ItemType.Ingredient:
                        path += "Ingredients/";

                        IngredientSO ingredientItem = new();
                        ingredientItem = ScriptableObject.CreateInstance<IngredientSO>();
                        ingredientItem.CastFromParent(ItemToCreate);

                        AssetDatabase.CreateAsset(ingredientItem, path + ingredientItem.ItemName + ".asset");
                        break;
                    case ItemType.Material:
                        break;
                    case ItemType.Weapon:
                        path += "Weapons/";

                        WeaponSO weaponItem = new();
                        weaponItem = ScriptableObject.CreateInstance<WeaponSO>();
                        weaponItem.CastFromParent(ItemToCreate);

                        AssetDatabase.CreateAsset(weaponItem, path + weaponItem.ItemName + ".asset");
                        break;
                    case ItemType.Consumable:
                        break;
                    default:
                        AssetDatabase.CreateAsset(ItemToCreate, path + ItemToCreate.ItemName + ".asset");
                        break;
                }

                AssetDatabase.SaveAssets();

                ItemToCreate = ScriptableObject.CreateInstance<BaseItemSO>();
                ItemToCreate.ItemName = "New Item";
            }
        }
    }
}