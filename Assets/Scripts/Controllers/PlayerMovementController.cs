using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    #region Self Variables
    
    #region Serialized Variables
    [SerializeField] private new Rigidbody rigidbody;
    [SerializeField] private PlayerManager playerManager;
    //[SerializeField] private Transform playerMesh;
    #endregion

    #region Private Variables

    private PlayerMovementData _movementData;
    private bool _isReadyToMove, _isReadyToPlay;
    private float _inputValue;
    private Vector2 _clampValues;
    private bool _sidewaysEnable = false;
    #endregion
    #endregion

    public void SetMovementData(PlayerMovementData playerMovementData)
    {
        _movementData = playerMovementData;
    }

    public void EnableMovement()
    {
        _isReadyToMove = true;
        _isReadyToPlay = true;
    }

    public void UpdateInputValue(HorizontalInputParams inputParam)
    {
        _inputValue = inputParam.XValue;
        _clampValues = inputParam.ClampValues;
    }
    
    public void IsReadyToPlay(bool state)
    {
        _isReadyToPlay = state;
    }


    private void FixedUpdate()
    {
        if (_isReadyToPlay)
        {
            if (_isReadyToMove && _sidewaysEnable)
            {
                OctopusMove();
            }
            //else
            //{
            //    StopSideways();
            //}
        }
        else
            Stop();
    }
    
    private void OctopusMove()
    {
        var velocity = rigidbody.velocity;

        velocity = new Vector3(_inputValue * _movementData.SidewaysSpeed, velocity.y,
            _movementData.ZSpeed);
        rigidbody.velocity = velocity;
        Vector3 position;
        position = new Vector3(
            Mathf.Clamp(rigidbody.position.x, _clampValues.x,
                _clampValues.y),
            (position = rigidbody.position).y,
            position.z);
        rigidbody.position = position;
    }

    
    public void SetSidewayEnabled(bool isSidewayEnabled)
    {
        _sidewaysEnable = isSidewayEnabled;
    }

    //private void StopSideways()
    //{
    //    rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, _movementData.ZSpeed);
    //    rigidbody.angularVelocity = Vector3.zero;
    //}

    public void Stop()
    {
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
    }
    public void OnReset()
    {
        Stop();
        _isReadyToPlay = false;
        _isReadyToMove = false;
    }
    public void StopAllMovement()
    {
        _isReadyToPlay = false;
    }
   
   

    

}
