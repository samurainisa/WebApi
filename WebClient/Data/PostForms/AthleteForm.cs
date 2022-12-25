using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebClient.Data.Models;
using WebClient.Data.Service;
using WebClient.Data.Transfer;
using WebClient.Forms;

namespace WebClient.Data.PostForms
{
    public partial class AthleteForm : Form
    {
        private IAdminUseCases post = new UploadData();
        private readonly AuthInfo _authInfo;

        public AthleteForm()
        {
            InitializeComponent();
        }

        public AthleteForm(AuthInfo authInfo)
        {
            InitializeComponent();
            _authInfo = authInfo;
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            try
            {
                var firstnamee = textBox1.Text;
                var lastname = textBox2.Text;
                var clubname = textBox4.Text;
                var sportname = textBox3.Text;
                var trenername = textBox6.Text;
                var sportplacename = textBox5.Text;


                var athlete = new AthleteDto
                {
                    FirstName = firstnamee,
                    LastName = lastname,
                    ClubName = clubname,
                    SportName = sportname,
                    TrenerName = trenername,
                    SportPlaceName = sportplacename
                };

                if (athlete.FirstName == "" || athlete.LastName == "" || athlete.ClubName == "" ||
                    athlete.SportName == "" || athlete.TrenerName == "" || athlete.SportPlaceName == "")
                {
                    MessageBox.Show("Заполните все поля");
                    return;
                }


                var result = post.PostAthleteDto(athlete, _authInfo.access_token);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                Hide();
                AuthForm authForm = new AuthForm();
                authForm.Show();
            }
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.ForeColor = Color.DarkTurquoise;
        }

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.ForeColor = Color.Black;
        }
    }
}