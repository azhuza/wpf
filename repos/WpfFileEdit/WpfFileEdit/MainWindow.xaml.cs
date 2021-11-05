
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;



namespace WpfFileEdit
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void newfile_Click(object sender, RoutedEventArgs e)
        {
           //清空文本内容并弹出一个新的窗体
            textfile.Clear();
            fileedit.Show();
           
        }

        private void openfile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Filter = "Text Files | *.txt";
            
            if (true == openDlg.ShowDialog())
            {
                string dataFromFile = File.ReadAllText(openDlg.FileName, Encoding.Default);   //ReadAllText(filepath)不能读取ANSI编码的txt
                textfile.Text = dataFromFile;
            }
        

    }

        private void savefile_Click(object sender, RoutedEventArgs e)
        {

            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = "Text Files | *.txt"; //只能保存成TXT文本文件  
            
           if (true == saveDlg.ShowDialog())
            {
                File.WriteAllText(saveDlg.FileName, textfile.Text,Encoding.Default);
            }

        }

        private void cut_Click(object sender, RoutedEventArgs e)
        {
            textfile.Cut();
        }

        private void copy_Click(object sender, RoutedEventArgs e)
        {
            textfile.Copy();
        }

        private void paste_Click(object sender, RoutedEventArgs e)
        {
            textfile.Paste();
        }

        private void subtitut_Click(object sender, RoutedEventArgs e)
        {
            textfile.Cut();
            textfile.Paste();
        }

            private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           
            MessageBoxResult result = MessageBox.Show("是否保存？", "提示", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = "Text Files | *.txt"; //只能保存成TXT文本文件  
            if (result == MessageBoxResult.Yes)
            {
                { 

                if (true == saveDlg.ShowDialog())
                {
                    File.WriteAllText(saveDlg.FileName, textfile.Text);
                }
            }
                e.Cancel = false;
                }
                else
                {
                    e.Cancel = false;
                }
            }
        }
    
}
