using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    #region Self Variables
    #region Public Variables

    [Header("InputData")] public InputData Data;

    #endregion
    #region Serialized Variables

    [SerializeField] private bool isFirstTimeTouchTaken = false;

    #endregion

    #region Private Variables

    private PlayerInputSystem _playerInput;
    private float _currentVelocity;
    private Vector3 _moveVector;
    private Vector3 _playerMovementValue;

    #endregion
    #endregion


    private void Awake()
    {
        Data = GetInputData();
        InitialSettings();
    }

    private InputData GetInputData() => Resources.Load<CD_Input>("Data/CD_Input").InputData;

    private void OnEnable()
    {
        _playerInput.Octopus.Enable();
        SubscribeEvents();
    }

    private void InitialSettings()
    {
        _playerInput = new PlayerInputSystem();
        _playerMovementValue = Vector3.zero;
    }

    private void SubscribeEvents()
    {
        CoreGameSignals.Instance.onReset += OnReset;
        _playerInput.Octopus.MouseDelta.performed += OnPlayerInputMouseDeltaPerformed;
        _playerInput.Octopus.MouseDelta.canceled += OnPlayerInputMouseDeltaCanceled;
        _playerInput.Octopus.MouseLeftButton.started += OnMouseLeftButtonStart;
    }

    private void UnSubscribeEvents()
    {
       
        CoreGameSignals.Instance.onReset -= OnReset;
        _playerInput.Octopus.MouseDelta.performed -= OnPlayerInputMouseDeltaPerformed;
        _playerInput.Octopus.MouseDelta.canceled -= OnPlayerInputMouseDeltaCanceled;
        _playerInput.Octopus.MouseLeftButton.started -= OnMouseLeftButtonStart;
    }

    private void OnDisable()
    {
        _playerInput.Octopus.Disable();
        UnSubscribeEvents();
    }

    void OnPlayerInputMouseDeltaPerformed(InputAction.CallbackContext context)
    {
        InputSignals.Instance.onSidewaysEnable?.Invoke(true);

        _playerMovementValue = new Vector3(context.ReadValue<Vector2>().x, 0f, 0f);
        Vector2 mouseDeltaPos = new Vector2(context.ReadValue<Vector2>().x, 0f);

        if (mouseDeltaPos.x > Data.HorizontalInputSpeed)
            _moveVector.x = Data.HorizontalInputSpeed / 10f * mouseDeltaPos.x;

        else if (mouseDeltaPos.x < -Data.HorizontalInputSpeed)
            _moveVector.x = -Data.HorizontalInputSpeed / 10f * -mouseDeltaPos.x;
        else
            _moveVector.x = Mathf.SmoothDamp(_moveVector.x, 0f, ref _currentVelocity,
                Data.ClampSpeed);

        InputSignals.Instance.onInputDragged?.Invoke(new HorizontalInputParams()
        {
            XValue = _moveVector.x,
            ClampValues = new Vector2(Data.ClampSides.x, Data.ClampSides.y)
        });

    }

    void OnPlayerInputMouseDeltaCanceled(InputAction.CallbackContext context)
    {
        InputSignals.Instance.onSidewaysEnable?.Invoke(false);
        _playerMovementValue = new Vector3(context.ReadValue<Vector2>().x, 0f, 0f);
    }

    void OnMouseLeftButtonStart(InputAction.CallbackContext cntx)
    {
        if (isFirstTimeTouchTaken == false)
        {
            isFirstTimeTouchTaken = true;
            CoreGameSignals.Instance.onPlay?.Invoke();
        }
    }


    private void OnReset()
    {
        isFirstTimeTouchTaken = false;
    }



}
