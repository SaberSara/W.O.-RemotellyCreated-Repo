using UnityEngine;
using System.Collections;

public class Save_Load : MonoBehaviour {
    

    private static Save_Load save_Load;
    
    void Awake()
    {
        //if we don't have an [_instance] set yet
        if (!save_Load)
            save_Load = this;
        //otherwise, if we do, kill this thing
        else
            Destroy(this.gameObject);


        DontDestroyOnLoad(this.gameObject);
    }
}
