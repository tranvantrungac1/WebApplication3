﻿using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using WebApplication3.DAL;
using WebApplication3.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplication3.BL
{
    public class UserManager
    {
        UserDAL userDAL;
        public UserManager()
        {
            userDAL = new UserDAL();
        }

        public User? Login(string username, string password)
        {
            return userDAL.SelectByUsernameAndPassword(username, password);
        }

        public List<User> Find(string key)
        {
            // 1. key - id
            // 2. key - username | fullname
            //int id;
            //bool success = int.TryParse(key, out id);
            //if (success)
            //{
            //    List<User> users = new List<User>();
            //    User? user = userDAL.SelectById(id);
            //    users.Add(user);
            //    return users;
            //}
            //else
            //{
                return userDAL.SelectByKey(key);
            //}
        }

        //public void Import(string filePath)
        //{
        //    StreamReader reader = new StreamReader(filePath);
        //    try
        //    {
        //        string line;
        //        while ((line = reader.ReadLine()) != null)
        //        {
        //            //tách chuỗi gán vào mảng 
        //            string[] tokens = line.Split(',');
        //            string username = tokens[0];
        //            string fullname = tokens[1];
        //            string password = tokens[2];
        //            UserRole role = (UserRole)Convert.ToInt32(tokens[3]);
        //            userDAL.Insert(new User(0, username, fullname, Utils.Hash(password), role));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    finally
        //    {
        //        reader.Close();
        //    }
        //}

        //public void Export(string filePath)
        //{
        //    StreamWriter writer = new StreamWriter(filePath);
        //    try
        //    {
        //        foreach (User item in userDAL.SelectAll())
        //        {
        //            writer.WriteLine(item);
        //            writer.Flush();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    finally
        //    {
        //        writer.Close();
        //    }
        //}
        public User? FindId(int id)
        {
            return userDAL.SelectById(id);
        }
        public List<User> FindAll()
        {
            return userDAL.SelectAll();
        }
        public int AddNew(User u)
        {
            return userDAL.Insert(u);
        }

        public int UpdateFullname(User u, string fullname)
        {
            
            return userDAL.UpdateFullname(u, fullname);
        }

        public int UpdatePassword(User u, string password)
        {
            return userDAL.UpdatePassword(u, password);
        }

        public int Delete(int id)
        {
            return userDAL.Delete(id);
        }

    }
}

