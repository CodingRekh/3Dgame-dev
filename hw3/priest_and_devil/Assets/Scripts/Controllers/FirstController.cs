using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstController : MonoBehaviour, ISceneController, IUserAction
{
    private LandModelController rightLandRoleController;
    private LandModelController leftLandRoleController;
    private RiverModel riverModel;
    private BoatController boatRoleController;
    private RoleModelController[] roleModelControllers;
    private MoveController moveController;
    private bool isRuning;
    private float runningTime;


    void Awake()
    {
        SSDirector.GetInstance().CurrentSenceController = this;
        LoadResources();
        this.gameObject.AddComponent<UserGUI>();
    }

    public void LoadResources()
    {
        roleModelControllers = new RoleModelController[6];
        for (int i = 0; i < 6; i++)
        {
            roleModelControllers[i] = new RoleModelController();
            roleModelControllers[i].CreateRole(PositionModel.roles[i], i < 3 ? true : false, i);
        }

        leftLandRoleController = new LandModelController();
        leftLandRoleController.CreateLand("left_land", PositionModel.left_land);

        rightLandRoleController = new LandModelController();
        rightLandRoleController.CreateLand("right_land", PositionModel.right_land);

        foreach (RoleModelController roleModelController in roleModelControllers)
        {
            roleModelController.GetRoleModel().role.transform.localPosition = leftLandRoleController.AddRole(roleModelController.GetRoleModel());
        }

        riverModel = new RiverModel(PositionModel.river);

        boatRoleController = new BoatController();
        boatRoleController.CreateBoat(PositionModel.left_boat);

        moveController = new MoveController();

        isRuning = true;
        runningTime = 0;
    }

    public void MoveBoat()
    {
        if ((!isRuning) || moveController.GetIsMoving())
            return;

        if (boatRoleController.GetBoatModel().isRight)
            moveController.SetMove(PositionModel.left_boat, boatRoleController.GetBoatModel().boat);
        else
            moveController.SetMove(PositionModel.right_boat, boatRoleController.GetBoatModel().boat);

        boatRoleController.GetBoatModel().isRight = !boatRoleController.GetBoatModel().isRight;
    }

    public void MoveRole(RoleModel roleModel)
    {
        if ((!isRuning) || moveController.GetIsMoving())
            return;

        if (roleModel.isInBoat)
        {
            if (boatRoleController.GetBoatModel().isRight)
                moveController.SetMove(rightLandRoleController.AddRole(roleModel), roleModel.role);
            else
                moveController.SetMove(leftLandRoleController.AddRole(roleModel), roleModel.role);

            roleModel.isRight = boatRoleController.GetBoatModel().isRight;
            boatRoleController.RemoveRole(roleModel);

            if (boatRoleController.GetBoatModel().roles[0] == null && boatRoleController.GetBoatModel().roles[1] == null)
                Check();
        }
        else if (boatRoleController.GetBoatModel().isRight == roleModel.isRight)
        {
            if (roleModel.isRight)
            {
                rightLandRoleController.RemoveRole(roleModel);
            }
            else
            {
                leftLandRoleController.RemoveRole(roleModel);
            }
            moveController.SetMove(boatRoleController.AddRole(roleModel), roleModel.role);
        }

    }

    public void Restart()
    {
        runningTime = 0;
        this.gameObject.GetComponent<UserGUI>().resetGameMessage();

        leftLandRoleController.CreateLand("left_land", PositionModel.left_land);
        rightLandRoleController.CreateLand("right_land", PositionModel.right_land);

        for (int i = 0; i < 6; i++)
        {
            roleModelControllers[i].CreateRole(PositionModel.roles[i], i < 3 ? true : false, i);
            roleModelControllers[i].GetRoleModel().role.transform.localPosition = leftLandRoleController.AddRole(roleModelControllers[i].GetRoleModel());
        }
        boatRoleController.CreateBoat(PositionModel.left_boat);
        isRuning = true;
    }


    public void Check()
    {
        if (!isRuning)
            return;

        int leftPriestNum = leftLandRoleController.GetLandModel().priestNum;
        int leftDevilNum = leftLandRoleController.GetLandModel().devilNum;
        int rightPriestNum = rightLandRoleController.GetLandModel().priestNum;
        int rightDevilNum = rightLandRoleController.GetLandModel().devilNum;

        if (rightLandRoleController.GetLandModel().priestNum == 3 && rightLandRoleController.GetLandModel().devilNum == 3)
        {
            this.gameObject.GetComponent<UserGUI>().setGameMessage(true);
            isRuning = false;
        }
        else if ((leftPriestNum != 0 && leftPriestNum < leftDevilNum) || (rightPriestNum != 0 && rightPriestNum < rightDevilNum))
        {
            this.gameObject.GetComponent<UserGUI>().setGameMessage(false);
            isRuning = false;
        }

    }

    void Update()
    {
        if (isRuning)
        {
            runningTime += Time.deltaTime;
            this.gameObject.GetComponent<UserGUI>().time = (int)runningTime;
        }
    }

}
