using Entidad;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Negocio;
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
    public partial class frmMapa : Form
    {
        private GMapOverlay puntos = new GMapOverlay("puntos");
        public frmMapa()
        {
            InitializeComponent();
            IniciarControles();
        }

        private void IniciarControles()
        {
            dtpDesde.Value = DateTime.Today.Date;
            dtpHasta.Value = DateTime.Today.Date;
            
            gmap.Manager.Mode = AccessMode.ServerAndCache;
            gmap.MapProvider = GMapProviders.GoogleMap;
            gmap.Position = new PointLatLng(-31.416358, -64.184044);
            gmap.MinZoom = 5;
            gmap.MaxZoom = 30;
            gmap.Zoom = 12;
            gmap.ShowCenter = false;
            gmap.DragButton = System.Windows.Forms.MouseButtons.Left;
            gmap.Overlays.Clear();
            gmap.Overlays.Add(puntos);
            bar.Visible = false;
            label4.Visible = false;
            
            cargarSucursalesMapa();
        }

        private void cargarSucursalesMapa()
        {
            // REAL 1
            GeoCoderStatusCode status = GeoCoderStatusCode.Unknow;
            PointLatLng? city = GMapProviders.GoogleMap.GetPoint("av Emilio Olmos 403, Cordoba Capital", out status);
            if (city != null && status == GeoCoderStatusCode.G_GEO_SUCCESS)
            {
                GMapMarker it = new GMarkerGoogle(city.Value, GMarkerGoogleType.blue_pushpin);
                it.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                it.ToolTipText = "SUCURSAL: REAL 1";

                puntos.Markers.Add(it);
            }

            // REAL 2
            status = GeoCoderStatusCode.Unknow;
            city = GMapProviders.GoogleMap.GetPoint("Av Vélez Sarsfield 700, Cordoba Capital", out status);
            if (city != null && status == GeoCoderStatusCode.G_GEO_SUCCESS)
            {
                GMapMarker it = new GMarkerGoogle(city.Value, GMarkerGoogleType.blue_pushpin);
                it.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                it.ToolTipText = "SUCURSAL: REAL 2";

                puntos.Markers.Add(it);
            }

            //// REAL 4
            status = GeoCoderStatusCode.Unknow;
            city = GMapProviders.GoogleMap.GetPoint("catamarca 140, Cordoba Capital", out status);
            if (city != null && status == GeoCoderStatusCode.G_GEO_SUCCESS)
            {
                GMapMarker it = new GMarkerGoogle(city.Value, GMarkerGoogleType.blue_pushpin);
                it.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                it.ToolTipText = "SUCURSAL: REAL 4";

                puntos.Markers.Add(it);
            }

            //// REAL 5
            status = GeoCoderStatusCode.Unknow;
            city = GMapProviders.GoogleMap.GetPoint("Lima 1, Cordoba Capital", out status);
            if (city != null && status == GeoCoderStatusCode.G_GEO_SUCCESS)
            {
                GMapMarker it = new GMarkerGoogle(city.Value, GMarkerGoogleType.blue_pushpin);
                it.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                it.ToolTipText = "SUCURSAL: REAL 5";

                puntos.Markers.Add(it);
            }


            //// REAL 6
            status = GeoCoderStatusCode.Unknow;
            city = GMapProviders.GoogleMap.GetPoint("La Rioja 73, Cordoba Capital", out status);
            if (city != null && status == GeoCoderStatusCode.G_GEO_SUCCESS)
            {
                GMapMarker it = new GMarkerGoogle(city.Value, GMarkerGoogleType.blue_pushpin);
                it.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                it.ToolTipText = "SUCURSAL: REAL 6";

                puntos.Markers.Add(it);
            }

            //// REAL 7
            status = GeoCoderStatusCode.Unknow;
            city = GMapProviders.GoogleMap.GetPoint("General Paz 30, Cordoba Capital", out status);
            if (city != null && status == GeoCoderStatusCode.G_GEO_SUCCESS)
            {
                GMapMarker it = new GMarkerGoogle(city.Value, GMarkerGoogleType.blue_pushpin);
                it.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                it.ToolTipText = "SUCURSAL: REAL 7";

                puntos.Markers.Add(it);
            }

            //// REAL 9
            status = GeoCoderStatusCode.Unknow;
            city = GMapProviders.GoogleMap.GetPoint("Santa Rosa 100, Cordoba Capital", out status);
            if (city != null && status == GeoCoderStatusCode.G_GEO_SUCCESS)
            {
                GMapMarker it = new GMarkerGoogle(city.Value, GMarkerGoogleType.blue_pushpin);
                it.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                it.ToolTipText = "SUCURSAL: REAL 9";

                puntos.Markers.Add(it);
            }

            //// REAL 11
            status = GeoCoderStatusCode.Unknow;
            city = GMapProviders.GoogleMap.GetPoint("Aguado 800, Cordoba Capital", out status);
            if (city != null && status == GeoCoderStatusCode.G_GEO_SUCCESS)
            {
                GMapMarker it = new GMarkerGoogle(city.Value, GMarkerGoogleType.blue_pushpin);
                it.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                it.ToolTipText = "SUCURSAL: REAL 11";

                puntos.Markers.Add(it);
            }

        }

      


        private void frmMapa_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (dtpDesde.Value <= dtpHasta.Value)
            {

                //gmap.Markers.Clear();
                puntos.Clear();
                cargarSucursalesMapa();
                //DataTable dt = new DataTable();
                List<Entrega> listEntrega = Entregas.GetEntregasDesdeHasta(dtpDesde.Value, dtpHasta.Value);
                List<Sucursal> listSucursal = Sucursales.GetTodos();
                List<Barrio> listBarrio = Barrios.GetTodos();

                var res = (from ents in listEntrega
                           join suc in listSucursal on
                           ents.sucid equals suc.sucid
                           join bars in listBarrio on
                           ents.barid equals bars.barid
                           select new
                           {
                               ents.remnumero,
                               ents.entcalle,
                               ents.entnumero,
                               bars.barnombre,
                               suc.sucnombre

                           }).ToList();

             
                bar.Minimum = 0;
                bar.Maximum = res.Count;
                bar.Value = 0;
                bar.Visible = true;
                label4.Visible = true;
             
                if (res.Count > 0)
                {

                    lblCantidad.Text = res.Count.ToString();
                    string ciudad = "Córdoba Capital";
                    //string pais = "Argentina";
                    string queryadress = "";



                    for (int i = 0; i < res.Count; i++)
                    {

                        queryadress = "";
                        queryadress = res[i].entcalle.ToString() + " " + res[i].entnumero.ToString() + "," + ciudad;
                        GeoCoderStatusCode status = GeoCoderStatusCode.Unknow;
                        PointLatLng? city = GMapProviders.GoogleMap.GetPoint(queryadress, out status);

                        if (city != null && status == GeoCoderStatusCode.G_GEO_SUCCESS)
                        {

                            GMapMarker punto = new GMarkerGoogle(city.Value, GMarkerGoogleType.red_dot);
                            punto.ToolTipMode = MarkerTooltipMode.OnMouseOver;

                            punto.ToolTipText = "N° REM: " + res[i].remnumero.ToString() + " - " + res[i].barnombre + " - " + res[i].sucnombre;
                            puntos.Markers.Add(punto);
                            bar.Value++;
                        }
                    }
                    bar.Value = 0;
                    bar.Visible = false;
                    label4.Visible = false;
                }
                else
                {
                    MessageBox.Show("ENTREGAS - NO HAY ENTREGAS REALIZADAS EL DÍA INDICADO.", "CONTROL DE ENTREGAS - INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bar.Value = 0;
                    bar.Visible = false;
                    label4.Visible = false;
                }
            }
            else
            {

                errorProvider1.SetError(dtpDesde, "LA FECHA INICIAL NO PUEDE SER MAYOR A LA FINAL");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMapa_Resize(object sender, EventArgs e)
        {
            gmap.Width = this.Width - 280;
            gmap.Height = this.Height - 100;
            groupBox1.Location = new Point(this.Width - 260, 30);
            groupBox2.Location = new Point(this.Width - 260, 30 + groupBox1.Height + 10);
            btnCancelar.Location = new Point(this.Width - 100, this.Height - 80);
            trackZoom.Location = new Point(gmap.Width + 20, this.Height - 250);
            btnImprimir.Location = new Point(this.Width - 150, groupBox1.Height + groupBox2.Height + 50);
            bar.Location = new Point(gmap.Width - 200, gmap.Height + 20);
            label4.Location = new Point(gmap.Width - 280, gmap.Height + 23);
        }

        private void trackZoom_Scroll(object sender, EventArgs e)
        {
            gmap.Zoom = trackZoom.Value;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "PNG (*.png)|*.png";
                    sfd.FileName = "CONTROL DE ENTREGAS - MAPA - " + DateTime.Today.Date.ToShortDateString();

                    Image tmpImage = gmap.ToImage();
                    if (tmpImage != null)
                    {
                        using (tmpImage)
                        {
                            if (sfd.ShowDialog() == DialogResult.OK)
                            {
                                tmpImage.Save(sfd.FileName);

                                MessageBox.Show("Imagen Guardada: " + sfd.FileName, "CONTROL DE ENTREGAS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("OCURRIO UN ERROR AL GUARDAR LA IMAGEN: " + ex.Message, "CONTROL DE ENTREGAS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
