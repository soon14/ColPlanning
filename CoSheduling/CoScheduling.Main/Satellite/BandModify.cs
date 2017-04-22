﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CoScheduling.Main.Satellite
{
    public partial class BandModify : Form
    {
        string band_id = "";
        string platform_id = "";
        string sensor_id = "";
        CoScheduling.Core.Model.Sensor_Band_Mode sensor_band_mode = new Core.Model.Sensor_Band_Mode();
        CoScheduling.Core.DAL.Sensor_Band_Mode dal_sensor_band_mode = new Core.DAL.Sensor_Band_Mode();
        CoScheduling.Core.Model.Sensor_1 sensor1 = new Core.Model.Sensor_1();
        CoScheduling.Core.DAL.Sensor_1 dal_sensor1 = new Core.DAL.Sensor_1();
        CoScheduling.Core.Model.SATELLITE_RANGE satellite_range = new Core.Model.SATELLITE_RANGE();
        public BandModify(string bandid, string platformid, string sensorid)
        {
            band_id = bandid;
            platform_id = platformid;
            sensor_id = sensorid;
            InitializeComponent();
        }
        public BandModify()
        {
            InitializeComponent();
        }

        private void BandModify_Load(object sender, EventArgs e)
        {
            sensor1 = dal_sensor1.GetModel(Convert.ToDecimal(sensor_id));
            sensor_band_mode = dal_sensor_band_mode.GetModel(platform_id, sensor_id, band_id);
            this.txtPLATFORMID.Text += sensor1.PLATFORM_ID;
            this.txtSensorID.Text += sensor1.SensorID;

            List<ListItem> items = new List<ListItem>();
            if (sensor1.SensorType == "1")
            {
                label4.Text += "(μm)";
                this.comboBoxPolar.Visible = false;
                this.comboBoxPolar.SelectedItem = "TBD";
                label6.Text += "(nm)";
                items.Add(new ListItem("1", "PAN"));
                items.Add(new ListItem("2", "VIS"));
                items.Add(new ListItem("3", "NIR"));
                items.Add(new ListItem("4", "SWIR"));
                items.Add(new ListItem("5", "MWIR"));
                items.Add(new ListItem("6", "TIR"));
                items.Add(new ListItem("7", "FIR"));
                items.Add(new ListItem("8", "UV"));

                items.Add(new ListItem("9", "UV - VIS"));
                items.Add(new ListItem("10", "UV - NIR"));
                items.Add(new ListItem("11", "UV - MWIR"));
                items.Add(new ListItem("12", "UV - FIR"));

                items.Add(new ListItem("13", "VIS - NIR"));
                items.Add(new ListItem("14", "VIS - MWIR"));
                items.Add(new ListItem("15", "VIS - TIR"));
                items.Add(new ListItem("16", "VIS - FIR"));


                items.Add(new ListItem("17", "NIR - SWIR"));

                items.Add(new ListItem("18", "MWIR - FIR"));
                items.Add(new ListItem("19", "MWIR - TIR"));

                items.Add(new ListItem("20", "TIR - FIR"));
            }
            else
            {
                label4.Text += "(GHz)";
                label6.Text += "(MHz)";
                this.txtSpeMin.ReadOnly = true;
                this.txtSpeMax.ReadOnly = true;

                items.Add(new ListItem("1", "L"));
                items.Add(new ListItem("2", "S"));
                items.Add(new ListItem("3", "C"));
                items.Add(new ListItem("4", "X"));
                items.Add(new ListItem("5", "Ku"));
                items.Add(new ListItem("6", "K"));
                items.Add(new ListItem("7", "Ka"));
                items.Add(new ListItem("8", "V"));
                items.Add(new ListItem("9", "W"));
                items.Add(new ListItem("10", "mm"));
                items.Add(new ListItem("11", "MW"));
            }
            items.Add(new ListItem("21", "TBD"));
            comboBoxBandType.DisplayMember = "Text";
            comboBoxBandType.ValueMember = "Value";
            comboBoxBandType.DataSource = items;
            

            this.txtBandID.Text = sensor_band_mode.BandID.ToString();
            this.txtBandName.Text = sensor_band_mode.BAND_MODE_NAME.ToString();
            this.txtBandSwathWidth.Text = sensor_band_mode.SwathWidth.ToString();
            this.comboBoxBandType.SelectedItem = sensor_band_mode.BandType;
            this.txtSpeMin.Text = sensor_band_mode.SpectralRangeMin.ToString();
            this.txtSpeMax.Text = sensor_band_mode.SpectralRangeMax.ToString();
            this.txtBandCenter.Text = sensor_band_mode.BandCenter.ToString();
            this.txtBandWidth.Text = sensor_band_mode.BandWidth.ToString();
            this.comboBoxPolar.SelectedItem = sensor_band_mode.PolarizationMode;
            this.txtAzimuResolution.Text = sensor_band_mode.AzimuthDirectionResolution.ToString();
            this.txtDistanceResolution.Text = sensor_band_mode.DistanceResolution.ToString();
            this.txtGeometryResolution.Text = sensor_band_mode.GeometryResolution.ToString();
            this.txtSNR.Text = sensor_band_mode.SNRRatio.ToString();
        }

        private void ButtonModify_Click(object sender, EventArgs e)
        {
            //给sensor_band_mode实体赋值
            try
            {
                sensor_band_mode.BandID = Convert.ToDecimal(this.txtBandID.Text);
                sensor_band_mode.BAND_MODE_NAME = this.txtBandName.Text;
                sensor_band_mode.SensorID = Convert.ToDecimal(sensor_id);
                sensor_band_mode.PLATFORM_ID = Convert.ToDecimal(platform_id);
                sensor_band_mode.SwathWidth = Convert.ToDecimal(this.txtBandSwathWidth.Text);
                sensor_band_mode.BandType = Convert.ToString(this.comboBoxBandType.SelectedItem);
                sensor_band_mode.SpectralRangeMin = Convert.ToDecimal(this.txtSpeMin.Text);
                sensor_band_mode.SpectralRangeMax = Convert.ToDecimal(this.txtSpeMax.Text);
                sensor_band_mode.BandCenter = Convert.ToDecimal(this.txtBandCenter.Text);
                sensor_band_mode.BandWidth = Convert.ToDecimal(this.txtBandWidth.Text);
                sensor_band_mode.PolarizationMode = Convert.ToString(this.comboBoxPolar.SelectedItem);
                sensor_band_mode.GeometryResolution = Convert.ToDecimal(this.txtGeometryResolution.Text);
                sensor_band_mode.AzimuthDirectionResolution = Convert.ToDecimal(this.txtAzimuResolution.Text);
                sensor_band_mode.DistanceResolution = Convert.ToDecimal(this.txtDistanceResolution.Text);
                sensor_band_mode.SNRRatio = Convert.ToDecimal(this.txtSNR.Text);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("请输入合法参数！");
                return;
            }
            try
            {
                //检查是否为空
                if (string.IsNullOrEmpty(this.txtBandID.Text) ||
                    string.IsNullOrEmpty(this.comboBoxBandType.SelectedItem.ToString()))
                {
                    MessageBox.Show("输入信息不完整！");
                    return;
                }
                //添加
                dal_sensor_band_mode.Update(sensor_band_mode);
                MessageBox.Show("波段修改成功！");
                //回传给父窗体消息
                //更新各个表中的属性没有写
                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();

            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString());
            }
        }
    }
}
