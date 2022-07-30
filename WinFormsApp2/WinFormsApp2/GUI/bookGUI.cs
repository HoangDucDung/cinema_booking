using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp2.Model;

namespace WinFormsApp2.GUI
{
    public partial class bookGUI : Form
    {
        CinemaContext context;
        char[] mySeat;
        decimal amout;
        Show show;

        public bookGUI(Show show, CinemaContext context, int bid)
        {
            InitializeComponent();
            this.context = context;
            this.show = show;


            //MessageBox.Show(show.RoomId.ToString());
            Room room = context.Rooms.Find(show.RoomId);
            if (bid != 0)
            {
                textBox1.Enabled = false;
                Booking bk = context.Bookings.Find(bid);
                textBox1.Text = bk.Name;
                textBox2.Text = bk.Amount.ToString();
            }
            createBt((int)room.NumberCols, (int)room.NumberRows, show.ShowId, bid);
        }

        private void createBt(int col, int row, int showID, int bId)
        {
            string seatStatus = new string('0', col * row);
            char[] seats = seatStatus.ToCharArray();
            mySeat = seatStatus.ToCharArray();
            var b = context.Bookings.Where(s => s.ShowId == showID).ToList<Booking>();
            if(bId != 0)
            {
                b = context.Bookings.Where(s => s.BookingId == bId).ToList<Booking>();
            }

            foreach (Booking bk in b)
            {
                for (int i = 0; i < bk.SeatStatus.Length; i++)
                {
                    if (bk.SeatStatus[i] == '1') seats[i] = '1';
                }
            }

            //MessageBox.Show(seatStatus);
            int width = panel1.Width / (col + 1);
            int height = panel1.Height / (row + 1);
            for (int i = 0; i < row; i++)
                for (int j = 0; j < col; j++)
                {
                    CheckBox cb = new CheckBox();
                    int index = i * col + j;
                    cb.Size = new Size(width, height);
                    cb.Name = index.ToString();
                    if (seats[index] == '1')
                    {
                        cb.Enabled = false;
                        cb.Checked = true;
                    }
                    else
                    {
                        cb.Enabled = true;
                        cb.Checked = false;
                    }
                    if (bId != 0)
                    {
                        cb.Enabled = false;
                    }
                    cb.CheckedChanged += CheckedChanged;
                    cb.Location = new Point((j + 1) * width, (i + 1) * height);
                    panel1.Controls.Add(cb);
                }
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (cb.Checked) amout += (decimal)show.Price;
            else amout -= (decimal)show.Price;
            textBox2.Text = amout.ToString();
            mySeat[int.Parse(cb.Name)] = cb.Checked ? '1' : '0';
        }

        private void Save_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to save?", "Confirm",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No) return;
            try
            {
                Booking bk = new Booking();
                bk.ShowId = show.ShowId;
                bk.Name = textBox1.Text;
                bk.SeatStatus = new string(mySeat);
                bk.Amount = amout;
                context.Bookings.Add(bk);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
