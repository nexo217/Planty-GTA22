using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarnPlant : MonoBehaviour
{
    public float radius = 2;

    public void Earn()
    {
        Vector3 position = transform.position;

        Collider[] colliders = Physics.OverlapSphere(position, radius);
        foreach (Collider hit in colliders)
        {
            Plant plant = hit.GetComponent<Plant>();
            if (plant != null)
            {
                if (plant.canEarn)
                {
                    plant.DestroyPlant();
                }
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
