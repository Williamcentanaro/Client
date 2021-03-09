using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class OptionsPlayer
{
    public int x { get; set; }
    public int w { get; set; }
    public int h { get; set; }
    public int y { get; set; }
    public bool fullScreen { get; set; }

    public OptionsPlayer (int _x, int _w, int _h, int _y, bool _fullScreen)
    {
        x = _x;
        w = _w;
        h = _h;
        y = _y;
        fullScreen = _fullScreen;
    }

}
