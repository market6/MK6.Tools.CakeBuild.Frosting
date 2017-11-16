using System;
using System.Collections.Generic;
using System.Text;

namespace Provisioning.TeamCity.Client
{
    static class Endpoints
    {
        public static string Resolve(string urlTemplate, params string[] tokenValues)
        {
            if (tokenValues == null || tokenValues.Length == 0)
                return urlTemplate;

            return string.Format(urlTemplate, tokenValues);
        }

        public static class Project
        {
            public const string All = "/app/rest/projects/";
            public const string Create = All;
            public const string ById = "/app/rest/projects/id:{0}";
            public const string ByName = "/app/rest/projects/name:{0}";
            
            public static class Parameters
            {
                public const string All = "/app/rest/projects/name:{0}/parameters/";
                public const string Create = All;
                public const string ByName = "/app/rest/projects/name:{0}/parameters/{1}";
            }
        }

        public static class BuildType
        {
            public const string ByProjectLocator = "/app/rest/projects/{0}/buildTypes/";
            public const string ByProjectLocatorAndId = "/app/rest/projects/{0}/buildTypes/id:{1}";
            public const string All = "/app/rest/buildTypes/";
            public const string Create = All;
            public const string ById = "/app/rest/buildTypes/id:{0}/";
            public const string ByName = "/app/rest/buildTypes/name:{0}/";

        }
    }
}
