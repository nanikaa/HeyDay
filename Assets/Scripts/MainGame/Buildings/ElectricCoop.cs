using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricCoop : Building
{
    private void Start()
    {
        this.buildingStringName = "Heyday Electric Cooperative";
        this.buildingEnumName = Buildings.ELECTRICCOOP;
        this.buildingOpeningTime = 8f;
        this.buildingClosingTime = 17f;
        this.buildingDescription = "You can explore the HeyDay Electric Cooperative, where state-of-the-art technology ensures a seamless and sustainable power supply for the city. The exterior is adorned with solar panels, symbolizing a commitment to renewable energy.";

        BuildingManager.Instance.onBuildingBtnClicked += CheckBtnClicked;
    }


    private void OnDestroy()
    {
        BuildingManager.Instance.onBuildingBtnClicked -= CheckBtnClicked;
    }

        private void OnEnable()
    {
        BuildingManager.Instance.onBuildingBtnClicked += CheckBtnClicked;
    }
    private void OnDisable()
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
            }
    }


    public override void CheckButtons()
    {
        this.actionButtons = new List<Buttons>(){Buttons.APPLY};     

        if (this.currentlyHired)
        {
            this.actionButtons.Add(Buttons.WORK);
            this.actionButtons.Add(Buttons.QUIT);   
        }
    }
}
