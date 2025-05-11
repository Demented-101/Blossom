using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("musicPlayer").Length > 1)
        {
            GameObject.Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(this);
        gameObject.GetComponent<AudioSource>().Play();
    }
}
