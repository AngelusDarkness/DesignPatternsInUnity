using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("PlayerController Start");
        GameController.Instance.AddScore(10);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.A)) 
        {
            GameController.Instance.AddScore(10);
        }
    }
}
