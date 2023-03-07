﻿
namespace RocketBoostForCar
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox_baseAddressOfCar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_EnableRocketBoost = new System.Windows.Forms.Button();
            this.button_AttachToProcess = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_processName = new System.Windows.Forms.TextBox();
            this.textBox_carSpeed = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label_xVelocityOfCar = new System.Windows.Forms.Label();
            this.button_DetachFromProcess = new System.Windows.Forms.Button();
            this.label_yVelocityOfCar = new System.Windows.Forms.Label();
            this.loopExecutor = new System.Windows.Forms.Timer(this.components);
            this.button_DisableRocketBoost = new System.Windows.Forms.Button();
            this.textBox_multiplierForBoost = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_baseAddressOfCar
            // 
            this.textBox_baseAddressOfCar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_baseAddressOfCar.Location = new System.Drawing.Point(270, 36);
            this.textBox_baseAddressOfCar.Name = "textBox_baseAddressOfCar";
            this.textBox_baseAddressOfCar.Size = new System.Drawing.Size(234, 29);
            this.textBox_baseAddressOfCar.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(266, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter base address of car:";
            // 
            // button_EnableRocketBoost
            // 
            this.button_EnableRocketBoost.Enabled = false;
            this.button_EnableRocketBoost.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_EnableRocketBoost.Location = new System.Drawing.Point(270, 130);
            this.button_EnableRocketBoost.Name = "button_EnableRocketBoost";
            this.button_EnableRocketBoost.Size = new System.Drawing.Size(205, 39);
            this.button_EnableRocketBoost.TabIndex = 2;
            this.button_EnableRocketBoost.Text = "Enable rocket boost";
            this.button_EnableRocketBoost.UseVisualStyleBackColor = true;
            this.button_EnableRocketBoost.Click += new System.EventHandler(this.button_EnableRocketBoost_Click);
            // 
            // button_AttachToProcess
            // 
            this.button_AttachToProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_AttachToProcess.Location = new System.Drawing.Point(16, 71);
            this.button_AttachToProcess.Name = "button_AttachToProcess";
            this.button_AttachToProcess.Size = new System.Drawing.Size(205, 39);
            this.button_AttachToProcess.TabIndex = 5;
            this.button_AttachToProcess.Text = "Attach to process";
            this.button_AttachToProcess.UseVisualStyleBackColor = true;
            this.button_AttachToProcess.Click += new System.EventHandler(this.button_AttachToProcess_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Enter name of process:";
            // 
            // textBox_processName
            // 
            this.textBox_processName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_processName.Location = new System.Drawing.Point(16, 36);
            this.textBox_processName.Name = "textBox_processName";
            this.textBox_processName.Size = new System.Drawing.Size(234, 29);
            this.textBox_processName.TabIndex = 3;
            // 
            // textBox_carSpeed
            // 
            this.textBox_carSpeed.Enabled = false;
            this.textBox_carSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_carSpeed.Location = new System.Drawing.Point(270, 322);
            this.textBox_carSpeed.Name = "textBox_carSpeed";
            this.textBox_carSpeed.Size = new System.Drawing.Size(234, 29);
            this.textBox_carSpeed.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(266, 295);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "Car speed:";
            // 
            // label_xVelocityOfCar
            // 
            this.label_xVelocityOfCar.AutoSize = true;
            this.label_xVelocityOfCar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_xVelocityOfCar.Location = new System.Drawing.Point(266, 228);
            this.label_xVelocityOfCar.Name = "label_xVelocityOfCar";
            this.label_xVelocityOfCar.Size = new System.Drawing.Size(147, 24);
            this.label_xVelocityOfCar.TabIndex = 9;
            this.label_xVelocityOfCar.Text = "X velocity of car:";
            // 
            // button_DetachFromProcess
            // 
            this.button_DetachFromProcess.Enabled = false;
            this.button_DetachFromProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_DetachFromProcess.Location = new System.Drawing.Point(16, 116);
            this.button_DetachFromProcess.Name = "button_DetachFromProcess";
            this.button_DetachFromProcess.Size = new System.Drawing.Size(205, 39);
            this.button_DetachFromProcess.TabIndex = 10;
            this.button_DetachFromProcess.Text = "Detach from process";
            this.button_DetachFromProcess.UseVisualStyleBackColor = true;
            this.button_DetachFromProcess.Click += new System.EventHandler(this.button_DetachFromProcess_Click);
            // 
            // label_yVelocityOfCar
            // 
            this.label_yVelocityOfCar.AutoSize = true;
            this.label_yVelocityOfCar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_yVelocityOfCar.Location = new System.Drawing.Point(266, 258);
            this.label_yVelocityOfCar.Name = "label_yVelocityOfCar";
            this.label_yVelocityOfCar.Size = new System.Drawing.Size(145, 24);
            this.label_yVelocityOfCar.TabIndex = 11;
            this.label_yVelocityOfCar.Text = "Y velocity of car:";
            // 
            // loopExecutor
            // 
            this.loopExecutor.Interval = 1;
            this.loopExecutor.Tick += new System.EventHandler(this.loopExecutor_Tick);
            // 
            // button_DisableRocketBoost
            // 
            this.button_DisableRocketBoost.Enabled = false;
            this.button_DisableRocketBoost.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_DisableRocketBoost.Location = new System.Drawing.Point(270, 175);
            this.button_DisableRocketBoost.Name = "button_DisableRocketBoost";
            this.button_DisableRocketBoost.Size = new System.Drawing.Size(205, 39);
            this.button_DisableRocketBoost.TabIndex = 12;
            this.button_DisableRocketBoost.Text = "Disable rocket boost";
            this.button_DisableRocketBoost.UseVisualStyleBackColor = true;
            this.button_DisableRocketBoost.Click += new System.EventHandler(this.button_DisableRocketBoost_Click);
            // 
            // textBox_multiplierForBoost
            // 
            this.textBox_multiplierForBoost.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_multiplierForBoost.Location = new System.Drawing.Point(270, 95);
            this.textBox_multiplierForBoost.Name = "textBox_multiplierForBoost";
            this.textBox_multiplierForBoost.Size = new System.Drawing.Size(234, 29);
            this.textBox_multiplierForBoost.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(266, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(217, 24);
            this.label4.TabIndex = 14;
            this.label4.Text = "Enter multiplier for boost:";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 413);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_multiplierForBoost);
            this.Controls.Add(this.button_DisableRocketBoost);
            this.Controls.Add(this.label_yVelocityOfCar);
            this.Controls.Add(this.button_DetachFromProcess);
            this.Controls.Add(this.label_xVelocityOfCar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_carSpeed);
            this.Controls.Add(this.button_AttachToProcess);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_processName);
            this.Controls.Add(this.button_EnableRocketBoost);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_baseAddressOfCar);
            this.Name = "MainWindow";
            this.Text = "Rookcet Boost";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_baseAddressOfCar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_EnableRocketBoost;
        private System.Windows.Forms.Button button_AttachToProcess;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_processName;
        private System.Windows.Forms.TextBox textBox_carSpeed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_xVelocityOfCar;
        private System.Windows.Forms.Button button_DetachFromProcess;
        private System.Windows.Forms.Label label_yVelocityOfCar;
        private System.Windows.Forms.Timer loopExecutor;
        private System.Windows.Forms.Button button_DisableRocketBoost;
        private System.Windows.Forms.TextBox textBox_multiplierForBoost;
        private System.Windows.Forms.Label label4;
    }
}
