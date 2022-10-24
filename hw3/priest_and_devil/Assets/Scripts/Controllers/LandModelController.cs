using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandModelController
{
    private LandModel landModel;

    public void CreateLand(string name, Vector3 position)
    {
        if (landModel == null)
            landModel = new LandModel(name, position);
        landModel.priestNum = landModel.devilNum = 0;
    }

    public LandModel GetLandModel()
    {
        return landModel;
    }

    public Vector3 AddRole(RoleModel roleModel)
    {
        if (roleModel.isPriest)
            landModel.priestNum++;
        else
            landModel.devilNum++;
        roleModel.role.transform.parent = landModel.land.transform;
        roleModel.isInBoat = false;
        return PositionModel.roles[roleModel.tag];
    }

    public void RemoveRole(RoleModel roleModel)
    {
        if (roleModel.isPriest)
            landModel.priestNum--;
        else
            landModel.devilNum--;
    }
}
