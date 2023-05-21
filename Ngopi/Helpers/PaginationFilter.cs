namespace Ngopi.Models
{
    public class PaginationFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? HargaMin { get; set; }
        public int? HargaMax { get; set; }
        public int? OrderBy { get; set; }
        public int[]? Origin { get; set; }
        public int[]? Species { get; set; }
        public int[]? RoastLevel { get; set; }
        public int[]? Tasted { get; set; }
        public int[]? Processing { get; set; }

        public PaginationFilter()
        {
            PageNumber = 1;
            PageSize = 10;
            HargaMin = 0;
            HargaMax = 0;
            OrderBy = 0;
            Origin = null;
            Species = null;
            RoastLevel = null;
            Tasted = null;
            Processing = null;
        }
        public PaginationFilter(int pageNumber, int pageSize, int? hargaMin, int? hargaMax, int? orderBy, int[]? origin, int[]? species, int[]? roastLevel, int[]? tasted, int[]? processing)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize > 10 ? 10 : pageSize;
            HargaMin = hargaMin;
            HargaMax = hargaMax;
            OrderBy = orderBy;
            Origin = origin;
            Species = species;
            RoastLevel = roastLevel;
            Tasted = tasted;
            Processing = processing;
        }
    }
}
