using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Main : MonoBehaviour {

    public float health;
    public float happiness;
    public float energy;
    public int maxHunger;
    public float hunger;
    public int maxThirst;
    public float thirst;
    public Text statsText;

	void Start () {
	    
	}
	
	void Update () {

        //Death 
        if (health <= 0)
        {
            //CharacterDeath();
        }

        /* THIRST CONTROL SECTION*/

        //Normal thirst degredation
        if (thirst >= 0)
        {
            thirst -= Time.deltaTime / 2;
        }

        if (thirst <= 0)
        {
            thirst = 0;
        }

        if (thirst >= maxThirst)
        {
            thirst = maxThirst;
        }

        /* HUNGER CONTROL SECTION*/
        if (hunger >= 0)
        {
            hunger -= Time.deltaTime / 4;
        }

        if (hunger <= 0)
        {
            hunger = 0;
        }

        if (hunger >= maxHunger)
        {
            hunger = maxHunger;
        }

        /* DAMAGE CONTROL SECTION*/
        if (hunger <= 0 && (thirst <= 0))
        {
            health -= Time.deltaTime / 2;
        }

        else
        {
            if (hunger <= 0 || thirst <= 0)
            {
                health -= Time.deltaTime / 4;
            }
        }
    }
}
