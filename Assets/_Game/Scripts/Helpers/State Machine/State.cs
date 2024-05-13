using UnityEngine;

namespace _Game.Scripts.Helpers.State_Machine
{
    public abstract class State<T> : ScriptableObject where T : MonoBehaviour
    {
        protected T _runner;

        public virtual void Enter(T parent)
        {
            _runner = parent;
        }

        // similar to Update
        public abstract void Tick(float deltaTime);

        // similar to FixedUpdate
        public abstract void FixedTick(float fixedDeltaTime);

        // here we put the conditions to change to another state if needed
        public abstract void ChangeState();

        // this one can be called from the animation timeline
        public virtual void AnimationTriggerEvent(AnimationTriggerType triggerType)
        {
        }

        public virtual void Exit()
        {
        }
    }

    public enum AnimationTriggerType
    {
        HitBox,
        FinishAttack,
    }
}