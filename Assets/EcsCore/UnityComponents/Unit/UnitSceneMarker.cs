using UnityEngine;

public enum UnitType
{
    Combat,
    Merchant
}

namespace UnityComponent
{
    public class UnitSceneMarker : MonoBehaviour
    {
        public UnitType unitType;

        public void DestroySelf()
        {
            Destroy(gameObject);
        }
    }
}
