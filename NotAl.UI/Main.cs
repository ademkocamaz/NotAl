using NotAl.Business.Abstract;
using NotAl.Business.DependencyResolvers.Ninject;
using NotAl.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotAl.UI
{
    public partial class Main : Form
    {
        private INoteService noteService;
        public Main()
        {
            InitializeComponent();
            noteService = InstanceFactory.GetInstance<INoteService>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView_Notes.AutoGenerateColumns = false;
            //dataGridView_Notes.Columns["Not"].DataPropertyName = "Title";
            LoadNotes();
        }

        private void LoadNotes()
        {
            dataGridView_Notes.DataSource = noteService.GetAll();
            Clear();
        }

        private void Clear()
        {
            textBox_Title.Text = "";
            richTextBox_Detail.Text = "";
        }

        private void dataGridView_Notes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //textBox1.Text = dataGridView_Notes.CurrentRow.Cells["ID"].Value.ToString();
            Note note = noteService.Get(Convert.ToInt32(dataGridView_Notes.CurrentRow.Cells["ID"].Value));
            textBox_Title.Text = note.Title;
            richTextBox_Detail.Text = note.Detail;
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            Note note = new Note();
            note.Title = textBox_Title.Text;
            note.Detail = richTextBox_Detail.Text;
            noteService.Add(note);
            LoadNotes();
        }

        private void button_Update_Click(object sender, EventArgs e)
        {
            Note note = new Note();
            note.Id = Convert.ToInt32(dataGridView_Notes.CurrentRow.Cells["ID"].Value);
            note.Title = textBox_Title.Text;
            note.Detail = richTextBox_Detail.Text;
            noteService.Update(note);
            LoadNotes();
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            Note note = new Note();
            note.Id = Convert.ToInt32(dataGridView_Notes.CurrentRow.Cells["ID"].Value);
            noteService.Delete(note);
            LoadNotes();
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
