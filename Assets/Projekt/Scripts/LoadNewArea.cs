using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNewArea : MonoBehaviour
{

    public string levelToLoad;
    public string exitpoint;
    private PlayerController thePaladin;

    // Use this for initialization
    void Start()
    {
        thePaladin = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Paladin")
        {
            Application.LoadLevel(levelToLoad);
            thePaladin.startPoint = exitpoint;
        }
    }
}