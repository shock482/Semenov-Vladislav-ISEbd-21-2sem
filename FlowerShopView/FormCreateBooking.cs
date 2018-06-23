﻿using FlowerShopService.DataFromUser;
using FlowerShopService.Interfaces;
using FlowerShopService.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using Unity.Attributes;

namespace FlowerShopView
{
    public partial class FormCreateBooking : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly InterfaceCustomerService serviceClient;

        private readonly InterfaceOutputService serviceProduct;

        private readonly InterfaceMainService serviceMain;

        public FormCreateBooking(InterfaceCustomerService serviceC, InterfaceOutputService serviceP, InterfaceMainService serviceM)
        {
            InitializeComponent();
            this.serviceClient = serviceC;
            this.serviceProduct = serviceP;
            this.serviceMain = serviceM;
        }

        private void FormCreateOrder_Load(object sender, EventArgs e)
        {
            try
            {
                List<ModelCustomerView> listClient = serviceClient.getList();
                if (listClient != null)
                {
                    comboBoxClient.DisplayMember = "CustomerFullName";
                    comboBoxClient.ValueMember = "Id";
                    comboBoxClient.DataSource = listClient;
                    comboBoxClient.SelectedItem = null;
                }
                List<ModelOutputView> listProduct = serviceProduct.getList();
                if (listProduct != null)
                {
                    comboBoxProduct.DisplayMember = "OutputName";
                    comboBoxProduct.ValueMember = "Id";
                    comboBoxProduct.DataSource = listProduct;
                    comboBoxProduct.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcSum()
        {
            if (comboBoxProduct.SelectedValue != null && !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxProduct.SelectedValue);
                    ModelOutputView product = serviceProduct.getElement(id);
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxSum.Text = (count * (int)product.Price).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void comboBoxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxClient.SelectedValue == null)
            {
                MessageBox.Show("Выберите клиента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxProduct.SelectedValue == null)
            {
                MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                serviceMain.createOrder(new BoundBookingModel
                {
                    CustomerID = Convert.ToInt32(comboBoxClient.SelectedValue),
                    OutputID = Convert.ToInt32(comboBoxProduct.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text),
                    Summa = Convert.ToInt32(textBoxSum.Text)
                });
                MessageBox.Show("Сохранение прошло успешно", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
