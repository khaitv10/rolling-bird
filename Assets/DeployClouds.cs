using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeployClouds : MonoBehaviour
{
    public GameObject cloudPrefab;
    public float respawnTime = 2f;
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        //screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)); 
        StartCoroutine(cloudWave());
    }

    private void spawnCloud()
    {
        GameObject cloud = Instantiate(cloudPrefab) as GameObject;
        cloud.transform.position = new Vector2(28f, Random.Range(-1.0f, 5.1f));
    }

    IEnumerator cloudWave()
    {
        while(true){
            yield return new WaitForSeconds(respawnTime);
            spawnCloud();
        }
    }
    
}
