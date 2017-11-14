using System;
using System.Collections.Generic;
using System.Text;

namespace Provisioning.TeamCity.Client
{
    static class Endpoints
    {
        public static string Resolve(string urlTemplate, params string[] tokenValues)
        {
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
            public const string ById = "/app/rest/buildTypes/id:{0}/";

        }
    }
}
