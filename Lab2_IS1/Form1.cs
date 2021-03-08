using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2_IS1
{
    public partial class Form1 : Form
    {
        public char[] symbols;

        public Dictionary<char, int> dictionary1;


        public string str;

        public string key;


        public Form1()
        {
            InitializeComponent();
            dictionary1 = new Dictionary<char, int>();
            symbols = new char[72] { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к',
                        'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ' , 'ъ', 'ы', 'ь', 'э', 'ю', 'я',
                            'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К',
                            'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х',
                                'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь',
                                'Э', 'Ю', 'Я',
                                ' ', '.', ':', '!', '?', ','};




            for (int i = 0; i < symbols.Length; i++)
            {
                dictionary1.Add(symbols[i], i + 1);
            }


            str = textBox1.Text;
            key = textBox2.Text;
            button2.Enabled = false;


            button2.Enabled = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str1 = "";

            str = textBox1.Text;
            key = textBox2.Text;
            try
            {
                for (int i = 0; i < str.Length; i++)
                {
                    str1 += (dictionary1[str[i]] + dictionary1[key[i % key.Length]]) % symbols.Length + " ";
                }

                textBox3.Text = str1.Substring(0, str1.Length - 1);
            }
            catch(DivideByZeroException ex)
            {
                textBox1.Text = "Пожалуйста, необходимо ввести ключ";
            }
            catch(Exception ex)
            {
                textBox1.Text = "Надо ввести текст";
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string message = "";

            key = textBox2.Text;

            string strCode = "";

            strCode = textBox3.Text;
            string[] strCodet;
            strCodet = strCode.Split(' ');
            try
            {
                /* foreach (var s in strCodet)
                 {
                     int keyt = dictionary1.FirstOrDefault(spt => spt.Key == key[i % key.Length]).Value;

                     string substr = strCode[i].ToString();
                     if ((Convert.ToInt32(substr) - keyt) % symbols.Length > 0)
                     {
                         message = message + dictionary1.FirstOrDefault(dp => dp.Value == (((Convert.ToInt32(substr) - keyt) % symbols.Length))).Key;
                     }
                     else
                     {
                         message = message + dictionary1.FirstOrDefault(dp => dp.Value == (symbols.Length - Math.Abs(((Convert.ToInt32(substr) - keyt) % symbols.Length)))).Key;
                     }
                 }
                 label5.Text = message;*/
                for (int i = 0; i < strCodet.Length; i = i + 1)
                {

                    int keyt = dictionary1.FirstOrDefault(spt => spt.Key == key[i % key.Length]).Value;

                    string substr = strCodet[i].ToString();
                    if ((Convert.ToInt32(substr) - keyt) % symbols.Length > 0)
                    {
                        message = message + dictionary1.FirstOrDefault(dp => dp.Value == (((Convert.ToInt32(substr) - keyt) % symbols.Length))).Key;
                    }
                    else
                    {
                        message = message + dictionary1.FirstOrDefault(dp => dp.Value == (symbols.Length - Math.Abs(((Convert.ToInt32(substr) - keyt) % symbols.Length)))).Key;
                    }


                }
            }
            catch (DivideByZeroException ex)
            {
                label5.Text = "Введите ключ, пожалуйста!";
            }

            catch (Exception ex)
            {
                label5.Text = "Повторите попытку, пожалуйста!"; 
            }

            label5.Text = message;
        }
    }
}
