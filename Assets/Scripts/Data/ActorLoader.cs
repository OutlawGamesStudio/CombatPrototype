using ForgottenLegends.Character;
using System;
using System.IO;
using UnityEngine;

namespace ForgottenLegends.Data
{
    public class ActorLoader : BaseLoader
    {
        public static ActorInfo Load(string fileName)
        {
            string jsonFile = LoadFile(fileName);
            if(jsonFile == string.Empty)
            {
                return null;
            }
            ActorInfo actorInfo = JsonUtility.FromJson<ActorInfo>(jsonFile);
            return actorInfo;
        }

        public static void Save(string fileName, ActorInfo actorInfo)
        {
            if(File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            string jsonOutput = JsonUtility.ToJson(actorInfo, true);
            try
            {
                File.Create(fileName).Dispose();
                File.WriteAllText(fileName, jsonOutput);
            }
            catch (Exception exception)
            {
                UnityEngine.Debug.LogError($"Exception saving file: {exception.Message}");
            }
        }
    }
}
