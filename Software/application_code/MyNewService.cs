using System;
using System.ServiceProcess;
using System.Timers;
using log4net;

namespace NewWindowsService
{
    public partial class MyNewService : ServiceBase
    {
        private System.Timers.Timer timer;
        // Logger để ghi file log (quan trọng nhất với Windows Service vì nó không có giao diện)
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public MyNewService()
        {
            InitializeComponent();
        }

        private void InitializeComponent() 
        {
             this.ServiceName = "MyNewService";
        }

        protected override void OnStart(string[] args)
        {
            // Điểm bắt đầu của Service
            log.Info("=== LEARNING SERVICE STARTED ===");
            
            // Tạo một timer chạy mỗi 10 giây
            timer = new System.Timers.Timer();
            timer.Interval = 10000; // 10000ms = 10s
            timer.Elapsed += new ElapsedEventHandler(OnTimer);
            timer.Start();
        }

        private void OnTimer(object sender, ElapsedEventArgs e)
        {
            // Hành động lặp lại: Ghi log "Tôi vẫn đang sống"
            log.Info($"Service is running is running... Time: {DateTime.Now}");
        }

        protected override void OnStop()
        {
            timer.Stop();
            log.Info("=== LEARNING SERVICE STOPPED ===");
        }
    }
}