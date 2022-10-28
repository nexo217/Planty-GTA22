using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablePlant : MonoBehaviour
{
    public GameObject ViewpointPrefab;
    Viewpoint viewpoint;
    public AudioSource audioSource; 
    public PopupWindow popupWindow;

    [Header("GameobjectParameter")]
    public GameObject prefab;
    public Sprite logo;
    public string name;
    public int seedCount;
    CollectableOrder order;


    // Start is called before the first frame update
    void Start()
    {
        order = GameObject.Find("PlayerController").GetComponent<CollectableOrder>();
        viewpoint = Instantiate(ViewpointPrefab, transform.position, transform.rotation).GetComponent<Viewpoint>();
        viewpoint.MaxTextViewRange = 10;
        viewpoint.MaxViewRange = 10;
        viewpoint.PointText = "Collectable";
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "GameController")
        {
            order.NextCollectable();
            Inventory inventory = other.GetComponent<Inventory>();
            inventory.SeedItemPrefabs.Add(prefab);
            inventory.SeedItemLogos.Add(logo);
            inventory.SeedItemName.Add(name);
            inventory.SeedItemCount.Add(seedCount);
            inventory.MaxSeedItems += 1;
            audioSource.Play();
            popupWindow.AddToQueue("New Seeds Unlocked!");
            popupWindow.AddToQueue("You can now find more Seeds on the Map");
            viewpoint.DestroyUI();
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
