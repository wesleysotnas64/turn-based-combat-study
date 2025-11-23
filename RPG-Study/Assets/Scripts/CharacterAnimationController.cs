using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    [SerializeField] private Transform selectPosition;
    public Transform SelectPosistion
    {
        get { return this.selectPosition; }
    }
}
