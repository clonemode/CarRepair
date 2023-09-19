﻿using CarRepair_CommonCL.Models;
using CarRepair_Dispatch_Client;
using CarRepair_Dispatch_Client.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarRepair_Dispatch_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class QueryWindow : Window
    {
        public QueryWindow()
        {
            InitializeComponent();
            UpdateRepairList();
        }

        private void CarList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedRecord = CarsListBox.SelectedItem as CarRecord;

            if (selectedRecord != null)
            {
                var window = new CarWindow(selectedRecord);
                if (window.ShowDialog() ?? false)
                {
                    UpdateRepairList();
                }

                CarsListBox.UnselectAll();
            }
        }

  
        
        private void UpdateRepairList()
        {
            var repairs = CarRecordProvider.GetCarRecords().ToList();
            CarsListBox.ItemsSource = repairs;
        }

        private void CreateRecordEvent(object sender, RoutedEventArgs e)
        {
            var window = new CarWindow(null);
            if (window.ShowDialog() ?? false)
            {
                UpdateRepairList();
            }
        }
    }
}
