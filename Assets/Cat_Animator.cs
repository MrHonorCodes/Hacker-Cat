using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat_Animator : MonoBehaviour
{
    private Animator CatMC;

    // Start is called before the first frame update
    void Start()
    {
        CatMC = GetComponent<Animator>();

        // Assuming that 'TrIdle' is a trigger parameter in your Animator Controller
        if (CatMC != null)
        {
            // Set the trigger parameter to transition to the Idle state
            CatMC.SetTrigger("TrIdle");
        }
        else
        {
            Debug.LogError("Animator component not found on the GameObject.");
        }
    }



    // Update is called once per frame
    void Update()
    {

    }
}
