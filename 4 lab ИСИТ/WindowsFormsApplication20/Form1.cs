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
            MessageBox.Show("Добро пожаловать");
            listBox1.Items.Add("Лёха");
            listBox1.Items.Add("Не Лёха");

            for(int i = 0; i<listBox1.Items.Count;i++)
            dataGridView7.Rows.Add(i+1, listBox1.Items[i], "0", "0%");

            solu.ClearVotes();
            solu.CreateVotesMass(listBox1.Items.Count);
            //label1.Text = "Избиратель № 1";
            label3.Text = "1";
           
            //MessageBox.Show("Спасибо за ответы!");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //variousDataGridView.Rows[listBox1.SelectedIndex].Cells[2].Value = Convert.ToInt32(variousDataGridView.Rows[listBox1.SelectedIndex].Cells[2].Value) + 1;
            //MessageBox.Show("Спасибо, что выбрали: " + listBox1.SelectedItem.ToString());
        }

        private void button1_Click(object sender, EventArgs e) //обнуляем список голосов ЗА
        {
            //foreach (DataGridViewRow check in variousDataGridView.Rows)
            //{
            //    check.Cells[2].Value = 0;
            //}
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

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            solu.Bolshinstvo(listBox1.SelectedIndex);
            for (int i = 0; i < solu.votes.Length; i++)
                dataGridView7.Rows[i].Cells[2].Value = solu.votes[i];
            for (int i = 0; i < solu.percents.Length; i++)
                dataGridView7.Rows[i].Cells[3].Value = (Math.Round(solu.percents[i],4)*100).ToString() + "%";
            int b = Convert.ToInt32(label3.Text);
            b++;
            label3.Text = b.ToString();
        }
    }
    }

