using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviourSingleton<TestManager>
{
    private TestState testState;
    protected override void Awake()
    {
        base.Awake();
        InitData();
    }

    public void InitData()
    {
        testState = new TestState();
        testState.alienShootRate = 3;
        testState.alienSpeed = 10f;
    }

    public int GetAlienShootRate()
    {
        return testState.alienShootRate;
    }

    public void SetAlienShootRate(int t)
    {
        testState.alienShootRate = t;
    }

    public float GetAlienSpeed()
    {
        return testState.alienSpeed;
    }

    public void SetAlienSpeed(float t)
    {
        testState.oldAlienSpeed = testState.alienSpeed;
        testState.alienSpeed = t;
    }

    public float GetOldAlienSpeed()
    {
        return testState.oldAlienSpeed;
    }
}
