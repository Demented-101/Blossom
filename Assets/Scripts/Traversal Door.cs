using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TraversalDoor : MonoBehaviour
{
    public string scene; // string name of the scene
    public float range = 3; // distance from object center to player
    public PlayerMovement player;
    public bool run = true;

    void Update(){
        if (!run){ return; }
        Vector3 playerPosition = player.transform.position;
        if (Vector3.Distance(playerPosition, transform.position) < range && Input.GetKeyDown(KeyCode.E)){
            Interacted();
        }
    }
    public void Interacted(){
        SaveManager.Save(); // saves all data between saves
        SceneManager.LoadScene(scene); // change the current scene
    }
}
