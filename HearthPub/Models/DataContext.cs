using Microsoft.AspNetCore.Http;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace HearthPub.Models
{
    public class DataContext
    {
        public string ConnectionString { get; set; }

        public DataContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        //Get All Cards List
        public List<Cards> GetAllCards(String set, String player, String Name)
        {
            List<Cards> list = new List<Cards>();

            using (MySqlConnection msconnection = GetConnection())
            {
                msconnection.Open();
                if (set == "ori" && player == "ori" && Name == "ori")
                {
                    MySqlCommand mscommand = new MySqlCommand("select * from Cards", msconnection);
                    using (MySqlDataReader reader = mscommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Cards()
                            {
                                CardId = reader.GetString("card_id"),
                                CardName = reader.GetString("cardname"),
                                CardSet = reader.GetString("cardset"),
                                CardCost = reader.GetInt16("cost"),
                                CardType = reader.GetString("cardtype"),
                                CardGroup = reader.GetString("playerclass")
                            });
                        }
                    }
                }
                else if(set != "ori")
                {
                    MySqlCommand mscommand = new MySqlCommand("select * from Cards where cardset like '" + set + "'", msconnection);
                    using (MySqlDataReader reader = mscommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Cards()
                            {
                                CardId = reader.GetString("card_id"),
                                CardName = reader.GetString("cardname"),
                                CardSet = reader.GetString("cardset"),
                                CardCost = reader.GetInt16("cost"),
                                CardType = reader.GetString("cardtype"),
                                CardGroup = reader.GetString("playerclass")
                            });
                        }
                    }
                }
                else if(player != "ori")
                {
                    MySqlCommand mscommand = new MySqlCommand("select * from Cards where playerClass like '" + player + "'", msconnection);
                    using (MySqlDataReader reader = mscommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Cards()
                            {
                                CardId = reader.GetString("card_id"),
                                CardName = reader.GetString("cardname"),
                                CardSet = reader.GetString("cardset"),
                                CardCost = reader.GetInt16("cost"),
                                CardType = reader.GetString("cardtype"),
                                CardGroup = reader.GetString("playerclass")
                            });
                        }
                    }
                }
                else
                {
                    MySqlCommand mscommand = new MySqlCommand("select * from Cards where cardname like '%" + Name + "%'", msconnection);
                    using (MySqlDataReader reader = mscommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Cards()
                            {
                                CardId = reader.GetString("card_id"),
                                CardName = reader.GetString("cardname"),
                                CardSet = reader.GetString("cardset"),
                                CardCost = reader.GetInt16("cost"),
                                CardType = reader.GetString("cardtype"),
                                CardGroup = reader.GetString("playerclass")
                            });
                        }
                    }
                }
            }
            return list;
        }

        //Get All CardSets List
        public List<CardSet> GetAllSets()
        {
            List<CardSet> setlist = new List<CardSet>();

            using (MySqlConnection msconnection = GetConnection())
            {
                msconnection.Open();

                MySqlCommand mscommand = new MySqlCommand("select * from cardset", msconnection);
                using (MySqlDataReader reader = mscommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        setlist.Add(new CardSet()
                        {
                            Setname = reader.GetString("Setname"),
                            Releasetype = reader.GetString("Release type"),
                            Releasedate = reader.GetString("Release date"),
                            Removaldate = reader.GetString("Removal date"),
                            Common = reader.GetString("Common"),
                            Rare = reader.GetString("Rare"),
                            Epic = reader.GetString("Epic"),
                            Legendary = reader.GetString("Legendary")
                        });
                    }
                }
            }
            return setlist;
        }

        //Get Players
        public List<Player> GetAllPlayers()
        {
            List<Player> playerlist = new List<Player>();

            using (MySqlConnection msconnection = GetConnection())
            {
                msconnection.Open();

                MySqlCommand mscommand = new MySqlCommand("select * from player", msconnection);
                using (MySqlDataReader reader = mscommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        playerlist.Add(new Player()
                        {
                            Playerclass = reader.GetString("playerclass"),
                            Comment = reader.GetString("comment")
                        });
                    }
                }
            }
            return playerlist;
        }

        //Register Function
        public bool Rigister(string username, string password)
        {
            using (MySqlConnection msconnection = GetConnection())
            {
                msconnection.Open();

                MySqlCommand mscomm = msconnection.CreateCommand();

                mscomm.CommandText = "select * from users where username = '" + username + "'";
                mscomm.ExecuteNonQuery();
                using (MySqlDataReader reader = mscomm.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return false;
                    }
                }

                MySqlCommand mscommand = msconnection.CreateCommand();
                mscommand.CommandText = "insert into users(username, password) values(@username, @password)";
                mscommand.Parameters.AddWithValue("@username", username);
                mscommand.Parameters.AddWithValue("@password", password);
                mscommand.ExecuteNonQuery();

                msconnection.Close();
            }
            return true;
        }

        //Login Function
        public bool Login(string username, string password)
        {
            using (MySqlConnection msconnection = GetConnection())
            {
                msconnection.Open();

                MySqlCommand mscommand = msconnection.CreateCommand();
                mscommand.CommandText = "select * from users where username='" + username + "' and password='" + password + "'";
                var output = mscommand.ExecuteScalar();

                msconnection.Close();

                if (output != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //Add Cards Function
        public void Add(CardDetails tmp)
        {
            using (MySqlConnection msconnection = GetConnection())
            {
                msconnection.Open();

                MySqlCommand mscommand = msconnection.CreateCommand();
                MySqlCommand mscomm = msconnection.CreateCommand();

                mscommand.CommandText = "insert into carddetails(card_id, cardname, playerClass, cardtype, cardset, cardtext, cost, attack, health, rarity, collectible, race, how_to_earn, targeting_arrow_text, url) values(@CardId, @CardName, @CardGroup, @CardType, @CardSet, @CardText, @CardCost, @CardAttack, @CardHealth, @CardRare, @CardCollect, @CardRace, @CardEarn, @CardTarget, @CardUrl)";
                mscomm.CommandText = "insert into cards(card_id, cardname, playerClass, cardtype, cardset, cost) values(@CardId, @CardName, @CardGroup, @CardType, @CardSet, @CardCost)";
               
                mscommand.Parameters.AddWithValue("@CardId", tmp.CardId);
                mscommand.Parameters.AddWithValue("@CardName", tmp.CardName);
                mscommand.Parameters.AddWithValue("@CardType", tmp.CardType);
                mscommand.Parameters.AddWithValue("@CardGroup", tmp.CardGroup);
                mscommand.Parameters.AddWithValue("@CardSet", tmp.CardSet);
                mscommand.Parameters.AddWithValue("@CardText", tmp.CardText);
                mscommand.Parameters.AddWithValue("@CardCost", tmp.CardCost);
                mscommand.Parameters.AddWithValue("@CardAttack", tmp.CardAttack);
                mscommand.Parameters.AddWithValue("@CardHealth", tmp.CardHealth);
                mscommand.Parameters.AddWithValue("@CardRare", tmp.CardRare);
                mscommand.Parameters.AddWithValue("@CardCollect", tmp.CardCollect);
                mscommand.Parameters.AddWithValue("@CardRace", tmp.CardRace);
                mscommand.Parameters.AddWithValue("@CardEarn", tmp.CardEarn);
                mscommand.Parameters.AddWithValue("@CardTarget", tmp.CardTarget);
                mscommand.Parameters.AddWithValue("@CardUrl", tmp.CardUrl);

                mscomm.Parameters.AddWithValue("@CardId", tmp.CardId);
                mscomm.Parameters.AddWithValue("@CardName", tmp.CardName);
                mscomm.Parameters.AddWithValue("@CardType", tmp.CardType);
                mscomm.Parameters.AddWithValue("@CardGroup", tmp.CardGroup);
                mscomm.Parameters.AddWithValue("@CardSet", tmp.CardSet);
                mscomm.Parameters.AddWithValue("@CArdCost", tmp.CardCost);

                mscommand.ExecuteNonQuery();
                mscomm.ExecuteNonQuery();

                msconnection.Close();
            }
            return;
        }

        //Card Edit Function
        public void Edit(CardDetails tmp)
        {
            using (MySqlConnection msconnection = GetConnection())
            {
                msconnection.Open();

                MySqlCommand mscommand = msconnection.CreateCommand();
                MySqlCommand mscomm = msconnection.CreateCommand();

                mscommand.CommandText = "UPDATE carddetails SET card_id='"+tmp.CardId+"',cardname='"+tmp.CardName+"',playerClass='"+tmp.CardGroup+"',cardtype='"+tmp.CardType+"',cardset='"+tmp.CardSet+"',cardtext='"+tmp.CardText+"',cost='"+tmp.CardCost+"',attack='"+tmp.CardAttack+"',health='"+tmp.CardHealth+"',rarity='"+tmp.CardRare+"',collectible='"+tmp.CardCollect+"',race='"+tmp.CardRace+"',how_to_earn='"+tmp.CardEarn+"',targeting_arrow_text='"+tmp.CardTarget+"' WHERE (card_id = '"+tmp.CardId+"');";
                mscomm.CommandText = "UPDATE cards SET card_id='" + tmp.CardId + "',cardname='" + tmp.CardName + "',playerClass='" + tmp.CardGroup + "',cardtype='" + tmp.CardType + "',cardset='" + tmp.CardSet + "',cost='" + tmp.CardCost + "' WHERE (card_id = '" + tmp.CardId + "');";

                mscommand.ExecuteNonQuery();
                mscomm.ExecuteNonQuery();

                msconnection.Close();
            }
            return;
        }

        //View Card Details
        public CardDetails GetDetail(string name)
        {
            CardDetails list = new CardDetails();

            using (MySqlConnection msconnection = GetConnection())
            {
                msconnection.Open();

                MySqlCommand mscommand = new MySqlCommand("select * from carddetails where cardname='" + name + "'", msconnection);
                using (MySqlDataReader reader = mscommand.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        list.CardId = reader.GetString("card_id");
                        list.CardName = reader.GetString("cardname");
                        list.CardSet = reader.GetString("cardset");
                        list.CardText = reader.GetString("cardtext");
                        list.CardCost = reader.GetInt16("cost");
                        list.CardType = reader.GetString("cardtype");
                        list.CardGroup = reader.GetString("playerClass");
                        list.CardAttack = reader.GetString("attack");
                        list.CardHealth = reader.GetString("health");
                        list.CardRare = reader.GetString("rarity");
                        list.CardCollect = reader.GetString("collectible");
                        list.CardEarn = reader.GetString("how_to_earn");
                        list.CardTarget = reader.GetString("targeting_arrow_text");
                        list.CardUrl = reader.GetString("url");
                    }
                    else
                    {
                        return null;
                    }
                }
                msconnection.Close();
            }
            return list;
        }

        //Delete Cards Function
        public void Delete(string name)
        {
            CardDetails list = new CardDetails();

            using (MySqlConnection msconnection = GetConnection())
            {
                msconnection.Open();
                MySqlCommand mscommand = new MySqlCommand("DELETE FROM cards WHERE (cardname = '"+name+"')", msconnection);
                MySqlCommand mscom = new MySqlCommand("DELETE FROM carddetails WHERE (cardname = '" + name + "')", msconnection);
                mscom.ExecuteNonQuery();
                mscommand.ExecuteNonQuery();
                msconnection.Close();
            }
            return;
        }
    }
}
