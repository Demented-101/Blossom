using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    private GameObject player;
    public float pickupDistance = 2f;
    public string flowerName = "N/a";
    public bool doPickup = false;

    [Header("parts")]
    [SerializeField] private GameObject flowerObj;
    [SerializeField] private GameObject stemObj;

    [Header("Materials")]
    [SerializeField] private Material flowerMaterial;
    [SerializeField] private Material stemMaterial;

    void Update()
    {
        player = GameObject.Find("Player");

        if (doPickup && Input.GetKey(KeyCode.E) && Vector4.Distance(transform.position, player.transform.position) < pickupDistance)
        {
            if (player.GetComponent<PlayerData>().AttemptPickup(flowerName)) // add to inventory
            {
                Object.Destroy(gameObject); // destroy object
            }
        }
    }

    public void SetupInteractionLabel(GameObject prefab){
        GameObject label = Instantiate(prefab, transform);

        InteractLabel interactLabel = label.GetComponent<InteractLabel>();
        interactLabel.text = "Pick " + flowerName;
        interactLabel.size = 3;
        interactLabel.distance = pickupDistance;
        interactLabel.UpdateText();
    }

    public void ResetMaterial()
    {
        flowerObj.GetComponent<MeshRenderer>().material = flowerMaterial;
        stemObj.GetComponent<MeshRenderer>().material = stemMaterial;
    }

    public void SetMaterial(Material material, bool includeStem)
    {
        flowerObj.GetComponent<MeshRenderer>().material = material;
        if (includeStem) { stemObj.GetComponent <MeshRenderer>().material = material; }
        else { stemObj.GetComponent<MeshRenderer>().material = stemMaterial; }
    }
}
