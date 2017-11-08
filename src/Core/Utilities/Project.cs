using Cake.Core.IO;
using Cake.Incubator;

namespace MK6.Tools.CakeBuild.Frosting.Utilities
{
    public class Project
    {
        public FilePath ProjectPath { get; set; }
        public CustomProjectParserResult ProjectParserResult { get; set; }

        public Project(FilePath projectPath, CustomProjectParserResult projectParserResult)
        {
            ProjectPath = projectPath;
            ProjectParserResult = projectParserResult;
        }
    } 
}
