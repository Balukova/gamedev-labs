using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Cinemachine.DocumentationSortingAttribute;

public class LevelManager : MonoBehaviour
{
    private LevelContext levelContext;
    public LevelManager()
    {
        levelContext = new LevelContext();
    }
    public void ChangeLevel()
    {
        levelContext.ChangeLevel();
        SceneManager.LoadScene(levelContext.Level.Name);
    }
}

public class LevelContext
{
    public Level Level
    {
        get => LevelState.Level;
        set
        {
            LevelState.Level = value;
        }
    }

    public void ChangeLevel()
    {
        LevelState.Level.ChangeLevel(this);
    }
}

public static class LevelState
{
    public static Level Level { get; set; } = new MenuLevel();
}

public abstract class Level
{
    public abstract string Name { get; set; }
    public abstract void ChangeLevel(LevelContext context);
}

class MenuLevel : Level
{
    public override string Name { get; set; } = "Menu";

    public override void ChangeLevel(LevelContext context)
    {
        context.Level = new Level1();
    }
}

class Level1 : Level
{
    public override string Name { get; set; } = "Level1";

    public override void ChangeLevel(LevelContext context)
    {
        context.Level = new Level2();
    }
}
class Level2 : Level
{
    public override string Name { get; set; } = "Level2";
    public override void ChangeLevel(LevelContext context)
    {
        //TODO Level3
    }
}

