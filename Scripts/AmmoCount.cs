using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCount : MonoBehaviour
{
    public Text ammoText;
    public Text magText;

    public static AmmoCount occurrence;

    private void Awake()
    {
        occurrence = this;
        Debug.Log("AmmoCount instance set");
    }

    public void UpdateAmmoText(int presentAmmo)
    {
        ammoText.text = "Ammo: " + presentAmmo;
    }

    public void UpdateMagText(int mag)
    {
        magText.text = "Magazine: " + mag;
    }
}
