using Discussion.Core.Utilities;
using Newtonsoft.Json;

namespace Discussion.Web.Services.ChatHistoryImporting
{
    public class ChatMessage
    {
        [JsonProperty("_sourceName")]
        public string SourceName {get;set;}

        [JsonProperty("_sourceUserId")]
        public string SourceWxId {get;set;}

        [JsonProperty("_sourceTime")]
        public string SourceTime {get;set;}

        [JsonProperty("_sourceTimestamp")]
        public long SourceTimestamp {get;set;}

        [JsonProperty("_content")]
        public MessageContent Content {get;set;}
    }
    
    public abstract class MessageContent
    {
        [JsonProperty("_type")]
        public MessageType Type { get; set; }
        
        public abstract string Summary { get; } 
    }

    public class TextChatMessageContent : MessageContent
    {
        public TextChatMessageContent()
        {
            Type = MessageType.Text;
        }
        
        [JsonProperty("_text")]
        public string Text { get; set; }

        public override string Summary => string.IsNullOrEmpty(Text) ? "[空消息]" : Text.SafeSubstring(0, 20) + "...";
    }

    public class UrlChatMessageContent : MessageContent
    {
        public UrlChatMessageContent()
        {
            Type = MessageType.Url;
        }
        
        [JsonProperty("_link")]
        public string Link { get; set; }
        
        [JsonProperty("_title")]
        public string Title { get; set; }
        
        [JsonProperty("_description")]
        public string Description { get; set; }
        
        public override string Summary => "[链接]";
    }

    public class FileChatMessageContent : MessageContent
    {
        public FileChatMessageContent()
        {
            Type = MessageType.Attachment;
        }
        
        [JsonProperty("_storageFileId")]
        public string FileId { get; set; }
        
        [JsonProperty("_originalFileName")]
        public string FileName { get; set; }
        
        public override string Summary => "[文件]";
    }
    
    public enum MessageType {
        Unknown = 0,
        Text = 1,
    
        Image = 2,
        Video = 4,
        Url = 5,
        Attachment = 8,
    
        ChatHistory = 17,

        // TinyVideo = 888,
    }
}