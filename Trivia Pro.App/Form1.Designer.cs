namespace Trivia_Pro.App
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.cmbNivel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPregunta = new System.Windows.Forms.Label();
            this.rbOpcionA = new System.Windows.Forms.RadioButton();
            this.rbOpcionB = new System.Windows.Forms.RadioButton();
            this.rbOpcionC = new System.Windows.Forms.RadioButton();
            this.rbOpcionD = new System.Windows.Forms.RadioButton();
            this.btnEnviarRespuesta = new System.Windows.Forms.Button();
            this.pgbTiempoRestante = new System.Windows.Forms.ProgressBar();
            this.lblPuntaje = new System.Windows.Forms.Label();
            this.btnReiniciar = new System.Windows.Forms.Button();
            this.tmrTemporizador = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(13, 81);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(121, 21);
            this.cmbCategoria.TabIndex = 0;
            // 
            // cmbNivel
            // 
            this.cmbNivel.FormattingEnabled = true;
            this.cmbNivel.Location = new System.Drawing.Point(12, 128);
            this.cmbNivel.Name = "cmbNivel";
            this.cmbNivel.Size = new System.Drawing.Size(121, 21);
            this.cmbNivel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "categoria";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "nivel";
            // 
            // lblPregunta
            // 
            this.lblPregunta.AutoSize = true;
            this.lblPregunta.Location = new System.Drawing.Point(12, 162);
            this.lblPregunta.Name = "lblPregunta";
            this.lblPregunta.Size = new System.Drawing.Size(35, 13);
            this.lblPregunta.TabIndex = 4;
            this.lblPregunta.Text = "label3";
            // 
            // rbOpcionA
            // 
            this.rbOpcionA.AutoSize = true;
            this.rbOpcionA.Location = new System.Drawing.Point(15, 179);
            this.rbOpcionA.Name = "rbOpcionA";
            this.rbOpcionA.Size = new System.Drawing.Size(85, 17);
            this.rbOpcionA.TabIndex = 5;
            this.rbOpcionA.TabStop = true;
            this.rbOpcionA.Text = "radioButton1";
            this.rbOpcionA.UseVisualStyleBackColor = true;
            // 
            // rbOpcionB
            // 
            this.rbOpcionB.AutoSize = true;
            this.rbOpcionB.Location = new System.Drawing.Point(127, 179);
            this.rbOpcionB.Name = "rbOpcionB";
            this.rbOpcionB.Size = new System.Drawing.Size(85, 17);
            this.rbOpcionB.TabIndex = 6;
            this.rbOpcionB.TabStop = true;
            this.rbOpcionB.Text = "radioButton2";
            this.rbOpcionB.UseVisualStyleBackColor = true;
            // 
            // rbOpcionC
            // 
            this.rbOpcionC.AutoSize = true;
            this.rbOpcionC.Location = new System.Drawing.Point(12, 202);
            this.rbOpcionC.Name = "rbOpcionC";
            this.rbOpcionC.Size = new System.Drawing.Size(85, 17);
            this.rbOpcionC.TabIndex = 7;
            this.rbOpcionC.TabStop = true;
            this.rbOpcionC.Text = "radioButton3";
            this.rbOpcionC.UseVisualStyleBackColor = true;
            // 
            // rbOpcionD
            // 
            this.rbOpcionD.AutoSize = true;
            this.rbOpcionD.Location = new System.Drawing.Point(127, 202);
            this.rbOpcionD.Name = "rbOpcionD";
            this.rbOpcionD.Size = new System.Drawing.Size(85, 17);
            this.rbOpcionD.TabIndex = 8;
            this.rbOpcionD.TabStop = true;
            this.rbOpcionD.Text = "radioButton4";
            this.rbOpcionD.UseVisualStyleBackColor = true;
            // 
            // btnEnviarRespuesta
            // 
            this.btnEnviarRespuesta.Location = new System.Drawing.Point(15, 272);
            this.btnEnviarRespuesta.Name = "btnEnviarRespuesta";
            this.btnEnviarRespuesta.Size = new System.Drawing.Size(119, 23);
            this.btnEnviarRespuesta.TabIndex = 9;
            this.btnEnviarRespuesta.Text = "Enviar Respuesta";
            this.btnEnviarRespuesta.UseVisualStyleBackColor = true;
            this.btnEnviarRespuesta.Click += new System.EventHandler(this.btnEnviarRespuesta_Click);
            // 
            // pgbTiempoRestante
            // 
            this.pgbTiempoRestante.Location = new System.Drawing.Point(15, 302);
            this.pgbTiempoRestante.Name = "pgbTiempoRestante";
            this.pgbTiempoRestante.Size = new System.Drawing.Size(100, 23);
            this.pgbTiempoRestante.TabIndex = 10;
            // 
            // lblPuntaje
            // 
            this.lblPuntaje.AutoSize = true;
            this.lblPuntaje.Location = new System.Drawing.Point(12, 338);
            this.lblPuntaje.Name = "lblPuntaje";
            this.lblPuntaje.Size = new System.Drawing.Size(35, 13);
            this.lblPuntaje.TabIndex = 11;
            this.lblPuntaje.Text = "label3";
            // 
            // btnReiniciar
            // 
            this.btnReiniciar.Location = new System.Drawing.Point(12, 364);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new System.Drawing.Size(75, 23);
            this.btnReiniciar.TabIndex = 12;
            this.btnReiniciar.Text = "Reiniciar";
            this.btnReiniciar.UseVisualStyleBackColor = true;
            // 
            // tmrTemporizador
            // 
            this.tmrTemporizador.Tick += new System.EventHandler(this.tmrTemporizador_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnReiniciar);
            this.Controls.Add(this.lblPuntaje);
            this.Controls.Add(this.pgbTiempoRestante);
            this.Controls.Add(this.btnEnviarRespuesta);
            this.Controls.Add(this.rbOpcionD);
            this.Controls.Add(this.rbOpcionC);
            this.Controls.Add(this.rbOpcionB);
            this.Controls.Add(this.rbOpcionA);
            this.Controls.Add(this.lblPregunta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbNivel);
            this.Controls.Add(this.cmbCategoria);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.ComboBox cmbNivel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPregunta;
        private System.Windows.Forms.RadioButton rbOpcionA;
        private System.Windows.Forms.RadioButton rbOpcionB;
        private System.Windows.Forms.RadioButton rbOpcionC;
        private System.Windows.Forms.RadioButton rbOpcionD;
        private System.Windows.Forms.Button btnEnviarRespuesta;
        private System.Windows.Forms.ProgressBar pgbTiempoRestante;
        private System.Windows.Forms.Label lblPuntaje;
        private System.Windows.Forms.Button btnReiniciar;
        private System.Windows.Forms.Timer tmrTemporizador;
    }
}

