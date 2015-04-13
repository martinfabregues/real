using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace REAL
{
    public partial class frmFiltro : Form
    {
        public frmFiltro()
        {
            InitializeComponent();
            IniciarControles();
        }


        private void IniciarControles()
        {
            cmbAno.Enabled = false;
            cmbMes.Enabled = false;
            dtpDesde.Enabled = false;
            dtpHasta.Enabled = false;



            cmbMes.Items.Add("ENERO");
            cmbMes.Items.Add("FEBRERO");
            cmbMes.Items.Add("MARZO");
            cmbMes.Items.Add("ABRIL");
            cmbMes.Items.Add("MAYO");
            cmbMes.Items.Add("JUNIO");
            cmbMes.Items.Add("JULIO");
            cmbMes.Items.Add("AGOSTO");
            cmbMes.Items.Add("SEPTIEMBRE");
            cmbMes.Items.Add("OCTUBRE");
            cmbMes.Items.Add("NOVIEMBRE");
            cmbMes.Items.Add("DICIEMBRE");



            cmbAno.Items.Add("2013");
            cmbAno.Items.Add("2014");
            cmbAno.Items.Add("2015");
            cmbAno.Items.Add("2016");
            cmbAno.Items.Add("2017");
            cmbAno.Items.Add("2018");

            cmbMes.SelectedIndex = 0;
            cmbAno.SelectedIndex = 0;
        }


        private void ckbHistorico_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbHistorico.Checked == true)
            {
                ckbFecha.CheckState = CheckState.Unchecked;
                ckbMes.CheckState = CheckState.Unchecked;

            }
            else
            {

            }


        }

        private void ckbMes_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbMes.Checked == true)
            {
                ckbHistorico.CheckState = CheckState.Unchecked;
                ckbFecha.CheckState = CheckState.Unchecked;
                cmbAno.Enabled = true;
                cmbMes.Enabled = true;
            }
            else
            {
                cmbMes.Enabled = false;
                cmbAno.Enabled = false;
            }
        }

        private void ckbFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbFecha.Checked == true)
            {
                ckbHistorico.CheckState = CheckState.Unchecked;
                ckbMes.CheckState = CheckState.Unchecked;
                dtpDesde.Enabled = true;
                dtpHasta.Enabled = true;
            }
            else
            {
                dtpHasta.Enabled = false;
                dtpDesde.Enabled = false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (ckbHistorico.Checked == true)
            {
                frmReporteEntregas frm = new frmReporteEntregas("HISTORICO", DateTime.Today.Date, DateTime.Today.Date);
                frm.MdiParent = this.MdiParent;
                frm.Text = "REPORTE DE ENTREGAS - HISTORICO";
                this.Hide();
                frm.Show();
                
            }
            else
            {
                if (ckbMes.Checked == true)
                {
                    int ano = Convert.ToInt32(cmbAno.Text);
                    int mes = (cmbMes.SelectedIndex + 1);
                    DateTime primerdia = new DateTime(ano, mes, 1);
                    DateTime ultimodia = primerdia.AddMonths(1).AddDays(-1);
                    frmReporteEntregas frm = new frmReporteEntregas("MES", primerdia, ultimodia);
                    frm.MdiParent = this.MdiParent;
                    frm.Text = "REPORTE DE ENTREGAS - MENSUAL";
                    this.Hide();
                    frm.Show();
                    
                }
                else
                {
                    if (ckbFecha.Checked == true)
                    {
                        if (dtpDesde.Value <= dtpHasta.Value)
                        {
                            frmReporteEntregas frm = new frmReporteEntregas("FECHA", dtpDesde.Value, dtpHasta.Value);
                            frm.MdiParent = this.MdiParent;
                            frm.Text = "REPORTE DE ENTREGAS - PERIODO";
                            this.Hide();
                            frm.Show();
                        }
                        else
                        {
                            errorProvider1.SetError(dtpDesde, "LA FECHA DE INICIO NO PUEDE SER MAYOR A LA FINAL");
                            dtpDesde.Focus();
                        }

                    }
                    else
                    {
                        MessageBox.Show("DEBE SELECCIONAR AL MENOS UN TIPO DE REPORTE.", "CONTROL DE ENTREGAS - INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
        }
    }
}
