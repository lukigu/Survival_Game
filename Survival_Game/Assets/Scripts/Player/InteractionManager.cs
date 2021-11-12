using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionManager : MonoBehaviour
{
    //perf
    public float checkRate = 0.05f;
    private float lastCheckTime;
    public float maxCheckDistance;
    public LayerMask layerMask;

    private GameObject curInteractGameObject;
    private IInteractable curInteractable;

    public TextMeshProUGUI promptText;
    private Camera cam;

    //perf
    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        // true every "checkRate" seconds
        if (Time.time - lastCheckTime > checkRate)
        {
            lastCheckTime = Time.time;
        }
    }

}

public interface IInteractable
{
    string GetInteractable();
    void OnInteract();
}
