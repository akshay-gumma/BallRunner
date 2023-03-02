using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveBall : MonoBehaviour
{
    public Camera camera;
    bool isTouching = false;
    Rigidbody rigidbody;
    public Text text;
    int score = 0;
    int counter = 16;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }



    void Update()
    {
        camera.transform.position = transform.position + new Vector3(0,15,-20);
        float Hmove = Input.GetAxis("Horizontal");
        float Vmove = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(Hmove, 0, Vmove);
        rigidbody.AddForce(move * 10);

        if(Input.GetKey(KeyCode.Space) && isTouching == true)
        {
            rigidbody.AddForce(new Vector3(Hmove, 5, Vmove)*20);
        }
        isTouching = false;
    }


    private void OnCollisionStay(Collision collision)
    {
        isTouching = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            score++;
            other.gameObject.SetActive(false);
            text.text = "Score : " + score;
            counter--;
            if(counter==0)
            {
                SceneManager.LoadScene("SceneTwo");
            }
        }

    }
}
