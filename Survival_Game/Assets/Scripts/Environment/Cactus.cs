using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    public int damage;
    public float damageRate;

    private List<IDamagable> thingsToDamage = new List<IDamagable>();

    IEnumerator DealDamage()
    {
        // every "damageRate" seconds, damage all thingsToDamage
        while (true)
        {
            for (int i = 0; i < thingsToDamage.Count; i++)
            {
                thingsToDamage[i].TakePhysicalDamage(damage);
            }

            yield return new WaitForSeconds(damageRate);
        }
    }
}
