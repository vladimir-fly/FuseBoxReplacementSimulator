using UnityEngine;

namespace FBRS.Managers
{
    public class ResourceManager : MonoBehaviour
    {
        public static T Load<T>(string resourceId) where T : MonoBehaviour
        {
            var instance = Instantiate(Resources.Load(resourceId)) as GameObject;
            return instance != null ? instance.GetComponent<T>() : null;
        }

        public static T Load<T>() where T : Object
        {
            return Instantiate(Resources.Load<T>(typeof(T).Name));
        }
    }
}