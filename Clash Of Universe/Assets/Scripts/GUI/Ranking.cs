using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;

public class Ranking
{
    private XDocument RankXML;
    public List<KeyValuePair<string, int>> ListedRank;
    private Encryption encryption;

    public Ranking()
    {
        encryption = new Encryption();
        if (File.Exists("GameRank.spht"))
        {
            try
            {
                ListedRank = new List<KeyValuePair<string, int>>();
                byte[] rankEncrypted = File.ReadAllBytes("GameRank.spht");
                string rankDecrypted = encryption.Decrypt(rankEncrypted);
                RankXML = XDocument.Parse(rankDecrypted);
                XMLtoList();
            }
            catch (Exception e)
            {
                RankXML = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("GameRank", new XElement("Players")));
                ListedRank = new List<KeyValuePair<string, int>>();
            }
        }
        else
        {
            RankXML = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("GameRank", new XElement("Players")));
            ListedRank = new List<KeyValuePair<string, int>>();
        }
    }
    private void XMLtoList()
    {
        foreach (var elem in RankXML.Element("GameRank").Element("Players").Elements())
        {
            KeyValuePair<string, int> pair = new KeyValuePair<string, int>(elem.Name.ToString(), Convert.ToInt32(elem.FirstAttribute.Value));
            ListedRank.Add(pair);
        }
    }
    private void ListToXML()
    {
        RankXML = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("GameRank", new XElement("Players")));
        foreach (KeyValuePair<string, int> pair in ListedRank)
        {
            RankXML.Element("GameRank").Element("Players").Add(new XElement(pair.Key, new XAttribute("Score", pair.Value)));
        }
    }
    public void AddtoRank(KeyValuePair<string, int> pair)
    {
        ListedRank.Add(pair);
        ListedRank = ListedRank.OrderByDescending(x => x.Value).Take(10).ToList();
    }
    public void AddtoRank(string name, int value)
    {
        KeyValuePair<string, int> pair = new KeyValuePair<string, int>(name, value);

        ListedRank.Add(pair);
        ListedRank = ListedRank.OrderByDescending(x => x.Value).Take(10).ToList();
    }
    public void SaveRank()
    {
        ListToXML();
        string rankDecrypted = RankXML.ToString();
        byte[] rankEncrypted = encryption.Encrypt(rankDecrypted);

        using (FileStream fs = new FileStream("GameRank.spht", FileMode.OpenOrCreate))
        {
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                bw.Write(rankEncrypted);
                bw.Close();
            }
        }
    }
    public string GetRankTexted()
    {
        string TEXT = "";
        string SEP = ".";
        int SIZE = 55;

        if (ListedRank.Count > 0)
        {
            foreach (KeyValuePair<string, int> pair in ListedRank)
            {
                int fill = SIZE - pair.Key.Length - pair.Value.ToString().Length;
                TEXT += pair.Key;
                for (int i = fill; i >= 0; i--)
                {
                    TEXT += SEP;
                }
                TEXT += pair.Value.ToString() + "\n";
            }
            return TEXT;
        }
        else
        {
            return "Obecnie ranking jest pusty.\nZagraj w grę aby go zapełnić.";
        }
    }
}
