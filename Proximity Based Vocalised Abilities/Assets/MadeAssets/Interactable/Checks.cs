using UnityEngine;
using UnityEngine.Timeline;

public class Checks : MonoBehaviour
{
    public PlayerController playerController;
    public ColourChange attachedScript;
    private bool actionExectuted = false;
    private bool playerProx;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.gameObject.name == "Player")
        {
            playerProx = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.transform.gameObject.name == "Player")
        {
            playerProx = false;
        }
    }

    void Update()
    {
        if (playerProx == true)
        {
            {

            }
            if (playerController.vPressed == true && !actionExectuted)
            {
                attachedScript.action();
                //print("V press on");
                actionExectuted = true;
            }
            if (playerController.vPressed == false && actionExectuted)
            {
                //print("V press off");
                actionExectuted = false;
            }
        }
    }
}
