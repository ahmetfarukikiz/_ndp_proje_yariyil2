/****************************************************************************
**					SAKARYA �N�VERS�TES�
**				B�LG�SAYAR VE B�L���M B�L�MLER� FAK�LTES�
**				    B�LG�SAYAR M�HEND�SL��� B�L�M�
**				   NESNEYE DAYALI PROGRAMLAMA DERS�
**					2024-2025 BAHAR D�NEM�
**	
**				�DEV NUMARASI..........: Proje
**				��RENC� ADI............: Ahmet Faruk �kiz
**				��RENC� NUMARASI.......: B241210040   
**              DERS�N ALINDI�I GRUP...: B Grubu
****************************************************************************/

namespace _ndp_proje_yariyil2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new GirisMenuForm());
        }
    }
}