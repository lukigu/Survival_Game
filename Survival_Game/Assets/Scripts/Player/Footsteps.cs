using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioClip[] footstepClips;
    public AudioSource audioSource;

    public Rigidbody controller;

    public float footstepTreshold;
    public float footstepRate;

    private float lastFootstepTime;

    private void Update()
    {
        if(controller.velocity.magnitude > footstepTreshold)
        {
            if(Time.time - lastFootstepTime > footstepRate)
            {
                lastFootstepTime = Time.time;

                audioSource.PlayOneShot(footstepClips[Random.Range(0, footstepClips.Length)]);
            }
        }
    }

}
