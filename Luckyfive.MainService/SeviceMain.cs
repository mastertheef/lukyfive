using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Luckyfive.DataAccess.Infrastructure;
using Luckyfive.Service;
using Luckyfive.Service.Abstraction;

namespace Luckyfive.MainService
{
    public partial class SeviceMain : ServiceBase
    {
        private readonly IAdvertismentService advService;

        public SeviceMain()
        {
            InitializeComponent();
        }

        public SeviceMain(IAdvertismentService advService)
        {
            InitializeComponent();
            this.advService = advService;
        }

        protected override void OnStart(string[] args)
        {
            var readyToFinishAdvs = this.advService.GetReadyToFinishAdvertisments();
            // TODO: calculate needed amount of money and request it from money service
        }

        protected override void OnStop()
        {
        }
    }
}
