using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Invector.vCharacterController;

public class PlayerScript : MonoBehaviourPunCallbacks
{

    #region Public Fields

    [Tooltip("The local player instance. Use this to know if the local player is represented in the Scene")]
    public static GameObject LocalPlayerInstance;

    [SerializeField]
    public Camera PlayerCam;


    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        // #Important
        // used in GameManager.cs: we keep track of the localPlayer instance to prevent instantiation when levels are synchronized
        if (photonView.IsMine)
        {
            LocalPlayerInstance = gameObject;
        }

        else
        {
            Debug.Log("wrong view; destroying camera");
            Destroy(PlayerCam);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // stop character from falling
        if (!Physics.Raycast(transform.position, -Vector3.up, 5f))
        {
            transform.position = new Vector3(0f, 5f, 0f);
        }

    }
}
