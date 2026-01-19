using System;
using System.Windows.Forms;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using System.Text;
using System.Threading.Tasks;

namespace LocalCenterForm
{
    public partial class MainForm : Form
    {
        private IMqttClient _client;
        private System.ComponentModel.IContainer components = null;

        public MainForm()
        {
            InitializeComponent();
            this.Text = "Learning Project - Simple Control Form"; // Đánh dấu phiên bản học tập
            InitializeMQTT();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "MainForm";
        }

        private async void InitializeMQTT()
        {
            try 
            {
                var factory = new MqttFactory();
                _client = factory.CreateMqttClient();

                // Cấu hình kết nối cơ bản
                var options = new MqttClientOptionsBuilder()
                    .WithTcpServer("broker.hivemq.com", 1883) // Dùng broker công cộng để test
                    .WithClientId("Student_Learning_Client")
                    .Build();

                // Xử lý khi nhận tin nhắn
                _client.UseApplicationMessageReceivedHandler(e =>
                {
                    string msg = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                    
                    // Chỉ đơn giản là hiện tin nhắn lên giao diện
                    Invoke((MethodInvoker)delegate {
                        MessageBox.Show($"Nhận tin nhắn từ topic {e.ApplicationMessage.Topic}:\n{msg}");
                    });
                });

                // Kết nối
                await _client.ConnectAsync(options);
                
                // Subscribe thử một topic đơn giản
                await _client.SubscribeAsync(new MqttTopicFilterBuilder().WithTopic("learning/test").Build());

                MessageBox.Show("Đã kết nối MQTT thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }
    }
}