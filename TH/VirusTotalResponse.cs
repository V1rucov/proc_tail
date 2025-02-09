using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class VirusTotalResponse
{
    [JsonProperty("data")]
    public FileData Data { get; set; }
}

public class FileData
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("links")]
    public Links Links { get; set; }

    [JsonProperty("attributes")]
    public FileAttributes Attributes { get; set; }
}

public class Links
{
    [JsonProperty("self")]
    public string Self { get; set; }
}

public class FileAttributes
{
    [JsonProperty("sha256")]
    public string Sha256 { get; set; }

    [JsonProperty("ssdeep")]
    public string Ssdeep { get; set; }

    [JsonProperty("popular_threat_classification")]
    public ThreatClassification PopularThreatClassification { get; set; }

    [JsonProperty("type_tags")]
    public List<string> TypeTags { get; set; }

    [JsonProperty("tags")]
    public List<string> Tags { get; set; }

    [JsonProperty("md5")]
    public string Md5 { get; set; }

    [JsonProperty("type_description")]
    public string TypeDescription { get; set; }

    [JsonProperty("times_submitted")]
    public int TimesSubmitted { get; set; }

    [JsonProperty("last_analysis_date")]
    public long LastAnalysisDate { get; set; }

    [JsonProperty("last_analysis_stats")]
    public AnalysisStats LastAnalysisStats { get; set; }

    [JsonProperty("last_analysis_results")]
    public Dictionary<string, AnalysisResult> LastAnalysisResults { get; set; }
}

public class ThreatClassification
{
    [JsonProperty("popular_threat_name")]
    public List<ThreatDetail> PopularThreatName { get; set; }

    [JsonProperty("popular_threat_category")]
    public List<ThreatDetail> PopularThreatCategory { get; set; }

    [JsonProperty("suggested_threat_label")]
    public string SuggestedThreatLabel { get; set; }
}

public class ThreatDetail
{
    [JsonProperty("count")]
    public int Count { get; set; }

    [JsonProperty("value")]
    public string Value { get; set; }
}

public class AnalysisStats
{
    [JsonProperty("malicious")]
    public int Malicious { get; set; }

    [JsonProperty("suspicious")]
    public int Suspicious { get; set; }

    [JsonProperty("undetected")]
    public int Undetected { get; set; }

    [JsonProperty("harmless")]
    public int Harmless { get; set; }

    [JsonProperty("timeout")]
    public int Timeout { get; set; }

    [JsonProperty("confirmed-timeout")]
    public int ConfirmedTimeout { get; set; }

    [JsonProperty("failure")]
    public int Failure { get; set; }

    [JsonProperty("type-unsupported")]
    public int TypeUnsupported { get; set; }
}

public class AnalysisResult
{
    [JsonProperty("engine_name")]
    public string EngineName { get; set; }

    [JsonProperty("engine_version")]
    public string EngineVersion { get; set; }

    [JsonProperty("engine_update")]
    public string EngineUpdate { get; set; }

    [JsonProperty("category")]
    public string Category { get; set; }

    [JsonProperty("result")]
    public string Result { get; set; }
}
