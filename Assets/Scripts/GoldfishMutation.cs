using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MutationState
{
    Bad,
    Good,
    Great,
    Caught,
    Break
}

public class GoldfishMutationStateMachine : MonoBehaviour
{
    private MutationState currentState = MutationState.Bad;

    public void ApplyMutation(MutationState newState)
    {
        currentState = newState;
        UpdateMutationState();
    }

    private void UpdateMutationState()
    {
        switch (currentState)
        {
            case MutationState.Bad:
                
                break;
            case MutationState.Good:
                
                break;
            case MutationState.Great:
                
                break;
            case MutationState.Caught:
                
                break;
            case MutationState.Break:

                break;
            default:
                break;
        }
    }

    public void SetGoodMutation()
    {
        ApplyMutation(MutationState.Good);
    }

    public void SetGreatMutation()
    {
        ApplyMutation(MutationState.Great);
    }
    public void SetCaughtMutation()
    {
        ApplyMutation(MutationState.Caught);
    }
    public void SetBreakMutation()
    {
        ApplyMutation(MutationState.Break);
    }
}

public class GoldfishMutation : MonoBehaviour
{
        public MutationState mutationStateMachine;

    public void ApplyGoodMutation()
    {
        mutationStateMachine.SetGoodMutation();
    }

    public void ApplyGreatMutation()
    {
        mutationStateMachine.SetGreatMutation();
    }
    public void ApplyCaughtMutation()
    {
        mutationStateMachine.SetCaughtMutation();
    }

    public void ApplyBreakMutation()
    {
        mutationStateMachine.SetBreakMutation();
    }
}
