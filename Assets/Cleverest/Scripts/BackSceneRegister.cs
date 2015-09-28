using UnityEngine;
using System.Collections;

public class BackSceneRegister : MonoBehaviour {

    // Use this for initialization
    public void LoadDelayed()
    {
        //Load the selected scene, by scene index number in build settings
        Application.LoadLevel(0);
    }
}
