using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNeeds : MonoBehaviour
{
    public Need health;
    public Need hunger;
    public Need thirst;
    public Need sleep;

    public float noHungerHealthDecay;
    public float noThirstHealthDeacy;

    private void Start()
    {
        //set the start values
        health.curValue = health.startValue;
        hunger.curValue = hunger.startValue;
        thirst.curValue = thirst.startValue;
        sleep.curValue = sleep.startValue;
    }

    private void Update()
    {
        
    }
}

[System.Serializable]
public class Need
{
    [HideInInspector]
    public float curValue;
    public float maxValue;
    public float startValue;
    public float regenRate;
    public float decayRate;
    public Image uiBar;

    public void Add(float amount)
    {
        curValue = Mathf.Min(curValue + amount, maxValue);
    }

    public void Substract(float amount)
    {
        curValue = Mathf.Max(curValue - amount, 0.0f);
    }

    public float GetPercentage()
    {
        return curValue / maxValue;
    }

}
