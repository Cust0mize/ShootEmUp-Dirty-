using Controllers;
using UnityEngine;
using ShootEmUp;

public class CharacterAttackController : MonoBehaviour, IGameStartListener{
    [SerializeField] private CharacterAttackAgent _characterAttackAgent;
    [SerializeField] private InputSystem _inputSystem;

    public void OnStartGame(){
        _inputSystem.OnFire += Fire;
    }

    private void OnDestroy(){
        _inputSystem.OnFire -= Fire;
    }

    private void Fire(){
        _characterAttackAgent.OnFlyBullet();
    }
}