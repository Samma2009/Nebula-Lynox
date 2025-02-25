﻿using Cosmos.HAL;
using Lynox.SystemUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TestDistro.GraphicMode;
using Sys = Cosmos.System;

namespace Lynox
{
    public class Kernel : Sys.Kernel
    {
        
        protected override void BeforeRun() => Booting.Boot();

        protected override void Run()
        {

            if (!File.Exists("0:\\system\\bin_enabled.conf"))
            {
                Booting.diagPrint("FAILED", "Your system has invalid/broken binaries, you will be sent to mode config recovery.");
                SystemUtils.FirstTimeSetup.FreshSetup();
            }
            else if (Directory.GetFiles("0:\\bin").Length != 1)
            {
                Booting.diagPrint("FAILED", "Your system has invalid/broken binaries, you will be sent to mode config recovery.");
                SystemUtils.FirstTimeSetup.FreshSetup();
            }
            TestDistro.GraphicMode.graphics.entry();
        }
    }
}
