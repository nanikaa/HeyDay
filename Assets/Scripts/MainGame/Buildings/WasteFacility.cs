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
        this.buildingDescription = "You can explore the efficient Solid Waste Management Facility, a vital hub in keeping the city clean. Inside, workers diligently sort and process recyclables and waste, maintaining an eco-friendly environment.";

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
            }
    }


    public override void CheckButtons()
    {
        this.actionButtons = new List<Buttons>(){Buttons.APPLY};     

        if (this.currentlyHired && this.buildingEnumName == Player.Instance.CurrentPlayerJob.establishment)
        {
            this.actionButtons.Add(Buttons.WORK);
            this.actionButtons.Add(Buttons.QUIT);  
        }
    }
}
