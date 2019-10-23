using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackpackTask
{
    public partial class Form1 : Form
    {
        private List<Item> items;

        public Form1()
        {
            InitializeComponent();

            AddItems();
            ShowItems(items);
        }

        private void AddItems()
        {
            items = new List<Item>();

            items.Add(new Item("Книга", 1, 600));
            items.Add(new Item("Бинокль", 2, 5000));
            items.Add(new Item("Аптечка", 4, 1500));
            items.Add(new Item("Ноутбук", 2, 40000));
            items.Add(new Item("Котелок", 1, 500));
        }

        private void ShowItems(List<Item> _items)
        {
            itemsListView.Items.Clear();

            foreach (Item i in _items)
            {
                itemsListView.Items.Add(new ListViewItem(new string[] { i.name, i.weigth.ToString(), 
                    i.price.ToString() }));
            }
        }
        private void ShowConditionsButton_Click(object sender, EventArgs e)
        {
            ShowItems(items);
        }

        //решить задачу
        private void solveButton_Click(object sender, EventArgs e)
        {
            Backpack bp = new Backpack(Convert.ToDouble(weightTextBox.Text));

            bp.MakeAllSets(items);

            List<Item> solve = bp.GetBestSet();

            if(solve == null)
            {
                MessageBox.Show("Нет решения!");
            }
            else
            {
                itemsListView.Items.Clear();

                ShowItems(solve);
            }
        }

        private void button1_Click(object sender, EventArgs e) //bubble
        {
            Random rand = new Random();
            string result=null;
            string start = null;
            int temp;
            List<int> list = new List<int>();
            for(int i = 0; i < 10; i++)
            {

                list.Add(rand.Next(10));
                start += list[i]+" ";


            }
            textBoxStart.Text = start;

            for (int i = 0; i < list.Count - 1; i++)
            {

                for (int j = 0; j < list.Count - i - 1; j++)
                {
                    if (list[j + 1] > list[j])
                    {

                        temp = list[j + 1];
                        list[j + 1] = list[j];
                        list[j] = temp;
                    }
                }

            }

            for (int i = 0; i < list.Count; i++)
            {
                result += Convert.ToString(list[i]) + " ";
            }
            textBoxResult.Text = result;
            result = "";

        }

        private void button2_Click(object sender, EventArgs e) //fast
        {

            Random rand = new Random();
            string result = null;
            string start = null;
            
            List<int> list = new List<int>();
            for (int i = 0; i < 10; i++)
            {

                list.Add(rand.Next(10));
                start += list[i] + " ";


            }
            textBoxStart.Text = start;

            Sort(list, 0, list.Count - 1);
            for (int i = 0; i < list.Count; i++)
            {
                result += Convert.ToString(list[i]) + " ";
            }
            textBoxResult.Text = result;
            result = "";





        }
        static void Sort(List<int> list, int l, int r)
        {

            int i = l;
            int j = r;
            int x = list[(l + r) / 2];

            while (i <= j)
            {
                while (list[i] < x) i++;
                while (list[j] > x) j--;

                if (i <= j)
                {

                    int temp = list[i];
                    list[i] = list[j];
                    list[j] = temp;
                    i++;
                    j--;
                }
            }

            if (l < j) Sort(list, l, j);
            if (i < r) Sort(list, i, r);
        }


        private void button3_Click(object sender, EventArgs e)
        {
            string result="0"+ " "+"1"+ " ";
            int n = 10;          
            int x = 1;
            int y = 0;
            for (int i = 0; i < n; i++)
            {
                x += y;
                y = x - y;
                result += x+" ";

            }
            textBoxResult.Text = result;


        }
    }
}