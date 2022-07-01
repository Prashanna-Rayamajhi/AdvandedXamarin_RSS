using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;

namespace Finance.Model
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    [XmlRoot(ElementName = "enclosure")]
    public class Enclosures
    {
        [XmlAttribute(AttributeName = "url")]
        public string _url { get; set; }
        [XmlAttribute(AttributeName = "_length")]
        public string _length { get; set; }

        [XmlAttribute(AttributeName = "_type")]
        public string _type { get; set; }
    }

    [XmlRoot(ElementName = "guid")]
    public class Guid
    {
        [XmlElement(ElementName = "_isPermaLink")]
        public string _isPermaLink { get; set; }
        [XmlElement(ElementName = "_text")]
        public string __text { get; set; }
    }
    [XmlRoot(ElementName = "source")]
    public class Source
    {
        [XmlAttribute(AttributeName = "_url")]
        public string _url { get; set; }
        [XmlElement(ElementName = "_text")]
        public string __text { get; set; }
    }

    [XmlRoot(ElementName = "item")]
    public class Items
    {
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
        [XmlElement(ElementName = "link")]
        public string Link { get; set; }
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
        [XmlElement(ElementName = "enclosure")]
        public Enclosures Enclosure { get; set; }

        [XmlElement(ElementName = "guid")]
        public Guid guid { get; set; }
        [XmlElement(ElementName = "pubDate")]
        private string pubDate;
        public string PubDate
        {
            get { return pubDate; }
            set
            {
                pubDate = value;
                PublishedDate = DateTime.ParseExact(pubDate, "ddd, dd MMM yyyy HH:mm:ss GMT", CultureInfo.InvariantCulture);
            }
        }
        public DateTime PublishedDate { get; set; }

        [XmlElement(ElementName = "source")]
        public Source Source { get; set; }
    }
    [XmlRoot(ElementName = "channel")]
    public class Channels
    {
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
        [XmlElement(ElementName = "link")]
        public string Link { get; set; }

        [XmlElement(ElementName = "language")]
        public string Language { get; set; }
        [XmlElement(ElementName = "managingEditor")]
        public string ManagingEditor { get; set; }
        [XmlElement(ElementName = "webMaster")]
        public string WebMaster { get; set; }
        [XmlElement(ElementName = "item")]
        public ObservableCollection<Items> Item { get; set; }
    }

    [XmlRoot(ElementName = "rss")]
    public class Post
    {
        [XmlElement(ElementName = "channel")]
        public Channels Channel { get; set; }

        [JsonProperty("_xmlns:atom")]
        public string XmlnsAtom { get; set; }

        [JsonProperty("_xmlns:dc")]
        public string XmlnsDc { get; set; }

        [JsonProperty("_xmlns:itunes")]
        public string XmlnsItunes { get; set; }

        [JsonProperty("_xmlns:media")]
        public string XmlnsMedia { get; set; }
        public string _version { get; set; }

        [JsonProperty("_xml:base")]
        public string XmlBase { get; set; }
    }

   




}
