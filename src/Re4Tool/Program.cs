using System.Diagnostics;

namespace Re4Tool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Get a reference to the game process
            var process = Process.GetProcessesByName("bio4").FirstOrDefault();
            
            //The address will be relative: we have to start from the base address of the main module. The main module is basically the .exe
            var address = process.MainModule.BaseAddress.ToInt64() + 0x3091E3;
           
            //0x90 is a NOP instruction - "no operation"
            var bytes = new byte[]{0x90, 0x90, 0x90, 0x90};
            
            //Overwrite the game's code
            process.WriteMemory(address, bytes);


            //Overwrite the game memory instead of code
            address = process.MainModule.BaseAddress.ToInt64() + 0x85F708;
            bytes = BitConverter.GetBytes(999999999);
            process.WriteMemory(address, bytes);
        }
    }
}