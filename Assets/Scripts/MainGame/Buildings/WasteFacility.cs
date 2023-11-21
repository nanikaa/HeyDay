using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteFacility : Building
{
    private void Start()
    {
        this.buildingStringName = "Heyday Solid Waste Management Facility";
        this.buildingEnumName = Buildings.WASTEFACILITY;
        this.buildingOpeningTime = 8f;
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
            this.actionButtons = new List<Buttons>(){Buttons.WORK, Buttons.QUIT};     
        }
    }
}
