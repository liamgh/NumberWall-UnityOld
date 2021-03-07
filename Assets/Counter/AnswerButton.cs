using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerButton : MonoBehaviour
{
    private int myAnswer;
    private Counter counter;

    // Start is called before the first frame update
    void Start()
    {
        counter = FindObjectOfType<Counter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {

        myAnswer = int.Parse(GetComponentsInChildren<TextMesh>()[0].text);
        Debug.Log(myAnswer);
        counter.submitAnswer(myAnswer);
    }
}
