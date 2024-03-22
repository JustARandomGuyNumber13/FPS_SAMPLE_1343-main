using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] Image healthBar;
    [SerializeField] TMP_Text currentAmmoText;
    [SerializeField] TMP_Text maxAmmoText;

    FPSController player;
    [SerializeField]Gun gun;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<FPSController>();
        gun.updateAmmo.AddListener(UpdateAmmoValue);
    }
    private void UpdateAmmoValue(int curAmmo, int maxAmmo)
    {
        currentAmmoText.text = curAmmo.ToString();
        maxAmmoText.text = maxAmmo.ToString();
    }
}
