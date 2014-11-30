namespace ReddIt.Model
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Newtonsoft.Json;


    public class ModelReddIt : DbContext
    {
        // Your context has been configured to use a 'ModelReddIt' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ReddIt.Models.ModelReddIt' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ModelReddIt' 
        // connection string in the application configuration file.
        public ModelReddIt()
            : base("name=ModelReddIt")
        {
            //drop db 
            //Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, string.Format("ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE", Database.Connection.Database));

            Database.SetInitializer(new DropCreateDatabaseAlways<ModelReddIt>());

        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<RootReddit> RootReddits { get; set; }

        public virtual DbSet<MediaEmbed> MediaEmbeds { get; set; }
        public virtual DbSet<Oembed> Oembeds { get; set; }
        public virtual DbSet<NewsItem> NewsItems { get; set; }
        public virtual DbSet<SecureMedia> SecureMedias { get; set; }
        public virtual DbSet<SecureMediaEmbed> SecureMediaEmbeds { get; set; }
        public virtual DbSet<Child> Childs { get; set; }
        public virtual DbSet<Data> Datas { get; set; }


    }

    // Generated classes from JSon2CSharp
    //TODO separate classes in files
    public class MediaEmbed
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string content { get; set; }
        public int? width { get; set; }
        public bool? scrolling { get; set; }
        public int? height { get; set; }
    }

    public class Oembed
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string provider_url { get; set; }
        public string description { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string author_name { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        public string html { get; set; }
        public int thumbnail_width { get; set; }
        public string version { get; set; }
        public string provider_name { get; set; }
        public string thumbnail_url { get; set; }
        public string type { get; set; }
        public int thumbnail_height { get; set; }
        public string author_url { get; set; }
    }

    public class SecureMedia
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string type { get; set; }
        public Oembed oembed { get; set; }
    }

    public class SecureMediaEmbed
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string content { get; set; }
        public int? width { get; set; }
        public bool? scrolling { get; set; }
        public int? height { get; set; }
    }


    public class Media
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string type { get; set; }
        public Oembed oembed { get; set; }
    }

    public class NewsItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string domain { get; set; }
        public object banned_by { get; set; }
        public MediaEmbed media_embed { get; set; }
        public string subreddit { get; set; }
        public string selftext_html { get; set; }
        public string selftext { get; set; }
        public object likes { get; set; }
        public List<object> user_reports { get; set; }
        public SecureMedia secure_media { get; set; }
        public string link_flair_text { get; set; }
         [JsonProperty("id")]
        public string redditid { get; set; }
        public int gilded { get; set; }
        public SecureMediaEmbed secure_media_embed { get; set; }
        public bool clicked { get; set; }
        public object report_reasons { get; set; }
        public string author { get; set; }
        public Media media { get; set; }
        public int score { get; set; }
        public object approved_by { get; set; }
        public bool over_18 { get; set; }
        public bool hidden { get; set; }
        public string thumbnail { get; set; }
        public string subreddit_id { get; set; }
        public bool edited { get; set; }
        public string link_flair_css_class { get; set; }
        public string author_flair_css_class { get; set; }
        public int downs { get; set; }
        public List<object> mod_reports { get; set; }
        public bool saved { get; set; }
        public bool is_self { get; set; }
        public string name { get; set; }
        public string permalink { get; set; }
        public bool stickied { get; set; }
        public long created { get; set; }
        public DateTime createdDate { get { return Helper.UnixTimeStamp.UnixTimeStampToDateTime(created); } set { Helper.UnixTimeStamp.UnixTimeStampToDateTime(created); } }
        public string url { get; set; }
        public string author_flair_text { get; set; }
        public string title { get; set; }
        public double created_utc { get; set; }
        public int ups { get; set; }
        public int num_comments { get; set; }
        public bool visited { get; set; }
        public object num_reports { get; set; }
        public string distinguished { get; set; }
    }

    public class Child
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string kind { get; set; }
        [JsonProperty("Data")]
        public NewsItem newsItem { get; set; }
    }

    public class Data
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string modhash { get; set; }
        public List<Child> children { get; set; }
        public string after { get; set; }
        public object before { get; set; }
    }

    public class RootReddit
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string kind { get; set; }
        public Data data { get; set; }
    }

}