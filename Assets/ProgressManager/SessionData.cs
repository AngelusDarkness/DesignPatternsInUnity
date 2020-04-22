using UnityEngine;
using System;

public class SessionData {

	private static GameData GAME_DATA;

	private static bool LoadData() {
        var valid = false;

        var data = PlayerPrefs.GetString("data", "");
        if (data != "") {
	        DESEncryption.TryDecrypt(data, out var original);
            GAME_DATA = JsonUtility.FromJson<GameData>(original);
			GAME_DATA.LoadData();
            valid = true;
        } else {
            SessionData.GAME_DATA = new GameData();
        }

        return valid;
    }

    public static bool SaveData() {
        const bool valid = false;

        try {
            GAME_DATA.SaveData();
            var result = DESEncryption.Encrypt(JsonUtility.ToJson(SessionData.GAME_DATA));
            PlayerPrefs.SetString("data", result);
            PlayerPrefs.Save();
        } catch (Exception e) {
            Debug.LogError(e.ToString());
        }

        return valid;
    }

    public static GameData Data {
        get {
			if (GAME_DATA == null)
                LoadData();
            return GAME_DATA;
		}
    }

}


[System.Serializable]
public class GameData {
	//Put attributes that you want to save during your game.
    

	public GameData() {
    		
    }

	public void SaveData() {
    
				
    }

	public void LoadData() {
	
	}
}