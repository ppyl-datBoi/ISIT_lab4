using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication20
{
    public partial class Form1 : Form
    {
        solution solu = new solution();

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baza b = new baza();
            b.Show();
        }

        private void variousBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.variousBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bazaDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bazaDataSet.various". При необходимости она может быть перемещена или удалена.
            //this.variousTableAdapter.Fill(this.bazaDataSet.various);

            foreach (DataGridViewRow check in variousDataGridView.Rows)
            {
                listBox1.Items.Add(Convert.ToString(check.Cells[1].Value));
            }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Добро пожаловать");
            button3.Visible = true;
            button4.Visible = true;
            button2.Enabled = false;
            button1.Enabled = false;

            foreach (DataGridViewRow spisok in variousDataGridView.Rows)
            {
                //richTextBox1.Text = "Вы готовы выбрать: " + Convert.ToString(spisok.Cells[1].Value) + "?";
                DialogResult dialogResult = MessageBox.Show("Вы готовы выбрать: " + Convert.ToString(spisok.Cells[1].Value) + "?", "ГОЛОСОВАНИЕ", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    int yes = Convert.ToInt32(spisok.Cells[2].Value);
                    yes++;
                    Convert.ToString(spisok.Cells[2].Value = yes);
                }
                else if (dialogResult == DialogResult.No)
                {
                    int no = Convert.ToInt32(spisok.Cells[3].Value);
                    no++;
                    Convert.ToString(spisok.Cells[3].Value = no);
                }
                int max = 0;
                foreach (DataGridViewRow check in variousDataGridView.Rows)
                {
                    if (Convert.ToInt32(check.Cells[2].Value) > max)
                    {
                        max = Convert.ToInt32(check.Cells[2].Value);
                        label3.Text = "На данный момент победитель: " + Convert.ToString(check.Cells[1].Value);
                    }
                }
            }
            MessageBox.Show("Спасибо за ответы!");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            variousDataGridView.Rows[listBox1.SelectedIndex].Cells[2].Value = Convert.ToInt32(variousDataGridView.Rows[listBox1.SelectedIndex].Cells[2].Value) + 1;
            MessageBox.Show("Спасибо, что выбрали: " + listBox1.SelectedItem.ToString());
        }

        private void button1_Click(object sender, EventArgs e) //обнуляем список голосов ЗА
        {
            foreach (DataGridViewRow check in variousDataGridView.Rows)
            {
                check.Cells[2].Value = 0;
            }
        }

        private void button7_Click(object sender, EventArgs e) //подсчет голосов
        {
            //передача в массив
            int[,] array = new int[dataGridView1.RowCount - 1, dataGridView1.ColumnCount];
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    array[i, j] = Convert.ToInt32(dataGridView1[i, j].Value);
                }
            }

            //решение
            int [] reshenie = solu.yavno(array);

            //загружаем решение
            for (int k = 0; k < reshenie.GetLength(0); k++)
            {
              dataGridView2[0,k].Value = reshenie[k];
            }
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //foreach (DataGridViewRow dgw in dataGridView3.Rows) //для каждого эксперта высчитываем
            //{
            //    for (int i = 0; i < dataGridView3.ColumnCount; i++) //главный элемент
            //    {
            //        for (int j = 0; j < dataGridView3.ColumnCount; j++) //элемент с которым сравниваем
            //        {
            //            if (i != j) //не сравнимаем с самим собой
            //            {
            //                if (Convert.ToInt32(dgw.Cells[i].Value) < Convert.ToInt32(dgw.Cells[j].Value)) //если главный элемент значимее элемента для сравнения, то
            //                //  if(Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value) > Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value))
            //                {
            //                    //listBox2.Items. = Convert.ToInt32(listBox2.Items[1]) + 1;
            //                    dataGridView4.Rows[i].Cells[0].Value = Convert.ToInt32(dataGridView4.Rows[i].Cells[0].Value) + 1; //в таблицу результатов добавляем +1

            //                }
            //                else
            //                {
            //                    dataGridView4.Rows[i].Cells[0].Value = Convert.ToInt32(dataGridView4.Rows[i].Cells[0].Value) - 1;
            //                }
            //            }
            //        }
            //    }
            //}

            //передача в массив
            int[,] array = new int[dataGridView3.RowCount - 1, dataGridView3.ColumnCount];
            for (int i = 0; i < dataGridView3.RowCount - 1; i++)
            {
                for (int j = 0; j < dataGridView3.ColumnCount; j++)
                {
                    array[i, j] = Convert.ToInt32(dataGridView3[i, j].Value);
                }
            }

            //решение
            int[] reshenie = solu.kopland(array);

            //загружаем решение
            for (int k = 0; k < reshenie.GetLength(0); k++)
            {
                dataGridView4[0, k].Value = reshenie[k];
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            //решение Симпсона
            int[,] array = new int[dataGridView5.RowCount - 1, dataGridView5.ColumnCount];
            for (int i = 0; i < dataGridView5.RowCount - 1; i++)
            {
                for (int j = 0; j < dataGridView5.ColumnCount; j++)
                {
                    array[i, j] = Convert.ToInt32(dataGridView5[i, j].Value);
                }
            }

            //решение
            int[] reshenie = solu.simpson(array);

            //загружаем решение
            for (int k = 0; k < reshenie.GetLength(0); k++)
            {
                dataGridView6[0, k].Value = reshenie[k];
            }

        }
        

        private void button10_Click(object sender, EventArgs e)
        {
            string[] temp = new string[dataGridView9.RowCount - 1];

            for (int i = 0; i < dataGridView9.RowCount-1; i++)
            {
                temp[i] = "";
                for (int j = 0; j < dataGridView9.ColumnCount; j++)
                {
                    temp[i] += dataGridView9[j,i].Value.ToString();
                }
            }

            List<string> tt = new List<string>();//сами варианты 12345, 12354 и т.д.
            tt.Add( temp[0]);
            List<int> tt2 = new List<int>();//их кол-во
            tt2.Add(1);
            bool a;
            for (int i =1; i < dataGridView9.RowCount - 1; i++)//группируем голоса
            {
                a = false;
                for (int j = 0; j<tt.Count; j++)
                {
                    if (tt[j] == temp[i])
                    {
                        a = true;
                        tt2[j]++;
                    }

                }
                if (!a)
                {
                    tt.Add(temp[i]);
                    tt2.Add(1);
                }
            }
            int candidatcount = dataGridView9.ColumnCount;
            int[] candidat = new int[candidatcount];//candidat[x] += tt2[i] * ball in tt[i]
            for (int i = 0; i<tt.Count; i++)//из всех групп 12345 берем каждую группу отдельно и считаем баллы
                for (int j = 0; j<tt[i].Length; j++)//выбирае каждого кандидата из группы 1>2>3>4>5
                {
                    string pos = Convert.ToString(tt[i][j]);
                    if (j< tt[i].Length-1)//если позиция кандидата не последняя
                    candidat[Convert.ToInt32(pos)-1] += tt2[i] * (candidatcount - j);
                }
            dataGridView8.Rows.Clear();
            int max = 0, maxi = 0;
            for (int i = 0; i<candidat.Length; i++)
            {
                if (candidat[i] > max)
                {
                    max = candidat[i];
                    maxi = i+1;
                }
                dataGridView8.Rows.Add(candidat[i].ToString());
            }


            label4.Text = "Победитель: \nкандидат \"a" + maxi + "\" набрал " + max + " баллов";
        }
        

        private void button11_Click(object sender, EventArgs e)
        {
            //заполнение таблиц
            dataGridView5.ColumnCount = 5;
            string[] row = { "1","3","2","4","5"};
            dataGridView5.Rows.Add(row);
            row = new string[] { "2", "1", "3", "5", "4" };
            dataGridView5.Rows.Add(row);
            row = new string[] { "3", "1", "2", "4", "5" };
            dataGridView5.Rows.Add(row);
            row = new string[] { "2", "3", "4", "5", "1" };
            dataGridView5.Rows.Add(row);
            row = new string[] { "3", "2", "4", "1", "5" };
            dataGridView5.Rows.Add(row);

            for (int i = 0; i < 5; i++)
                dataGridView6.Rows.Add("0");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 5;
            string[] row = { "1", "3", "2", "4", "5" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "2", "1", "3", "5", "4" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "3", "1", "2", "4", "5" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "2", "3", "4", "5", "1" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "3", "2", "4", "1", "5" };
            dataGridView1.Rows.Add(row);

            for (int i = 0; i < 5; i++)
                dataGridView2.Rows.Add("0");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            dataGridView3.ColumnCount = 5;
            string[] row = { "1", "3", "2", "4", "5" };
            dataGridView3.Rows.Add(row);
            row = new string[] { "2", "1", "3", "5", "4" };
            dataGridView3.Rows.Add(row);
            row = new string[] { "3", "1", "2", "4", "5" };
            dataGridView3.Rows.Add(row);
            row = new string[] { "2", "3", "4", "5", "1" };
            dataGridView3.Rows.Add(row);
            row = new string[] { "3", "2", "4", "1", "5" };
            dataGridView3.Rows.Add(row);

            for (int i = 0; i < 5; i++)
                dataGridView4.Rows.Add("0");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            dataGridView9.ColumnCount = 5;
            string[] row = { "1", "3", "2", "4", "5" };
            for (int i = 0; i < 5; i++)
                dataGridView9.Rows.Add(row);

            row = new string[] { "2", "1", "3", "5", "4" };
            for (int i = 0;i<3;i++)
            dataGridView9.Rows.Add(row);

            row = new string[] { "3", "1", "2", "4", "5" };
            for (int i = 0; i < 5; i++)
                dataGridView9.Rows.Add(row);

            
                row = new string[] { "2", "3", "4", "5", "1" };
            for (int i = 0; i < 10; i++)
                dataGridView9.Rows.Add(row);
            
                row = new string[] { "3", "2", "4", "1", "5" };
            for (int i = 0; i < 4; i++)
                dataGridView9.Rows.Add(row);

            for (int i = 0; i < 5; i++)
                dataGridView8.Rows.Add("0");
        }
    }
    }

