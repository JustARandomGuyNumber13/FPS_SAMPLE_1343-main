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
        /*
        Not sure how to "refill" without creating more codes in Gun.cs / FPSController.cs when the provided methods are AddAmmo() and IncreaseAmmo()
        So I treated it as add more ammo instead of replacing it with the maxAmmo amount
        Same as updating the maxAmmo value, so I will just keep as default
         */
        if(Input.GetButtonDown("Interact")) print("Press E: True, Player in range: " + isPlayerInRange);
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
