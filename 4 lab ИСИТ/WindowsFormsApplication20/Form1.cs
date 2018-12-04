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
        }

        private void variousBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(button6.Text == "Начать голосование")
            {
                //очистка значений
                solu.ClearVotes();
                listBox1.Items.Clear();
                dataGridView7.Rows.Clear();
                //добавление кандидатов
                listBox1.Items.Add("Лёха");
                listBox1.Items.Add("Не Лёха");
                listBox1.Items.Add("Староста");
                listBox1.Items.Add("Не Староста");
                listBox1.Items.Add("Боулер");
                listBox1.Items.Add("Не боулер");
                listBox1.Items.Add("Симор");
                solu.CreateVotesMass(listBox1.Items.Count);
                for (int i = 0; i < listBox1.Items.Count; i++)
                    dataGridView7.Rows.Add(i + 1, listBox1.Items[i], "0", "0%");
                //различные параметры
                label1.Text = "Избиратель № 1";
                button6.Text = "Завершить голосование";
                button3.Enabled = true;
                dataGridView7.Enabled = true;
                listBox1.Enabled = true;
                label1.Enabled = true;
            }
            else
            {
                button6.Text = "Голосование завершено";
                button3.Enabled = false;
                listBox1.Enabled = false;
                button6.Enabled = false;
                label1.Enabled = false;
                int[] rez = solu.SelectPobeditel();
                string resultat;
                if (solu.votes[rez[1]] == solu.votes[rez[0]]) resultat = "Победителя нет";
                else resultat = "Победитель " + listBox1.Items[rez[0]];
                richTextBox1.Text = resultat + ", так как лучшие результаты набрали: " + 
                    listBox1.Items[rez[0]] + ", набрал " + solu.votes[rez[0]] + " голосов и " + 
                    listBox1.Items[rez[1]] + ", набрал " + solu.votes[rez[1]] + " голосов";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите кандидата!");
                return;
            }
            solu.Bolshinstvo(listBox1.SelectedIndex);
            for (int i = 0; i < solu.votes.Length; i++)
                dataGridView7.Rows[i].Cells[2].Value = solu.votes[i];
            for (int i = 0; i < solu.percents.Length; i++)
                dataGridView7.Rows[i].Cells[3].Value = solu.percents[i].ToString() + "%";
            label1.Text = "Избиратель № " + solu.chelik;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //обнуляем список голосов 
        {
            if(tabControl1.SelectedIndex == 0)
            {
                dataGridView7.Rows.Clear();
                button6.Text = "Начать голосование";
                button6.Enabled = true;
                richTextBox1.Text = "";
                button2.Enabled = false;
                listBox1.Enabled = false;
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
                    array[i, j] = Convert.ToInt32(dataGridView3[j, i].Value);
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
            string[,] array = new string[dataGridView9.RowCount - 1, dataGridView9.ColumnCount];
            for (int i = 0; i < dataGridView9.RowCount - 1; i++)
            {
                for (int j = 0; j < dataGridView9.ColumnCount; j++)
                {
                    array[i, j] = dataGridView9[j, i].Value.ToString();
                }
            }

            int[] candidat = solu.board(array, dataGridView9.RowCount, dataGridView9.ColumnCount);
            dataGridView8.Rows.Clear();
            int max, maxi;
            for (int i = 0; i<candidat.Length; i++)
            {
                dataGridView8.Rows.Add(candidat[i].ToString());
            }

            solu.maximum(candidat,out max,out maxi);

            richTextBox2.Text = "Победитель: \r\nкандидат " + dataGridView9.Columns[maxi].HeaderText + " набрал " + max + " баллов";//\"a" + maxi + "\"
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

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
    }

