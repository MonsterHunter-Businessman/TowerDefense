using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        JsonParser.Enemy enemy1;
        JsonParser json = new JsonParser();
        enemy1 = json.MonsterParsing("거미");
        Debug.Log(enemy1.AttCastle);

        JsonParser.UserInfo user;
        user = json.UserParsing("user");
        Debug.Log(user.Id);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
