using UnityEngine;

public class Buy : MonoBehaviour {

    public Main main;

    public int price;
    public int hunger;
    public int thirst;

    public void Click()
    {
        if (price <= main.money)
        {
            main.money -= price;
            main.hunger += hunger;
            main.thirst += thirst;
        }
    }

}
