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
    public partial class EdadForm : Form
    {
        public int? id;
        edades edad = null;

        public EdadForm(int? id = null)
        {
            InitializeComponent();
            this.id = id;
            if (id != null)
                CargaDatos();
        }

        private void CargaDatos()
        {
            using (crudEntities db = new crudEntities())
            {
                edad = db.edades.Find(id);
                textNro.Text = edad.nro;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            using(crudEntities db = new crudEntities())
            {
                if (id == null)
                    edad = new edades();

                edad.nro = textNro.Text;
                if (id == null)
                    db.edades.Add(edad);
                else
                {
                    db.Entry(edad).State = System.Data.Entity.EntityState.Modified;
                }

                db.SaveChanges();

                this.Close();
            }
        }
    }
}
