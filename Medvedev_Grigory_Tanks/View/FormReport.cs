using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace View
{
    public partial class FormReport : Form
    {
        private ListEntities entities;

        public FormReport(ListEntities entities)
        {
            InitializeComponent();
            this.entities = entities;
            timerReport.Enabled = true;
        }

        private void TimerReport_Tick(object sender, EventArgs e)
        {
            dataGridViewReport.Rows.Clear();

            dataGridViewReport.Rows.Add();
            dataGridViewReport.Rows[0].Cells[0].Value = $"({entities.Kolobok.Pos.x.ToString()} , {entities.Kolobok.Pos.y.ToString()})";

            for (int i = 0; i < entities.Apples.Count; i++)
            {
                dataGridViewReport.Rows.Add();
                dataGridViewReport.Rows[i].Cells[1].Value = $"({entities.Apples[i].Pos.x.ToString()} , {entities.Apples[i].Pos.y.ToString()})";
            }

            for (int i = 0; i < entities.Tanks.Count; i++)
            {
                dataGridViewReport.Rows.Add();
                dataGridViewReport.Rows[i].Cells[2].Value = $"({entities.Tanks[i].Pos.x.ToString()} , {entities.Tanks[i].Pos.y.ToString()})";
            }

            for (int i = 0; i < entities.Bullets.Count; i++)
            {
                dataGridViewReport.Rows.Add();
                dataGridViewReport.Rows[i].Cells[3].Value = $"({entities.Bullets[i].Pos.x.ToString()} , {entities.Bullets[i].Pos.y.ToString()})";
            }
        }
    }
}
