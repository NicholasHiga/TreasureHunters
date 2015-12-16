using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillsUI : MonoBehaviour {

    float time = 0;
    float skillOneCooldown = 0;
    public static bool canCastSkillOne = true;
    public static bool canCastSkillTwo = true;
    public static bool canCastSkillThree = true;
    public static bool canCastSkillFour = true;
    public static Image skillOne;
    public static Image skillTwo;
    public static Image skillThree;
    public static Image skillFour;

    // Use this for initialization
    void Start () {
        skillOne = GameObject.Find("SkillOne").GetComponent<Image>();
        skillOne.fillAmount = 1;
        skillTwo = GameObject.Find("SkillTwo").GetComponent<Image>();
        skillTwo.fillAmount = 1;
        skillThree = GameObject.Find("SkillThree").GetComponent<Image>();
        skillThree.fillAmount = 1;
        skillFour = GameObject.Find("SkillFour").GetComponent<Image>();
        skillFour.fillAmount = 1;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        
       //Skill one
        if (Input.GetKeyDown(KeyCode.Q) && canCastSkillOne == true)
        {
            skillOne.fillAmount = 0;
            canCastSkillOne = false;                     
        }
        if (time >= 0.1f)
        {
            skillOne.fillAmount += 0.009f;
            if (skillOne.fillAmount >= 1.0f)
            {
                canCastSkillOne = true;
            }
            //time = 0;
        }

        //Skill two
        if (Input.GetKeyDown(KeyCode.E) && canCastSkillTwo == true)
        {
            skillTwo.fillAmount = 0;
            canCastSkillTwo = false;
        }
        if (time >= 0.1f)
        {
            skillTwo.fillAmount += 0.01f;
            if (skillTwo.fillAmount >= 1.0f)
            {
                canCastSkillTwo = true;
            }
        }

        //Skill three
        if (Input.GetKeyDown(KeyCode.R) && canCastSkillThree == true)
        {
            skillThree.fillAmount = 0;
            canCastSkillThree = false;
        }
        if (time >= 0.1f)
        {
            skillThree.fillAmount += 0.03f;
            if (skillThree.fillAmount >= 1.0f)
            {
                canCastSkillThree = true;
            }
        }

        //Skill four
        if (Input.GetKeyDown(KeyCode.T) && canCastSkillFour == true)
        {
            skillFour.fillAmount = 0;
            canCastSkillFour = false;
        }
        if (time >= 0.1f)
        {
            skillFour.fillAmount += 0.0005f;
            if (skillFour.fillAmount >= 1.0f)
            {
                canCastSkillFour = true;
            }
        }

    }
}
