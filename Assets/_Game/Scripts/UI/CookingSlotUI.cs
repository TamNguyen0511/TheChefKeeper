using _Game.Scripts.ScriptableObjects.World_Area;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts.UI
{
    public class CookingSlotUI : MonoBehaviour
    {
        public Image SlotImage;

        public Sprite UnknowSlotSprite;

        public void SetupSlot(IngredientSO ingredient)
        {
            if (ingredient.IsNotice)
            {
                SlotImage.sprite = ingredient.Icon.sprite;
            }
            else
            {
                SlotImage.sprite = UnknowSlotSprite;
            }
        }
        public void SetupSlot(RecipeSO diskes)
        {
            if (diskes.IsLearned)
            {
                SlotImage.sprite = diskes.Icon.sprite;
            }
            else
            {
                SlotImage.sprite = UnknowSlotSprite;
            }
        }
    }
}