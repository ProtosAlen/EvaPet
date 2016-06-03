using UnityEngine;
using UnityEngine.UI;

public class OpenMenu : MonoBehaviour {

    public GameObject room0;
    public GameObject room1;
    public GameObject room2;
    public Text roomText;
    int room;

    public void Open(GameObject menu)
    {
        if (menu.activeSelf)
        {
            menu.SetActive(false);
        }
        else
        {
            menu.SetActive(true);
        }
    }

    public void ChangeRoomForward()
    {
        if (room == 0)
        {
            room = 1;
            room0.SetActive(false);
            room1.SetActive(true);
            room2.SetActive(false);
            roomText.text = "Game Room";
        }
        else if(room == 1)
        {
            room = 2;
            room0.SetActive(false);
            room1.SetActive(false);
            room2.SetActive(true);
            roomText.text = "Kitchen";
        }
        else if (room == 2)
        {
            room = 0;
            room0.SetActive(true);
            room1.SetActive(false);
            room2.SetActive(false);
            roomText.text = "Bedroom";
        }
    }

    public void ChangeRoomBackward()
    {
        if (room == 0)
        {
            room = 2;
            room0.SetActive(false);
            room1.SetActive(false);
            room2.SetActive(true);
            roomText.text = "Kitchen";
        }
        else if (room == 1)
        {
            room = 0;
            room0.SetActive(true);
            room1.SetActive(false);
            room2.SetActive(false);
            roomText.text = "Bedroom";
        }
        else if (room == 2)
        {
            room = 1;
            room0.SetActive(false);
            room1.SetActive(true);
            room2.SetActive(false);
            roomText.text = "Game Room";
        }
    }
}
