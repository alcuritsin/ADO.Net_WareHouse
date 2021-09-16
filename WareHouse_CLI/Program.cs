// See https://aka.ms/new-console-template for more information

using System;
using LibDB;

static void Main()
{
    var db = new DataBase();

    db.Open();
    Console.WriteLine("Hello, World!");
    Console.WriteLine(DataBase.Info());
    Console.WriteLine(DataBase.InfoVersion());
    db.Close();
}