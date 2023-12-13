using Controllers;
using UnityEngine;
using ShootEmUp;

public class CharacterMoveController : MonoBehaviour, IGameStartListener{
    [SerializeField] private CharacterMoveAgent _characterMoveAgent;
    [SerializeField] private InputSystem _inputSystem;

    public void OnStartGame(){
        _inputSystem.OnMove += Move;
    }
    
    private void OnDestroy(){
        _inputSystem.OnMove -= Move;
    }
    
    private void Move(float direction){
        _characterMoveAgent.SetMoveDirection(direction);
    }
}