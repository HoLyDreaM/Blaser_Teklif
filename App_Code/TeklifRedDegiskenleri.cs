using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class TeklifRedDegiskenleri
{
    static string _RedNeden1;
    static string _RedNeden2;
    static string _EvrakNumarasi;

    public static string RedNeden1
    {
        get { return _RedNeden1; }
        set { _RedNeden1 = value; }
    }
    public static string RedNeden2
    {
        get { return _RedNeden2; }
        set { _RedNeden2 = value; }
    }
    public static string EvrakNumarasi
    {
        get { return _EvrakNumarasi; }
        set { _EvrakNumarasi = value; }
    }
}