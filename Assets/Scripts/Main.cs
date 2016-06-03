using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour {

    public int maxHealth;
    public float health;

    public int maxHappiness;
    public float happiness;

    public int maxEnergy;
    public float energy;

    public int maxHunger;
    public float hunger;

    public int maxThirst;
    public float thirst;

    public int maxMoney;
    public float money;

    bool sleeping;
    public Text sleepText;
    public GameObject sleepImage;

    public Text statsText;

    public GameObject player;

    Animation anim;
    AudioSource aud;

    public AudioClip otherClip;

    void Start()
    {
        aud = player.GetComponent<AudioSource>();
        anim = player.GetComponent<Animation>();
    }

    public void Click()
    {
        happiness += 5;
        aud.clip = otherClip;
        aud.Play();
        anim.Play("jump");
    }

    public void Sleep()
    {
        if (sleeping)
        {
            sleepText.text = "Wake Up";
            sleeping = false;
            sleepImage.SetActive(false);
        }
        else
        {
            sleepText.text = "Sleep";
            sleeping = true;
            sleepImage.SetActive(true);
        }
    }

	void Update () {

        statsText.text = "Health: " + (int)health + "/" + maxHealth +
            "\nEnergy: " + (int)energy + "/" + maxEnergy +
            "\nHappiness: " + (int)happiness + "/" + maxHappiness +
            "\nHunger: " + (int)hunger + "/" + maxHunger +
            "\nThirst: " + (int)thirst + "/" + maxThirst +
            "\nMoney: " + (int)money + "/" + maxMoney;

        /* MONEY CONTROL SECTION*/

        if (money >= 0)
        {
            money -= Time.deltaTime / 12;
        }

        if (money <= 0)
        {
            money = 0;
        }

        if (money >= maxMoney)
        {
            money = maxMoney;
        }

        /* HAPPINESS CONTROL SECTION*/

        if (happiness >= 0)
        {
            happiness -= Time.deltaTime / 2;
        }

        if (happiness <= 0)
        {
            happiness = 0;
        }

        if (happiness >= maxHappiness)
        {
            happiness = maxHappiness;
        }

        /* ENERGY CONTROL SECTION*/

        if (sleeping == false)
        {
            if (energy >= 0)
            {
                energy -= Time.deltaTime / 2;
            }

            if (energy <= 0)
            {
                energy = 0;
            }

            if (energy >= maxEnergy)
            {
                energy = maxEnergy;
            }
        }
        else
        {
            if (energy >= maxEnergy)
            {
                Debug.Log("Fully Rested.");
            }
            else
            {
                energy += Time.deltaTime / 2;
            }
        }
        
        /* THIRST CONTROL SECTION*/

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

        /* DEATH CONTROL SECTION*/
        if (health <= 0)
        {
            Debug.Log("Your Eva is dead...");
            //Death
        }
    }
}
