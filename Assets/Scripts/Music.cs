using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private const string V = "music";

    // Start is called before the first frame update
    void Start()
    { GameObject[] musicgameobjects = GameObject.FindGameObjectsWithTag(V);
        if (musicgameobjects.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
