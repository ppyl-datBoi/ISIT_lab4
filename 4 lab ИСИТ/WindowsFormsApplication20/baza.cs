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
    public partial class baza : Form
    {
        public baza()
        {
            InitializeComponent();
        }

        private void variousBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.variousBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bazaDataSet);

        }

        private void variousBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.variousBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bazaDataSet);

        }

        private void baza_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bazaDataSet.various". При необходимости она может быть перемещена или удалена.
            this.variousTableAdapter.Fill(this.bazaDataSet.various);

        }
    }
}
