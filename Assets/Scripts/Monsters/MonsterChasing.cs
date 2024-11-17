using System.Collections;
using Incantium.Attributes;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace Monsters
{
    /// <summary>
    /// Class representing the "Chasing" state of a monster. This class make the monster chase the
    /// <see cref="Monster.target"/> until able to attack.
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(FieldOfView))]
    [RequireComponent(typeof(Monster))]
    internal sealed class MonsterChasing : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The maximum speed at which the monster will chase.")]
        [Min(0f)]
        private float speed;
        
        [SerializeField]
        [Tooltip("The acceleration of the monster at chasing.")]
        [Min(0f)]
        private float acceleration;
        
        [SerializeField]
        [Tooltip("The maximum radius in which the monster will search for targets.")]
        [Min(0f)]
        private float radius;

        [SerializeField]
        [Tooltip("The amount of seconds the monster will chase when having sight of the target.")]
        [Min(0f)]
        private float seconds;
        
        [SerializeField]
        [AutoReference]
        private NavMeshAgent agent;
        
        [SerializeField]
        [AutoReference]
        private FieldOfView sensor;

        [SerializeField] 
        [AutoReference] 
        private Monster monster;
        
        /// <summary>
        /// Method called when starting with chasing. This will make the monster start moving with a new speed and
        /// acceleration and keeps looking for the current target.
        /// </summary>
        [VisualScript]
        public void OnEnter()
        {
            agent.isStopped = false;
            agent.speed = speed;
            agent.acceleration = acceleration;

            sensor.radius = radius;
            sensor.onTargetFound += ResetCountDown;
            sensor.StartSearching(true);

            StartCoroutine(CountDown());
        }

        /// <summary>
        /// Method called when a new target is found. If this is the same target as is already targeted, this method
        /// will reset the countdown.
        /// </summary>
        /// <param name="target">The game object found in the field of view.</param>
        private void ResetCountDown(GameObject target)
        {
            if (target != monster.target) return;
            
            StopAllCoroutines();
            StartCoroutine(CountDown());
        }

        /// <summary>
        /// Method to countdown for a determined set of seconds until the monster loses interests in chasing the current
        /// target.
        /// </summary>
        private IEnumerator CountDown()
        {
            yield return new WaitForSeconds(seconds);
            
            sensor.onTargetFound -= ResetCountDown;
            monster.target = null;
            
            CustomEvent.Trigger(gameObject, "Patrol");
        }

        /// <summary>
        /// Method called when updating the chase state. This method will update the latest position of the
        /// <see cref="Monster.target"/> and create a new path.
        /// </summary>
        [VisualScript]
        public void OnUpdate() => agent.SetDestination(monster.target.transform.position);
        
        /// <summary>
        /// Method called when colliding with any other game object. If the collider is the
        /// <see cref="Monster.target"/>, it will switch over to the "Attack" state.
        /// </summary>
        /// <param name="other">The other game object colliding with this monster.</param>
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject != monster.target) return;
            
            CustomEvent.Trigger(gameObject, "Attack");
        }
    }
}