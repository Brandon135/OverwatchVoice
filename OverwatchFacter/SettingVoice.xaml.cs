using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

using Microsoft.Speech.Recognition;
using Microsoft.Speech.Synthesis;

namespace OverwatchFacter
{
    /// <summary>
    /// SettingVoice.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SettingVoice
    {
        public SettingVoice()
        {
            InitializeComponent();
            initRS();
            initTTS();
            tts.SpeakAsync("반갑습니다 음성인식 테스터입니다");
        }
        public void initRS()
        {
            try
            {
                SpeechRecognitionEngine sre = new SpeechRecognitionEngine(new CultureInfo("ko-KR"));

                Grammar g = new Grammar(@"C:\Users\q\source\repos\OverwatchFacter\OverwatchFacter\mccree.xml");
                sre.LoadGrammar(g);

                sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);
                sre.SetInputToDefaultAudioDevice();
                sre.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception e)
            {

            }
        }
        SpeechSynthesizer tts;

        public void initTTS()
        {
            try
            {
                tts = new SpeechSynthesizer();
                tts.SelectVoice("Microsoft Server Speech Text to Speech Voice (ko-KR, Heami)");
                tts.SetOutputToDefaultAudioDevice();
                tts.Volume = 100;
            }
            catch (Exception e)
            {

            }
        }
        void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            label1.Content = e.Result.Text;

            switch (e.Result.Text)
            {
                case "컴퓨터":
                    tts.SpeakAsync("네 컴퓨터입니다");
                    break;

                case "안녕":
                    tts.SpeakAsync("반갑습니다 음성인식 테스터입니다");
                    break;

                case "종료":
                    {
                        tts.Speak("프로그램을 종료합니다");
                        Application.Exit();
                        break;
                    }
            }
        } 
    }
}
