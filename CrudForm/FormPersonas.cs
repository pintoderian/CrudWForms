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
    public partial class FormPersonas : Form
    {
        public FormPersonas()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        #region HELPER
        private void Refrescar()
        {
            using (crudEntities db = new crudEntities())
            {
                var lst = from d in db.personas
                          join edad in db.edades on d.edad_id equals edad.id
                          select new
                          {
                              id = d.id,
                              nombre = d.nombre,
                              fecha = d.fecha,
                              edad = edad.nro
                          };
                dataGridView1.DataSource = lst.ToList();
            }
        }

        private int? GetId()
        {
            try
            {
                int index = dataGridView1.CurrentRow.Index;
                int id = int.Parse(dataGridView1.Rows[index].Cells[0].Value.ToString());
                return id;
            }
            catch (Exception)
            {

                return null;
            }
        }
        #endregion

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormPersonas_Load(object sender, EventArgs e)
        {
            Refrescar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            using (crudEntities db = new crudEntities())
            {
                personas persona = db.personas.Find(id);
                db.personas.Remove(persona);
                db.SaveChanges();
            }
            Refrescar();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            if (id != null)
            {
                PersonaForm oFrmTabla = new PersonaForm(id);
                oFrmTabla.ShowDialog();

                Refrescar();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            PersonaForm oFrmTabla = new PersonaForm();
            oFrmTabla.ShowDialog();

            Refrescar();
        }
    }
}
