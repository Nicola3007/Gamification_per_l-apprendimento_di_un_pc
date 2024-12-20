using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using JetBrains.Annotations;

public class QuestionManager : MonoBehaviour
{
    public Text questiontext; 
    public Text scoretext;
    public Text finalScore;
    public Button[] replyButton;
    public QtsData qtsdata;
    public GameObject Right;
    public GameObject Wrong;

    private int currentQuestion = 0;
    private static int score = 0;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetQuestion(currentQuestion);
        Right.SetActive(false);
        Wrong.SetActive(false); 
    }

    void SetQuestion(int questionIndex)
    {
        questiontext.text = qtsdata.question[questionIndex].questionText;

        foreach (Button r in replyButton) {
            r.onClick.RemoveAllListeners();
        }

        for (int i = 0; i < replyButton.Length; i++) {
            replyButton[i].GetComponentInChildren<Text>().text = qtsdata.question[questionIndex].replies[i];
            int replyIndex = i;
            replyButton[i].onClick.AddListener(() =>
            {
                CheckReply(replyIndex);
            });

        }

    }

    void CheckReply(int replyIndex)
    {
        if (replyIndex == qtsdata.question[currentQuestion].correctReplyInedex)
        {
            score++;
            scoretext.text = "" + score;

            Right.gameObject.SetActive(true);

            foreach (Button r in replyButton)
            {
                r.interactable = false;

            }
            StartCoroutine(Next());
        }

        else
        {
            Wrong.gameObject.SetActive(true);

            foreach (Button r in replyButton)
            {
                r.interactable = false;

            }
            StartCoroutine(Next());
        }
    }

        IEnumerator Next()
        {
            yield return new WaitForSeconds(2);
            
            currentQuestion++;

            if (currentQuestion< qtsdata.question.Length)
            {
                Reset();
            }
            else
            {
                // inserire qua cosa succede se sono finite le domande
            }

        }

        public void Reset()
    {
        Right.SetActive(false);
        Wrong.SetActive(false);

            foreach (Button r in replyButton) 
            { 
            r.interactable=true;
            }

            SetQuestion(currentQuestion);
    }



}
