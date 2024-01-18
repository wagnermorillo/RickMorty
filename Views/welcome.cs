using RickMorty.Models.Models;
using RickMorty.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RickMorty
{
    public partial class welcome : Form
    {
        public welcome()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var charac = new CharacterRepository();
            Multiple<Character> value = await charac.GetFilter(page:3, name:"rick", gender:"");
            label1.Text = value.Info.Count.ToString() +" "+ value.Info.Pages+" "+value.Info.Next;


        }
    }
}
