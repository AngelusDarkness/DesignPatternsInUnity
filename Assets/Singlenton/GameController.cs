using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    
    private float _score;
    
    private static GameController _instance;
    public static GameController Instance => _instance;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("GameController Start");
        if (_instance == null) 
        {
            _instance = this;
        }
        
        DontDestroyOnLoad(this);
    }

    public static GameController GetInstance() {
        return _instance;
    }
    
    public void AddScore(float score) 
    {
        _score += score;
        Debug.Log($"Player Current Score {_score}");
    }
    
}
