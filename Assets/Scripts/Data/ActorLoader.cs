using ForgottenLegends.Character;
using System;
using System.IO;
using UnityEngine;

namespace ForgottenLegends.Data
{
    public static class ActorLoader
    {
        public static ActorInfo Load(string fileName)
        {
            if(!File.Exists(fileName) || Path.GetExtension(fileName) != ".json")
            {
                return null;
            }

            string jsonFile = File.ReadAllText(fileName);
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
