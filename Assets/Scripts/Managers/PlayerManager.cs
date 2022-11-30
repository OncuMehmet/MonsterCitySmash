using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Self Variables
    
    #region Public Variables

    //public float CurrentScore;

    #endregion

    #region Serialized Variables

    [SerializeField]
    private PlayerMovementController playerMovementController;
    //[SerializeField]
    //private PlayerPhysicsController playerPhysicsController;
    //[SerializeField]
    //private PlayerAnimationController playerAnimationController;
    //[SerializeField]
    //private PlayerMeshController playerMeshController;
    //[SerializeField]
    //private PlayerTextController playerTextController;
    #endregion
    #region Private Variables

    private PlayerData _data;

    #endregion
    #endregion

    private void Awake()
    {
        _data = GetPlayerData();
        SendPlayerDataToMovementController();
    }
    
    private PlayerData GetPlayerData() => Resources.Load<CD_Player>("Data/CD_Player").PlayerData;

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        InputSignals.Instance.onInputDragged += OnGetInputValues;
        CoreGameSignals.Instance.onPlay += OnPlay;
        CoreGameSignals.Instance.onReset += OnReset;
        InputSignals.Instance.onSidewaysEnable += OnSidewaysEnable;
        //ScoreSignals.Instance.onUpdateScore += OnUpdateScoreText;
        //CoreGameSignals.Instance.onLevelSuccessful += OnLevelSuccessful;
        //CoreGameSignals.Instance.onLevelFailed += OnLevelFailed;

    }
    
    private void UnSubscribeEvents()
    {
        InputSignals.Instance.onInputDragged -= OnGetInputValues;
        CoreGameSignals.Instance.onPlay -= OnPlay;
        CoreGameSignals.Instance.onReset -= OnReset;
        InputSignals.Instance.onSidewaysEnable -= OnSidewaysEnable;
        //ScoreSignals.Instance.onUpdateScore -= OnUpdateScoreText;
        //CoreGameSignals.Instance.onLevelSuccessful -= OnLevelSuccessful;
        //CoreGameSignals.Instance.onLevelFailed -= OnLevelFailed;

    }

    private void OnDisable()
    {
        UnSubscribeEvents();
    }

    private void SendPlayerDataToMovementController()
    {
        playerMovementController.SetMovementData(_data.PlayerMovementData);
    }

    private void OnGetInputValues(HorizontalInputParams inputParams)
    {
        playerMovementController.UpdateInputValue(inputParams);
    }

    private void OnPlay()
    {
        playerMovementController.EnableMovement();
    }

    private void OnReset()
    {
        playerMovementController.OnReset();
    }

    public void OnSidewaysEnable(bool isSidewayEnable)
    {
        playerMovementController.SetSidewayEnabled(isSidewayEnable);
    }

    public void StopAllMovement()
    {
        playerMovementController.StopAllMovement();
        
    }

    

}
