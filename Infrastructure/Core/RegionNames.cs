using System.ComponentModel.Composition;

namespace Infrastructure.Core
{
    [Export]
    public static class RegionNames
    {
        public const string MainContentRegion = "MainContentRegion";
        public const string AccueilRegion = "AccueilRegion";
    }
}
