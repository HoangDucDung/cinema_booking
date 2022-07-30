﻿using System;
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
    public partial class ShowGUI : Form
    {
        CinemaContext context;
        bool check;
        public ShowGUI(bool check)
        {
            this.check = check;
            InitializeComponent();
            context = new CinemaContext();
            cboFilmId.DataSource = context.Films.ToList<Film>();
            cboFilmId.DisplayMember = "Title";
            cboFilmId.ValueMember = "FilmId";

            dtpShowDate.Value = DateTime.Now;

            cboRoomId.DataSource = context.Rooms.ToList<Room>();
            cboRoomId.DisplayMember = "Name";
            cboRoomId.ValueMember = "RoomId";
            if(check == false)
            {
                btnAdd.Visible = false;
            }
            
            bindGrid(false);
        }

        void bindGrid(bool filter)
        { 
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = context.Shows
                .Where(s => s.FilmId == (filter ? (int)cboFilmId.SelectedValue : s.FilmId)
                && s.ShowDate == (filter ? dtpShowDate.Value : s.ShowDate)
                && s.RoomId == (filter ? (int)cboRoomId.SelectedValue : s.RoomId))
                .OrderByDescending(s => s.ShowDate)
                .ToList<Show>();
            int count = dataGridView1.Columns.Count;

            DataGridViewButtonColumn btnBooking = new DataGridViewButtonColumn
            {
                Name = "Booking",
                Text = "Booking",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Insert(count, btnBooking);
            if (check == true)
            {
                DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn
                {
                    Name = "Edit",
                    Text = "Edit",
                    UseColumnTextForButtonValue = true
                };
                dataGridView1.Columns.Insert(count + 1, btnEdit);

                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn
                {
                    Name = "Delete",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true
                };
                dataGridView1.Columns.Insert(count + 2, btnDelete);
            }
            dataGridView1.Columns["showId"].Visible = false;
            dataGridView1.Columns["status"].Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (check == true)
            {
                if (e.ColumnIndex == dataGridView1.Columns["Edit"].Index)
                {
                    int showId;
                    showId = (int)dataGridView1.Rows[e.RowIndex].Cells["ShowId"].Value;
                    //Show show = ShowDAO.GetInstance().GetById(showId);
                    // Show show = context.Shows.Find(showId);

                    AddEditGUI f = new AddEditGUI(0, showId, context);
                    DialogResult dr = f.ShowDialog();
                    if (dr == DialogResult.OK)
                        bindGrid(false);

                }
                if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
                {
                    DialogResult dr = MessageBox.Show("Do you want to delete?", "Confirm",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.No) return;
                    try
                    {
                        int showId;
                        showId = (int)dataGridView1.Rows[e.RowIndex].Cells["ShowId"].Value;
                        //Show show = ShowDAO.GetInstance().GetById(showId);
                        Show show = context.Shows.Find(showId);
                        context.Shows.Remove(show);
                        context.SaveChanges();

                        bindGrid(false);
                        MessageBox.Show("That shows is deleted!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
            if (e.ColumnIndex == dataGridView1.Columns["Booking"].Index)
            {
                int showId = (int)dataGridView1.Rows[e.RowIndex].Cells["ShowId"].Value;
                Show show = context.Shows.Find(showId);
                BookingGUI bg = new BookingGUI(show, context);
                DialogResult dr = bg.ShowDialog();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bindGrid(true);
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            numberRow.Text = dataGridView1.Rows.Count.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int roomId;
            roomId = (int)cboRoomId.SelectedValue;
            AddEditGUI f = new AddEditGUI(1, roomId, context);
            DialogResult dr = f.ShowDialog();
            if (dr == DialogResult.OK)
                bindGrid(false);
        }
    }
}
