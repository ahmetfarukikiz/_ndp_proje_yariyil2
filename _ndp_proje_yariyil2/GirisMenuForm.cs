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

using _ndp_proje_yariyil2.HizmetFormlar�;
using _ndp_proje_yariyil2.�demeFormlar�;
using _ndp_proje_yariyil2.Y�netimS�n�flar�;

namespace _ndp_proje_yariyil2
{
    public partial class GirisMenuForm : Form
    {
        private MekanYonetim _mekanYonetim;
        private KisiYonetim _kisiYonetim;
        private OdemeYonetim _odemeYonetim;
        private HavuzYonetim _havuzYonetim;
        private FitnessYonetim _fitnessYonetim;

        public GirisMenuForm()
        {
            InitializeComponent();
            _mekanYonetim = new MekanYonetim();
            _kisiYonetim = new KisiYonetim();
            _odemeYonetim = new OdemeYonetim();
            _havuzYonetim = new HavuzYonetim();
            _fitnessYonetim = new FitnessYonetim();



            _mekanYonetim.DosyadanYukle();
            _kisiYonetim.DosyadanYukle(_mekanYonetim);
            _odemeYonetim.DosyadanYukle(_kisiYonetim);
            _odemeYonetim.AbonelikKontrol();
            _havuzYonetim.DosyadanYukle();
            _fitnessYonetim.DosyadanYukle();

            HizmetYonetim.AyarlarTxtdenYukle();
        }

        private void GirisMenuForm_Load(object sender, EventArgs e)
        {
            _mekanYonetim.DosyaGuncelle(); //Dosyadaki olas� bir hatay� d�zeltmesi i�in dosyaGuncellemesi DosyaYuklendikten hemen sonra yap�lmal�d�r.
            _kisiYonetim.DosyaGuncelle();
            _odemeYonetim.DosyaGuncelle();
            _havuzYonetim.DosyaGuncelle();
            _fitnessYonetim.DosyaGuncelle();
            _kisiYonetim.DairedekiKisileriGuncelle(_mekanYonetim.Daireler);
            _odemeYonetim.KisiOdemeleriniGuncelle(_kisiYonetim.Oturanlar);
            tuslariGuncelle();


        }

        private void daireYonButton_Click(object sender, EventArgs e)
        {
            DaireYonetimForm daireYonetimForm = new DaireYonetimForm(_mekanYonetim, _kisiYonetim, _odemeYonetim);
            daireYonetimForm.Opacity = 0;
            daireYonetimForm.Show();
            daireYonetimForm.Location = this.Location;
            daireYonetimForm.Opacity = 1;
            daireYonetimForm.FormClosed += (s, args) => this.Show(); //DaireYonetimForm kapand���nda girisMenuForm u tekrar g�stericek
            daireYonetimForm.FormClosed += (s, args) => tuslariGuncelle(); //form kapand���nda tu�lar�n kontrol�n� sa�la
            daireYonetimForm.FormClosed += (s, args) => _odemeYonetim.AbonelikKontrol();
            this.Hide();

        }

        private void kisiYonButton_Click(object sender, EventArgs e)
        {
            KisiYonetimForm kisiYonetimForm = new KisiYonetimForm(_kisiYonetim, _mekanYonetim, _odemeYonetim);
            kisiYonetimForm.Opacity = 0;
            kisiYonetimForm.Show();
            kisiYonetimForm.Location = this.Location;
            kisiYonetimForm.Opacity = 1;
            kisiYonetimForm.FormClosed += (s, args) => this.Show(); //KisiYonetimForm kapand���nda girisMenuForm u tekrar g�stericek
            kisiYonetimForm.FormClosed += (s, args) => tuslariGuncelle(); //form kapand���nda tu�lar�n kontrol�n� sa�la
            kisiYonetimForm.FormClosed += (s, args) => _odemeYonetim.AbonelikKontrol();
            this.Hide();

        }

        private void odemeYonButton_Click(object sender, EventArgs e)
        {
            OdemeYonetimForm odemeYonetimForm = new OdemeYonetimForm(_odemeYonetim, _mekanYonetim, _kisiYonetim);
            odemeYonetimForm.Opacity = 0;
            odemeYonetimForm.Show();
            odemeYonetimForm.Location = this.Location;
            odemeYonetimForm.Opacity = 1;
            odemeYonetimForm.FormClosed += (s, args) => this.Show(); //oyunForm kapand���nda girisMenuForm u tekrar g�stericek
            odemeYonetimForm.FormClosed += (s, args) => tuslariGuncelle(); //form kapand���nda tu�lar�n kontrol�n� sa�la
            odemeYonetimForm.FormClosed += (s, args) => _odemeYonetim.AbonelikKontrol();
            this.Hide();

            
        }


        private void hizmetYonButton_Click(object sender, EventArgs e)
        {
            HizmetYonetimForm hizmetYonetimForm = new HizmetYonetimForm(_mekanYonetim, _kisiYonetim, _odemeYonetim, _havuzYonetim, _fitnessYonetim);
            hizmetYonetimForm.Opacity = 0;
            hizmetYonetimForm.Show();
            hizmetYonetimForm.Location = this.Location;
            hizmetYonetimForm.Opacity = 1;
            hizmetYonetimForm.FormClosed += (s, args) => this.Show(); //oyunForm kapand���nda girisMenuForm u tekrar g�stericek
            hizmetYonetimForm.FormClosed += (s, args) => _odemeYonetim.AbonelikKontrol();
            this.Hide();
        }

        private void cikisButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tuslariGuncelle()
        {
            kisiYonButton.Enabled = (_mekanYonetim.Daireler.Count != 0);
            odemeYonButton.Enabled = (_kisiYonetim.Oturanlar.Count != 0);
        }

        private void GirisMenuForm_Shown(object sender, EventArgs e)
        {
            _mekanYonetim.DosyaGuncelle(); //Dosyadaki olas� bir hatay� d�zeltmesi i�in dosyaGuncellemesi DosyaYuklendikten hemen sonra yap�lmal�d�r.
            _kisiYonetim.DosyaGuncelle();
            _odemeYonetim.DosyaGuncelle();
            _kisiYonetim.DairedekiKisileriGuncelle(_mekanYonetim.Daireler);
            _odemeYonetim.KisiOdemeleriniGuncelle(_kisiYonetim.Oturanlar);
            tuslariGuncelle();
        }

        private void GirisMenuForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Capture = false;


                Message m = Message.Create(Handle, 0xA1, new IntPtr(2), IntPtr.Zero);
                this.WndProc(ref m);
            }
        }

        private void ayarlarButton_Click(object sender, EventArgs e)
        {
            AyarlarForm ayarlarForm = new AyarlarForm();
            ayarlarForm.Location = new(this.Location.X+150, this.Location.Y+100) ;
            ayarlarForm.ShowDialog();
        }
    }
}
