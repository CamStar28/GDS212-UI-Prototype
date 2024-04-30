using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI; 

public class actionRandomiser : MonoBehaviour
{
    public GameObject partyMember; 

    public float basicAttackChance = 0;
    public float healChance = 0;

    private float oldAggressionValue = (float)0.5;
    private float oldCautionValue = (float)0.5;

    public GameObject aggressionSlider; 
    public GameObject cautionSlider;

    public TextMeshProUGUI playerTextBox;

    // Start is called before the first frame update
    void Start()
    {
        basicAttackChance = 0;
        healChance = 0; 
        oldAggressionValue = (float)0.5;
        oldCautionValue = (float)0.5;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            basicAttackChance = Random.Range(1, 10) + (aggressionSlider.GetComponent<Slider>().value * 5);
            //healChance = Random.Range(1, 10) + (cautionSlider.GetComponent<Slider>().value * 5 + ((partyMember.GetComponent<PlayerController>().currentHealth - partyMember.GetComponent<PlayerController>().maxHealth) / 100); 
            healChance = Random.Range(1, 10) + (cautionSlider.GetComponent<Slider>().value * 10);

            if (basicAttackChance >= 10 )
            {
                print("Basic Attack");
                partyMember.GetComponent<PlayerController>().PerformBasicAttack();
                playerTextBox.text = ("Basic Attack");

            } else if (healChance >= 10) {
                print("Heal");
                partyMember.GetComponent<PlayerController>().PerformHeal();
                playerTextBox.text = ("Heal");

            } else {
                print("nothing I guess lmao");
                playerTextBox.text = ("nothing I guess lmao");
            }
        }
    }

    public void AggressionUp(float x)
    {
        //oldValue = x > oldValue ? x : oldValue;

        if(x > oldAggressionValue)
        {
            cautionSlider.GetComponent<Slider>().value -= ((x - oldAggressionValue) / 2);
            
            //value went up
            //Debug.Log("up");
        }
        else
        {
            //value went down/didn't change
            //Debug.Log("down");
        }
        oldAggressionValue = x;

        //Debug.Log(oldValue);
    }

    public void CautionUp(float x)
    {
        if (x > oldCautionValue)
        {
            aggressionSlider.GetComponent<Slider>().value -= ((x - oldCautionValue) / 2);
        } 
        else
        {

        }
        oldCautionValue = x;
    }

}
