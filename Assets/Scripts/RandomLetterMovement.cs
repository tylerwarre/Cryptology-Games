using UnityEngine;
using System.Collections;

public class RandomLetterMovement : MonoBehaviour {

    public int fallSpeed;
    
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        fallSpeed = 1;
        transform.Translate(fallSpeed * (-Vector3.back * Time.deltaTime));
    }
}