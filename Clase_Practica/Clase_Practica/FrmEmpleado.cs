using Clase_Practica.Models;
using Clase_Practica.poco;
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
    public partial class FrmEmpleado : Form
    {
        DataTable dt;
        public EmpleadoModel EmpleadoModel { get; set; }
        public FrmEmpleado()
        {
            InitializeComponent();
        }

        private void FrmEmpleado_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Nombres");
            dt.Columns.Add("Apellidos");
            dt.Columns.Add("Cedula");
            dt.Columns.Add("Telefono");
            dt.Columns.Add("Correo");
            dt.Columns.Add("Profesion");
            dt.Columns.Add("Cargo");
            dt.Columns.Add("Salario");
            dgvEmpleados.DataSource = dt;
            LoadEmpleados();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddDialog addDialog = new AddDialog();
            addDialog.EmpleadoModel = EmpleadoModel;
            addDialog.ShowDialog();
        }

        private void LoadEmpleados()
        {
            if (EmpleadoModel.GetAll() == null)
            {
                return;
            }
            foreach (Empleado e in EmpleadoModel.GetAll())
            {
                DataRow dr = dt.NewRow();
                dr["ID"] = e.Id;
                dr["Nombres"] = e.Nombres;
                dr["Apellidos"] = e.Apellidos;
                dr["Cedula"] = e.Cedula;
                dr["Telefono"] = e.Cedula;
                dr["Correo"] = e.Correo;
                dr["Profesion"] = e.Profesion;
                dr["Cargo"] = e.Cargo;
                dr["Salario"] = e.Salario;
                dt.Rows.Add(dr);
            }
            dgvEmpleados.DataSource = dt;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dgvEmpleados.CurrentCell.RowIndex;
                EmpleadoModel.Remove(index);
                dgvEmpleados.Rows.RemoveAt(index);
                MessageBox.Show("Empleado eliminado con éxito!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al eliminar");
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dgvEmpleados.DataSource;
            bs.Filter = "Nombres like '%" + textBox1.Text + "%'";
            //bs.Filter = "Apellidos like '%" + textBox1.Text + "%'";
            //bs.Filter = "Cedula like '%" + textBox1.Text + "%'";
            dgvEmpleados.DataSource = bs;
        }
    }
}
