using Clase_Practica.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clase_Practica
{
    public partial class Form1 : Form
    {
        EmpleadoModel empleadoModel;
        public Form1()
        {
            InitializeComponent();
        }

        private void empleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEmpleado frmEmpleado = new FrmEmpleado();
            frmEmpleado.EmpleadoModel = empleadoModel;
            frmEmpleado.MdiParent = this;
            frmEmpleado.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            empleadoModel = new EmpleadoModel();
        }

        private void tsAdd_Click(object sender, EventArgs e)
        {
            AddDialog addDialog = new AddDialog();
            addDialog.EmpleadoModel = empleadoModel;
            addDialog.ShowDialog();
        }
    }
}
