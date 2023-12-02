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
                    JobManager.Instance.Apply(this);
                    break;
                case Buttons.WORK:
                    JobManager.Instance.Work();
                    break;
                case Buttons.QUIT:
                    JobManager.Instance.QuitWork();
                    break;
                case Buttons.STUDY:
                    BuildingManager.Instance.OpenUniversityStudyOverlay();
                    break;
                case Buttons.ENROL:
                    BuildingManager.Instance.OpenUniversityEnrollOverlay();
                    break;
            }
    }


    public override void CheckButtons()
    {
        UniversityManager.Instance.OnEnteredUniversity();
        this.actionButtons = new List<Buttons>(){Buttons.APPLY};

        if (GameManager.Instance.CurrentGameLevel == 1)
        {
            this.actionButtons.Add(Buttons.ENROL);
        }
        else
        {
            this.actionButtons.Add(Buttons.STUDY);
        }

        if (this.currentlyHired)
        {
            this.actionButtons.Add(Buttons.WORK);
            this.actionButtons.Add(Buttons.QUIT);  
        }
    }
}
