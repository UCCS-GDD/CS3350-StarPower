using UnityEngine;
using System.Collections;

public static class GameData {

    //
	// enemy ship stats
    public static float bomberEnemyMoveSpeed = 1f;
    public static float tankEnemyMoveSpeed = 1f;
    public static float defaultEnemyMoveSpeed = 1f;
    public static float defaultBossMoveSpeed = 1.5f;

    public static int bomberBaseHealth = 10;
    public static int tankBaseHealth = 80;
    public static int defaultBaseHealth = 30;
    public static int defaultBossHealth = 1000;

    public static int deafultShieldPowerUp = 10;

    public static int bomberLoot;           // cast these as actual loot later
    public static int tankLoot;
    public static int defaultLoot;

    public static int bomberBounty;
    public static int tankBounty;
    public static int enemyBounty;

    public static int bomberStartBombs;
    public static int tankStartBombs;
    public static int enemyStartBombs;

    //
    // player ship stats
    public static float playerMoveSpeed = 1f;

    //
    // sound effect volume
    public static float laserVolume = 1f;
    public static float menuSelectVolume = 1f;
    public static float shieldUpVolume = 1f;
    public static float shieldDownVolume = 1f;
    public static float explosionVolume = 1f;

    //
    // weapon cost modifiers
    public static float projectileCountDiv = 200f;
    public static float spreadOffset = -25f;
    public static float spreadMult = 30f;
    public static float burstFireCountMult = 250f;
    public static float refireRateMult = 1000f;
    public static float cooldownRateMult = 1000f;

    //
    //

    //
    //

    //// saves the current game data into a binary file
    //public void Save()
    //{

    //}

    //// loads the previous game from a binary file
    //public void Load()
    //{

    //}

}
