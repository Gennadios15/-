/*
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers.Classic;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.Util;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using MySql.Data.MySqlClient;
using MySqlConnector;
using System.Data;
using System.IO;
using static Lucene.Net.Util.Packed.PackedInt32s;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Directory = Lucene.Net.Store.Directory;

namespace UniCalendar.Controllers
{
    public class SearchEngine
    {







        public void CopyMySQLDataToLuceneIndex()
        {
            string serverIp = "unicalendar.mysql.database.azure.com";
            string username = "admin1";
            string password = "FEFEdeefa1732!";
            string databaseName = "unicalendar_db";

            string dbConnectionString = string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);


            string query = "SELECT * FROM categories";
            const LuceneVersion lv = LuceneVersion.LUCENE_48;
            Analyzer a = new StandardAnalyzer(lv);
            Directory directory = FSDirectory.Open("C:\\MyIndex");
            var config = new IndexWriterConfig(lv, a);
            IndexWriter Writer = new IndexWriter(directory, config);

            using (var conn = new MySqlConnection(dbConnectionString))
            {
                conn.Open();

                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var document = new Document();
                            document.Add(new Field("idCategory", reader.GetString(0), Field.Store.NO, Field.Index.ANALYZED));
                            document.Add(new Field("CategoryName", reader.GetString(1), Field.Store.YES, Field.Index.ANALYZED));

                            Writer.AddDocument(document);
                        }
                        Writer.Commit();


                    }
                }
            }

        }


        public static Search(String input)
        {
            const LuceneVersion lv = LuceneVersion.LUCENE_48;
            Analyzer a = new StandardAnalyzer(lv);
            var dirReader = DirectoryReader.Open("C:\\MyIndex");
            var searcher = new IndexSearcher(dirReader);
            {
                using (Analyzer analyzer = new StandardAnalyzer(lv)
                using (var queryParser = new QueryParser(lv, "CategoryName", analyzer))
                {

                    var query = query.Parse(textSearch);

                    var collector = TopScoreDocCollector.Create(1000, true);

                    searcher.Search(query, collector);

                    var matches = collector.TopDocs().ScpreDocs;

                    foreach (var item in matches)
                    {
                        var id = item.Doc;
                        var doc = searcher.Doc(id);

                        var row = table.NewRow();
                        row["idCategory"] = doc.GetField("idCategory").StringValue;
                        row["CategoryName"] = doc.GetField("CategoryName").StringValue;
                        table.Rows.Add(row);
                    }
                }
            }
        }

    }*/