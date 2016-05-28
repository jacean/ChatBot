using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syn.Bot;
using Syn.EmotionML;
using System.IO;

namespace ChatBot
{
    public partial class Form1 : Form
    {
        public SynBot Chatbot;
        public Form1()
        {
            InitializeComponent();
            Chatbot = new SynBot();
            Chatbot.PackageManager.LoadFromString(File.ReadAllText("chatBot.simlpk"));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = Chatbot.Chat(InputBox.Text);
            var time = DateTime.Now.ToString("yy/MM/dd-HH:mm:ss");

            Emotion emo=result.UserEmotion;
            OutputBox.Text = string.Format("{2}    -*-*-{3}-*-*- \r\nUser: {0}\r\nBot: {1}\r\n\r\n", InputBox.Text, result.BotMessage, OutputBox.Text,time);
            
            InputBox.Text = string.Empty;
        }

        private void OutputBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
