using UnityEngine;
using System;

public class SessionData {

	private static GameData GAME_DATA;

	private static bool LoadData() {
        var valid = false;

        var data = PlayerPrefs.GetString("data", "");
        if (data != "") {
	        var success = DESEncryption.TryDecrypt(data, out var original);
	        if (success) {
		        GAME_DATA = JsonUtility.FromJson<GameData>(original);
		        GAME_DATA.LoadData();
		        valid = true;    
	        }
	        else {
		        GAME_DATA = new GameData();
	        }
            
        } else {
            GAME_DATA = new GameData();
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
        } catch (Exception ex) {
            Debug.LogError(ex.ToString());
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


[Serializable]
public class GameData {
	//Put attributes that you want to save during your game.
	public int currentCharacterLevel = 0;
	public int[] abilitiesLevel = { 0, 0 , 0 };

	public GameData() {
		currentCharacterLevel = -1;
		abilitiesLevel[0] = -1;
		abilitiesLevel[1] = -1;
	}

	public void SaveData() {
    
				
    }

	public void LoadData() {
	
	}
}