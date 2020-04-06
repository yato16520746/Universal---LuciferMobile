using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // singleton
    static Player _instance;
    public static Player Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Start()
    {
        // set singleton for Player
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

}
