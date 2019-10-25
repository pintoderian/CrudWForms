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
    public partial class FormEdad : Form
    {
        public FormEdad()
        {
            InitializeComponent();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void FormEdad_Load(object sender, EventArgs e)
        {
            Refrescar();
        }

        #region HELPER
        private void Refrescar()
        {
            using (crudEntities db = new crudEntities())
            {
                var lst = from d in db.edades
                          select new
                          {
                              id = d.id,
                              nro = d.nro
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

        private void button1_Click(object sender, EventArgs e)
        {
            EdadForm oFrmTabla = new EdadForm();
            oFrmTabla.ShowDialog();

            Refrescar();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            if(id != null)
            {
                EdadForm oFrmTabla = new EdadForm(id);
                oFrmTabla.ShowDialog();

                Refrescar();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            using (crudEntities db = new crudEntities())
            {
                edades edad = db.edades.Find(id);
                db.edades.Remove(edad);
                db.SaveChanges();
            }
            Refrescar();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
