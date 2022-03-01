using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager
{
    private const string FILE_PATH_HIGHSCORE = "highscore.dat";

    public static void SaveScore(int score)
    {
        // todo:ficar abrindo o arquivo a cada game over, pode ser pesado, talvez criar somente quando a aplicação for fechada e salvar antes tudo local 
        var binaryFormatter = new BinaryFormatter();
        FileStream fileStream = File.Create(GetPath());

        var highscore = new Highscore
        {
            score = score
        };

        binaryFormatter.Serialize(fileStream, highscore);

        fileStream.Close();
    }

    public static string LoadScore()
    {
        Debug.Log(GetPath());
        if (File.Exists(GetPath()))
        {
            var binaryFormatter = new BinaryFormatter();
            FileStream fileStream = File.OpenRead(GetPath());
            Highscore highscore = binaryFormatter.Deserialize(fileStream) as Highscore;
            fileStream.Close();

            return highscore.score.ToString();
        }

        return "0";
    }

    private static string GetPath()
    {
        return Path.Combine(Application.persistentDataPath, FILE_PATH_HIGHSCORE);
    }
}


[Serializable]
public class Highscore
{
    public int score;
}
