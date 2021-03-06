using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSlot : MonoBehaviour
{
    public GameObject lineObject;
    public LevelManager levelManager;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == lineObject)
        {
            other.GetComponent<Rigidbody2D>().simulated = false;
            levelManager.SendMessage("Inserted", gameObject);
        }
    }
}