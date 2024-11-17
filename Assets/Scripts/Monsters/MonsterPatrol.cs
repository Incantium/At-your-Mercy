using Incantium.Attributes;
using Incantium.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace Monsters
{
    /// <summary>
    /// Class representing the "Patrol" state of the monster. This class will move the monster around in a predetermined
    /// path and look for a target.
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(FieldOfView))]
    [RequireComponent(typeof(Monster))]
    internal sealed class MonsterPatrol : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The maximum speed at which the monster will patrol.")]
        [Min(0f)]
        private float speed;
        
        [SerializeField]
        [Tooltip("The acceleration of the monster at patrol.")]
        [Min(0f)]
        private float acceleration;

        [SerializeField]
        [Tooltip("The maximum radius in which the monster will search for targets.")]
        [Min(0f)]
        private float radius;
        
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
        /// The current waypoint index the monster is in the <see cref="Waypoints"/> path.
        /// </summary>
        private int currentWaypoint;

        /// <summary>
        /// Method called when starting the "Patrol" state. This method will set the correct speed and acceleration,
        /// alongside starting to search for a target.
        /// </summary>
        [VisualScript]
        public void OnEnter()
        {
            agent.speed = speed;
            agent.acceleration = acceleration;
            
            sensor.radius = radius;
            sensor.onTargetFound += ChasePlayer;
            sensor.StartSearching(false);
            
            SetNextDestination();
        }
        
        /// <summary>
        /// Method called when patrolling. This method will update the target position in the <see cref="Waypoints"/>
        /// list so that the monster keeps patrolling.
        /// </summary>
        [VisualScript]
        public void OnUpdate()
        {
            if (!ReachedDestination()) return;
            
            currentWaypoint = (currentWaypoint + 1) % monster.path.Count;
            
            SetNextDestination();
        }

        /// <summary>
        /// Method called when a new target has been found by the monster's <see cref="FieldOfView"/>. This method will
        /// update the <see cref="Monster.target"/> of the monster and trigger the "Scream" state.
        /// </summary>
        /// <param name="target">The game object found to be its new target.</param>
        private void ChasePlayer(GameObject target)
        {
            monster.target = target;
            sensor.onTargetFound -= ChasePlayer;
            
            CustomEvent.Trigger(gameObject, "Scream");
        }

        /// <summary>
        /// Method to set a new position in the <see cref="NavMeshAgent"/> from the <see cref="currentWaypoint"/> in its
        /// path.
        /// </summary>
        private void SetNextDestination()
        {
            if (!monster.path) return;
            
            agent.SetDestination(monster.path[currentWaypoint]);
        }

        /// <summary>
        /// Method to check if the monster has reached its next position along its path.
        /// </summary>
        /// <returns>True if the monster is very close to the next waypoint, otherwise false.</returns>
        private bool ReachedDestination() =>
            !agent.pathPending
            && !agent.hasPath
            && agent.remainingDistance <= 2f;
    }
}