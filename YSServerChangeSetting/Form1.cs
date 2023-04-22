using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YSServerChangeSetting
{
    public partial class Form1 : Form
    {
        String[] directory;
        List<String> directoryFullName = new List<string>();
        String[] fileNames;
        List<String> fileNamesFullName = new List<string>();
        public Form1()
        {
            InitializeComponent();
            
        }
        //获取配置文件信息
        private void GetDataFromDisk(object sender, EventArgs e)
        {
            
            textBox1.Text = Config.ReadConfig("GamePath");
            textBox2.Text = Config.ReadConfig("CNBackupPath");
            textBox3.Text = Config.ReadConfig("OSBackupPath");
            directory = Config.ReadConfig("CNDic").Split(',');
            foreach (String s in directory) {
                listBox1.Items.Add(s);
            }
            fileNames = Config.ReadConfig("CNFileNames").Split(',');
            foreach (String s in fileNames)
            {
                listBox2.Items.Add(s);
            }
            directory = Config.ReadConfig("OSDic").Split(',');
            foreach (String s in directory)
            {
                listBox3.Items.Add(s);
            }
            fileNames = Config.ReadConfig("OSFileNames").Split(',');
            foreach (String s in fileNames)
            {
                listBox4.Items.Add(s);
            }
        }
        //设置游戏路径
        private void DirectorySelect1(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog(this);
            textBox1.Text = folderBrowserDialog1.SelectedPath;
        }
        //设置CN备份路径
        private void DirectorySelect2(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog(this);
            textBox2.Text = folderBrowserDialog1.SelectedPath;

            if (folderBrowserDialog1.SelectedPath != null && folderBrowserDialog1.SelectedPath != "")
            {
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                int len = folderBrowserDialog1.SelectedPath.Length;
                LoopDirectory(folderBrowserDialog1.SelectedPath, len);
            }
        }
        //设置OS备份路径
        private void DirectorySelect3(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog(this);
            textBox3.Text = folderBrowserDialog1.SelectedPath;

            if (folderBrowserDialog1.SelectedPath != null && folderBrowserDialog1.SelectedPath != "")
            {
                listBox3.Items.Clear();
                listBox4.Items.Clear();
                int len = folderBrowserDialog1.SelectedPath.Length;
                LoopDirectory2(folderBrowserDialog1.SelectedPath, len);
            }
        }
        //读取目标服务器 游戏文件
        private void DirectorySelect4(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog(this);
            if (folderBrowserDialog1.SelectedPath != null && folderBrowserDialog1.SelectedPath != "") {
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                int len = folderBrowserDialog1.SelectedPath.Length;
                LoopDirectory(folderBrowserDialog1.SelectedPath,len);
            }
        }
        //遍历文件夹CN
        private void LoopDirectory(String fullName, int startIndex) {
            DirectoryInfo directInfo = new DirectoryInfo(fullName);
            foreach (FileInfo f in directInfo.GetFiles())
            {
                listBox2.Items.Add(f.FullName.Substring(startIndex+1));
                fileNamesFullName.Add(f.FullName);
            }
            foreach (DirectoryInfo d in directInfo.GetDirectories()) {
                if (d.Exists) {
                    listBox1.Items.Add(d.FullName.Substring(startIndex+1));
                    directoryFullName.Add(d.FullName);
                    LoopDirectory(d.FullName,startIndex);
                }
                
            }
        }

        //遍历文件夹2OS
        private void LoopDirectory2(String fullName, int startIndex)
        {
            DirectoryInfo directInfo = new DirectoryInfo(fullName);
            foreach (FileInfo f in directInfo.GetFiles())
            {
                listBox4.Items.Add(f.FullName.Substring(startIndex + 1));
                fileNamesFullName.Add(f.FullName);
            }
            foreach (DirectoryInfo d in directInfo.GetDirectories())
            {
                if (d.Exists)
                {
                    listBox3.Items.Add(d.FullName.Substring(startIndex + 1));
                    directoryFullName.Add(d.FullName);
                    LoopDirectory2(d.FullName, startIndex);
                }

            }
        }

        private void SaveConfig(object sender, EventArgs e)
        {
            Config.WriteConfig("GamePath", textBox1.Text);
            Config.WriteConfig("CNBackupPath", textBox2.Text);
            Config.WriteConfig("OSBackupPath", textBox3.Text);
            //文件夹列表
            directory = new String[listBox1.Items.Count];
            listBox1.Items.CopyTo(directory, 0);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < directory.Length; i++) {
                sb.Append(directory[i]);
                if (i < directory.Length - 1) {
                    sb.Append(",");
                }
            }
            Config.WriteConfig("CNDic", sb.ToString());
            //文件列表
            fileNames = new String[listBox2.Items.Count];
            listBox2.Items.CopyTo(fileNames, 0);
            StringBuilder sbFileNames = new StringBuilder();
            for (int i = 0; i < fileNames.Length; i++)
            {
                sbFileNames.Append(fileNames[i]);
                if (i < fileNames.Length - 1)
                {
                    sbFileNames.Append(",");
                }
            }
            Config.WriteConfig("CNFileNames", sbFileNames.ToString());
            //文件夹列表
            directory = new String[listBox3.Items.Count];
            listBox3.Items.CopyTo(directory, 0);
            sb = new StringBuilder();
            for (int i = 0; i < directory.Length; i++)
            {
                sb.Append(directory[i]);
                if (i < directory.Length - 1)
                {
                    sb.Append(",");
                }
            }
            Config.WriteConfig("OSDic", sb.ToString());
            //文件列表
            fileNames = new String[listBox4.Items.Count];
            listBox4.Items.CopyTo(fileNames, 0);
            sbFileNames = new StringBuilder();
            for (int i = 0; i < fileNames.Length; i++)
            {
                sbFileNames.Append(fileNames[i]);
                if (i < fileNames.Length - 1)
                {
                    sbFileNames.Append(",");
                }
            }
            Config.WriteConfig("OSFileNames", sbFileNames.ToString());
            //HandleSave(sender as Button);
        }

        private void HandleSave(Button tx)
        {
            //文件夹创建
            for (int i = 0; i < directoryFullName.Count; i++)
            {
                if (Directory.Exists(textBox2.Text + "\\" + Config.ReadConfig("TargetServer") + "\\" + directory[i]) == false)
                {
                    Directory.CreateDirectory(textBox2.Text + "\\" + Config.ReadConfig("TargetServer") + "\\" + directory[i]);
                }
                if (Directory.Exists(textBox2.Text + "\\" + Config.ReadConfig("SourceServer") + "\\" + directory[i]) == false)
                {
                    Directory.CreateDirectory(textBox2.Text + "\\" + Config.ReadConfig("SourceServer") + "\\" + directory[i].Replace(Config.ReadConfig("TargetDataFileName"), Config.ReadConfig("SourceDataFileName")));
                }
            }
            if (tx.Text == "保存并剪切")
            {
                //文件剪切
                for (int i = 0; i < fileNamesFullName.Count; i++)
                {
                    if (File.Exists(textBox2.Text + "\\" + Config.ReadConfig("TargetServer") + "\\" + fileNames[i]) == false)
                    {
                        File.Move(fileNamesFullName[i], textBox2.Text + "\\" + Config.ReadConfig("TargetServer") + "\\" + fileNames[i]);
                    }
                }
                //文件夹删除
/*                for (int i = 0; i < directoryFullName.Count; i++)
                {
                    Directory.Delete(directoryFullName[i]);
                }*/
            }
            else if (tx.Text == "保存并复制")
            {
                for (int i = 0; i < fileNamesFullName.Count; i++)
                {
                    if (File.Exists(textBox2.Text + "\\" + Config.ReadConfig("TargetServer") + "\\" + fileNames[i]) == false)
                    {
                        File.Copy(fileNamesFullName[i], textBox2.Text + "\\" + Config.ReadConfig("TargetServer") + "\\" + fileNames[i]);
                    }
                }

            }
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
