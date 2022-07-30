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
    public partial class BookingGUI : Form
    {
        CinemaContext context;
        Show show;
        public BookingGUI(Show shows, CinemaContext context)
        {
            this.context = context;
            this.show = shows;
            Room room = context.Rooms.Find(shows.RoomId);
            InitializeComponent();
            bindGrid(shows.ShowId);
            createBt((int)room.NumberCols, (int)room.NumberRows, shows.ShowId);
        }
        private void bindGrid(int showID)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = context.Bookings.Where(s => s.ShowId == showID).ToList<Booking>();
            int count = dataGridView1.Columns.Count;

            DataGridViewButtonColumn btnDetail = new DataGridViewButtonColumn
            {
                Name = "Detail",
                Text = "Detail",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Insert(count, btnDetail);

            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn
            {
                Name = "Delete",
                Text = "Delete",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Insert(count + 1, btnDelete);
            dataGridView1.Columns["BookingId"].Visible = false;
            dataGridView1.Columns["ShowId"].Visible = false;
        }

        private void createBt(int col, int row, int showID)
        {
            string seatStatus = new string('0', col * row);
            char[] seats = seatStatus.ToCharArray();

            var b = context.Bookings.Where(s => s.ShowId == showID).ToList<Booking>();

            foreach (Booking bk in b)
            {
                for (int i = 0; i < bk.SeatStatus.Length; i++)
                {
                    if (bk.SeatStatus[i] == '1') seats[i] = '1';
                }
            }

            //MessageBox.Show(seatStatus);
            panel1.Controls.Clear();
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
                        cb.Enabled = false;
                        cb.Checked = false;
                    }
                    cb.Location = new Point((j + 1) * width, (i + 1) * height);
                    panel1.Controls.Add(cb);
                }
        }

        private void booking_Click(object sender, EventArgs e)
        {
            Show sh = context.Shows.Find(show.ShowId);
            Room room = context.Rooms.Find(sh.RoomId);
            bookGUI bk = new bookGUI(sh, context, 0);
            DialogResult dr = bk.ShowDialog();
            if (dr == DialogResult.OK)
                bindGrid(sh.ShowId);
                createBt((int)room.NumberCols, (int)room.NumberRows, sh.ShowId);
        }

        private void cellClick_DetailDelete(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Detail"].Index)
            {
                int bookingID = (int)dataGridView1.Rows[e.RowIndex].Cells["BookingId"].Value;
                int showid = (int)dataGridView1.Rows[e.RowIndex].Cells["ShowId"].Value;

                Show sh = context.Shows.Find(showid);

                bookGUI bg = new bookGUI(show, context, bookingID);
                DialogResult dr = bg.ShowDialog();
            }
            if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
            {
                int bookingID = (int)dataGridView1.Rows[e.RowIndex].Cells["BookingId"].Value;
                int showid = (int)dataGridView1.Rows[e.RowIndex].Cells["ShowId"].Value;

                Show sh = context.Shows.Find(showid);
                Room room = context.Rooms.Find(sh.RoomId);
                Booking bk = context.Bookings.Find(bookingID);

                DialogResult dr = MessageBox.Show("Do you want to delete?", "Confirm",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No) return;

                context.Bookings.Remove(bk);
                context.SaveChanges();

                bindGrid(sh.ShowId);
                createBt((int)room.NumberCols, (int)room.NumberRows, sh.ShowId);
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            numberRow.Text = dataGridView1.Rows.Count.ToString();
        }
    }


}
