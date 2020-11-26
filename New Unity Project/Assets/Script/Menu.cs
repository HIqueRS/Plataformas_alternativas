using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            changeScene();
        }
        else if (Input.GetAxisRaw("Vertical") != 0)
        {
            changeScene();
        }
    }

    private void changeScene()
    {
        SceneManager.LoadScene("Game");
    }
}
