using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BlackJackGame
{
    public partial class HistoryForm : Form
    {
        public HistoryForm(List<GameResult> history)
        {
            InitializeComponent();
            dataGridView1.DataSource = history;
        }
    }
}
