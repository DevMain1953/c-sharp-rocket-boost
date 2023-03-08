using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;

namespace RocketBoostForCar
{
    public class MemoryManagerFor32bitProcesses
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, Int32 nSize, out IntPtr lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, Int32 nSize, out IntPtr lpNumberOfBytesWritten);

        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);

        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(System.Int32 vKey);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr OpenProcess(uint processAccess, bool bInheritHandle, int processId);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseHandle(IntPtr hObject);

        public bool IsKeyPushedDown(System.Windows.Forms.Keys key)
        {
            return (GetAsyncKeyState((int)key) & 0x8000) != 0;
        }

        public bool IsKeyPressed(System.Windows.Forms.Keys key)
        {
            return (GetAsyncKeyState((int)key) & 1) != 0;
        }

        public int GetProcessIDByProcessName(string processName)
        {
            var processes = Process.GetProcesses();
            if (processes.Count() != 0)
            {
                foreach (var process in processes)
                {
                    if (process.ProcessName == processName)
                    {
                        return process.Id;
                    }
                }
            }
            return 0;
        }

        public float GetValueFromTargetAddressAsFloat(int targetAddress, IntPtr processHandle)
        {
            int numberOfBytesInTargetAddress = 4;
            byte[] buffer = new byte[numberOfBytesInTargetAddress];
            IntPtr numberOfReadBytes;
            ReadProcessMemory(processHandle, (IntPtr)targetAddress, buffer, numberOfBytesInTargetAddress, out numberOfReadBytes);
            float valueAsFloat = BitConverter.ToSingle(buffer, 0);
            return valueAsFloat;
        }

        public int GetValueFromTargetAddressAsInt(int targetAddress, IntPtr processHandle)
        {
            int numberOfBytesInTargetAddress = 4;
            byte[] buffer = new byte[numberOfBytesInTargetAddress];
            IntPtr numberOfReadBytes;
            ReadProcessMemory(processHandle, (IntPtr)targetAddress, buffer, numberOfBytesInTargetAddress, out numberOfReadBytes);
            int valueAsInt = BitConverter.ToInt32(buffer, 0);
            return valueAsInt;
        }

        public void SetValueAsFloatToTargetAddress(int targetAddress, float value , IntPtr processHandle)
        {
            int numberOfBytesInTargetAddress = 4;
            byte[] buffer = new byte[numberOfBytesInTargetAddress];
            buffer = BitConverter.GetBytes(value);
            IntPtr numberOfWrittenBytes;
            WriteProcessMemory(processHandle, (IntPtr)targetAddress, buffer, numberOfBytesInTargetAddress, out numberOfWrittenBytes);

        }

        public int GetTargetAddressByPointersUsingOffsets(int[] offsetsInBytes, int baseAddressFromWhereToStartSearch , IntPtr processHandle)
        {
            int sizeOfTargetAddressInBytes = 4;
            byte[] buffer = new byte[sizeOfTargetAddressInBytes];
            IntPtr numberOfReadBytes;
            int nextPointerAddress = 0;
            int nextFoundValue = 0;

            ReadProcessMemory(processHandle, (IntPtr)baseAddressFromWhereToStartSearch, buffer, sizeOfTargetAddressInBytes, out numberOfReadBytes);
            for (int i = 0; i < offsetsInBytes.Length; i++)
            { 
                nextFoundValue = BitConverter.ToInt32(buffer, 0);
                nextPointerAddress = nextFoundValue + offsetsInBytes[i];
                ReadProcessMemory(processHandle, (IntPtr)nextPointerAddress, buffer, sizeOfTargetAddressInBytes, out numberOfReadBytes);
            }
            return nextPointerAddress;
        }
    }
}
