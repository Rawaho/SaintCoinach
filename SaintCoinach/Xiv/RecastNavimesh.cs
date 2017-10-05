using SaintCoinach.Ex.Relational;

namespace SaintCoinach.Xiv
{
    public class RecastNavimesh : XivRow 
    {
        public Text.XivString Name => AsString("Name");
        public float TileSize => AsSingle("TileSize");
        public float CellSize => AsSingle("CellSize");
        public float CellHeight => AsSingle("CellHeight");
        public float AgentHeight => AsSingle("AgentHeight");
        public float AgentRadius => AsSingle("AgentRadius");
        public float AgentMaxClimb => AsSingle("AgentMaxClimb");
        public float AgentMaxSlope => AsSingle("AgentMaxSlope");
        public float RegionMinSize => AsSingle("RegionMinSize");
        public float RegionMergedSize => AsSingle("RegionMergedSize");
        public float MaxEdgeLength => AsSingle("MaxEdgeLength");
        public float MaxEdgeError => AsSingle("MaxEdgeError");
        public float VerticiesPerPolygon => AsSingle("VerticiesPerPolygon");
        public float SampleDistance => AsSingle("SampleDistance");
        public float MaxSampleError => AsSingle("MaxSampleError");

        public RecastNavimesh(IXivSheet sheet, IRelationalRow sourceRow)
            : base(sheet, sourceRow) { }
    }
}
