using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TraversalDoor : MonoBehaviour
{
    public string scene;
    public PlayerMovement player;

    void Update(){
        Vector3 playerPosition = player.transform.position;
        if (Vector3.Distance(playerPosition, transform.position) < 5 && Input.GetKeyDown(KeyCode.E)){
            Interacted();
            Debug.Log("hellooo");
        }
    }
    void Interacted(){
        SceneManager.LoadScene(scene);
    }
}
