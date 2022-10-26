using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watering : MonoBehaviour
{
    public WaterCan waterCanScript;
    public float radius = 2;

    private void Update()
    {
        Water();
    }

    public void Water()
    {
        Vector3 position = transform.position;

        Collider[] colliders = Physics.OverlapSphere(position, radius);
        foreach (Collider hit in colliders)
        {
            Plant plant = hit.GetComponent<Plant>();           
            if (plant != null && waterCanScript.watering && waterCanScript.gameObject.active)
            {
                    plant.waterGot += 0.001f;
            }          
        }
    }

    private void OnDrawGizmos()
    {
        // Draw a red sphere at the transform's position
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
