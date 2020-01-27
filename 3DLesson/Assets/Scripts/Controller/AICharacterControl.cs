using UnityEngine;
using UnityEngine.AI;

namespace Geekbrains
{
	[RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
    public class AICharacterControl : MonoBehaviour
    {
        public NavMeshAgent agent { get; private set; }            
        public Transform target;                                


        private void Start()
        {
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();

	        agent.updateRotation = false;
	        agent.updatePosition = true;
		}


        private void Update()
        {
	        if (target != null)
                agent.SetDestination(target.position);
        }


        public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}
