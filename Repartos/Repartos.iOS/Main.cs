using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace Repartos.iOS
{
    public class Application
    {
        /// <summary>
        /// Esta es la entrada principal a la aplicacion.
        /// </summary>
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}
