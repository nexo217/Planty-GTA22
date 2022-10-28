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


    // Start is called before the first frame update
    void Start()
    {
        viewpoint = Instantiate(ViewpointPrefab, transform.position, transform.rotation).GetComponent<Viewpoint>();
        viewpoint.MaxTextViewRange = 40;
        viewpoint.MaxViewRange = 40;
        viewpoint.PointText = "Collectable";
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "GameController")
        {
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
