using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Runtime.InteropServices; 
using System.Windows.Shapes;
using System.Windows.Forms;

namespace OverwatchFacter
{

    /// <summary>
    /// MainCore.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainCore : Window
    {
        
        public MainCore()
        {
            InitializeComponent();
            /*
            while (true)
            {
                System.Threading.Thread.Sleep(3000);
                
            }*/
        }

        
        int Info = 0;

        private void Setting_Click(object sender, RoutedEventArgs e)
        {
            SettingVoice aaa = new SettingVoice();
            aaa.Show();
        }
        private void StartSkill_Click(object sender, RoutedEventArgs e)
        {
            Core a = new Core("hello");

        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            //XmlMody mody = new XmlMody();
            //mody.Access();
        }
    }
}
