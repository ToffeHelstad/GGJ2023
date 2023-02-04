using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestThornProd : MonoBehaviour
{
    public Image questItem;
    public Color completedColor;
    public Color activeColor;

    void FinishQuest()
    {
        questItem.color = completedColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FinishQuest();
            Destroy(gameObject);
        }

    }
}
