using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class University : Building
{
    private void Start()
    {
        this.buildingStringName = "Heyday University";
        this.buildingEnumName = Buildings.UNIVERSITY;
        this.buildingOpeningTime = 7f;
        this.buildingClosingTime = 17f;

        this.actionButtons = new List<Buttons>(){Buttons.APPLY};
        BuildingManager.Instance.onBuildingBtnClicked += CheckBtnClicked;
    }


    private void OnDestroy()
    {
        BuildingManager.Instance.onBuildingBtnClicked -= CheckBtnClicked;
    }


    public override void CheckBtnClicked(Buttons clickedBtn)
    {
        if (BuildingManager.Instance.CurrentSelectedBuilding.buildingEnumName == this.buildingEnumName)
            switch (clickedBtn)
            {
                case Buttons.APPLY:
                    Debug.Log("money deposited");
                    break;
                case Buttons.WORK:
                    Debug.Log("money deposited");
                    break;
                case Buttons.QUIT:
                    Debug.Log("money deposited");
                    break;
                case Buttons.STUDY:
                    UniversityManager.Instance.StudyPromptOverlay.SetActive(true);
                    break;
                case Buttons.ENROL:
                    UniversityManager.Instance.FieldSelectionOverlay.SetActive(true);
                    break;
            }
    }


    public override void CheckButtons()
    {
        if (this.currentlyHired)
        {
            this.actionButtons = new List<Buttons>(){Buttons.WORK, Buttons.QUIT};     
        }

        if (Player.Instance.PlayerEnrolledCourse == UniversityCourses.NONE)
        {
            this.actionButtons.Add(Buttons.ENROL);
        }
        else
        {
            this.actionButtons.Add(Buttons.STUDY);
        }
    }
}
