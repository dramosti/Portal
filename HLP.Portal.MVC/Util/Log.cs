﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace HLP.Portal.MVC.Util
{
    public static class Log
    {
        private static string _xPath;

        public static string xPath
        {
            get { return _xPath + @"\log.txt"; }
            set
            {

                _xPath = value;
                if (!Directory.Exists(path: _xPath))
                {
                    Directory.CreateDirectory(path: _xPath);
                }
            }
        }

        public static void AddLog(string xLog)
        {
            using (StreamWriter sw = File.AppendText(path: xPath))
            {
                sw.WriteLine(value: DateTime.Now.ToString() + " - " + xLog);
            }
        }
    }

}