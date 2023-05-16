using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecutionManager : MonoBehaviour
{

    public PlayerManager playerManager;
    // Start is called before the first frame update
    void Start()
    {
        playerManager.InitPlayerManager();
    }

    // Update is called once per frame
    void Update()
    {
        playerManager.UpdatePlayerManager();
    }
   
}
