using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gamemannager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
          
            SceneManager.LoadScene(1);
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
           
            SceneManager.LoadScene(2);
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
           
            SceneManager.LoadScene(3);
        }
    }
}
