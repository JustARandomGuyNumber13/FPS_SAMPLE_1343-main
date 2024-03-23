using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefillAmmo : MonoBehaviour
{
    private FPSController player;
    private bool isPlayerInRange;
    private void Start()
    {
        player = FindObjectOfType<FPSController>();
    }
    private void Update()
    {
        if (isPlayerInRange && Input.GetButtonDown("Interact"))
            player.IncreaseAmmo(10);
    }
    private void OnTriggerEnter(Collider other)
    {
         if (other.gameObject.Equals(player.gameObject)) isPlayerInRange = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.Equals(player.gameObject)) isPlayerInRange = false;
    }
}
