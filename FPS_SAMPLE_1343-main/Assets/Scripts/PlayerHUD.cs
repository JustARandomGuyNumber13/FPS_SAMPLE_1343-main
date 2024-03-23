using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using Cinemachine;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] Image healthBar;
    [SerializeField] TMP_Text currentAmmoText;
    [SerializeField] TMP_Text maxAmmoText;
    [SerializeField] private CinemachineVirtualCamera camera;

    private CinemachineBasicMultiChannelPerlin cameraEffect;
    FPSController player;
    Gun gun;

    // Start is called before the first frame update
    void Awake()
    {
        player = FindObjectOfType<FPSController>();
        gun = FindObjectOfType<Gun>();
        cameraEffect = camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        gun.updateAmmo.AddListener(UpdateAmmoValue);
        player.decreaseHealth.AddListener(DecreaseHealth);
    }
    private void UpdateAmmoValue(int curAmmo, int maxAmmo)
    {
        currentAmmoText.text = curAmmo.ToString();
        maxAmmoText.text = maxAmmo.ToString();
    }
    private void DecreaseHealth(int percent) 
    {
        healthBar.fillAmount -= 0.1f;
    }
    public void ShakeCamera()
    {
        cameraEffect.m_FrequencyGain = 1.0f;
        cameraEffect.m_AmplitudeGain = 1.0f;
        Invoke("StopShakeCamera", 0.05f);
    }
    private void StopShakeCamera()
    {
        cameraEffect.m_AmplitudeGain = 0;
    }
    public void MuzzleEffect()
    { 
        
    }
}
