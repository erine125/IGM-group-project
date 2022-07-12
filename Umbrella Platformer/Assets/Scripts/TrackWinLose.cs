using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrackWinLose : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "obstacle") {
            Debug.Log("game over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        } 

        if (collision.gameObject.tag == "Finish") {
            Debug.Log("won");
            SceneManager.LoadScene("Lvl1");
        }
    }
}
