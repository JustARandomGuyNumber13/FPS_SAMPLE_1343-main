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
    [SerializeField] ParticleSystem muzzleEffect;
    [SerializeField] Image bloodFlash;

    private Color bloodFlashTransparency;
    private CinemachineBasicMultiChannelPerlin cameraEffect;
    FPSController player;
    Gun gun;

    // Start is called before the first frame update
    void Awake()
    {
        player = FindObjectOfType<FPSController>();
        gun = FindObjectOfType<Gun>();
        cameraEffect = camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        bloodFlashTransparency = bloodFlash.color;

        gun.updateAmmo.AddListener(UpdateAmmoValue);
        player.decreaseHealth.AddListener(DecreaseHealth);
    }
    private void Update()
    {
        if (bloodFlashTransparency.a > 0)
        {
            bloodFlashTransparency.a -= 1 * Time.deltaTime;
            bloodFlash.color = bloodFlashTransparency;
        }
    }
    private void UpdateAmmoValue(int curAmmo, int maxAmmo)
    {
        currentAmmoText.text = curAmmo.ToString();
        maxAmmoText.text = maxAmmo.ToString();
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
        muzzleEffect.Play();
    }
    private void DecreaseHealth(int percent) 
    {
        healthBar.fillAmount -= 0.1f;
        BloodFlashEffect();
    }
    private void BloodFlashEffect()
    {
        bloodFlashTransparency.a = 1;
        bloodFlash.color = bloodFlashTransparency;
    }
}
