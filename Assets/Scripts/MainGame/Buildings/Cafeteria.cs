using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cafeteria : Building
{
    private void Start()
    {
        this.buildingStringName = "Gracianna's Cafeteria";
        this.buildingEnumName = Buildings.CAFETERIA;
        this.buildingOpeningTime = 6f;
        this.buildingClosingTime = 20f;
        this.buildingDescription = "You can step into Graciana’s cafeteria, filled with the aroma of freshly brewed coffee and various delectable dishes. Inside, tables are filled with patrons chatting and enjoying meals, creating a warm and inviting atmosphere.";

        BuildingManager.Instance.onBuildingBtnClicked += CheckBtnClicked;
        GameManager.Instance.MeetupLocBuildings.Add(this);
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
                    BuildingManager.Instance.OpenConsumablesOverlay();
                    break;
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
        this.actionButtons = new List<Buttons>(){Buttons.BUY, Buttons.APPLY};

        if (this.currentlyHired && this.buildingEnumName == Player.Instance.CurrentPlayerJob.establishment)
        {
            this.actionButtons.Add(Buttons.WORK);
            this.actionButtons.Add(Buttons.QUIT);   
        }
    }
}
