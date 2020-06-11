using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CpuBurndownApi.Controllers
{
    [ApiController]
    [Route("api/burndown")]
    public class BurndownController : ControllerBase
    {
        private IBurndown _burndown;

        public BurndownController(IBurndown burndown)
        {
            _burndown = burndown;
        }

        [HttpGet]
        public string Get()
        {
            int cpuUsage = 50;
            int time = 10000;
            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                Thread t = new Thread(new ParameterizedThreadStart(_burndown.CPUKill));
                t.Start(cpuUsage);
                threads.Add(t);
            }
            Thread.Sleep(time);
            _burndown.ShouldContinue = false;
            return "Burned";            
        }
    }
}
