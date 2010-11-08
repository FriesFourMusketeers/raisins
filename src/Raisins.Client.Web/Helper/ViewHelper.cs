﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Raisins.Client.Web.Helper
{
    public class ViewHelper
    {

        public static string Title
        { 
            get { return ConfigurationManager.AppSettings["app.title"]; } 
        }
 
        public static string Description 
        {
            get { return ConfigurationManager.AppSettings["app.description"]; }
        }

        public static string Version
        {
            get { return ConfigurationManager.AppSettings["app.version"]; }
        }

    }
}