using Incantium.Attributes;
using Unity.VisualScripting;
using UnityEngine;

namespace Monsters
{
    /// <summary>
    /// Class representing the "Attack" state of a monster. This class will kill the <see cref="Monster.target"/> and
    /// play the kill animation.
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Monster))]
    internal sealed class MonsterAttack : MonoBehaviour
    {
        private static readonly int KILL = Animator.StringToHash("Kill");

        [SerializeField]
        [AutoReference]
        private Animator animator;
        
        [SerializeField]
        [AutoReference]
        private Monster monster;
        
        /// <summary>
        /// Method called when starting to attack. This will start the attack animation and kill the
        /// <see cref="Monster.target"/> if possible.
        /// </summary>
        [VisualScript]
        public void OnEnter()
        {
            animator.SetTrigger(KILL);
            
            if (!monster.target.TryGetComponent<IKillable>(out var killable)) return;
            
            killable.Kill();
        }

        /// <summary>
        /// Method called when the attack animation has completed. This will remove the current
        /// <see cref="Monster.target"/> from being targeted again and will return the monster to the "Patrol" state.
        /// </summary>
        public void Complete()
        {
            monster.target = null;
            
            CustomEvent.Trigger(gameObject, "Patrol");
        }
    }
}