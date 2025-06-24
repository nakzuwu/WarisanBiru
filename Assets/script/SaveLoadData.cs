using System;
using System.Collections.Generic;
using UnityEngine;


    public static class SaveLoadData
    {
        private const string ScoreDataKey = "ScoreDataJSON";

        public static void ResetAll()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
            Debug.Log("y bsr");
            Debug.Log("♻️ PlayerPrefs reset");
        }

        public static void JsonSave(SOsavedData scoreData)
        {
            var wrapper = new ScoreDataWrapper
            {
                lvlScores = scoreData.lvlScores,
            };

            var json = JsonUtility.ToJson(wrapper);
            PlayerPrefs.SetString(ScoreDataKey, json);
            PlayerPrefs.Save();

            Debug.Log("✅ Saved using PlayerPrefs (JSON)");
        }

        public static void JsonLoad(SOsavedData scoreData)
        {
            if (PlayerPrefs.HasKey(ScoreDataKey))
            {
                var json = PlayerPrefs.GetString(ScoreDataKey);
                var wrapper = JsonUtility.FromJson<ScoreDataWrapper>(json);
                scoreData.lvlScores = wrapper.lvlScores;

                Debug.Log("✅ Loaded from PlayerPrefs (JSON)");
            }
            else
            {
                Debug.LogWarning("⚠️ No saved score data found, generating defaults.");
                
                scoreData.lvlScores.Clear();
                for (int i = 0; i < 5; i++)
                {
                    scoreData.lvlScores.Add(new lvlScore()
                    {
                        name = $"level{i+1}",
                        isGameFinished = false,
                        quizPoint = new bool[] { false, false, false, false }
                    });
                }
            }
        }

        [Serializable]
        private class ScoreDataWrapper
        {
            public List<lvlScore> lvlScores;
        }
    }