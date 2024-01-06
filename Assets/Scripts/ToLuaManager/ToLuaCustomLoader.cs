using System.Collections;
using System.Collections.Generic;
using LuaInterface;
using UnityEngine;

public class ToLuaCustomLoader : LuaFileUtils
{
    public override byte[] ReadFile(string fileName)
    {
        byte[] buffer = null;

        if (!fileName.EndsWith(".lua"))
        {
            fileName += ".lua";
        }

        string[] strs = fileName.Split('/');
        
        // TextAsset luaCode = 

        return null;
    }
}
