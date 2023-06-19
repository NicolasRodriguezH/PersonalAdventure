using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNewPlace : MonoBehaviour
{
    public string newPlaceName = "The new scene name here";
    public string goToPlaceName;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag.Equals("Player")) 
        {
            // Buscamos el Script del player y llamados a su variable de tipo string para asignarle el lugar al que se dirigira
            FindObjectOfType<PlayerController>().nextPlaceName = goToPlaceName;
            SceneManager.LoadScene(newPlaceName);
        }    
    }
}
