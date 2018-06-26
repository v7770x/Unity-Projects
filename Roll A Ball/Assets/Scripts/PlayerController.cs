using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    private Rigidbody rb;
    private int collected_count;
    public Text countText, winText;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        collected_count = 0;
        setCountText();
        winText.text = "";
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            collected_count++;
            setCountText();
        }
    }

    void setCountText()
    {
        countText.text = "Count: " + collected_count.ToString();
        if (collected_count >= 10)
        {
            winText.text = "You Win!";
        }
    }
}
