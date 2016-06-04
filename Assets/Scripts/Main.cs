using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour {

    public Slider healthSlider;
    public float health;

    public Slider happinessSlider;
    public float happiness;

    public Slider energySlider;
    public float energy;

    public Slider hungerSlider;
    public float hunger;

    public Slider thirstSlider;
    public float thirst;

    public Text moneyText;
    public int maxMoney;
    public float money;

    bool sleeping;
    public Text sleepText;
    public GameObject sleepImage;

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
            sleepText.text = "Sleep";
            sleeping = false;
            sleepImage.SetActive(false);
        }
        else
        {
            sleepText.text = "Wake Up";
            sleeping = true;
            sleepImage.SetActive(true);
        }
    }

	void Update () {

        healthSlider.value = health;
        happinessSlider.value = happiness;
        energySlider.value = energy;
        hungerSlider.value = hunger;
        thirstSlider.value = thirst;
        moneyText.text = (int)money + "€";

        //statsText.text = "Health: " + (int)health + "/" + maxHealth +
         //   "\nEnergy: " + (int)energy + "/" + maxEnergy +
          //  "\nHappiness: " + (int)happiness + "/" + maxHappiness +
          //  "\nHunger: " + (int)hunger + "/" + maxHunger +
         //   "\nThirst: " + (int)thirst + "/" + maxThirst +
         //   "\nMoney: " + (int)money + "/" + maxMoney;

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

        if (happiness >= 100)
        {
            happiness = 100;
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

            if (energy >= 100)
            {
                energy = 100;
            }
        }
        else
        {
            if (energy >= 100)
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

        if (thirst >= 100)
        {
            thirst = 100;
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

        if (hunger >= 100)
        {
            hunger = 100;
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
