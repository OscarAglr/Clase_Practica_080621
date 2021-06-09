using Clase_Practica.Enums;
using Clase_Practica.Models;
using Clase_Practica.poco;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clase_Practica
{
    public partial class AddDialog : Form
    {
        public EmpleadoModel EmpleadoModel { get; set; }
        public FrmEmpleado frmEmpleado;
        int id = 0;
        public AddDialog()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            List<Empleado> sida = new List<Empleado>();
            try
            {
                Regex r = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                string nombres = txtName.Text;
                string apellidos = txtLastName.Text;
                string cedula = txtCedula.Text;
                long telefono = Convert.ToInt64(txtPhone.Text);
                string correo = txtMail.Text;
                if (!r.IsMatch(correo))
                {
                    MessageBox.Show("Correo no válido");
                    return;
                }
                int index1 = cbProfesion.SelectedIndex;
                Profesion profesion = (Profesion)Enum.GetValues(typeof(Profesion))
                                                      .GetValue(index1);
                int index2 = cbCargo.SelectedIndex;
                Cargo cargo = (Cargo)Enum.GetValues(typeof(Cargo))
                                                      .GetValue(index2);
                decimal salario = Convert.ToDecimal(txtSalario.Text);
                
                Empleado emp = new Empleado()
                {
                    Id = id++,
                    Nombres = nombres,
                    Apellidos = apellidos,
                    Cedula = cedula,
                    Telefono = telefono,
                    Correo = correo,
                    Profesion = profesion,
                    Cargo = cargo,
                    Salario = salario
                };
                //MessageBox.Show($"Nombres: {emp.Nombres} \n" +
                //    $"Apellidos: {emp.Apellidos}\n" +
                //    $"Cedula: {emp.Cedula}\n" +
                //    $"Correo: {emp.Correo} \n" +
                //    $"Profesion: {emp.Profesion}\n" +
                //    $"Cargo: {emp.Cargo}\n" + 
                //    $"{emp.Salario}");
                
                EmpleadoModel.AddEmpleado(emp);
                frmEmpleado.dgvEmpleados.Refresh();
                MessageBox.Show("Empleado añadido con éxito");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void validateEmpleado(string nombres, string apellidos, string cedula, long telefono, decimal salario)
        {
            if (string.IsNullOrWhiteSpace(nombres) || string.IsNullOrWhiteSpace(apellidos) || string.IsNullOrWhiteSpace(cedula) || string.IsNullOrWhiteSpace(cedula))
            {
                throw new ArgumentException("Valores vacíos");
            }

            if (salario < 0)
            {
                throw new ArgumentException("El salario no puede ser 0");
            }

            if (telefono <= 0)
            {
                throw new ArgumentException("TAS MAL");
            }
        }

        private void AddDialog_Load(object sender, EventArgs e)
        {
            
            cbProfesion.Items.AddRange(Enum.GetValues(typeof(Profesion))
                                       .Cast<object>()
                                       .ToArray());
            cbCargo.Items.AddRange(Enum.GetValues(typeof(Cargo))
                                       .Cast<object>()
                                       .ToArray());
            cbProfesion.SelectedIndex = 0;
            cbCargo.SelectedIndex = 0;
            cbProfesion.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCargo.DropDownStyle = ComboBoxStyle.DropDownList;
            frmEmpleado = new FrmEmpleado();
            
            if (EmpleadoModel.GetAll() == null)
            {
                id = 0;
            }
            else
            {
                id = EmpleadoModel.GetAll().Length;
            }
        }
    }
}
