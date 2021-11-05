using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerNeeds : MonoBehaviour
{
    public Need health;
    public Need hunger;
    public Need thirst;
    public Need sleep;

    public float noHungerHealthDecay;
    public float noThirstHealthDeacy;

    public UnityEvent onTakeDamage;

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
        //decay needs over time
        hunger.Substract(hunger.decayRate * Time.deltaTime);
        thirst.Substract(thirst.decayRate * Time.deltaTime);
        sleep.Add(sleep.regenRate * Time.deltaTime);

        //decay health over time if no hunger or thirst
        if(hunger.curValue == 0.0f)
        {
            health.Substract(noHungerHealthDecay * Time.deltaTime);
        }
        if(thirst.curValue == 0.0f)
        {
            health.Substract(noThirstHealthDeacy * Time.deltaTime);
        }

        //check if player is dead
        if(health.curValue == 0.0f)
        {
            Die();
        }

        //update UI bars
        health.uiBar.fillAmount = health.GetPercentage();
        hunger.uiBar.fillAmount = hunger.GetPercentage();
        thirst.uiBar.fillAmount = thirst.GetPercentage();
        sleep.uiBar.fillAmount = sleep.GetPercentage();
    }

    public void Heal(float amount)
    {
        health.Add(amount);
    }

    public void Eat(float amount)
    {
        hunger.Add(amount);
    }

    public void Drink(float amount)
    {
        thirst.Add(amount);
    }

    public void Sleep(float amount)
    {
        sleep.Substract(amount);
    }

    // called when the player takes physical damage (fire, enemy, etc)
    public void TakePhysicalDamage(int amount)
    {
        health.Substract(amount);
        onTakeDamage?.Invoke();
    }

    // called when the player's health reaches 0
    public void Die()
    {
        Debug.Log("Player is dead");
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

    // add to the need
    public void Add(float amount)
    {
        curValue = Mathf.Min(curValue + amount, maxValue);
    }

    // subtract from the need
    public void Substract(float amount)
    {
        curValue = Mathf.Max(curValue - amount, 0.0f);
    }

    // return the percentage value (0.0 - 1.0)
    public float GetPercentage()
    {
        return curValue / maxValue;
    }

}
