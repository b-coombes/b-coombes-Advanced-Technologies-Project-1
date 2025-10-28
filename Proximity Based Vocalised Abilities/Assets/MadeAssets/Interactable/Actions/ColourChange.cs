using UnityEngine;

public class ColourChange : MonoBehaviour
{

    public Material material;
    private bool runOnce;

    public void action()
    {
        if (runOnce == true)
        {
            material.color = Color.white;
            runOnce = false;
        }
        else
        {
            material.color = Color.red;
            runOnce = true;
        }
    }













    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        material.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
