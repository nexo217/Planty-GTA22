using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRefill : MonoBehaviour
{
    public WaterCan waterCan;
    float normalWaterFill;
    public float fillAmount = 0.1f;

    private void Start()
    {
        normalWaterFill = waterCan.waterFill;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "GameController" && waterCan.waterFill < normalWaterFill)
        {
            waterCan.waterFill += fillAmount;
        }
    }
}
