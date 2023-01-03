using MySql.Data.MySqlClient;

namespace Proje
{
    internal class kontrol
    {
        string con = "Server=localhost;Database=proje;Uid=root;Pwd='';";

        public int giris(string ka, string sf)
        {
            int sonuc = 0;

            using (var baglan = new MySqlConnection(con))
            {
                using (var komut = new MySqlCommand($"SELECT ka,sf FROM kullanici WHERE ka='{ka}' AND sf='{sf}'", baglan))
                {

                    try
                    {
                        komut.Connection.Open();
                        MySqlDataReader dr = komut.ExecuteReader();
                        if (dr.Read())
                        {
                            string k = dr["ka"].ToString();
                            string s = dr["sf"].ToString();
                            if (k == ka && s == sf)
                            {
                                sonuc = 1;
                            }
                            else
                            {
                                sonuc = 0;
                            }
                        }
                    }
                    catch (System.Exception)
                    {

                        sonuc =0;
                    }
                    
                }
            }
            return sonuc;
        }
    }
}
