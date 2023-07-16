﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using WebApplication3.DTO;
using WebApplication3.DAL;

namespace WebApplication3.BL
{
    public class DeviceManager
    {
        DeviceDAL deviceDAL;

        public DeviceManager()
        {
            deviceDAL = new DeviceDAL();
        }
        public List<Device> Find(string key)
        {
            // 1. key - quantity
            // 2. key - name
            int id;
            bool success = int.TryParse(key, out id);
            if (success)
            {
                return deviceDAL.SelectByIdOrQuantity(id);
            }
            else
            {
                return deviceDAL.SelectByName(key);
            }
        }
        public void Import(string filePath)
        {
            StreamReader reader = new StreamReader(filePath);
            try
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    //tách chuỗi gán vào mảng 
                    string[] tokens = line.Split(',');
                    string name = tokens[0];
                    int quantity = Convert.ToInt32(tokens[1]);
                    deviceDAL.Insert(new Device(0, name, quantity));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                reader.Close();
            }
        }

        public void Export(string filePath)
        {
            StreamWriter writer = new StreamWriter(filePath);
            try
            {
                foreach (Device item in deviceDAL.SelectAll())
                {
                    writer.WriteLine(item);
                    writer.Flush();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                writer.Close();
            }
        }

        public int AddNew(Device d)
        {
            return deviceDAL.Insert(d);
        }

        public int UpdateName(Device d, string name)
        {
            return deviceDAL.UpdateName(d,name);
        }

        public int UpdateQuantity(Device d, int quantity)
        {
            return deviceDAL.UpdateQuantity(d, quantity);
        }

        public int Delete(int id)
        {
            return deviceDAL.Delete(id);
        }
    }
}
