using System;
using System.Collections;
using System.Net.Mail;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace ind3_v1
{
    public partial class Form1 : Form
    {
        private ArrayList addresses = new ArrayList();
        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
        }
        private void Update()
        {
            listBox1.Items.Clear();
            foreach (Address address in addresses)
            {
                listBox1.Items.Add(address.Info());
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string message = "";
            string organization = textBox1.Text;
            if (string.IsNullOrEmpty(organization))
            {
                message += "Введите название организации";
            }
            string street = textBox2.Text;
            if (string.IsNullOrEmpty(street))
            {
                message += "\nВведите улицу организации";
            }
            string city = textBox3.Text;
            if (string.IsNullOrEmpty(city))
            {
                message += "\nВведите город организации";
            }

            if (!(message == ""))
            {
                MessageBox.Show(message, "Ошибка");
            }
            var newAddress = new Address(organization, street, city);
            addresses.Add(newAddress);
            Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                var selectedAddress = (Address)addresses[listBox1.SelectedIndex];
                string newOrganozation = textBox1.Text;
                string newStreet = textBox2.Text;
                string newCity = textBox3.Text;
                selectedAddress.Update(newOrganozation, newStreet, newCity);
                Update();
            }
            else
            {
                MessageBox.Show("Выберите адрес для изменения", "Ошибка");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex  != -1)
            {
                addresses.RemoveAt(listBox1.SelectedIndex);
                Update();
            }
            else
            {
                MessageBox.Show("Выберите адрес для удаления", "Ошибка");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists("Address.txt"))
                {
                    string[] lines = File.ReadAllLines("Address.txt");
                    addresses.Clear();
                    foreach (var line in lines)
                    {
                        if (string.IsNullOrWhiteSpace(line)) continue;
                        var parts = line.Split(',');
                        if (parts.Length == 3)
                        {
                            string organization = parts[0].Trim();
                            string street = parts[1].Trim();
                            string city = parts[2].Trim();
                            Address address = new Address(organization, street, city);
                            addresses.Add(address);
                        }
                        else
                        {

                        }
                    }
                    Update();
                }
                else
                {
                    MessageBox.Show("Файл не найден", "Ошибка");
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"Произошла ошибка при загрузке данных", "Ошибка");
            }
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;

            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
        }
    }
}
