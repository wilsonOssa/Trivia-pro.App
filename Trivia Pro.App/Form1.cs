using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trivia_Pro.App
{
    public partial class Form1 : Form
    {
        private List<Pregunta> preguntas = new List<Pregunta>();
        private Pregunta preguntaActual;
        private int puntajeTotal = 0;
        private int preguntasRestantes = 15;
        private Timer timer = new Timer();
        public Form1()
        {
            InitializeComponent();
        }

        private void IniciarJuego()
        {
            // Validar selección
            if (cmbCategoria.SelectedItem == null || cmbNivel.SelectedItem == null)
            {
                MessageBox.Show("¡Selecciona categoría y nivel!");
                return;
            }

            // Cargar 15 preguntas aleatorias usando Factory
            for (int i = 0; i < 15; i++)
            {
                preguntas.Add(PreguntaFactory.CrearPregunta(
                    cmbCategoria.SelectedItem.ToString(),
                    cmbNivel.SelectedItem.ToString()
                ));
            }

            MostrarSiguientePregunta();
        }
        private void MostrarSiguientePregunta()
        {
            if (preguntas.Count == 0 || preguntasRestantes == 0)
            {
                FinalizarJuego();
                return;
            }

            preguntaActual = preguntas[0];
            preguntas.RemoveAt(0);
            lblPregunta.Text = preguntaActual.Texto;

            // Mostrar opciones en RadioButtons
            rbOpcionA.Text = preguntaActual.Opciones[0];
            rbOpcionB.Text = preguntaActual.Opciones[1];
            rbOpcionC.Text = preguntaActual.Opciones[2];
            rbOpcionD.Text = preguntaActual.Opciones[3];


            // Iniciar temporizador
            pgbTiempoRestante.Maximum = preguntaActual.Tiempo;
            timer.Interval = 1000; // 1 segundo
            timer.Tick += tmrTemporizador_Tick;
            timer.Start();
        }

        private void tmrTemporizador_Tick(object sender, EventArgs e)
        {
            
                if (pgbTiempoRestante.Value > 0)
                {
                pgbTiempoRestante.Value--;
                }
                else
                {
                    timer.Stop();
                    MarcarRespuestaIncorrecta();
                    MostrarSiguientePregunta();
                }
        }
        private void MarcarRespuestaIncorrecta()
        {
            puntajeTotal = Math.Max(0, puntajeTotal - 2);
            lblPuntaje.Text = $"Puntaje: {puntajeTotal}";
        }

        private void btnEnviarRespuesta_Click(object sender, EventArgs e)
        {
            timer.Stop();
            string respuestaSeleccionada = "";

            // Obtener la opción seleccionada
            if (rbOpcionA.Checked) respuestaSeleccionada = rbOpcionA.Text;
            else if (rbOpcionB.Checked) respuestaSeleccionada = rbOpcionB.Text;
            else if (rbOpcionC.Checked) respuestaSeleccionada = rbOpcionC.Text;
            else if (rbOpcionD.Checked) respuestaSeleccionada = rbOpcionD.Text;


            if (preguntaActual.EvaluarRespuesta(respuestaSeleccionada))
            {
                puntajeTotal += preguntaActual.Puntaje;
                MessageBox.Show("¡Correcto!");
            }
            else
            {
                MarcarRespuestaIncorrecta();
                MessageBox.Show("Incorrecto :(");
            }

            preguntasRestantes--;
            MostrarSiguientePregunta();
        }
        private void FinalizarJuego()
        {
            MessageBox.Show($"Juego terminado. Puntaje final: {puntajeTotal}");
            // Reiniciar variables
            puntajeTotal = 0;
            preguntasRestantes = 15;
            lblPuntaje.Text = "Puntaje: 0";
        }
    }
}
