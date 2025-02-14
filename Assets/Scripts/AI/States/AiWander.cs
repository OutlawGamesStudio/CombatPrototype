﻿using System;
using UnityEngine;
using UnityEngine.AI;

namespace ForgottenLegends.AI
{
    [Serializable]
    public class AiWander : AiState
    {
        [NonSerialized] private Vector3 startingPosition;
        [NonSerialized] private Vector3 destination;
        [NonSerialized] private bool destinationFound = false;
        public float DestinationTolerance = 1f;
        public float WanderDistance = 10f;

        public override bool EnterState(StateMachine stateMachine, float deltaTime)
        {
            startingPosition = stateMachine.transform.position;
            destination = Vector3.zero;
            destinationFound = false;
            return base.EnterState(stateMachine, deltaTime);
        }

        public override void Execute(float deltaTime)
        {
            float distance = Vector3.Distance(m_StateMachine.transform.position, destination);

            if (distance <= DestinationTolerance || destinationFound == false || destination.x == Mathf.Infinity)
            {
                if(destination == startingPosition && distance > DestinationTolerance)
                {
                    return;
                }
                m_StateMachine.StopPathing();
                destination = GetRandomDestination(distance);
                destinationFound = true;
                return;
            }
            float startDest = Vector3.Distance(startingPosition, destination);
            if (startDest < 2.5f)
            {
                destinationFound = false;
            }
            m_StateMachine.PathTo(destination);
        }

        private Vector3 GetRandomDestination(float distance)
        {
            // If the NPC is too far away from the starting position, then move back to the starting pos.
            float dist = Vector3.Distance(startingPosition, m_StateMachine.transform.position);
            if (dist > WanderDistance)
            {
                return startingPosition;
            }

            // Find a random spot on the navmesh within the specified distance.
            for (int i = 0; i < 30; i++)
            {
                Vector3 randomPoint = UnityEngine.Random.insideUnitSphere * distance;
                randomPoint += startingPosition;
                NavMeshHit hit;
                if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
                {
                    return hit.position;
                }
            }

            // If we can't get a random pos, then return the starting pos.
            return startingPosition;
        }
    }
}
