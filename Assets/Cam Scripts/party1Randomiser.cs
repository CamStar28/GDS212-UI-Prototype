using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI; 

public class party1Randomiser : MonoBehaviour
{

    public float basicAttackChance = 0;
    public float healChance = 0;

    public GameObject aggressionSlider; 
    public GameObject cautionSlider;

    // Start is called before the first frame update
    void Start()
    {
        basicAttackChance = 0;
        healChance = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            basicAttackChance = Random.Range(1, 10) + (aggressionSlider.GetComponent<Slider>().value * 5);
            healChance = Random.Range(1, 10) + (cautionSlider.GetComponent<Slider>().value * 5); 

            if (basicAttackChance >= 10 )
            {
                print("Basic Attack");
            } else if (healChance >= 10) {
                print("Heal"); 
            } else
            {
                print("nothing I guess lmao"); 
            }
        }
    }


}
