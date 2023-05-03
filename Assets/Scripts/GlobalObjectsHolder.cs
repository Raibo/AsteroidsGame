using Assets.Scripts.EntityHolders;
using UnityEngine;

namespace Assets.Scripts
{
    public class GlobalObjectsHolder : MonoBehaviour
    {
        public static GlobalObjectsHolder Instance;

        public MapBordersProviderHolder MapBordersProvider;


        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }
    }
}
