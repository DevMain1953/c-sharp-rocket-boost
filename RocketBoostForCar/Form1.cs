﻿using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;

namespace RocketBoostForCar
{
    public partial class MainWindow : Form
    {
        private readonly MemoryManagerFor32bitProcesses memoryManager;
        private IntPtr processHandle;
        private float multiplierForBoost;

        public MainWindow()
        {
            InitializeComponent();
            memoryManager = new MemoryManagerFor32bitProcesses();
        }

        private void button_AttachToProcess_Click(object sender, EventArgs e)
        {
            int processId = memoryManager.GetProcessIDByProcessName(textBox_processName.Text);
            if (processId != 0)
            {
                MessageBox.Show("Process ID is found");
            }

            uint allRightsToProcess = 0x001F0FFF;
            processHandle = MemoryManagerFor32bitProcesses.OpenProcess(allRightsToProcess, false, processId);

            button_AttachToProcess.Enabled = false;
            button_DetachFromProcess.Enabled = true;
            button_EnableRocketBoost.Enabled = true;
        }

        private void button_DetachFromProcess_Click(object sender, EventArgs e)
        {
            MemoryManagerFor32bitProcesses.CloseHandle(processHandle);
            MessageBox.Show("Process handle is closed");

            button_DetachFromProcess.Enabled = false;
            button_EnableRocketBoost.Enabled = false;
            button_AttachToProcess.Enabled = true;
        }

        private void button_EnableRocketBoost_Click(object sender, EventArgs e)
        {
            if (textBox_multiplierForBoost.Text != "")
            {
                multiplierForBoost = Convert.ToSingle(textBox_multiplierForBoost.Text);
                loopExecutor.Enabled = true;
                button_EnableRocketBoost.Enabled = false;
                button_DisableRocketBoost.Enabled = true;
            }
        }

        private void button_DisableRocketBoost_Click(object sender, EventArgs e)
        {
            loopExecutor.Enabled = false;
            button_EnableRocketBoost.Enabled = true;
            button_DisableRocketBoost.Enabled = false;
        }

        private void loopExecutor_Tick(object sender, EventArgs e)
        {
            int baseAddressOfCar = Convert.ToInt32(textBox_baseAddressOfPlayer.Text, 16);

            int offsetToAddressOfXVelocityVectorOfCarInBytes = 0x78;
            int addressOfXVelocityVectorOfCar = baseAddressOfCar + offsetToAddressOfXVelocityVectorOfCarInBytes;

            int offsetToAddressOfYVelocityVectorOfCarInBytes = 0x7C;
            int addressOfYVelocityVectorOfCar = baseAddressOfCar + offsetToAddressOfYVelocityVectorOfCarInBytes;

            float xVelocityVectorOfCar = memoryManager.GetValueFromTargetAddressAsFloat(addressOfXVelocityVectorOfCar, processHandle);
            float yVelocityVectorOfCar = memoryManager.GetValueFromTargetAddressAsFloat(addressOfYVelocityVectorOfCar, processHandle);
            float speedOfCar = GetSpeedOfObject(xVelocityVectorOfCar, yVelocityVectorOfCar);

            label_xVelocityOfCar.Text = "X velocity of car: " + xVelocityVectorOfCar;
            label_yVelocityOfCar.Text = "Y velocity of car: " + yVelocityVectorOfCar;
            textBox_carSpeed.Text = speedOfCar.ToString();

            if (GetSpeedOfObject(xVelocityVectorOfCar, yVelocityVectorOfCar) < 1.8 && memoryManager.IsKeyPushedDown(Keys.W))
            {
                float newXVelocityVectorOfCar = xVelocityVectorOfCar * multiplierForBoost;
                float newYVelocityVectorOfCar = yVelocityVectorOfCar * multiplierForBoost;

                memoryManager.SetValueAsFloatToTargetAddress(addressOfXVelocityVectorOfCar, newXVelocityVectorOfCar, processHandle);
                memoryManager.SetValueAsFloatToTargetAddress(addressOfYVelocityVectorOfCar, newYVelocityVectorOfCar, processHandle);
            }
        }

        private float GetSpeedOfObject(float xVelocityVector, float yVelocityVector)
        {
            double speedOfObject = Math.Sqrt((xVelocityVector * xVelocityVector) + (yVelocityVector * yVelocityVector));
            return Convert.ToSingle(speedOfObject);
        }
    }
}
