using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timerButton : MonoBehaviour
{


    float timer = 1;
    bool hasPressed = false;
    bool gameSolved = false;
    bool onePressed = false;
    bool twoPressed = false;
    float start_time = 0;
    public KeypadLEDManager ledManager; 


    // Use this for initialization
    void Start()
    {
        GameObject g = GameObject.Find("KeypadLED");
        ledManager = g.GetComponent<KeypadLEDManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log(hit.transform.gameObject.name);

                //timer += Time.deltaTime;

                //if(Time.time - start_time  > timer){
                //    Debug.Log("tick");

                //}
                if (hit.transform.gameObject.name == "Keypad2" && onePressed == true)
                {
                    hasPressed = true;
                }

                if (hit.transform.gameObject.name == "Keypad1")
                {
                    onePressed = true;
                    StartCoroutine(CountdownTo((3)));
                }
            }
        }
    }

        IEnumerator CountdownTo(float sec)
        {
            Debug.Log("countdown started for " + sec + "seconds");
            yield return new WaitForSeconds(sec);

        if (hasPressed && gameSolved == false)
            {
                gameSolved = true;
                Debug.Log("Puzzle Solved!!!!!");
                ledManager.changeColor = true;
            }
            else
            {
                Debug.Log("Not on time! Try again! Or you already solved");
            }
        }

        //void OnGUI()
        //{
        //    if (timer < 10)
        //    {
        //        GUI.Label(new Rect(100, 100, 200, 200), "timer = " + timer);
        //    }
        //    else
        //    {
        //        GUI.Label(new Rect(100, 100, 200, 200), "over ");
        //    }
        //}
    }
