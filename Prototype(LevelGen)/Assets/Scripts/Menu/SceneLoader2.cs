using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader2 : MonoBehaviour {

     public void ChangeScene()
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
}
