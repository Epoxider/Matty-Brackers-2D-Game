using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboPointController : MonoBehaviour
{
    public GameObject ComboPoint1;
    public GameObject ComboPoint2;
    public GameObject ComboPoint3;
    public int maxComboPoints = 3;
    public int currentComboPoints;

    void ToggleAllComboPoints() {
        ComboPoint1.GetComponent<Image>().enabled = true;
        ComboPoint2.GetComponent<Image>().enabled = true;
        ComboPoint3.GetComponent<Image>().enabled = true;
    }
    void ToggleTwoComboPoints() {
        ComboPoint1.GetComponent<Image>().enabled = true;
        ComboPoint2.GetComponent<Image>().enabled = true;
        ComboPoint3.GetComponent<Image>().enabled = false;
    }
    void ToggleOneComboPoints() {
        ComboPoint1.GetComponent<Image>().enabled = true;
        ComboPoint2.GetComponent<Image>().enabled = false;
        ComboPoint3.GetComponent<Image>().enabled = false;
    }
    void ToggleNoComboPoints() {
        ComboPoint1.GetComponent<Image>().enabled = false;
        ComboPoint2.GetComponent<Image>().enabled = false;
        ComboPoint3.GetComponent<Image>().enabled = false;
    }
    public void CheckComboPoints() {
        if (currentComboPoints == 3) {
            ToggleAllComboPoints();
        } else if (currentComboPoints == 2) {
            ToggleTwoComboPoints();
        } else if (currentComboPoints == 1) {
            ToggleOneComboPoints();
        } else {
            ToggleNoComboPoints();
        }
    }

    public void SetComboPoints(int comboPoint) {
        currentComboPoints = comboPoint;
    }
    public int GetComboPoints() {
        return currentComboPoints;
    }
    public void AddComboPoints(int comboPoint) {
        if (currentComboPoints+comboPoint > 3) {
            currentComboPoints = 3;
        } else {
            currentComboPoints += comboPoint;
        }
    }

    void Start()
    {
        currentComboPoints = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CheckComboPoints();
    }
}
