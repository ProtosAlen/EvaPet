using UnityEngine;
using System.Collections;

public class Suicide : MonoBehaviour {

	void Update () {
        Destroy(gameObject, 5);
    }
}
