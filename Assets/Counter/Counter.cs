//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public TextMesh CounterText;
    public TextMesh questionText;
    public TextMesh timeLeftText;
    public List<TextMesh> answerBoxes;
    public TextAsset translationsFile;
    private List<string> translations;

    private int Count = 0;
    private int maxTime = 59;
    private float timeLeft = 59;
    int correctAnswer;

    private float gameStartTime;

    private void Start()
    {
        translations = new List<string>();
        Count = 0;
        gameStartTime = Time.time;
        timeLeft = 0;
        string[] lines = translationsFile.text.Split("\n"[0]);
        foreach (string line in lines)
        {

            translations.Add(line);
        }

        NewQuestion();
    }

    public void submitAnswer(int answer)
    {
        if (timeLeft == 0)
        {
            return;
        }

        if (answer == correctAnswer)
        {
            Count++;
        }
        NewQuestion();
    }

    private void NewQuestion()
    {
        correctAnswer = Random.Range(0, 100);
        questionText.text = translations[correctAnswer];
        int placement = Random.Range(0, answerBoxes.Count);
        for (int i=0; i< answerBoxes.Count; i++)
        {
            if (i == placement)
            {
                answerBoxes[i].text = correctAnswer.ToString();
            }
            else
            {
                answerBoxes[i].text = Random.Range(0, 100).ToString();
            }
        }

    }

    private void Update()
    {
        timeLeft = maxTime - (Time.time - gameStartTime);
        if (timeLeft < 1)
        {
            timeLeft = 0;
        }
        CounterText.text = Count.ToString();
        timeLeftText.text = timeLeft.ToString("00");
    }

}
