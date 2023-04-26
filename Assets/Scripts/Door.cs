using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int timesOfDeath = 0;
    public int numberToOpen;
    public Animator doorAnim;


    // Update is called once per frame
    void Update()
    {
        if(timesOfDeath == numberToOpen)
        {
            FindObjectOfType<AudioManager>().Play("Door");
            OpenDoor(true);
        }
    }

    public void IncreasesDeath()
    {
        timesOfDeath++;
    }

    public void OpenDoor(bool state)
    {
        doorAnim.SetBool("Open", state);

    }
}
