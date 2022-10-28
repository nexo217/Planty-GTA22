using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog2 : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(Vector3.down * Time.deltaTime, Space.World);
    }
}
