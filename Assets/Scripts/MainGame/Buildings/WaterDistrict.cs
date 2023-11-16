using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDistrict : Building
{
    private void Start()
    {
        this.buildingStringName = "Heyday Water District";
        this.buildingEnumName = Buildings.WATERDISTRICT;
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


    public override void CheckButtons()
    {
        if (this.currentlyHired)
        {
            this.actionButtons = new List<Buttons>(){Buttons.WORK, Buttons.QUIT};     
        }
    }
}
