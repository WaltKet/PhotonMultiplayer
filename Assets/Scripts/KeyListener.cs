using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyListener : MonoBehaviour
{
    ExitScene sceneManager;
    // Start is called before the first frame update
    void Start()
    {
        sceneManager = GetComponent<ExitScene>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            sceneManager.LoadingLevel();
        }
    }
}
