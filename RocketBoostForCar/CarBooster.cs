using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;

namespace RocketBoostForCar
{
    public partial class CarBooster : Form
    {
        private readonly MemoryManagerFor32bitProcesses memoryManager;
        private IntPtr processHandle;
        private float multiplierForBoost = 0;
        private float yawAngleInDegrees = 0;

        private int baseAddressOfPlayer = 0;
        private int pointerToCar = 0;
        private int baseAddressOfCar = 0;
        private int pointerToCarBody = 0;
        private int baseAddressOfCarBody = 0;

        private int addressOfXVelocity = 0;
        private int addressOfYVelocity = 0;
        private int addressOfYawAngleSinus = 0;
        private int addressOfYawAngleCosine = 0;
        private int addressOfRollAngleSinus = 0;
        private int addressOfPitchAngleSinus_withMinus = 0;

        public CarBooster()
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
                baseAddressOfPlayer = Convert.ToInt32(textBox_baseAddressOfPlayer.Text, 16);
                pointerToCar = baseAddressOfPlayer + 0x58C;
                baseAddressOfCar = memoryManager.GetValueFromTargetAddressAsInt(pointerToCar, processHandle);
                pointerToCarBody = baseAddressOfCar + 0x14;
                baseAddressOfCarBody = memoryManager.GetValueFromTargetAddressAsInt(pointerToCarBody, processHandle);

                addressOfXVelocity = baseAddressOfCar + 0x44;
                addressOfYVelocity = baseAddressOfCar + 0x48;

                addressOfYawAngleSinus = baseAddressOfCarBody + 0x10;
                addressOfYawAngleCosine = baseAddressOfCarBody + 0x14;
                addressOfRollAngleSinus = baseAddressOfCarBody + 0x8;
                addressOfPitchAngleSinus_withMinus = baseAddressOfCarBody + 0x18;

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
            RotateCarAroundZAxis();
            BoostCar();
        }

        private float GetSpeedOfObject(float xVelocityVector, float yVelocityVector)
        {
            double speedOfObject = Math.Sqrt((xVelocityVector * xVelocityVector) + (yVelocityVector * yVelocityVector));
            return Convert.ToSingle(speedOfObject);
        }

        private float GetYawAngleInDegreesFromSinusAndCosine(float sinusOfAngle, float cosineOfAngle)
        {
            double yawAngleInRadians = Math.Atan2(sinusOfAngle, cosineOfAngle);
            double yawAngleInDegrees = yawAngleInRadians * (180 / Math.PI);
            return Convert.ToSingle(yawAngleInDegrees);
        }

        private void RotateCarAroundZAxis()
        {
            if (memoryManager.IsKeyPushedDown(Keys.D))
            {
                if (yawAngleInDegrees > 180)
                {
                    yawAngleInDegrees = yawAngleInDegrees * -1;
                }
                yawAngleInDegrees = yawAngleInDegrees + (1 * Convert.ToSingle(0.05));
            }

            if (memoryManager.IsKeyPushedDown(Keys.A))
            {
                if (yawAngleInDegrees < -180)
                {
                    yawAngleInDegrees = yawAngleInDegrees * -1;
                }
                yawAngleInDegrees = yawAngleInDegrees - (1 * Convert.ToSingle(0.05));
            }
            RotateCarToFlipItOver();

            float newSinusOfYawAngle = Convert.ToSingle(Math.Sin(yawAngleInDegrees));
            float newCosineOfYawAngle = Convert.ToSingle(Math.Cos(yawAngleInDegrees));
            memoryManager.SetValueAsFloatToTargetAddress(addressOfYawAngleSinus, newSinusOfYawAngle, processHandle);
            memoryManager.SetValueAsFloatToTargetAddress(addressOfYawAngleCosine, newCosineOfYawAngle, processHandle);
            
            memoryManager.SetValueAsFloatToTargetAddress(addressOfRollAngleSinus, Convert.ToSingle(0), processHandle);
            memoryManager.SetValueAsFloatToTargetAddress(addressOfPitchAngleSinus_withMinus, Convert.ToSingle(0), processHandle);
        }

        private void BoostCar()
        {
            float sinusOfYawAngle = memoryManager.GetValueFromTargetAddressAsFloat(addressOfYawAngleSinus, processHandle);
            float cosineOfYawAngle = memoryManager.GetValueFromTargetAddressAsFloat(addressOfYawAngleCosine, processHandle);
            float xVelocityOfCar = memoryManager.GetValueFromTargetAddressAsFloat(addressOfXVelocity, processHandle);
            float yVelocityOfCar = memoryManager.GetValueFromTargetAddressAsFloat(addressOfYVelocity, processHandle);

            float speedOfCar = GetSpeedOfObject(xVelocityOfCar, yVelocityOfCar);
            if (speedOfCar < 1.8 && memoryManager.IsKeyPushedDown(Keys.W) && loopExecutor.Enabled != false)
            {
                float newXVelocityOfCar = xVelocityOfCar - ((sinusOfYawAngle * -1) * multiplierForBoost);
                float newYVelocityOfCar = yVelocityOfCar + (cosineOfYawAngle * multiplierForBoost);

                memoryManager.SetValueAsFloatToTargetAddress(addressOfXVelocity, newXVelocityOfCar, processHandle);
                memoryManager.SetValueAsFloatToTargetAddress(addressOfYVelocity, newYVelocityOfCar, processHandle);
            }

            label_xVelocityOfCar.Text = "X velocity of car: " + xVelocityOfCar;
            label_yVelocityOfCar.Text = "Y velocity of car: " + yVelocityOfCar;
            label_carSpeed.Text = "Car speed: " + speedOfCar;
            label_yawAngleInDegrees.Text = "Yaw angle in degrees: " + yawAngleInDegrees.ToString();
        }

        private void RotateCarToFlipItOver()
        {
            if (memoryManager.IsKeyPushedDown(Keys.NumPad7))
            {
                if (yawAngleInDegrees != 90)
                {
                    yawAngleInDegrees = 90;
                }
                else
                {
                    yawAngleInDegrees = -90;
                }
            }
        }
    }
}
