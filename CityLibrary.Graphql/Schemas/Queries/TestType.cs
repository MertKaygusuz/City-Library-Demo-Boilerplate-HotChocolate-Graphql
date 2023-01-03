namespace CityLibrary.Graphql.Schemas.Queries;

public class TestType
{
    public TestType(string stringField, int intField)
    {
        StringField = stringField;
        IntField = intField;
    }
    public string StringField { get; set; }

    public int IntField { get; set; }
}