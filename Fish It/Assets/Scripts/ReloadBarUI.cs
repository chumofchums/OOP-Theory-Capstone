using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadBarUI : MonoBehaviour
{

    [SerializeField] private Image barImage;
    [SerializeField] private SpearGun spearGun;


    private void Start()
    {
        barImage.fillAmount = 0f;
    }

    private void Update()
    {
        barImage.fillAmount = spearGun.reloadTime / spearGun.reloadTimeMax;
    }

}
