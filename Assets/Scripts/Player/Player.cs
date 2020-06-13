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

    // pistol transform default
    // -0.06474289   -0.02103081   0.001257472
    // 0   290   90.00001
    // 1   1   1
                                           

    private void Awake()
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


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}
