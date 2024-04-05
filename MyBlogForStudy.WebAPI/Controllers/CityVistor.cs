namespace MyBlogForStudy.WebAPI.Controllers
{
    using SqlSugar;

    [SugarTable("CityVisitor")]
    public class CityVisitor
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        [SugarColumn(Length = 100)]
        public string City { get; set; }

        public int Uv { get; set; }
    }

}
