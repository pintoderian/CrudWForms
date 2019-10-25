using CrudForm.Models;
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
    
    public partial class PersonaForm : Form
    {
        public int? id;
        personas persona = null;

        public PersonaForm(int? id = null)
        {
            InitializeComponent();
            this.id = id;
            CargarEdades();
            if (id != null)
                CargaDatos();
        }

        private void CargaDatos()
        {
            using (crudEntities db = new crudEntities())
            {
                persona = db.personas.Find(id);
                textNombre.Text = persona.nombre;
                textFecha.Value = Convert.ToDateTime(persona.fecha);
                edadesList.SelectedValue = persona.edad_id;

            }
        }

        private void CargarEdades()
        {
            using (crudEntities db = new crudEntities())
            {
                var edades = from d in db.edades
                            select new
                            {
                                id = d.id,
                                nro = d.nro
                            };
                edadesList.DataSource = edades.ToList();
                edadesList.DisplayMember = "nro";
                edadesList.ValueMember = "id";
            }
        }

        private void PersonaForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (crudEntities db = new crudEntities())
            {
                if (id == null)
                    persona = new personas();

                int edad_id = int.Parse(edadesList.SelectedValue.ToString());
                persona.nombre = textNombre.Text;
                persona.edad_id = edad_id;
                persona.fecha = textFecha.Value;

                if (id == null)
                    db.personas.Add(persona);
                else
                {
                    db.Entry(persona).State = System.Data.Entity.EntityState.Modified;
                }

                db.SaveChanges();

                this.Close();
            }
        }
    }
}
