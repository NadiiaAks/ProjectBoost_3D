using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    void Update()
    {
        EndApp();
    }

    private void EndApp()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Esc is down");
            Application.Quit();
        }
    }
}
