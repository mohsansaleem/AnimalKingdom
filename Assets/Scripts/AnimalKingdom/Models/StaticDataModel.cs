using PG.AnimalKingdom.Models.Data;

namespace PG.AnimalKingdom.Models
{
    public class StaticDataModel
    {
        public MetaData MetaData;

        public void SeedMetaData(MetaData metaData)
        {
            MetaData = metaData;
        }
    }
}

