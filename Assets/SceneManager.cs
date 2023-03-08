using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine;

public class SceneManager : MonoBehaviour
{

    #region Prefabs
    
    [SerializeField]
    public GameObject baloonsObject;
    [SerializeField]
    public GameObject baloonLightObject;
    [SerializeField]
    public GameObject hearthPrefabObject;
    [SerializeField]
    public GameObject woodStandingHearthObject;
    [SerializeField]
    public GameObject sparklerObject;
    [SerializeField]
    public GameObject woodPlankObject;

    #endregion

    #region References
    
    public TapToPlace tapToPlace;
    
    #endregion

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
