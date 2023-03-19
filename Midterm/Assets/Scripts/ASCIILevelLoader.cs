using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ASCIILevelLoader : MonoBehaviour
{

    public GameObject player;
    public GameObject rock;
    public GameObject stal;
    public GameObject tree;
    public GameObject ruin;
    public GameObject camp;

    public Vector2 startPos;

    public int xOffset = -3;
    public int yOffset = -2;

    private GameObject level;
    private GameObject currentPlayer;
    
    public int thisLevel = 0;

    public int ThisLevel
    {
        get { return thisLevel; }
        set
        {
            thisLevel = value;
            LoadLevel();
        }
    }

    private const string FILE_NAME = "LevelNo.txt";

    private const string FILE_DIR = "/Levels/";

    private string FILE_PATH;
    
    // Start is called before the first frame update
    void Start()
    {
        FILE_PATH = Application.dataPath + FILE_DIR + FILE_NAME;
        LoadLevel();
    }

    void LoadLevel()
    {
        Destroy(level);
        level = new GameObject("Level");
       
        string newPath = FILE_PATH.Replace("No", thisLevel + "");
        string[] fileLines = File.ReadAllLines(newPath);

        for (int yPos = 0; yPos < fileLines.Length; yPos++)
        {
            string lineText = fileLines[yPos];
            char[] lineChars = lineText.ToCharArray();

            for (int xPos = 0; xPos < lineChars.Length; xPos++)
            {
                char c = lineChars[xPos];

                GameObject newObject;

                switch (c)
                {
                    case 'p':
                        startPos = new Vector2(xPos, yPos);
                        newObject = Instantiate<GameObject>(player);
                        currentPlayer = newObject;
                        break;
                    case 'r':
                        newObject = Instantiate<GameObject>(rock);
                        break;
                    case 's':
                        newObject = Instantiate<GameObject>(stal);
                        break;
                    case 't':
                        newObject = Instantiate<GameObject>(tree);
                        break;
                    case 'c':
                        newObject = Instantiate<GameObject>(camp);
                        break;
                    case 'x':
                        newObject = Instantiate<GameObject>(ruin);
                        break;
                    default:
                        newObject = null;
                        break;
                }

                if (newObject != null)
                {
                    newObject.transform.position =
                        new Vector2(xPos + xOffset, yPos + yOffset);
                    newObject.transform.parent = level.transform;
                }
            }
        }
    }

    public void FoundShelter()
    {
        ThisLevel++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
