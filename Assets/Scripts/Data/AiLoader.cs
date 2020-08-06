using ForgottenLegends.AI;
using UnityEngine;

namespace ForgottenLegends.Data
{
    public class AiLoader : BaseLoader
    {
        // Load Ai State Data
        public static T Load<T>(string fileName) where T : AiState
        {
            string jsonFile = LoadFile(fileName);
            if (jsonFile == string.Empty)
            {
                return null;
            }
            T aiState = null;
            try
            {
                aiState = JsonUtility.FromJson<T>(jsonFile);
            }
            catch (System.Exception exception)
            {
                UnityEngine.Debug.LogError($"Cannot load {fileName}: {exception.Message}");
            }
            return aiState;
        }
    }
}
