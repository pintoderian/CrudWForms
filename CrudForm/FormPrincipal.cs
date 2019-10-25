using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudForm
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void btnEdad_Click(object sender, EventArgs e)
        {
            FormEdad edad = new FormEdad();
            edad.Show();
        }

        private void btnPersona_Click(object sender, EventArgs e)
        {
            FormPersonas persona = new FormPersonas();
            persona.Show();
        }
    }
}
