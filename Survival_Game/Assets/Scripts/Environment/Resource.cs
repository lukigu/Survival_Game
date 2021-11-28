using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public ItemData itemToGive;
    public int quantityPerHit = 1;
    public int capacity;
    public GameObject hitParticle;

    public void Gather(Vector3 hitPoint, Vector3 hitNormal)
    {
        //give the player quantity per hit of the resource
        for(int i = 0; i < quantityPerHit; i++)
        {
            if (capacity <= 0)
            {
                break;
            }

            capacity -= 1;

            Inventory.instance.AddItem(itemToGive);
        }

        //create hit particle
        Destroy(Instantiate(hitParticle, hitPoint, Quaternion.LookRotation(hitNormal, Vector3.up)), 1.0f);

        //if empty destroy the resource
        if(capacity <= 0)
        {
            Destroy(gameObject);
        }
    }
}
