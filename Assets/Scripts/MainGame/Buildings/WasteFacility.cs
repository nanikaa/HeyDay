using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteFacility : Building
{
    private void Start()
    {
        this.buildingName = Buildings.WASTEFACILITY;
        this.buildingOpeningTime = 8;
        this.buildingClosingTime = 17;

        this.actionButtons = new List<Buttons>(){Buttons.APPLY, Buttons.WORK, Buttons.QUIT};     
        BuildingManager.Instance.onBuildingBtnClicked += CheckBtnClicked;
    }


    private void OnDestroy()
    {
        BuildingManager.Instance.onBuildingBtnClicked -= CheckBtnClicked;
    }


    public override void CheckBtnClicked(Buttons clickedBtn)
    {
        if (BuildingManager.Instance.CurrentSelectedBuilding.buildingName == this.buildingName)
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
            }
    }
}
