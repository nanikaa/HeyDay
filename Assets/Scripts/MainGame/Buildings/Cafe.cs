using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cafe : Building
{
    private void Start()
    {
        this.buildingStringName = "DDoS Cafe";
        this.buildingEnumName = Buildings.CAFE;
        this.buildingOpeningTime = 10f;
        this.buildingClosingTime = 22f;

        this.actionButtons = new List<Buttons>(){Buttons.BUY};
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
                case Buttons.BUY:
                    Debug.Log("money deposited");
                    break;
                case Buttons.APPLY:
                    JobManager.Instance.Apply(this);
                    break;
                case Buttons.WORK:
                    JobManager.Instance.Work();
                    break;
                case Buttons.QUIT:
                    Debug.Log("money deposited");
                    break;
            }
    }


    public override void CheckButtons()
    {
        if (this.currentlyHired)
        {
            this.actionButtons.Add(Buttons.WORK);
            this.actionButtons.Add(Buttons.QUIT);   
        }
        else
        {
            this.actionButtons.Add(Buttons.APPLY);   
        }
    }
}
