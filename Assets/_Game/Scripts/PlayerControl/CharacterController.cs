using _Game.Scripts.Interfaces.InterfaceActors;
using _Game.Scripts.Inventory;
using _Game.Scripts.Items;
using _Game.Scripts.Items.Weapons;
using _Game.Scripts.ScriptableObjects.World_Area;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Game.Scripts.PlayerControl
{
    [RequireComponent(typeof(PlayerInputHandle))]
    public class CharacterController : Interactor
    {
        [ShowInInspector, ReadOnly] private PlayerInputHandle _playerInput;

        #region Flash Light

        [SerializeField] private UnityEngine.Rendering.Universal.Light2D _light2D;
        [SerializeField] private GameObject _lightHolder;
        [SerializeField] private float _lightMaxIntensity;

        #endregion

        private void OnEnable()
        {
            _playerInput = GetComponent<PlayerInputHandle>();
            _playerInput.OnAttackPress += Attack;
        }

        private void OnDisable()
        {
            _playerInput.OnAttackPress -= Attack;
        }

        private void Attack()
        {
            SelectingItem = InventoryManager.Instance.GetSelectingItem();

            if (SelectingItem == null)
            {
                InteractAction();
                return;
            }

            Weapon weapon = SelectingItem as Weapon;
            if (weapon != null)
            {
                weapon.Attack();
            }
            else SelectingItem.UseItem();
        }

        #region Player's flash-light

        public void TurnLightOn()
        {
            FlashLightEffect();
        }

        public void TurnLightOff()
        {
            _light2D.intensity = 0;
        }

        private async void FlashLightEffect()
        {
            for (int i = 0; i < 3; i++)
            {
                _light2D.intensity = Random.Range(0, _lightMaxIntensity * 2 / 3);
                await UniTask.Delay(50);
                _light2D.intensity = 0;
                await UniTask.Delay(50);
            }

            DOTween.To(() => _light2D.intensity, newValue => _light2D.intensity = newValue, _lightMaxIntensity, 0.5f);
            await UniTask.WaitUntil(() => _light2D.intensity >= _lightMaxIntensity);
        }

        #endregion
    }
}