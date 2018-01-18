using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestDenisSkornyakov
{
    public partial class Form1 : Form
    {
        public static DateTime CalcWorkingDays(DateTime _a, double _n, List<string> _dirs, double _rb)
        {
            bool flag = false;
            while (_n > -1)  //Пока у нас есть рабочие дни, идем по циклу, прибавляя/вычитая дни, если текущий день не находится в списке выходных или праздников, то вычитаем один рабочий день
            {
                foreach (var Dir in _dirs)
                    if (CalcFiles(_a, Dir) == true)
                        flag = true;
                if (flag == true)
                {
                    _a = _a.AddDays(_rb);
                }
                else if ((flag == false) && (_n != 0))
                {
                    _a = _a.AddDays(_rb);
                    _n -= 1;
                }
                else if ((flag == false) && (_n == 0))
                    _n -= 1;
                flag = false;
            }
            return _a;
        }
        public void FileSearchFunction(string _dir, List<string> _dirs) //Функция, которая ищет и сохраняет директорию каждого файла в выбранной папке
        {
            System.IO.DirectoryInfo DI = new System.IO.DirectoryInfo(_dir);
            System.IO.DirectoryInfo[] SubDir = DI.GetDirectories();
            for (int i = 0; i < SubDir.Length; ++i)
                this.FileSearchFunction(SubDir[i].FullName, _dirs);
            System.IO.FileInfo[] FI = DI.GetFiles();
            for (int i = 0; i < FI.Length; ++i)
                _dirs.Add(FI[i].FullName);
        }
        public Form1()
        {
            InitializeComponent();
        }
        public static bool CalcFiles(DateTime _a, string _dir) //Функция, которая проверяет выпадает ли текущий день на праздник или выходной
        {
            string line;
            string[] lstring;
            DateTime check;
            System.IO.StreamReader file =
                new System.IO.StreamReader(_dir);
            while ((line = file.ReadLine()) != null)
            {
                lstring = line.Split(' ');
                foreach (string str in lstring)
                {
                    check = Convert.ToDateTime(str);
                    if (check == _a)
                        return true;
                }
            }
            file.Close();
            return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            List<string> Dirs = new List<string>();
            double N = Convert.ToDouble(textBox1.Text);
            DateTime a = Convert.ToDateTime(dateTimePicker1.Text);
            double RadioButton = 1;
            if (radioButton2.Checked == true)  //Выбираем в какую сторону идет поиск
                RadioButton = -1;
            if (textBox2.Text != String.Empty && System.IO.Directory.Exists(textBox2.Text))
                this.FileSearchFunction(textBox2.Text, Dirs); //Получаем путь к каждому файлу в виде списка
            a = CalcWorkingDays(a, N, Dirs, RadioButton);         
            label4.Text = Convert.ToString(a);
            label3.Visible = true;
            label4.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
                FolderBrowserDialog FBD = new FolderBrowserDialog();
                if (FBD.ShowDialog() == DialogResult.OK)
                {
                    textBox2.Text = FBD.SelectedPath;
                }
        }
    }
}
