using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using Microsoft.Speech.Recognition;
using Microsoft.Speech.Synthesis;

namespace OverwatchFacter
{
    class Core
    {

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte vk, byte scan, int flags, ref int extrainfo);
        int Info = 0;

        const byte AltKey = 18;
        const int KEYUP = 0x0002;

        private string Hero;
        SpeechSynthesizer tts;
        public Core(string ChooseHero)
        {
            this.Hero = ChooseHero;
            initRS();
            initTTS();
            tts.Speak("헤헤헤헤헤헤");
        }
        public void initRS()// 선택한 영웅
        {
            try
            {
                SpeechRecognitionEngine sre = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("ko-KR"));
                Grammar g = new Grammar(AppDomain.CurrentDomain.BaseDirectory+@"\mccree.xml");//매개변수1
                sre.LoadGrammar(g);

                sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);
                sre.SetInputToDefaultAudioDevice();
                sre.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception e)
            {

            }
        }
        

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
        void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)//건들 ㄴㄴ
        {
            Console.Write(e.Result.Text);

            switch (e.Result.Text)
            {
                case "안녕":
                    tts.SpeakAsync("반갑습니다 음성인식 테스터입니다");
                    keybd_event((byte)Keys.E, 0, 0, ref Info);
                    
                    break;
                case "훗":
                    tts.SpeakAsync("쉬프트 키가 눌림");
                    keybd_event((byte)Keys.LShiftKey, 0, 0, ref Info);
                    break;
                case "헛":
                    tts.SpeakAsync("쉬프트 키가 눌림");
                    keybd_event((byte)Keys.L, 0, 0, ref Info);
                    break;
                case "험":
                    tts.SpeakAsync("쉬프트 키가 눌림");
                    keybd_event((byte)Keys.S, 0, 0, ref Info);
                    break;
                case "석양이":
                    tts.SpeakAsync("반갑습니다 음성인식 테스터입니다");
                    keybd_event((byte)Keys.Q, 0, 0, ref Info);
                    break;
                case "석양이진다":
                    tts.SpeakAsync("반갑습니다 음성인식 테스터입니다");
                    keybd_event((byte)Keys.Q, 0, 0, ref Info);
                    Thread.Sleep(3000);
                    keybd_event((byte)Keys.Q, 0, KEYUP, ref Info);
                    break;
                case "석양이 진다":
                    tts.SpeakAsync("반갑습니다 음성인식 테스터입니다");
                    keybd_event((byte)Keys.Q, 0, 0, ref Info);
                    break;
            }
        }

        void mccree(string receive)
        {
            switch (receive)
            {
                case "안녕":
                    tts.SpeakAsync("반갑습니다 음성인식 테스터입니다");
                    break;
                case "훗":
                    tts.SpeakAsync("쉬프트 키가 눌림");
                    break;
                case "헛":
                    tts.SpeakAsync("쉬프트 키가 눌림");
                    break;
                case "험":
                    tts.SpeakAsync("쉬프트 키가 눌림");
                    break;
                case "석양이":
                    tts.SpeakAsync("반갑습니다 음성인식 테스터입니다");
                    break;
                case "진다":
                    tts.SpeakAsync("반갑습니다 음성인식 테스터입니다");
                    break;
                case "석양이 진다":
                    tts.SpeakAsync("석양이 진다");
                    break;
                case "서걍이 진다":
                    tts.SpeakAsync("석양이 진다");
                    break;
            }
        }
       
        void LineHeart(string receive)
        {
            switch (receive)
            {
                case "망치나가신다":
                    tts.SpeakAsync("반갑습니다 음성인식 테스터입니다");
                    break;
                case "화염강타":
                    tts.SpeakAsync("쉬프트 키가 눌림");
                    break;
                case "험":
                    tts.SpeakAsync("쉬프트 키가 눌림");
                    break;
                case "돌진":
                    tts.SpeakAsync("석양이 진다");
                    break;
            }
        }
        void MccreeSkill(string receive)
        {
            switch (receive)
            {
                case "안녕":
                    tts.SpeakAsync("반갑습니다 음성인식 테스터입니다");
                    break;
                case "훗":
                    tts.SpeakAsync("쉬프트 키가 눌림");
                    break;
                case "헛":
                    tts.SpeakAsync("쉬프트 키가 눌림");
                    break;
                case "험":
                    tts.SpeakAsync("쉬프트 키가 눌림");
                    break;
                case "석양이":
                    tts.SpeakAsync("반갑습니다 음성인식 테스터입니다");
                    break;
                case "진다":
                    tts.SpeakAsync("반갑습니다 음성인식 테스터입니다");
                    break;
                case "석양이진다":
                    tts.SpeakAsync("석양이 진다");
                    break;
                case "서걍이 진다":
                    tts.SpeakAsync("석양이 진다");
                    break;
            }
        }
    }
    /*class XmlMody
    {
        public void Access(string E, string shift, string Q, string LOL)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(AppDomain.CurrentDomain.BaseDirectory + @"\mccree.xml");
        
            XPathNavigator nav = xdoc.CreateNavigator();
            XPathNodeIterator nodes = nav.Select("//grammar/rule/one-of");

            while (nodes.MoveNext())
            {
                nodes.Current.MoveToChild("item", "");

                // Tim을 Timothy로 변경
                if (nodes.Current.Value == "석양이")
                {
                    nodes.Current.SetValue("아니 시발개새끼야ㅑㅑㅑㅑㅑㅑㅑㅑㅑㅑㅑㅑㅑㅑㅑㅑㅑㅑㅑㅑㅑㅑㅑㅑㅑㅑㅑㅑㅑㅑ     ");
                }
            }

            // XML 전체 트리를 저장
            using (XmlWriter wr = XmlWriter.Create(AppDomain.CurrentDomain.BaseDirectory + @"\mccree.xml")) 
            {
                nav.WriteSubtree(wr);
            }
            // XML 파일 저장
        }
    }*/
}
