using System.Collections;
using System.Collections.Generic;
using AudioAdapter;
using UnityEngine;

public class AudioServiceLocator : MonoBehaviour {

    //Editor Members
    [SerializeField] private AudioClipAdapter _serviceProvider;
    
    private static AudioServiceLocator _instance;
   
    //Global access to the Service Locator
    public static AudioServiceLocator Instance => _instance;


    // Start is called before the first frame update
    protected void Awake()
    {
        Debug.Log("Audio Service Locator Start");
        if (_instance == null) 
        {
            _instance = this;
        }
        
        DontDestroyOnLoad(this);
    }

    public AudioClipAdapter GetProvider() {
        return _serviceProvider;
    }
    
    
    
}
