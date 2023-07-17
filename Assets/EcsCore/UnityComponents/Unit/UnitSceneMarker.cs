using UnityEngine;

public enum UnitType
{
    Combat,
    Merchant,
    Netral
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
