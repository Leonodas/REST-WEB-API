using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_Web_API_ELO.Models
{
    public class Search_Response
    {
        public string guid { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int type { get; set; }
        public bool isDir { get; set; }
        public string desc { get; set; }
        public string @lock { get; set; }
        public string ownerName { get; set; }
        public string access { get; set; }
        public int parentId { get; set; }
        public DateTime dateArchived { get; set; }
        public DateTime? dateCustom { get; set; }
        public DateTime dateModified { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Info
    {
        public string guid { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int type { get; set; }
        public bool isDir { get; set; }
        public string desc { get; set; }
        public string @lock { get; set; }
        public string ownerName { get; set; }
        public string access { get; set; }
        public int parentId { get; set; }
        public DateTime dateArchived { get; set; }
        public object dateCustom { get; set; }
        public DateTime dateModified { get; set; }
    }

    public class Acl
    {
        public string member { get; set; }
        public int id { get; set; }
        public string type { get; set; }
        public string access { get; set; }
    }

    public class Fields
    {
        public string BESTNR { get; set; }
        public string BESTDATUM { get; set; }
        public string BESTELLER { get; set; }
        public string LIEFERANT { get; set; }
        public string BRUTTO { get; set; }
        public string NETTO { get; set; }
        public string MWSTSATZ { get; set; }
        public string ELO_FNAME { get; set; }
    }

    public class Map
    {
    }

    public class Keywording
    {
        public int maskId { get; set; }
        public string maskNameOriginal { get; set; }
        public Fields fields { get; set; }
        public Map map { get; set; }
    }

    public class Version
    {
        public string guid { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string comment { get; set; }
        public string committer { get; set; }
        public string createdAt { get; set; }
        public bool isWorkVersion { get; set; }
        public string ext { get; set; }
        public string contentType { get; set; }
        public int size { get; set; }
        public string url { get; set; }
    }

    public class Content
    {
        public string mime { get; set; }
        public string filename { get; set; }
        public DateTime lastModified { get; set; }
        public int size { get; set; }
        public string url { get; set; }
    }

    public class File_Response
    {
        public Info info { get; set; }
        public List<Acl> acl { get; set; }
        public List<object> children { get; set; }
        public Keywording keywording { get; set; }
        public List<Version> versions { get; set; }
        public Content content { get; set; }
    }
}