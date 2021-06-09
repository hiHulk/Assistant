using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assistant
{
    public class Header
    {
    }

    public class Data
    {
        public string ID { get; set; }
        public string OriginalRequest { get; set; }
        public string UsedRootDomain { get; set; }
        public string TotalRefDomains { get; set; }
        public string PrefixScanMode { get; set; }
    }

    public class Request
    {
        public Headers Header { get; set; }
        public List<Data> Data { get; set; }
    }

    public class Headers
    {
        public string AnalysisDepth { get; set; }
        public string ColumnsForGlobalInfo { get; set; }
        public string ColumnsPerRequestedDomain { get; set; }
        public string MaxRefDomainTopics { get; set; }
        public string RefDomainTopicsCount { get; set; }
        public string TotalConsideredDomains { get; set; }
        public string TotalMatchedDomains { get; set; }
    }

    public class DataItem
    {
        public string Position { get; set; }
        public string Domain { get; set; }
        public string RefDomains { get; set; }
        public string AlexaRank { get; set; }
        public string Matches { get; set; }
        public string MatchedLinks { get; set; }
        public string ExtBackLinks { get; set; }
        public string IndexedURLs { get; set; }
        public string CrawledURLs { get; set; }
        public string FirstCrawled { get; set; }
        public string LastSuccessfulCrawl { get; set; }
        public string IP { get; set; }
        public string SubNet { get; set; }
        public string CountryCode { get; set; }
        public string TLD { get; set; }
        public string CitationFlow { get; set; }
        public string TrustFlow { get; set; }
        public string Title { get; set; }
        public string OutDomainsExternal { get; set; }
        public string OutLinksExternal { get; set; }
        public string OutLinksInternal { get; set; }
        public string OutLinksPages { get; set; }
        public string Language { get; set; }
        public string LanguageDesc { get; set; }
        public string LanguageConfidence { get; set; }
        public string LanguagePageRatios { get; set; }
        public string LanguageTotalPages { get; set; }
        public string LinkSaturation { get; set; }
    }

    public class Results
    {
        public Headers Headers { get; set; }
        public List<DataItem> Data { get; set; }
    }

    public class DataTables
    {
        public Request Request { get; set; }
        public Results Results { get; set; }
    }

    public class RootObject
    {
        public string Code { get; set; }
        public string ErrorMessage { get; set; }
        public string FullError { get; set; }
        public string ChargedAnalysisResUnits { get; set; }
        public string ChargedRetrievalResUnits { get; set; }
        public string Cmd { get; set; }
        public string IndexBuildDate { get; set; }
        public string IndexType { get; set; }
        public string RemainingAnalysisResUnits { get; set; }
        public string RemainingRetrievalResUnits { get; set; }
        public string ServerBuild { get; set; }
        public string ServerName { get; set; }
        public string ServerVersion { get; set; }
        public string UniqueIndexID { get; set; }
        public DataTables DataTables { get; set; }
    }
    //--------------------------------------------------------------------------------------
    public class myBackLinks
    {
        public BackLinksHeaders Headers { get; set; }
        public List<BackLinksData> Data { get; set; }
    }

    public class BackLinksData
    {
        public string SourceURL { get; set; }
        public string ACRank { get; set; }
        public string AnchorText { get; set; }
        public string Date { get; set; }
        public string SourceTitle { get; set; }
        public string SourceOutDomainsExternal { get; set; }
        public string SourceOutLinksExternal { get; set; }
        public string SourceOutLinksInternal { get; set; }
        public string SourceLanguage { get; set; }
        public string SourceLanguageDesc { get; set; }
        public string SourceLanguageConfidence { get; set; }
        public string FlagRedirect { get; set; }
        public string FlagFrame { get; set; }
        public string FlagNoFollow { get; set; }
        public string FlagImages { get; set; }
        public string FlagDeleted { get; set; }
        public string FlagAltText { get; set; }
        public string FlagMention { get; set; }
        public string TargetURL { get; set; }
        public string IndirectTargetURL { get; set; }
        public string IndirectTargetType { get; set; }
        public string TargetTitle { get; set; }
        public string TargetLanguage { get; set; }
        public string TargetLanguageDesc { get; set; }
        public string TargetLanguageConfidence { get; set; }
        public string LinksAvailableForRootDomain { get; set; }
        public string DomainID { get; set; }
        public string FirstIndexedDate { get; set; }
        public string LastSeenDate { get; set; }
        public string DateLost { get; set; }
        public string ReasonLost { get; set; }
        public string LinkType { get; set; }
        public string LinkSubType { get; set; }
        public string TargetCitationFlow { get; set; }
        public string TargetTrustFlow { get; set; }
        public string TargetTopicalTrustFlow_Topic_0 { get; set; }
        public string TargetTopicalTrustFlow_Value_0 { get; set; }
        public string SourceCitationFlow { get; set; }
        public string SourceTrustFlow { get; set; }
        public string SourceTopicalTrustFlow_Topic_0 { get; set; }
        public string SourceTopicalTrustFlow_Value_0 { get; set; }
        public string SourceTopicalTrustFlow_Topic_1 { get; set; }
        public string SourceTopicalTrustFlow_Value_1 { get; set; }
        public string SourceTopicalTrustFlow_Topic_2 { get; set; }
        public string SourceTopicalTrustFlow_Value_2 { get; set; }
    }

    public class BackLinksHeaders
    {
        public string AvailableLines { get; set; }
        public string BackLinkItem { get; set; }
        public string BackLinkType { get; set; }
        public string Count { get; set; }
        public string From { get; set; }
        public string Item { get; set; }
        public string ItemType { get; set; }
        public string MaxRefDomainTopics { get; set; }
        public string MaxSourceTopics { get; set; }
        public string MaxTargetTopics { get; set; }
        public string OrigItem { get; set; }
        public string RefDomainTopicsCount { get; set; }
        public string SourceTopicsCount { get; set; }
        public string TargetTopicsCount { get; set; }
        public string TotalBackLinks { get; set; }
        public string TotalLines { get; set; }
        public string TotalMatches { get; set; }
    }

    public class BackLinksDataTables
    {
        public myBackLinks BackLinks { get; set; }
    }

    public class BackLinksRootObject
    {
        public string Code { get; set; }
        public string ErrorMessage { get; set; }
        public string FullError { get; set; }
        public string IndexBuildDate { get; set; }
        public string IndexType { get; set; }
        public string ServerBuild { get; set; }
        public string ServerName { get; set; }
        public string ServerVersion { get; set; }
        public string UniqueIndexID { get; set; }
        public BackLinksDataTables DataTables { get; set; }
    }
}
