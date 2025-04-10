using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;

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
            // Suscripción única del evento Tick
            timer.Tick += tmrTemporizador_Tick;
            timer.Interval = 1000; // 1 segundo por tick
            cmbCategoria.Items.AddRange(new string[] { "Ciencia", "Historia", "Cultura General" });
            cmbNivel.Items.AddRange(new string[] { "Fácil", "Medio", "Difícil" });
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            IniciarJuego();
        }

        private void IniciarJuego()
        {
            if (cmbCategoria.SelectedItem == null || cmbNivel.SelectedItem == null)
            {
                MessageBox.Show("¡Selecciona categoría y nivel!");
                return;
            }

            string categoria = cmbCategoria.SelectedItem.ToString();
            string nivel = cmbNivel.SelectedItem.ToString();

            // Obtener preguntas disponibles (sin límite de 15)
            preguntas = PreguntaFactory.ObtenerPreguntasAleatorias(categoria, nivel);

            if (preguntas.Count == 0)
            {
                MessageBox.Show("No hay preguntas para esta combinación.");
                return;
            }

            // Limitar a 15 preguntas si hay más
            if (preguntas.Count > 15)
            {
                preguntas = preguntas.Take(15).ToList();
            }

            preguntasRestantes = preguntas.Count; // Ajustar según preguntas reales
            puntajeTotal = 0;
            lblPuntaje.Text = $"Puntaje: {puntajeTotal}";

            // Resto del código (deshabilitar controles, etc.)
            cmbCategoria.Enabled = false;
            cmbNivel.Enabled = false;
            btnIniciar.Enabled = false;

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

            // Actualizar las opciones en los RadioButtons
            rbOpcionA.Text = preguntaActual.Opciones[0];
            rbOpcionB.Text = preguntaActual.Opciones[1];
            rbOpcionC.Text = preguntaActual.Opciones[2];
            rbOpcionD.Text = preguntaActual.Opciones[3];

            // Reiniciar la barra de progreso y el temporizador
            pgbTiempoRestante.Maximum = preguntaActual.Tiempo;
            pgbTiempoRestante.Value = preguntaActual.Tiempo;
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
                MessageBox.Show("Tiempo agotado. Respuesta incorrecta.");
                MarcarRespuestaIncorrecta();
                preguntasRestantes--;
                MostrarSiguientePregunta();
            }
        }

        private void btnEnviarRespuesta_Click(object sender, EventArgs e)
        {
            timer.Stop();
            string respuestaSeleccionada = "";

            // Verifica cuál RadioButton está seleccionado
            if (rbOpcionA.Checked) respuestaSeleccionada = rbOpcionA.Text;
            else if (rbOpcionB.Checked) respuestaSeleccionada = rbOpcionB.Text;
            else if (rbOpcionC.Checked) respuestaSeleccionada = rbOpcionC.Text;
            else if (rbOpcionD.Checked) respuestaSeleccionada = rbOpcionD.Text;
            else
            {
                MessageBox.Show("Selecciona una respuesta antes de enviar.");
                timer.Start(); // Reinicia el temporizador si no se seleccionó respuesta
                return;
            }

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
            lblPuntaje.Text = $"Puntaje: {puntajeTotal}";
            MostrarSiguientePregunta();
        }

        private void MarcarRespuestaIncorrecta()
        {
            puntajeTotal = Math.Max(0, puntajeTotal - 2);
            lblPuntaje.Text = $"Puntaje: {puntajeTotal}";
        }

        private void FinalizarJuego()
        {
            timer.Stop();
            MessageBox.Show($"Juego terminado. Puntaje final: {puntajeTotal}");

            // Habilitar controles para una nueva partida
            cmbCategoria.Enabled = true;
            cmbNivel.Enabled = true;
            btnIniciar.Enabled = true;
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            // Limpiar todas las preguntas y variables de estado
            preguntas.Clear();
            puntajeTotal = 0;
            preguntasRestantes = 15;

            // Restablecer controles básicos
            lblPuntaje.Text = "Puntaje: 0";
            lblPregunta.Text = "";
            cmbCategoria.Enabled = true;
            cmbNivel.Enabled = true;
            btnIniciar.Enabled = true;

            // Limpiar selecciones de RadioButtons
            rbOpcionA.Checked = false;
            rbOpcionB.Checked = false;
            rbOpcionC.Checked = false;
            rbOpcionD.Checked = false;

            // Detener y reiniciar el temporizador
            timer.Stop();
            pgbTiempoRestante.Value = 0;

            // Recargar preguntas para una nueva partida
            PreguntaFactory.RecargarPreguntas();
        }
    }
}
