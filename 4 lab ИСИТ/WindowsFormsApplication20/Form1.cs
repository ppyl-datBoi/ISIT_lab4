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
            this.variousTableAdapter.Fill(this.bazaDataSet.various);

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
            foreach(DataGridViewRow dgw in dataGridView1.Rows) //для каждого эксперта высчитываем
            {
                for(int i=0; i<dataGridView1.ColumnCount; i++) //главный элемент
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++) //элемент с которым сравниваем
                    {
                        if(i != j) //не сравнимаем с самим собой
                        {
                            if (Convert.ToInt32(dgw.Cells[i].Value) < Convert.ToInt32(dgw.Cells[j].Value)) //если главный элемент значимее элемента для сравнения, то
                            //  if(Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value) > Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value))
                            {
                                //listBox2.Items. = Convert.ToInt32(listBox2.Items[1]) + 1;
                                dataGridView2.Rows[i].Cells[0].Value = Convert.ToInt32(dataGridView2.Rows[i].Cells[0].Value) + 1; //в таблицу результатов добавляем +1
                                   
                            }
                        }
                    }
                }
            }
           
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgw in dataGridView3.Rows) //для каждого эксперта высчитываем
            {
                for (int i = 0; i < dataGridView3.ColumnCount; i++) //главный элемент
                {
                    for (int j = 0; j < dataGridView3.ColumnCount; j++) //элемент с которым сравниваем
                    {
                        if (i != j) //не сравнимаем с самим собой
                        {
                            if (Convert.ToInt32(dgw.Cells[i].Value) < Convert.ToInt32(dgw.Cells[j].Value)) //если главный элемент значимее элемента для сравнения, то
                            //  if(Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value) > Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value))
                            {
                                //listBox2.Items. = Convert.ToInt32(listBox2.Items[1]) + 1;
                                dataGridView4.Rows[i].Cells[0].Value = Convert.ToInt32(dataGridView4.Rows[i].Cells[0].Value) + 1; //в таблицу результатов добавляем +1

                            }
                            else
                            {
                                dataGridView4.Rows[i].Cells[0].Value = Convert.ToInt32(dataGridView4.Rows[i].Cells[0].Value) - 1;
                            }
                        }
                    }
                }
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            //int[,] ar = [5,5];
            
                for (int i = 0; i < dataGridView5.ColumnCount; i++) //главный элемент
                {
                    for (int j = 0; j < dataGridView5.ColumnCount; j++) //элемент с которым сравниваем
                    {
                        if (i != j) //не сравнимаем с самим собой
                        {
                            for (int k = 0; k < dataGridView5.RowCount; k++)
                            {
                                if (Convert.ToInt32(dataGridView5.Rows[k].Cells[i].Value) < Convert.ToInt32(dataGridView5.Rows[k].Cells[j].Value)) //если главный элемент значимее элемента для сравнения, то
                                                                                                               //  if(Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value) > Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value))
                                {
                                    //ar[i, j] ++;
                                    dataGridView7[i, j].Value = Convert.ToInt32(dataGridView7[i, j].Value) + 1;
                                    //listBox2.Items. = Convert.ToInt32(listBox2.Items[1]) + 1;
                                    // dataGridView4.Rows[i].Cells[0].Value = Convert.ToInt32(dataGridView4.Rows[i].Cells[0].Value) + 1; //в таблицу результатов добавляем +1
                                }
                            }
                        }
                    }
                }
            
                foreach (DataGridViewRow sp in dataGridView7.Rows)
            {

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }
    }
    }

